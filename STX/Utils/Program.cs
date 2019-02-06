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
        public static ListLembrete listLembrete;

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
            switch (typeof(T).Name)
            {
                case "Lembrete":
                    FormLembrete frmLembrete = new FormLembrete(listaRetorno);
                    frmLembrete.MdiParent = formMain;
                    frmLembrete.Show();
                    break;
                case "Passageiro":
                    FormPassageiro frmPassageiro = new FormPassageiro(listaRetorno);
                    frmPassageiro.MdiParent = formMain;
                    frmPassageiro.Show();
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
            //Forms não genéricos
            switch (typeof(T).Name)
            {
                case "Lembrete":
                    listLembrete = new ListLembrete(returnSelector);
                    listLembrete.MdiParent = formMain;
                    listLembrete.Show();
                    break;
                default:
                    ListStx<T> frm = new ListStx<T>(searchProperty, returnSelector);
                    frm.MdiParent = formMain;
                    frm.Show();
                    break;
            }
        }

    }
}
