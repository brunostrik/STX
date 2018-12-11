using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STX
{
    public class Login
    {
        public int id = 0;
        public string usuario = "";
        public string senha = "";
        public bool trocar = false;

        public Login()
        {
        }
        public Login(int id)
        {
            string CmdString = "SELECT * FROM login WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@ID", MySqlDbType.Int16);
            cmd.Parameters["@ID"].Value = id;
            MySqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                this.id = rs.GetInt32("id");
                this.usuario = rs.GetString("usuario");
                this.senha = rs.GetString("senha");
                this.trocar = rs.GetBoolean("trocar");
            }
            rs.Close();
        } 
        public Login(string usuario, string senha)
        {
            string CmdString = "SELECT * FROM login WHERE usuario = @USU AND senha = @SEN";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@USU", MySqlDbType.VarChar);
            cmd.Parameters["@USU"].Value = usuario;
            cmd.Parameters.Add("@SEN", MySqlDbType.VarChar);
            cmd.Parameters["@SEN"].Value = senha;
            MySqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                this.id = rs.GetInt32("id");
                this.usuario = rs.GetString("usuario");
                this.senha = rs.GetString("senha");
                this.trocar = rs.GetBoolean("trocar");
            }
            rs.Close();
        }
        public void Update()
        {
            string CmdString = "UPDATE login SET usuario = @USU, senha = @SEN, trocar = @TRO WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@USU", MySqlDbType.VarChar);
            cmd.Parameters["@USU"].Value = usuario;
            cmd.Parameters.Add("@SEN", MySqlDbType.VarChar);
            cmd.Parameters["@SEN"].Value = senha;
            cmd.Parameters.Add("@TRO", MySqlDbType.Bit);
            cmd.Parameters["@TRO"].Value = (trocar ? 1 : 0);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = id;
            cmd.ExecuteNonQuery();
        }
    }
}
