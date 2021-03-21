using FlashcardsApp.Helpers;
using FlashcardsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlashcardsApp.ViewModels
{
    public class TestViewModel : ViewModel
    {
        private IWebAPIService _webAPIService;

        public Flashcard Item { get; set; }

        public TestViewModel(IWebAPIService webAPIService)
        {
            _webAPIService = webAPIService;
            Task.Run(async () => await GetData());
        }

        private async Task GetData()
        {
            Item = await _webAPIService.GetFlashcardAsync();

        }
    }
}
