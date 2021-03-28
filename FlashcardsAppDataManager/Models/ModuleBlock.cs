using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Models
{
    public class ModuleBlock
    {
        public int Id { get; set; }
        public string ModuleCode { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        internal AppDb Db { get; set; }

        public ModuleBlock()
        {
        }

        public ModuleBlock(AppDb db)
        {
            Db = db;
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.String,
                Value = Id
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@module_code",
                DbType = DbType.String,
                Value = ModuleCode
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
