using FlashcardsApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashcardsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashcardsView : ContentPage
    {
        public FlashcardsView(FlashcardsViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}