using FlashcardsAppDataManager.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        public async Task<List<Flashcard>> GetAll()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM flashcards";

            var result = await ReadAll(await cmd.ExecuteReaderAsync());

            return result;
        }

        public async Task<Flashcard> GetOne(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT 'id', 'term', 'definition' FROM 'flashcards' WHERE 'id' = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id
            });
            var result = await ReadAll(await cmd.ExecuteReaderAsync());
            
            if (result.Count > 0)
            {
                return result[0];
            } else {
                return null;
            }
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
                        Definition = reader.GetString(2)
                    };
                    flashcards.Add(flashcard);
                }
            }

            return flashcards;
        }
    }
}
