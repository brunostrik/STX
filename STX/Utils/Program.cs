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

        public static ListLogin listLogin;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain = new FormMain();
            Application.Run(formMain);
        }

        public static void OpenForm<T>(IModel<T> entity, IListForm listaRetorno = null)
        {
            /*if (entity.GetType().Equals(typeof(Filial))) //FILIAL
            {
                //FormFilial frm = new FormFilial((Filial)entity, listaRetorno);
                //frm.MdiParent = formMain;
                //frm.Show();
                FormStx<Filial> frm = new FormStx<Filial>(((Filial)entity), listaRetorno);
                frm.MdiParent = formMain;
                frm.Show();
            }
            else if (entity.GetType().Equals(typeof(Login)))
            {

            }
            else
            {
                Alerts.Message("Não implementado: " + entity.GetType().ToString());
            }*/
            FormStx<T> form = new FormStx<T>((T)entity, listaRetorno);
            form.MdiParent = formMain;
            form.Show();
        }
        public static void OpenList<T>(string searchProperty = "", ISelector returnSelector = null)
        {
           ListStx<T> frm = new ListStx<T>(searchProperty, returnSelector);
           frm.MdiParent = formMain;
           frm.Show();
        }

    }
}
