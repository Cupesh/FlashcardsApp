using FlashcardsApp.Models;
using FlashcardsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FlashcardsApp.ViewModels
{
    public class FlashcardsViewModel : ViewModel
    {
        public ObservableCollection<Flashcard> Flashcards { get; set; }
        public ObservableCollection<FlashcardDetailViewModel> Pages { get; set; }

        public void Initialize(ObservableCollection<Flashcard> flashcards)
        {
            Flashcards = flashcards;
            Pages = new ObservableCollection<FlashcardDetailViewModel>(Flashcards.Select(f => new FlashcardDetailViewModel(f)));
        }
    }
}
