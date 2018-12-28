using System;
using System.Windows.Forms;

namespace STX
{
    public class Alerts
    {
        public static void Message(String msg)
        {
            MessageBox.Show(msg, Config.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Alert(String msg)
        {
            MessageBox.Show(msg, Config.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Error(String msg)
        {
            MessageBox.Show(msg, Config.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool Ask(String question)
        {
            return DialogResult.Yes == MessageBox.Show(question, Config.APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

    }
}
