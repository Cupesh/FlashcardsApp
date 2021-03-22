using FlashcardsApp.Helpers;
using FlashcardsApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlashcardsApp.ViewModels
{
    public class MainMenuViewModel
    {
        private IWebAPIService _webAPIService;

        private ObservableCollection<Module> Modules { get; set; }

        public MainMenuViewModel(IWebAPIService webAPIService)
        {
            _webAPIService = webAPIService;
            Task.Run(async () => await GetData());
        }

        private async Task GetData()
        {
            Modules = new ObservableCollection<Module>(await _webAPIService.GetAllModulesAsync());
        }
    }
}
