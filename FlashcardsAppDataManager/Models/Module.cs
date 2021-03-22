using MySqlConnector;
using System.Data;

namespace FlashcardsAppDataManager.Models
{
    public class Module
    {
        public string ModuleCode { get; set; }
        public string Name { get; set; }

        internal AppDb Db { get; set; }

        public Module()
        {
        }

        public Module(AppDb db)
        {
            Db = db;
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@module_code",
                DbType = DbType.String,
                Value = ModuleCode
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
