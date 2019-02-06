using System;
using System.Collections.Generic;

namespace STX
{
    public partial class FormLembrete : FormStxBase
    {

        public FormLembrete(IListForm listaRetorno)
        {
            InitializeComponent();
            btnExcluir.Visible = false;
            ListaRetorno = listaRetorno;
            //carrega o remetente como o usuario atual do sistema
            txtRemetente.Text = Program.login.email;
            //carrega todos os usuarios ativos e coloca na listinha
            CriteriaBuilder criteria = new CriteriaBuilder();
            criteria.AddWhere("ativo", "1", MatchMode.Equals);
            criteria.AddOrderBy("email", Ordenation.Asc);
            lstDestinatarios.Items.AddRange(GenericController<Login>.Select(criteria).ToArray());
            lstDestinatarios.DisplayMember = "email";
            lstDestinatariosSelecionados.DisplayMember = "email";
            //mindate como amanha
            dtsDiaLembrete.MinDate = DateTime.Now.AddDays(1);
            GerenciarBotoesListas();
        }

        private void FormLembrete_SalvarPressed(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Pega a entidade selecionada
            Login sel = lstDestinatarios.SelectedItem as Login;
            //Adiciona na lista 2
            lstDestinatariosSelecionados.Items.Add(sel);
            //Remove na lista 1
            lstDestinatarios.Items.Remove(sel);
            //Reorganiza as listas alfabeticamente
            List<Login> temp = new List<Login>();
            foreach(Login l in lstDestinatarios.Items) temp.Add(l);           
            temp.Sort((x, y) => String.Compare(x.email, y.email));
            lstDestinatarios.Items.Clear();
            lstDestinatarios.Items.AddRange(temp.ToArray());
            temp.Clear();
            foreach (Login l in lstDestinatariosSelecionados.Items) temp.Add(l);
            temp.Sort((x, y) => String.Compare(x.email, y.email));
            lstDestinatariosSelecionados.Items.Clear();
            lstDestinatariosSelecionados.Items.AddRange(temp.ToArray());
            GerenciarBotoesListas();
        }

        private void btnRmv_Click(object sender, EventArgs e)
        {
            //Pega a entidade selecionada
            Login sel = lstDestinatariosSelecionados.SelectedItem as Login;
            //Adiciona na lista 1
            lstDestinatarios.Items.Add(sel);
            //Remove da lista 2
            lstDestinatariosSelecionados.Items.Remove(sel);
            //Reorganiza as listas alfabeticamente
            List<Login> temp = new List<Login>();
            foreach (Login l in lstDestinatarios.Items) temp.Add(l);
            temp.Sort((x, y) => String.Compare(x.email, y.email));
            lstDestinatarios.Items.Clear();
            lstDestinatarios.Items.AddRange(temp.ToArray());
            temp.Clear();
            foreach (Login l in lstDestinatariosSelecionados.Items) temp.Add(l);
            temp.Sort((x, y) => String.Compare(x.email, y.email));
            lstDestinatariosSelecionados.Items.Clear();
            lstDestinatariosSelecionados.Items.AddRange(temp.ToArray());
            GerenciarBotoesListas();
        }

        private void lstDestinatarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GerenciarBotoesListas();
        }

        private void lstDestinatariosSelecionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GerenciarBotoesListas();
        }
        private void GerenciarBotoesListas()
        {
            btnAdd.Enabled = lstDestinatarios.SelectedItems.Count > 0;
            btnRmv.Enabled = lstDestinatariosSelecionados.SelectedItems.Count > 0;
        }
        private void Salvar()
        {
            if (!ValidarPreenchimento()) return;
            Lembrete lemb = new Lembrete();
            lemb = new Lembrete();
            //adicionar os valores, popular as sub entidades, chamar um control nao generico e mandar bala.
            lemb.dataHoraCadastro = DateTime.Now;
            lemb.dataHoraEnvio = dtsDiaLembrete.Value;
            lemb.enviada = false;
            lemb.idLoginRemetente = Program.login.id;
            lemb.mensagem = txtMensagem.Text;
            lemb.titulo = txtTitulo.Text;
            List<LembreteDestinatario> dest = new List<LembreteDestinatario>();
            foreach (Login l in lstDestinatariosSelecionados.Items)
            {
                LembreteDestinatario ld = new LembreteDestinatario();
                ld.idlogindestinatario = l.id;
                dest.Add(ld);
            }
            if (new LembreteControl().CadastrarLembrete(lemb, dest))
            {
                Alerts.Message("Os lembretes foram cadastrados corretamente.\r\nO envio irá ocorrer no dia determinado, com variações de horário conforme configurado no servidor do sistema.");
                ListaRetorno.Retornar();
                this.Close();
            }
            else
            {
                Alerts.Error("Ocorreu algum erro durante o cadastro destes lembretes. Caso o problema persista solicite que o responsável pelo sistema verifique o arquivo de logs para identificar a causa.");
            }
        }
        private bool ValidarPreenchimento()
        {
            //validar o preenchimento aq
            if (dtsDiaLembrete.Value.Date < (DateTime.Now.Date))
            {
                Alerts.Alert("Um lembrete só pode ser cadastrado para o dia de amanhã em diante.");
                dtsDiaLembrete.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                Alerts.Alert("Preencha o título do lembrete.");
                txtTitulo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMensagem.Text))
            {
                Alerts.Alert("Preencha a mensagem do lembrete.");
                txtMensagem.Focus();
                return false;
            }
            if (lstDestinatariosSelecionados.Items.Count == 0)
            {
                Alerts.Alert("Adicione os destinatários de seu lembrete.");
                lstDestinatarios.Focus();
                return false;
            }
            return true;
        }
    }
}
