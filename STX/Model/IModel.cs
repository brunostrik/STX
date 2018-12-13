using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX
{
    public interface IModel
    {
        List<Object> Search(string keyword);
        void Insert();
        void Update();
        void Delete();
    }
}
