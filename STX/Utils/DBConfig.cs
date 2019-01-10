using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Configuration;

namespace STX
{
    public class DBConfig
    {
        private static string CONNECTION_STRING = "";
        private static MySqlConnection connection;

        private static string GetConnectionString()
        {
            if (CONNECTION_STRING != "")
            {
                return CONNECTION_STRING;
            }
            else
            {
                //CONNECTION_STRING = LoadConfigFile();
                CONNECTION_STRING = ConfigurationManager.AppSettings.Get("ConnectionString");
                return GetConnectionString();
            }
        }

        public static MySqlConnection getConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(GetConnectionString());
            }
            try { connection.Close(); }
            catch (Exception) { }
            try { connection.Open(); }
            catch (Exception) { }
            return connection;
        }
        public static string LoadConfigFile()
        {
            string file = System.IO.File.ReadAllText(@"database.cfg");
            return Encrypt.DecryptString(file, "STX");
        }
        public static void WriteConfigFile(string text)
        {
            string textToWrite = Encrypt.EncryptString(text, "STX");
            System.IO.File.WriteAllText(@"database.cfg", textToWrite);
        }

        public static void ErrorLog(string log)
        {
            System.IO.File.AppendAllLines(@"errorlog.txt", new string[] { DateTime.Now.ToString() + "> " + log });
        }
        public static void Log(string log)
        {
            System.IO.File.AppendAllLines(@"log.txt", new string[] { DateTime.Now.ToString()+"> "+log });
        }

        public static int TestDatabaseConnection()
        {
            //RETORNA 0 SE ESTA TUDO CERTO
            //RETORNA 1 SE NAO TEM ARQUIVO DE CONFIGURACAO
            //RETORNA 2 SE ESTA CONFIGURADO POREM NAO CONECTOU (REDE CAGADA)
            /*
            if (!File.Exists(@"database.cfg"))
            {
                return 1;
            }
            */
            try
            {
                new MySqlCommand("SELECT 1+1", getConnection()).ExecuteScalar();
            }
            catch (Exception)
            {
                return 2;
            }


            return 0;
        }

        public static void SaveConfigFile(string originalFilePath)
        {
            File.Copy(originalFilePath, @"database.cfg", true);
        }

        public static List<T> ConvertToList<T>(DataTable table)
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = Activator.CreateInstance<T>();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
        public static string DateTimeSQLFormat(DateTime dt)
        {
            return dt.Year + "-" + dt.Month + "-" + dt.Day + " " + dt.Hour + ":" + dt.Minute + ":" + dt.Second;
        }
    }
}
