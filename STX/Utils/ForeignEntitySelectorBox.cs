﻿using System.Windows.Forms;

namespace STX
{
    public partial class ForeignEntitySelectorBox<T> : UserControl, ISelector where T : IModel<T>, new()
    {
        public T Entity { get; set; }
        private string DisplayField;
        public ForeignEntitySelectorBox(T entity, string ForeignKeyDisplayField)
        {
            InitializeComponent();
            Entity = entity;
            DisplayField = ForeignKeyDisplayField;
            Display();
        }
        public ForeignEntitySelectorBox(int idEntityToLoad, string ForeignKeyDisplayField)
        {
            InitializeComponent();
            if (idEntityToLoad == 0)
            {
                Entity = new T();
            }
            else
            {
                Entity = GenericController<T>.Load(idEntityToLoad);
            }
            DisplayField = ForeignKeyDisplayField;
            Display();
        }
       
        private void Display()
        {
            if (Entity == null)
            {
                txtDisplay.Text = "(Nenhum item selecionado)";
                return;
            }
            //Encontrar o campo determinado no displayfield, identificar com reflection, carregar da entidade e exibir no txt
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                if (prop.Name.ToLower() == DisplayField.ToLower()) //encontrou
                {
                    txtDisplay.Text = prop.GetValue(Entity, null).ToString();
                    break;
                }
            }
        }

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            Program.OpenList<T>(DisplayField, this);
        }

        public void Return(object item)
        {
            Entity = (T)item;
            Display();
        }
    }
}
