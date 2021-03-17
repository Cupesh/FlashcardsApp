using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlashcardsApp.Views;

namespace FlashcardsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(Resolver.Resolve<TestView>());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
