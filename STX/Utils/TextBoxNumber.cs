using System;
using System.Media;
using System.Windows.Forms;

namespace STX
{
    public class TextBoxNumber : TextBoxStx
    {
        public TextBoxNumber() : base()
        {
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_KeyPress);
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Asterisk.Play();
            }
            if (!double.TryParse(this.Text, out double val))
            {
                Alerts.Alert("Valor inválido");
                e.Handled = true;
            }
        }
        public int Value
        {
            get
            {
                return Convert.ToInt32(base.Text);
            }
            set
            {
                base.Text = value.ToString();
            }
        }
    }
}
