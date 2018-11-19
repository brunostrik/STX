using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STX
{
    public class Alerts
    {
        public static void Message(String msg)
        {
            MessageBox.Show(msg, Program.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Alert(String msg)
        {
            MessageBox.Show(msg, Program.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Error(String msg)
        {
            MessageBox.Show(msg, Program.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool Ask(String question)
        {
            return DialogResult.Yes == MessageBox.Show(question, Program.APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        
    }
}
