using System;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace STX
{
    public class TextBoxMoney : TextBoxStx
    {

        public TextBoxMoney() : base()
        {
            base.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            base.Enter += new EventHandler(textBox_Enter);
            base.Leave += new EventHandler(textBox_Leave);
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                SystemSounds.Asterisk.Play();
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                SystemSounds.Asterisk.Play();
            }
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            base.Text = base.Text.Replace(",", ".");
            base.Text = Regex.Replace(base.Text, "[^.0-9]", "");
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            double val;
            if (!double.TryParse(Text, out val))
            {
                Alerts.Alert("Valor inválido");
                return;
            }
            Text = string.Format("{0:C}", val);
        }
        public double Value
        {
            get
            {
                return Convert.ToDouble(Regex.Replace(base.Text.Replace(",", "."), "[^.0-9]", ""));
            }
            set
            {
                base.Text = string.Format("{0:C}", value);
            }
        }
    }
}
