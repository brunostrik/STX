using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace STX
{
    class DBConfig
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
                CONNECTION_STRING = LoadConfigFile();
                return GetConnectionString();
            }
        }

        public static MySqlConnection getConnection()
        {
            try
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
            }catch(Exception x)
            {
                if (Program.DEBUG_MODE)
                {
                    Alerts.Error(x.Message + "\r" + x.StackTrace);
                }
                return null;
            }
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
        public static int TestDatabaseConnection()
        {
            //RETORNA 0 SE ESTA TUDO CERTO
            //RETORNA 1 SE NAO TEM ARQUIVO DE CONFIGURACAO
            //RETORNA 2 SE ESTA CONFIGURADO POREM NAO CONECTOU (REDE CAGADA)
            if (!File.Exists(@"database.cfg"))
            {
                return 1;
            }
            try
            {
                new MySqlCommand("SELECT 1+1", getConnection()).ExecuteScalar();
            }catch (Exception) {
                return 2;
            }


            return 0;
        }
        public static void SaveConfigFile(string originalFilePath)
        {
            File.Copy(originalFilePath, @"database.cfg", true);
        }
    }
}
