using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Models
{
    public class BlockPart
    {
        public int Id { get; set; }
        public int ModuleBlockId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        internal AppDb Db { get; set; }

        public BlockPart()
        {
        }

        public BlockPart(AppDb db)
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
                ParameterName = "@module_block_id",
                DbType = DbType.String,
                Value = ModuleBlockId
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@number",
                DbType = DbType.String,
                Value = Number
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.String,
                Value = Name
            });
        }
    }
}
