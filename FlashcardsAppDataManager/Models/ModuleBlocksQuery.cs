using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Models
{
    public class ModuleBlocksQuery
    {
        public AppDb Db { get; }

        public ModuleBlocksQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<List<ModuleBlock>> RetrieveAll(string moduleCode)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM modules WHERE module_code = @moduleCode" ;

            var result = await ReadAll(await cmd.ExecuteReaderAsync());

            return result;
        }

        public async Task<List<ModuleBlock>> ReadAll(DbDataReader reader)
        {
            var moduleBlocks = new List<ModuleBlock>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var moduleBlock = new ModuleBlock(Db)
                    {
                        ModuleCode = reader.GetString(0),
                        Number = reader.GetInt32(1),
                        Name = reader.GetString(2)
                    };
                    moduleBlocks.Add(moduleBlock);
                }
            }

            return moduleBlocks;
        }
    }
}
