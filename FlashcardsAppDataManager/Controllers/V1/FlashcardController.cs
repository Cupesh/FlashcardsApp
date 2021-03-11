using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashcardsAppDataManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlashcardsAppDataManager.Controllers
{
    public class FlashcardController : Controller
    {
        private List<Flashcard> _flashcards;
        public FlashcardController()
        {
            _flashcards = new List<Flashcard>();
            _flashcards.Add(new Flashcard { Id = 1, Term = "a", Definition = "aa" });
            _flashcards.Add(new Flashcard { Id = 1, Term = "b", Definition = "bb" });
        }

        [HttpGet("api/v1/flashcards")]
        public IActionResult GetAll()
        {
            return Ok(_flashcards);
        }
    }
}
