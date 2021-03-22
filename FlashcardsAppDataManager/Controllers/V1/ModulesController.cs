using FlashcardsAppDataManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Controllers.V1
{
    public class ModulesController : Controller
    {
        private List<Module> _modules;

        private AppDb Db { get; set; }

        public ModulesController(AppDb db)
        {
            Db = db;
        }

        [HttpGet("api/v1/modules")]
        public async Task<IActionResult> GetAll()
        {
            await Db.Connection.OpenAsync();
            var query = new ModulesQuery(Db);
            _modules = await query.RetrieveAll();
            return Ok(_modules);
        }
    }
}
