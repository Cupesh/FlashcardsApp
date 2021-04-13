using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Models
{
    public class BlockPartsQuery
    {
        public AppDb Db { get; }

        public BlockPartsQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<List<BlockPart>> RetrieveAll(int module_block_id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id, module_block_id, number, name FROM block_parts WHERE module_block_id = @module_block_id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@module_block_id",
                DbType = DbType.Int32,
                Value = module_block_id
            });

            var result = await ReadAll(await cmd.ExecuteReaderAsync());

            return result;
        }

        public async Task<List<BlockPart>> ReadAll(DbDataReader reader)
        {
            var blockParts = new List<BlockPart>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var moduleBlock = new BlockPart(Db)
                    {
                        Id = reader.GetInt32(0),
                        ModuleBlockId = reader.GetInt32(1),
                        Number = reader.GetInt32(2),
                        Name = reader.GetString(3)
                    };
                    blockParts.Add(moduleBlock);
                }
            }

            return blockParts;
        }
    }
}
