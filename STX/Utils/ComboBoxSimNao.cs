using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace STX
{
    public class ComboBoxSimNao : ComboBox
    {
        public PropertyInfo EntityProperty { get; set; }

        public ComboBoxSimNao() : base()
        {
            base.Items.AddRange(new object[] {"Sim", "Não"});
            
        }
        public bool Value
        {
            get
            {
                return base.SelectedIndex == 0; ;
            }
            set
            {
                base.SelectedIndex = value ? 0 : 1;
            }
        }
    }
}
