using System;
using System.Collections.Generic;


namespace STX
{
    [Serializable]
    [Table("login", "usuário", "usuários")]
    public class Login : IModel<Login>
    {
        [Field("id", "Código", SqlTypes.integer, true, true, true)]
        public int id { get; set; } = 0;

        [Field("usuario", "User", SqlTypes.varchar, false, true, true)]
        public string usuario { get; set; } = "";

        [Field("senha", "Senha", SqlTypes.password, false, true, false)]
        public string senha { get; set; } = "";

        [Field("trocar", "Necessário trocar a senha", SqlTypes.boolean, false, true, true)]
        public int trocar = 0;

        [Field("ativo", "Ativado", SqlTypes.boolean, false, true, true)]
        public bool ativo { get; set; } = true;

        [Field("email", "E-mail", SqlTypes.varchar, false, true, true)]
        public string email { get; set; } = "";

        public Login()
        {

        }

        public int Id()
        {
            return id;
        }

        public static Login Validate(string usuario, string senha)
        {
            CriteriaBuilder cb = new CriteriaBuilder();
            cb.AddWhere("usuario", usuario, MatchMode.Equals);
            cb.AddWhere("senha", senha, MatchMode.Equals, CriterionRelation.And);
            cb.AddWhere("ativo", 1, MatchMode.Equals, CriterionRelation.And);
            List<Login> ll = GenericController<Login>.Select(cb);
            if (ll == null)
            {
                return new Login();
            }
            else
            {
                if (ll.Count == 0)
                {
                    return new Login();

                }
                else
                {
                    return ll[0];
                }
            }
        }
        public List<Login> Select(CriteriaBuilder criteria)
        {
            return GenericController<Login>.Select(criteria);
        }
        public bool Update()
        {
            return GenericController<Login>.Update(this);
        }
        public bool Delete()
        {
            return GenericController<Login>.Delete(this);
        }
        public bool Insert()
        {
            return GenericController<Login>.Insert(this);
        }

        public Login Load(int id)
        {
            throw new NotImplementedException();
        }
    }
}
