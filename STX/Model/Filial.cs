using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STX
{
    public class Filial
    {
        public int id { get; set; } = 0;
        public string nome { get; set; } = "";
        public bool ativo { get; set; } = false;

        public Filial()
        {

        }
        public Filial(int id)
        {
            string CmdString = "SELECT * FROM filial WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@ID", MySqlDbType.Int16);
            cmd.Parameters["@ID"].Value = id;
            MySqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                this.id = rs.GetInt32("id");
                this.nome = rs.GetString("nome");
                this.ativo = rs.GetBoolean("ativo");
            }
            rs.Close();
        }
        public List<Filial> Search(string keyword)
        {
            List<Filial> list = new List<Filial>();
            string CmdString = "SELECT * FROM filial WHERE nome LIKE @KEY";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@KEY", MySqlDbType.VarChar);
            cmd.Parameters["@KEY"].Value = "%"+keyword+"%";
            MySqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                Filial x = new Filial();
                x.id = rs.GetInt32("id");
                x.nome = rs.GetString("nome");
                x.ativo = rs.GetBoolean("ativo");
                list.Add(x);
            }
            rs.Close();
            return list;
        }

    }
}
