using FlashcardsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FlashcardsApp.ViewModels
{
    public class FlashcardDetailViewModel : ViewModel
    {
        public Flashcard Flashcard { get; set; }

        public FlashcardDetailViewModel(Flashcard flashcard)
        {
            Flashcard = flashcard;
        }
    }
}
