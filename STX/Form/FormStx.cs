using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Windows.Forms;

namespace STX
{
    public partial class FormStx<T> : Form where T : IModel<T>
    {

        private T entity;
        IListForm listaRetorno;

        public FormStx(T e, IListForm lf = null)
        {
            InitializeComponent();
            entity = e;
            //Encontra o nome no singular do elemento
            Text = Config.APP_NAME + " - " + Util.FirstCharToUpper(((Table)e.GetType().GetCustomAttribute(typeof(Table), false)).NomeSingular);
            listaRetorno = lf;
            DefineEntidadeCampos(e);
            Size = new System.Drawing.Size(tableLayoutPanel.Width + 50, tableLayoutPanel.Height + 110);
            groupBox.Size = new System.Drawing.Size(Width - 40, Height - 80);
        }
        public void DefineEntidadeCampos(T e) //TODO
        {
            entity = e;
            if (((IModel<T>)entity).Id() == 0)
            {
                btnExcluir.Enabled = false;
            }
            var props = typeof(T).GetProperties();
            foreach (var prop in props) //Analisar todas as variaveis da entidade
            {
                Control ctl = new Control();
                var anns = prop.GetCustomAttributes(false);
                foreach (var ann in anns) //analisar todas as anotacoes da entidade
                {
                    if (ann.GetType() == typeof(ForeignKey))
                    {
                        //Descobrindo o tipo da sub-entidade e a instanciando com reflection, chamando método herdado 
                        //e outro reflection para instanciar o componente genérico com base na sub-entidade instanciada
                        //PERIGO, BRUXARIA MUITO FORTE, ALTA PROBABIIDADE CTHULHU - SEMPRE RODAR DEBUG
                        //Define o tipo do elemento a ser exibido
                        var selectorType = typeof(ForeignEntitySelectorBox<>);
                        Type[] typeArgs = { ((ForeignKey)ann).FkEntity }; //GRANDE SEGREDO DO UNIVERSO
                        //Usando o reflection 
                        object[] args = { Convert.ToInt32(prop.GetValue(entity)), ((ForeignKey)ann).ForeignKeyDisplayField };
                        var makeme = selectorType.MakeGenericType(typeArgs);
                        object o = Activator.CreateInstance(makeme, args);
                        ctl = o as Control;
                        Label lbl = new Label();
                        //Descobre a anotacao do field com o nome para gerar a label desse menino já aqui
                        lbl.Text = Util.FirstCharToUpper(((ForeignKey)ann).ForeignKeyAlias);
                        lbl.Anchor = AnchorStyles.Right;
                        lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        tableLayoutPanel.Controls.Add(lbl);
                        tableLayoutPanel.Controls.Add(ctl); //add o ctl na grid

                    }
                    if (ann.GetType() == typeof(Field))
                    {
                        if (((Field)ann).Visible) //se nao for visivel nem adiciona o campo
                        {
                            //Texto da label
                            Label lbl = new Label();
                            lbl.Text = Util.FirstCharToUpper(((Field)ann).DisplayName);
                            lbl.Anchor = AnchorStyles.Right;
                            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                            tableLayoutPanel.Controls.Add(lbl);
                            //Tipo do controle (se for foreign key analisar)

                            switch (((Field)ann).FieldType)
                            {
                                case SqlTypes.boolean:
                                    ComboBoxSimNao cmb = new ComboBoxSimNao();
                                    cmb.Value = Convert.ToBoolean(prop.GetValue(entity));
                                    cmb.EntityProperty = prop;
                                    ctl = cmb;
                                    break;
                                case SqlTypes.datetime:
                                    DateTimeSelectorStx dts = new DateTimeSelectorStx();
                                    dts.Value = (DateTime)prop.GetValue(entity);
                                    dts.EntityProperty = prop;
                                    ctl = dts;
                                    break;
                                case SqlTypes.integer:
                                    TextBoxNumber tbn = new TextBoxNumber();
                                    tbn.Value = Convert.ToInt32(prop.GetValue(entity));
                                    tbn.EntityProperty = prop;
                                    ctl = tbn;
                                    break;
                                case SqlTypes.longtext:
                                    TextBoxStx tbx = new TextBoxStx();
                                    tbx.Text = prop.GetValue(entity).ToString();
                                    tbx.EntityProperty = prop;
                                    tbx.Multiline = true;
                                    tbx.Width = ((Field)ann).ComponentWidth;
                                    tbx.Height = Convert.ToInt32(tbx.Width / 3);
                                    ctl = tbx;
                                    break;
                                case SqlTypes.money:
                                    TextBoxMoney tbm = new TextBoxMoney();
                                    tbm.Value = Convert.ToDouble(prop.GetValue(entity));
                                    tbm.EntityProperty = prop;
                                    ctl = tbm;
                                    break;
                                case SqlTypes.real:
                                    TextBoxDecimal tbd = new TextBoxDecimal();
                                    tbd.Value = Convert.ToDouble(prop.GetValue(entity));
                                    tbd.EntityProperty = prop;
                                    break;
                                case SqlTypes.varchar:
                                    TextBoxStx txt = new TextBoxStx();
                                    txt.Text = prop.GetValue(entity).ToString();
                                    txt.EntityProperty = prop;
                                    txt.Width = ((Field)ann).ComponentWidth;
                                    ctl = txt;
                                    break;
                                case SqlTypes.password:
                                    TextBoxStx pwd = new TextBoxStx();
                                    pwd.Text = prop.GetValue(entity).ToString();
                                    pwd.EntityProperty = prop;
                                    pwd.Width = ((Field)ann).ComponentWidth;
                                    pwd.UseSystemPasswordChar = true;
                                    ctl = pwd;
                                    break;
                            }

                            if (((Field)ann).IsPrimaryAutoIncrement) //autoincrement nao deve ser habilitado
                            {
                                ctl.Enabled = false;
                            }

                        }
                    }
                }
                if (ctl.GetType() != typeof(Control))
                {
                    tableLayoutPanel.Controls.Add(ctl); //add o ctl na grid
                }
            }
        }

