using System;
using System.Collections.Generic;

namespace STX
{
    [Serializable]
    [Table("filial", "filial", "filiais")]
    public class Filial : IModel<Filial>
    {
        [Field("id", "Código", SqlTypes.integer, true, true, true)]
        public int id { get; set; } = 0;

        [Field("nome", "Nome da Filial", SqlTypes.varchar, false, true, true, 300)]
        public string nome { get; set; } = "";

        [Field("ativo", "Ativado", SqlTypes.boolean, false, true, true)]
        public bool ativo { get; set; } = true;

        public Filial()
        {

        }
        public int Id()
        {
            return id;
        }
        public List<Filial> Select(CriteriaBuilder criteria)
        {
            return GenericController<Filial>.Select(criteria);
        }
        public bool Insert()
        {
            return GenericController<Filial>.Insert(this);
        }
        public bool Update()
        {
            return GenericController<Filial>.Update(this);
        }
        public bool Delete()
        {
            return GenericController<Filial>.Delete(this);
        }
        public Filial Load(int id) => GenericController<Filial>.Load(id);
    }
}
