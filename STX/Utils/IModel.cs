using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX
{
    public interface IModel<T>
    {
        bool Insert();
        bool Update();
        bool Delete();
        T Load(int id);
        int Id();
    }
}
