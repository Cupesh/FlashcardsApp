using FlashcardsAppDataManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Controllers.V1
{
    // First submenu. Displays the main blocks that are part of the selected module.
    public class ModuleBlocksController : Controller
    {
        private List<ModuleBlock> _moduleBlocks;

        private AppDb Db { get; set; }

        public ModuleBlocksController(AppDb db)
        {
            Db = db;
        }

        // Exposed endpoint
        [HttpGet("api/v1/moduleblocks/{moduleCode}")]
        public async Task<IActionResult> GetAll(string moduleCode)
        {
            await Db.Connection.OpenAsync();
            var query = new ModuleBlocksQuery(Db);
            _moduleBlocks = await query.RetrieveAll(moduleCode);
            return Ok(_moduleBlocks);
        }
    }
}