        private bool ValidarMontarPreenchimento()
        {
            //identificar os controles e pegar os valores
            foreach (Control control in tableLayoutPanel.Controls)
            {
                string tipoControle = control.Name.Substring(0, 3);
                if (tipoControle == "lbl") //pula as labels
                {
                    continue;
                }
                string nomeControle = control.Name.Substring(3);
                var props = typeof(T).GetProperties();
                foreach (var prop in props)
                {
                    if (prop.Name == nomeControle)
                    {
                        //analisa se é de preenchimento obrigatório
                        foreach (var a in prop.GetCustomAttributes(false))
                        {
                            if (a.GetType() == typeof(RequiredAttribute)) //é obrigatorio
                            {
                                if (string.IsNullOrWhiteSpace(control.Text))
                                {
                                    Alerts.Alert(((RequiredAttribute)a).ErrorMessage);
                                    control.Focus();
                                    return false;
                                }
                            }
                        }
                        switch (tipoControle)//preenche o valor na entidade
                        {
                            case "txt":
                                prop.SetValue(entity, control.Text);
                                break;
                            case "csn":
                                if (nomeControle.ToLower() == "ativo")
                                {
                                    //perguntar se o cara tem certeza que quer desativar, se o falor for 0
                                    if (!((ComboBoxSimNao)control).Value)
                                    {
                                        if (!Alerts.Ask("Ao este item como não ativo, ele não será mais mostrado no sistema. Você tem certeza disso?"))
                                        {
                                            return false;
                                        }
                                    }
                                }
                                prop.SetValue(entity, ((ComboBoxSimNao)control).Value);
                                break;
                            case "tbn":
                                prop.SetValue(entity, ((TextBoxNumber)control).Value);
                                break;
                            case "tbd":
                                prop.SetValue(entity, ((TextBoxDecimal)control).Value);
                                break;
                            case "dtp":
                                if (((DateTimePicker)control).Value == null)
                                {
                                    Alerts.Alert("Por favor selecione uma data válida");
                                    control.Focus();
                                    return false;
                                }
                                prop.SetValue(entity, ((DateTimePicker)control).Value);
                                break;
                            default:
                                prop.SetValue(entity, control.Text);
                                break;
                        }
                    }
                }
            }
            return true;
        }

        private void Salvar()
        {
            if (((IModel<T>)entity).Id() == 0)
            {
                if (((IModel<T>)entity).Insert())
                {
                    Alerts.Message("Item adicionado!");
                    if (listaRetorno != null)
                    {
                        listaRetorno.Retornar();
                    }
                    Close();
                }
                else
                {
                    Alerts.Error("Falha ao excluir este item.");
                }
            }
            else
            {
                if (((IModel<T>)entity).Update())
                {
                    Alerts.Message("Item atualizado!");
                    if (listaRetorno != null)
                    {
                        listaRetorno.Retornar();
                    }
                    Close();
                }
                else
                {
                    Alerts.Alert("Falha ao atualizar este item.");
                }
            }
        }
        private void Excluir()
        {
            if (!Alerts.Ask("Confirma a exclusão do item selecionado?"))
            {
                return;
            }

            if (((IModel<T>)entity).Delete())
            {
                Alerts.Message("Item excluído!");
                if (listaRetorno != null)
                {
                    listaRetorno.Retornar();
                }
                Close();
            }
            else
            {
                Alerts.Error("Falha ao excluir este item.");
            }
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            if (ValidarMontarPreenchimento())
            {
                Salvar();
            }
        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            Excluir();
        }

    }
}
