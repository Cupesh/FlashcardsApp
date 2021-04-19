using FlashcardsApp.Helpers;
using FlashcardsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardsApp.ViewModels
{
    public class BlockPartViewModel : ViewModel
    {
        private IWebAPIService _webAPIService;

        public ObservableCollection<BlockPart> BlockParts { get; set; }
        public ModuleBlock ModuleBlock { get; set; }
        public BlockPart SelectedBlockPart
        {
            get { return null; }
            set
            {
                throw new NotImplementedException();
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
    }
}
