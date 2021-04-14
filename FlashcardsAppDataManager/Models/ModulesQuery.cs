using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Models
{
    public class ModulesQuery
    {
        public AppDb Db { get; }

        public ModulesQuery(AppDb db)
        {
            Db = db;
        }

        // Called from the controller
        public async Task<List<Module>> RetrieveAll()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM modules";

            var result = await ReadAll(await cmd.ExecuteReaderAsync());

            return result;
        }

        public async Task<List<Module>> ReadAll(DbDataReader reader)
        {
            var modules = new List<Module>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var module = new Module(Db)
                    {
                        ModuleCode = reader.GetString(0),
                        Name = reader.GetString(1)
                    };
                    modules.Add(module);
                }
            }

            return modules;
        }
    }
}
