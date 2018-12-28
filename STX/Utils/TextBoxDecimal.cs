using System;
using System.Media;
using System.Windows.Forms;

namespace STX
{
    public class TextBoxDecimal : TextBoxStx
    {

        public TextBoxDecimal() : base()
        {
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_KeyPress);
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
        public double Value
        {
            get
            {
                return Convert.ToDouble(base.Text.Replace(',', '.'));
            }
            set
            {
                base.Text = value.ToString().Replace('.', ',');
            }
        }

    }
}
