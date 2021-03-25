using FlashcardsApp.Helpers;
using FlashcardsApp.Models;
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

        public ModuleBlockViewModel(IWebAPIService webAPIService)
        {
            _webAPIService = webAPIService;
            ModuleBlocks = new ObservableCollection<ModuleBlock>();

            GetData(Module);
        }

        private void GetData(Module module)
        {
            string moduleCode = module.ModuleCode;

            for (var i = 0; i < 3; i++)
            {
                ModuleBlocks.Add(new ModuleBlock
                {
                    Id = i,
                    ModuleCode = moduleCode,
                    Number = i,
                    Name = String.Format("Block {0}, part of {1}", i, moduleCode)
                });
            }
        }
    }
}
