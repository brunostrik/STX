using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace STX
{
    public class DateTimeSelectorStx : DateTimePicker
    {
        public PropertyInfo EntityProperty { get; set; }

        public DateTimeSelectorStx() : base()
        {
            base.CustomFormat = "dd/MM/yyyy hh:mm";
            base.Format = DateTimePickerFormat.Custom;
            base.Value = DateTime.Now;
        }
    }
}
