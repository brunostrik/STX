using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace STX
{
    public class Filial : IModel
    {
        [Browsable(false)]
        public int id { get; set; } = 0;
        [DisplayName("Nome da Filial")]
        public string nome { get; set; } = "";
        [Browsable(false)]
        public bool ativo { get; set; } = false;

        public Filial(int id = 0)
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
        public List<Object> Search(string keyword = "")
        {
            List<Object> list = new List<Object>();
            string CmdString = "SELECT id, nome, ativo FROM filial WHERE nome LIKE @KEY";
            //string CmdString = "SELECT * FROM filial";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@KEY", MySqlDbType.VarChar);
            cmd.Parameters["@KEY"].Value = "%"+keyword+"%";
            MySqlDataReader rs = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(rs);
            List<DataRow> dr = dt.AsEnumerable().ToList();
            foreach (var r in dr)
            {
                Filial x = new Filial();
                x.id = Convert.ToInt32(r[0]);
                x.nome = r[1].ToString();
                x.ativo = Convert.ToBoolean(r[2]);
                list.Add(x);
            }
            rs.Close();
            return list;
        }
        public void Insert()
        {
            string CmdString = "INSERT INTO filial (nome, ativo) VALUES (@NOM, @ATI)";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@NOM", MySqlDbType.VarChar);
            cmd.Parameters["@NOM"].Value = nome;
            cmd.Parameters.Add("@ATI", MySqlDbType.Bit);
            cmd.Parameters["@ATI"].Value = (ativo ? 1 : 0);
            cmd.ExecuteNonQuery();
        }
        public void Update()
        {
            string CmdString = "UPDATE filial SET nome = @NOM, ativo = @ATI WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@NOM", MySqlDbType.VarChar);
            cmd.Parameters["@NOM"].Value = nome;
            cmd.Parameters.Add("@ATI", MySqlDbType.Bit);
            cmd.Parameters["@ATI"].Value = (ativo ? 1 : 0);
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = id;
            cmd.ExecuteNonQuery();
        }
        public void Delete()
        {
            string CmdString = "DELETE FROM filial WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
            cmd.Parameters.Add("@ID", MySqlDbType.Int32);
            cmd.Parameters["@ID"].Value = id;
            cmd.ExecuteNonQuery();
        }

    }
}
