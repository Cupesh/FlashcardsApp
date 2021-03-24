using FlashcardsApp.Helpers;
using System;
using FlashcardsApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlashcardsApp.ViewModels
{
    public class MainMenuViewModel : ViewModel
    {
        private IWebAPIService _webAPIService;
        public ObservableCollection<Module> Modules { get; set; }

        public MainMenuViewModel(IWebAPIService webAPIService)
        {
            _webAPIService = webAPIService;
            Modules = new ObservableCollection<Module>();

            Task.Run(async () => await GetData());
        }

        private async Task GetData()
        {
            Modules = await _webAPIService.GetAllModulesAsync();
        }
    }
}
