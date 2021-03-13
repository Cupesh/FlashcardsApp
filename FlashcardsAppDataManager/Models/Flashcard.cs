using MySqlConnector;
using System.Data;

namespace FlashcardsAppDataManager.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }

        internal AppDb Db { get; set; }

        public Flashcard()
        {
        }

        public Flashcard(AppDb db)
        {
            Db = db;
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@term",
                DbType = DbType.String,
                Value = Term
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@definition",
                DbType = DbType.String,
                Value = Definition
            });
        }
    }
}
