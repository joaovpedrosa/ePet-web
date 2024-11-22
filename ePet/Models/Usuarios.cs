
namespace ePet.Models
{

    public class Usuarios
    {
        protected string 
            email, 
            senha, 
            cpf, 
            nome, 
            dataNasc,
            cep, 
            cidade, 
            telefone, 
            bairro, 
            rua, 
            complemento,
            isAdm;

        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public string DataNasc { get => dataNasc; set => dataNasc = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public string IsAdm { get => isAdm; set => isAdm = value; }


       


        public Usuarios(string nome, string telefone, string cep, string cidade, string bairro, string rua, string complemento, string cpf, string email, string dataNasc, string senha, string isAdm)
        {

            this.email = email;
            this.senha = senha;
            this.cpf = cpf;
            this.nome = nome;
            this.dataNasc = dataNasc;
            this.cep = cep;
            this.cidade = cidade;
            this.telefone = telefone;
            this.bairro = bairro;
            this.rua = rua;
            this.complemento = complemento;
            this.isAdm = isAdm;
        }
    }
}

