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

        public Flashcard Flashcard { get; set; }

        public TestViewModel(IWebAPIService webAPIService)
        {
            _webAPIService = webAPIService;
            Task.Run(async () => await GetData());
        }

        private async Task GetData()
        {
            Flashcard = await _webAPIService.GetFlashcardAsync();
        }
    }
}
