using FlashcardsApp.Helpers;
using FlashcardsApp.Models;
using FlashcardsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlashcardsApp.ViewModels
{
    public class BlockPartViewModel : ViewModel
    {
        private IWebAPIService _webAPIService;

        public ObservableCollection<BlockPart> BlockParts { get; set; }
        public ObservableCollection<Flashcard> Flashcards { get; set; }
        public ModuleBlock ModuleBlock { get; set; }
        public BlockPart SelectedBlockPart
        {
            get { return null; }
            set
            {
                Device.BeginInvokeOnMainThread(async () => await NavigateToFlashcards(value));
            }
        }

        public void Initialize(ModuleBlock moduleBlock)
        {
            ModuleBlock = moduleBlock;
            Task.Run(async () => await GetData());
        }

        public BlockPartViewModel(IWebAPIService webAPIService)
        {
            _webAPIService = webAPIService;
            BlockParts = new ObservableCollection<BlockPart>();
        }

        private async Task GetData()
        {
            string moduleBlockId = ModuleBlock.Id.ToString();
            BlockParts = await _webAPIService.GetBlockPartsAsync(moduleBlockId);
        }

        private async Task NavigateToFlashcards(BlockPart selectedBlockPart)
        {
            if (selectedBlockPart == null)
            {
                return;
            }

            await Task.Run(async () => await GetFlashcards());

            var subMenu = Resolver.Resolve<FlashcardsView>();
            ((FlashcardsViewModel)subMenu.BindingContext).Initialize(Flashcards);

            await Navigation.PushModalAsync(subMenu);
        }

        private async Task GetFlashcards()
        {
            string selectedBlockPartId = SelectedBlockPart.Id.ToString();
            Flashcards = await _webAPIService.GetFlashcardsAsync(selectedBlockPartId);
        }
    }
}
