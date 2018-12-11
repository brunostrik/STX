using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STX
{
    static class Program
    {
        public const string APP_NAME = "Sistema STX";
        public const string EMPRESA_MANTENEDORA = "Strik Turismo";
        public const string TELEFONE_SUPORTE = "(43) 3341-6395";
        public const bool DEBUG_MODE = true;

        public static Login login = null;

        public static FormLoad formLoad;
        public static FormLogin formLogin;
        public static FormMain formMain;
        public static FormTrocaSenha formTrocaSenha;

        public static ListFilial listFilial;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain = new FormMain();
            Application.Run(formMain);
        }

    }
}
