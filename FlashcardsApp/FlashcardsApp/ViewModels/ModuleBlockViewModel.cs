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
    public class ModuleBlockViewModel : ViewModel
    {
        private IWebAPIService _webAPIService;
        
        public ObservableCollection<ModuleBlock> ModuleBlocks { get; set; }

        public Module Module { get; set; }

        public ModuleBlock SelectedModuleBlock
        {
            get { return null; }
            set
            {
                Device.BeginInvokeOnMainThread(async () => await NavigateToSubMenu(value));
            }
        }

        public void Initialize(Module module)
        {
            Module = module;
            Task.Run(async () => await GetData());
        }

        public ModuleBlockViewModel(IWebAPIService webAPIService)
        {
            _webAPIService = webAPIService;
            ModuleBlocks = new ObservableCollection<ModuleBlock>();
        }

        private async Task GetData()
        {
            string moduleCode = Module.ModuleCode;
            ModuleBlocks = await _webAPIService.GetModuleBlocksAsync(moduleCode); 
        }

        private async Task NavigateToSubMenu(ModuleBlock selectedModuleBlock)
        {
            if (selectedModuleBlock == null)
            {
                return;
            }

            var subMenu = Resolver.Resolve<BlockPartView>();
            ((BlockPartViewModel)subMenu.BindingContext).Initialize(selectedModuleBlock);

            await Navigation.PushAsync(new NavigationPage(subMenu));
        }
    }
}
