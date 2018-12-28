using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace STX
{
    public class GenericController<T> : DBConfig
    {
        public static bool Insert(T entity)
        {
            try
            {
                Hashtable ht = Entity2Hashtable(entity);
                string cmdString = "INSERT INTO ";
                cmdString += typeof(T).Name;
                cmdString += (" (");
                foreach (var k in ht.Keys)//Adiciona os campos
                {
                    cmdString += k.ToString();
                    cmdString += ", ";
                }
                cmdString = cmdString.Remove(cmdString.Length - 2); //Remove a virgula inútil do ultimo parâmetro
                cmdString += ") VALUES (";
                foreach (var k in ht.Values)//Adiciona os valores
                {
                    cmdString += "'";
                    cmdString += k.ToString();
                    cmdString += "'";
                    cmdString += ", ";
                }
                cmdString = cmdString.Remove(cmdString.Length - 2); //Remove a virgula inútil do ultimo parâmetro
                cmdString += ");";
                if (Config.DEBUG_MODE)
                {
                    ErrorLog("[SQL]: " + cmdString);
                }
                MySqlCommand cmd = new MySqlCommand(cmdString, getConnection());
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception x)
            {
                ErrorLog("[" + DateTime.Now + "] Erro MagicSqlFramework.GenericController.Insert: " + x.Message);
                return false;
            }
        }
        public static bool Update(T entity)
        {
            try
            {
                Hashtable ht = Entity2Hashtable(entity);
                string cmdString = "UPDATE ";
                cmdString += typeof(T).Name;
                cmdString += (" SET ");
                foreach (var k in ht.Keys) //Adiciona os campos e valores
                {
                    cmdString += k.ToString();
                    cmdString += "='";
                    cmdString += ht[k];
                    cmdString += "', ";
                }
                cmdString = cmdString.Remove(cmdString.Length - 2); //Remove a virgula inútil do ultimo parâmetro
                cmdString += " WHERE id = ";
                cmdString += ht["id"];
                if (Config.DEBUG_MODE)
                {
                    ErrorLog("[SQL]: " + cmdString);
                }
                MySqlCommand cmd = new MySqlCommand(cmdString, getConnection());
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception x)
            {
                ErrorLog("[" + DateTime.Now + "] Erro MagicSqlFramework.GenericController.Update: " + x.Message);
                return false;
            }
        }
        public static bool Delete(T entity)
        {
            try
            {
                Hashtable ht = Entity2Hashtable(entity);
                string cmdString = "DELETE FROM ";
                cmdString += typeof(T).Name;
                cmdString += " WHERE id = ";
                cmdString += ht["id"];
                if (Config.DEBUG_MODE)
                {
                    ErrorLog("[SQL]: " + cmdString);
                }
                MySqlCommand cmd = new MySqlCommand(cmdString, getConnection());
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception x)
            {
                ErrorLog("[" + DateTime.Now + "] Erro MagicSqlFramework.GenericController.Delete: " + x.Message);
                return false;
            }
        }
        public static List<T> Select(CriteriaBuilder criteria = null)
        {
            try
            {
                //identificar o nome da tabela no banco de dados usando o StxFramework
                string nomeTabela = typeof(T).GetCustomAttributesData().Where(item => item.AttributeType == typeof(Table)).FirstOrDefault().ConstructorArguments[0].ToString().Replace("\"", ""); //(typeof(Table), false)[0].ToString();
                /*
                //identificar os campos da tabela no banco de dados usando o stx framework
                var props = typeof(T).GetProperties();
                List<string> campos = new List<string>();
                foreach (var prop in props)
                {
                    campos.Add(prop.GetCustomAttributesData().Where(item => item.AttributeType == typeof(Field)).FirstOrDefault().ConstructorArguments[0].ToString().Replace("\"", ""));
                }
                */
                //Monta o SQL
                List<T> list = new List<T>();
                string CmdString = "SELECT * FROM ";
                CmdString += nomeTabela;
                if (criteria != null)
                {
                    CmdString += " WHERE ";
                    CmdString += criteria.GetQuery();
                }
                if (Config.DEBUG_MODE)
                {
                    Log(CmdString);
                }
                MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
                MySqlDataReader rs = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(rs);
                list = ConvertToList<T>(dt);
                rs.Close();
                return list;
            }
            catch (Exception x)
            {
                ErrorLog("Erro MagicSqlFramework.GenericController.Select: " + x.Message);
                return null;
            }
        }
        public static T Load(int id)
        {
            try
            {
                //identificar o nome da tabela no banco de dados usando o StxFramework
                string nomeTabela = typeof(T).GetCustomAttributesData().Where(item => item.AttributeType == typeof(Table)).FirstOrDefault().ConstructorArguments[0].ToString().Replace("\"", ""); //(typeof(Table), false)[0].ToString();

                //Monta o SQL
                List<T> list = new List<T>();
                string CmdString = "SELECT * FROM ";
                CmdString += nomeTabela;
                CmdString += " WHERE id = '" + id + "'";
                if (Config.DEBUG_MODE)
                {
                    Log(CmdString);
                }
                MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
                MySqlDataReader rs = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(rs);
                list = ConvertToList<T>(dt);
                rs.Close();
                return list.FirstOrDefault<T>();
            }
            catch (Exception x)
            {
                ErrorLog("Erro MagicSqlFramework.GenericController.Select: " + x.Message);
                throw x;
            }
        }
        /*
        public static List<T> Select(CriteriaBuilder criteria = null)
        {
            try
            {
                List<T> list = new List<T>();
                string CmdString = "SELECT * FROM ";
                CmdString += typeof(T).ToString();
                if (criteria != null)
                {
                    CmdString += " WHERE ";
                    CmdString += criteria.GetQuery();
                }
                if (Config.DEBUG_MODE)
                {
                    ErrorLog("[SQL]: " + CmdString);
                }
                MySqlCommand cmd = new MySqlCommand(CmdString, DBConfig.getConnection());
                MySqlDataReader rs = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(rs);
                list = ConvertToList<T>(dt);
                rs.Close();
                return list;
            }
            catch (Exception x)
            {
                ErrorLog("[" + DateTime.Now + "] Erro MagicSqlFramework.GenericController.Select: " + x.Message);
                return null;
            }
        }
        */

        public static Hashtable Entity2Hashtable(T entity)
        {
            Hashtable table = new Hashtable();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                table.Add(prop.Name, prop.GetValue(entity));
            }
            return table;
        }
    }
}
