using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX
{
    public class Vendedor : IModel<Vendedor>
    {
        public int id = 0;
        public int idLogin = 0;
        public int idFilial = 0;
        public string nome = "";
        public string celular = "";
        public string cpf = "";
        public string rg = "";
        public bool ativo = false;

        public Vendedor()
        {

        }

        public int Id()
        {
            return this.id;
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Insert()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public Vendedor Load(int id)
        {
            throw new NotImplementedException();
        }
    }
}
