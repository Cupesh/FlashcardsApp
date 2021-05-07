using FlashcardsAppDataManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Controllers.V1
{
    // Fetches flashcards based on the ID of selected Block part
    public class FlashcardsController : Controller
    {
        private List<Flashcard> _flashcards;
        private AppDb Db { get; set; }

        public FlashcardsController(AppDb db)
        {
            Db = db;
        }

        // Exposed endpoint
        [HttpGet("api/v1/flashcards/{selectedBlockPartId}")]
        public async Task<IActionResult> GetAll(int selectedBlockPartId)
        {
            await Db.Connection.OpenAsync();
            var query = new FlashcardsQuery(Db);
            _flashcards = await query.RetrieveAll(selectedBlockPartId);
            return Ok(_flashcards);
        }
    }
}
