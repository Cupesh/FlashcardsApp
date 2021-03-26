using FlashcardsApp.Helpers;
using FlashcardsApp.Models;
using FlashcardsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardsApp.ViewModels
{
    public class ModuleBlockViewModel : ViewModel
    {
        private IWebAPIService _webAPIService;
        
        public ObservableCollection<ModuleBlock> ModuleBlocks { get; set; }

        public Module Module { get; set; }

        public void Initialize(Module module)
        {
            Module = module;
            Task.Run(async () => await GetData(Module));
        }

        public ModuleBlockViewModel(IWebAPIService webAPIService)
        {
            _webAPIService = webAPIService;
            ModuleBlocks = new ObservableCollection<ModuleBlock>();
        }

        private async Task GetData(Module module)
        {
            // todo: finish method in Helpers/IWebAPISerivce
            ModuleBlocks = await _webAPIService 
        }
    }
}
