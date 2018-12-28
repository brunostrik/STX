using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;


namespace STX
{
    [Serializable]
    [Table("login", "usuário", "usuários")]
    public class Login : IModel<Login>
    {
        [Browsable(false)]
        public int id { get; set; } = 0;
        [DisplayName("Login")]
        [Required(ErrorMessage = "Preencha o login")]
        public string usuario { get; set; } = "";
        [DisplayName("Senha")]
        [PasswordPropertyText]
        [Required(ErrorMessage = "Preencha a senha")]
        [DataType(DataType.Password)]
        public string senha { get; set; } = "";
        [Browsable(false)]
        public int trocar = 0;
        [Browsable(false)]
        [DataType(DataType.Custom)]
        public int ativo { get; set; } = 0;

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
            cb.Add("usuario", usuario, MatchMode.Equals);
            cb.Add("senha", senha, MatchMode.Equals, CriterionRelation.And);
            cb.Add("ativo", 1, MatchMode.Equals, CriterionRelation.And);
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
