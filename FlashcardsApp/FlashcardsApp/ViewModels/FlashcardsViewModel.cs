using FlashcardsApp.Models;
using FlashcardsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlashcardsApp.ViewModels
{
    public class FlashcardsViewModel : ViewModel
    {
        public ObservableCollection<Flashcard> Flashcards { get; set; }

        public void Initialize(ObservableCollection<Flashcard> flashcards)
        {
            Flashcards = flashcards;
        }
    }
}
