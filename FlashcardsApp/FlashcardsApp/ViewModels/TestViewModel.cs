using FlashcardsApp.Helpers;
using FlashcardsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FlashcardsApp.ViewModels
{
    public class TestViewModel : ViewModel
    {
        private Flashcard flashcard;
        private WebAPIService _webAPIService;

        public TestViewModel()
        {
            _webAPIService = new WebAPIService();
            GetData();
        }

        private async void GetData()
        {
            flashcard = await _webAPIService.GetFlashcardAsync();
        }
    }
}
