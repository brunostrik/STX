using System;

namespace STX
{
    [Serializable]
    [Table("lembretedestinatario", "", "")]
    public class LembreteDestinatario : IModel<LembreteDestinatario>
    {
        [Field("id", "Código", SqlTypes.integer, true, true, true)]
        public int id = 0;

        [Field("idlembrete", "Código Lembrete", SqlTypes.foreignKey, false, true, true)]
        [ForeignKey(typeof(Lembrete), "titulo", "id")]
        public int idLembrete = 0;

        [Field("idlogindestinatario", "Código Destinatário", SqlTypes.foreignKey, false, true, true)]
        [ForeignKey(typeof(Login), "email", "id")]
        public int idlogindestinatario = 0;

        public bool Delete()
        {
            return GenericController<LembreteDestinatario>.Delete(this);
        }

        public int Id()
        {
            return id;
        }

        public bool Insert()
        {
            return GenericController<LembreteDestinatario>.Insert(this);
        }

        public LembreteDestinatario Load(int id)
        {
            return GenericController<LembreteDestinatario>.Load(id);
        }

        public bool Update()
        {
            return GenericController<LembreteDestinatario>.Update(this);
        }
    }
}
