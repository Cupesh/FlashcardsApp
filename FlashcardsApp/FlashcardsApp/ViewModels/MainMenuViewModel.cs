using FlashcardsApp.Helpers;
using System;
using FlashcardsApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using FlashcardsApp.Views;

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

        public Module SelectedModule
        {
            get { return null; }
            set
            {
                Device.BeginInvokeOnMainThread(async () => await NavigateToSubMenu(value));
            }
        }

        private async Task NavigateToSubMenu(Module selectedModule)
        {
            if (selectedModule == null)
            {
                return;
            }

            var subMenu = Resolver.Resolve<ModuleBlockView>();
            ((ModuleBlockViewModel)subMenu.BindingContext).Initialize(selectedModule);

            await Navigation.PushAsync(new NavigationPage(subMenu));
        }
    }
}
