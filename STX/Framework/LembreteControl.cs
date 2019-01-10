using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace STX
{
    public class LembreteControl
    {
        public bool CadastrarLembrete(Lembrete lembrete, List<LembreteDestinatario> destinatarios)
        {
            MySqlTransaction trans = null;
            MySqlConnection conn = null;
            try
            {
                conn = DBConfig.getConnection();
                trans = conn.BeginTransaction();
                string cmdString = "INSERT INTO lembrete (idloginremetente, titulo, mensagem, datahoracadastro, datahoraenvio, enviada) VALUES ('" + lembrete.idLoginRemetente + "','" + lembrete.titulo + "','" + lembrete.mensagem + "','" + DBConfig.DateTimeSQLFormat(lembrete.dataHoraCadastro) + "','" + DBConfig.DateTimeSQLFormat(lembrete.dataHoraEnvio) + "','" + (lembrete.enviada ? 1 : 0) + "')";
                if (Config.DEBUG_MODE)
                {
                    DBConfig.Log(cmdString);
                }

                new MySqlCommand(cmdString, conn).ExecuteNonQuery();
                cmdString = "SELECT DISTINCT LAST_INSERT_ID() FROM lembrete;";
                int idLembrete = Convert.ToInt32(new MySqlCommand(cmdString, conn).ExecuteScalar());
                foreach (LembreteDestinatario ld in destinatarios)
                {
                    cmdString = "INSERT INTO lembretedestinatario (idlembrete, idlogindestinatario) VALUES ('" + idLembrete + "','" + ld.idlogindestinatario + "')";
                    new MySqlCommand(cmdString, conn).ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }
            catch (Exception x)
            {
                trans.Rollback();
                DBConfig.ErrorLog("Erro LembreteControl.CadastrarLembrete: " + x.Message);
                return false;
            }
        }
        public string Sincronizar()
        {
            try
            {
                string CmdString = "SELECT l.id as idlembrete, l.titulo as assunto, l.mensagem as corpo, r.email as remetente, d.email as destinatario " +
                                    "FROM lembrete l " +
                                    "JOIN login r ON l.idloginremetente = r.id " +
                                    "JOIN lembretedestinatario ld ON ld.idlembrete = l.id " +
                                    "JOIN login d ON ld.idlogindestinatario = d.id " +
                                    "WHERE l.enviada = 0 " +
                                    "AND DATE(l.datahoraenvio) <= DATE(NOW()) " + //comentar esta linha para forceps em todos
                                    "ORDER BY l.id";

                if (Config.DEBUG_MODE)
                {
                    DBConfig.Log(CmdString);
                }
                MySqlDataReader rs = new MySqlCommand(CmdString, DBConfig.getConnection()).ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rs);
                List<int> idLembretesEnviadosRaw = new List<int>();
                if (dt.Rows.Count == 0)
                {
                    return "Não há mensagens pendentes";
                }
                foreach(DataRow dr in dt.Rows)
                {
                    
                    Util.SendMail(dr["remetente"].ToString(), dr["destinatario"].ToString(), dr["assunto"].ToString(), dr["corpo"].ToString());
                    idLembretesEnviadosRaw.Add((int)dr["idlembrete"]);
                }
                rs.Close();
                //registra que foi enviada a mensagem
                CmdString = "UPDATE lembrete SET enviada = 1 WHERE id IN (";
                foreach (int n in idLembretesEnviadosRaw.Distinct())
                {
                    CmdString += n + ", ";
                }
                CmdString += "-1)"; //coloca essa gambi aqui só pra nao bugar na ultima virgula perdida
                if (Config.DEBUG_MODE)
                {
                    DBConfig.Log(CmdString);
                }
                new MySqlCommand(CmdString,DBConfig.getConnection()).ExecuteNonQuery();
                return "Foram sincronizadas " + dt.Rows.Count + " mensagens.";
            }
            catch (Exception x)
            {
                DBConfig.ErrorLog("Erro LembreteControl.Sincronizar: " + x.Message);
                throw x;
            }
        }
    }
}
