using FlashcardsApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashcardsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlockPartView : ContentPage
    {
        public BlockPartView(BlockPartViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}