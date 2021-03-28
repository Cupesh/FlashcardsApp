using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<List<ModuleBlock>> RetrieveAll(string module_code)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id, module_code, number, name FROM module_blocks WHERE module_code = @module_code" ;
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@module_code",
                DbType = DbType.Int32,
                Value = module_code
            });

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
                        Id = reader.GetInt32(0),
                        ModuleCode = reader.GetString(1),
                        Number = reader.GetInt32(2),
                        Name = reader.GetString(3)
                    };
                    moduleBlocks.Add(moduleBlock);
                }
            }

            return moduleBlocks;
        }
    }
}
