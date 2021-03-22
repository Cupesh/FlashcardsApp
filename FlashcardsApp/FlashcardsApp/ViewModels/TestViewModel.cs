﻿using FlashcardsApp.Helpers;
using FlashcardsApp.Models;
using System.Threading.Tasks;

namespace FlashcardsApp.ViewModels
{
    // ..
    public class TestViewModel : ViewModel
    {
        private IWebAPIService _webAPIService;

        private Flashcard Flashcard { get; set; }

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
