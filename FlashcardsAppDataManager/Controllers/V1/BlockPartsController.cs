using FlashcardsAppDataManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Controllers.V1
{
    // Second submenu. Displays parts/chapters of the selected module block Id.
    public class BlockPartsController : Controller
    {
        private List<BlockPart> _blockParts;
        private AppDb Db { get; set; }

        public BlockPartsController(AppDb db)
        {
            Db = db;
        }

        // Exposed endpoint
        [HttpGet("api/v1/blockparts/{moduleBlockId}")]
        public async Task<IActionResult> GetAll(int moduleBlockId)
        {
            await Db.Connection.OpenAsync();
            var query = new BlockPartsQuery(Db);
            _blockParts = await query.RetrieveAll(moduleBlockId);
            return Ok(_blockParts);
        }
    }
}
