using System;
using System.Windows.Forms;

namespace STX
{
    static class Program
    {

        public static Login login = null;

        public static FormLoad formLoad;
        public static FormLogar formLogar;
        public static FormMain formMain;
        public static FormTrocaSenha formTrocaSenha;
        public static FormFilial formFilial;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain = new FormMain();
            Application.Run(formMain);
        }

        public static void OpenForm<T>(IModel<T> entity, IListForm listaRetorno = null) where T : IModel<T>
        {
            //Forms não genéricos
            switch (entity.GetType().Name)
            {
                case "Lembrete":
                    FormLembrete frm = new FormLembrete(entity as Lembrete, listaRetorno);
                    frm.MdiParent = formMain;
                    frm.Show();
                    break;
                default: //Forms genéricos
                    FormStx<T> form = new FormStx<T>((T)entity, listaRetorno);
                    form.MdiParent = formMain;
                    form.Show();
                    break;
            }
            
        }
        public static void OpenList<T>(string searchProperty = "", ISelector returnSelector = null) where T : IModel<T>
        {
           ListStx<T> frm = new ListStx<T>(searchProperty, returnSelector);
           frm.MdiParent = formMain;
           frm.Show();
        }

    }
}
