using FlashcardsApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashcardsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModuleBlockView : ContentPage
    {
        public ModuleBlockView(ModuleBlockViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}