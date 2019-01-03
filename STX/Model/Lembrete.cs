using System;

namespace STX
{
    [Serializable]
    [Table("lembrete", "Lembrete", "Lembretes")]
    public class Lembrete : IModel<Lembrete>
    {
        [Field("id", "Código", SqlTypes.integer, true, true, true)]
        public int id { get; set; } = 0;
        
        [ForeignKey(typeof(Login), "email", "id", "Remetente")]
        [Field("idloginremetente", "Remetente", SqlTypes.integer, false, true, false)]
        public int idLoginRemetente { get; set; } = 0;

        [Field("titulo", "Assunto", SqlTypes.varchar, false, true, true, 300)]
        public string titulo { get; set; } = "";

        [Field("mensagem", "Mensagem", SqlTypes.longtext, false, true, true, 300)]
        public string mensagem { get; set; } = "";

        [Field("datahoracadastro", "Data de cadastro", SqlTypes.datetime, false, true, true)]
        public DateTime dataHoraCadastro { get; set; } = DateTime.Now;

        [Field("datahoraenvio", "Data para envio", SqlTypes.datetime, false, true, true)]
        public DateTime dataHoraEnvio { get; set; } = DateTime.Now;

        [Field("enviada", "Enviada", SqlTypes.boolean, false, true, true)]
        public bool enviada { get; set; } = false;

        public bool Delete()
        {
            return GenericController<Lembrete>.Delete(this);
        }

        public int Id()
        {
            return id;
        }

        public bool Insert()
        {
            return GenericController<Lembrete>.Insert(this);
        }

        public Lembrete Load(int id)
        {
            return GenericController<Lembrete>.Load(id);
        }

        public bool Update()
        {
            return GenericController<Lembrete>.Update(this);
        }
    }
}
