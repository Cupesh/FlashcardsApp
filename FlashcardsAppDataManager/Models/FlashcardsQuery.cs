using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Models
{
    public class FlashcardsQuery
    {
        public AppDb Db { get; }

        public FlashcardsQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<List<Flashcard>> RetrieveAll(int block_part_id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id, term, definition, block_part_id FROM flashcards WHERE block_part_id = @block_part_id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@block_part_id",
                DbType = DbType.Int32,
                Value = block_part_id
            });

            var result = await ReadAll(await cmd.ExecuteReaderAsync());

            return result;
        }

        public async Task<List<Flashcard>> ReadAll(DbDataReader reader)
        {
            var flashcards = new List<Flashcard>();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var flashcard = new Flashcard(Db)
                    {
                        Id = reader.GetInt32(0),
                        Term = reader.GetString(1),
                        Definition = reader.GetString(2),
                        BlockPartId = reader.GetInt32(3),
                    };
                    flashcards.Add(flashcard);
                }
            }

            return flashcards;
        }
    }
}
