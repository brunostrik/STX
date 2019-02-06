using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX
{
    [Serializable]
    [Table("passageiro", "Passageiro", "Passageiros")]
    class Passageiro : IModel<Passageiro>
    {
        [Field("id", "Código", SqlTypes.integer, true, true, true, 0)]
        public int id { get; set; } = 0;
        [Field("tipo", "Tipo Pessoa", SqlTypes.integer, false, true, false, 0)]
        public int tipoPessoa { get; set; } = 0; //0-PF, 1-PJ
        [Field("nome_Fantasia", "Nome", SqlTypes.varchar, false, true, true, 400)]
        public string nomeFantasia { get; set; } = "";
        [Field("apelido_razao_social", "Apelido", SqlTypes.varchar, false, false, false, 0)]
        public string apelidoRazaoSocial { get; set; } = "";
        [Field("cpf_cnpj", "CPF/CNPJ", SqlTypes.varchar, false, false, true, 200)]
        public string cpfCnpj { get; set; } = "";
        [Field("tipo_documento", "Tipo do Documento", SqlTypes.integer, false, false, false, 0)]
        public int tipoDocumento { get; set; } = 0; //0-Nenhum documento 1-RG 2-RN 3-CNH 4-Passaporte 5-Outros
        [Field("documento", "Documento", SqlTypes.varchar, false, true, true, 200)]
        public string documento { get; set; } = "";
        [Field("orgao_emissor", "Órgão Emissor", SqlTypes.varchar, false, true, false, 0)]
        public string orgaoEmissor { get; set; } = "";
        [Field("celular", "Celular/WhatsApp", SqlTypes.varchar, false, false, true, 180)]
        public string celular { get; set; } = "";
        [Field("telefone", "Telefone Fixo", SqlTypes.varchar, false, false, false, 0)]
        public string telefone { get; set; } = "";
        [Field("email", "E-Mail", SqlTypes.varchar, false, false, true, 220)]
        public string email { get; set; } = "";
        [Field("data_nascimento", "Data de Nascimento", SqlTypes.datetime, false, true, true, 150)]
        public DateTime dataNascimento { get; set; } = DateTime.Now;
        [Field("data_cadastro", "Data de Cadastro", SqlTypes.datetime, false, true, false, 0)]
        public DateTime dataCadastro { get; set; } = DateTime.Now;
        [Field("endereco", "Endereço", SqlTypes.varchar, false, false, false, 0)]
        public string endereco { get; set; } = "";
        [Field("numero", "Nro.", SqlTypes.varchar, false, false, false, 0)]
        public string numero { get; set; } = "";
        [Field("complemento", "Complemento", SqlTypes.varchar, false, false, false, 0)]
        public string complemento { get; set; } = "";
        [Field("bairro", "Bairro", SqlTypes.varchar, false, false, false, 0)]
        public string bairro { get; set; } = "";
        [Field("cidade", "Cidade", SqlTypes.varchar, false, false, false, 0)]
        public string cidade { get; set; } = "";
        [Field("uf", "Estado", SqlTypes.varchar, false, false, false, 0)]
        public string uf { get; set; } = "";
        

        public bool Delete()
        {
            return GenericController<Passageiro>.Delete(this);
        }

        public int Id()
        {
            return id;
        }

        public bool Insert()
        {
            return GenericController<Passageiro>.Insert(this);
        }

        public Passageiro Load(int id)
        {
            return GenericController<Passageiro>.Load(id);
        }

        public bool Update()
        {
            return GenericController<Passageiro>.Update(this);
        }
    }
}
