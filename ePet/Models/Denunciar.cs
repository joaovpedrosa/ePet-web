namespace ePet.Models
{
    public class Denunciar
    {
        protected string descricao, cidade, bairro, rua,  complemento, codigoDenun;

        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        public string Cidade
        {
            get => cidade;
            set => cidade = value;
        }

        public string Bairro
        {
            get => bairro;
            set => bairro = value;
        }

        public string Rua
        {
            get => rua;
            set => rua = value;
        }

       

        public string Complemento
        {
            get => complemento;
            set => complemento = value;
        }

        public string CodigoDenun
        {
            get => codigoDenun;
            set => codigoDenun = value; 
        }


        public Denunciar(string descricao, string cidade, string bairro, string rua,  string complemento, string codigoDenun)
        {
            this.descricao = descricao;
            this.cidade = cidade;
            this.bairro = bairro;
            this.rua = rua;
            this.Complemento = complemento;
            this.CodigoDenun = codigoDenun;
        }


    }
}
