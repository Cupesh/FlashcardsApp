using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using FlashcardsAppDataManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlashcardsAppDataManager.Controllers
{
    public class FlashcardController : Controller
    {
        private List<Flashcard> _flashcards;
        private Flashcard _flashcard;

        private AppDb Db { get; set; }

        public FlashcardController(AppDb db)
        {
            Db = db; 
        }

        [HttpGet("api/v1/flashcards")]
        public async Task<IActionResult> GetOne()
        {
            await Db.Connection.OpenAsync();
            var query = new FlashcardsQuery(Db);
            var result = await query.GetAll();
            return Ok(result);
        }
    }
}
