using System.Windows.Forms;
using System.Reflection;

namespace STX
{
    public class TextBoxStx : TextBox
    {
        public PropertyInfo EntityProperty { get; set; }
        public bool Required { get; set; }
        public virtual bool Validate()
        {
            return !string.IsNullOrWhiteSpace(this.Text);
        }
    }
}
