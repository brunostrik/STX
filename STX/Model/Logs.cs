using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STX
{
    class Logs
    {
        public static void Log(String texto)
        {
            string CmdString = "INSERT INTO logs (quando, registro) VALUES (CURRENT_TIMESTAMP, @REG)";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@REG", MySqlDbType.VarChar);
            cmd.Parameters["@REG"].Value = texto;
            cmd.ExecuteNonQuery();
        }
    }
}
