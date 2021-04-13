using FlashcardsAppDataManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Controllers.V1
{
    public class BlockPartsController : Controller
    {
        private List<BlockPart> _moduleBlocks;
        private AppDb Db { get; set; }

        public BlockPartsController(AppDb db)
        {
            Db = db;
        }

        [HttpGet("api/v1/blockparts/{moduleBlockId}")]
        public async Task<IActionResult> GetAll(int moduleBlockId)
        {
            await Db.Connection.OpenAsync();
            var query = new BlockPartsQuery(Db);
            _moduleBlocks = await query.RetrieveAll(moduleBlockId);
            return Ok(_moduleBlocks);
        }
    }
}
