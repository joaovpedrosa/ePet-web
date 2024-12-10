namespace ePet.Models
{
    public class Adocao
    {
        protected string cod_animal, cpf, codigoAdo;

        public string Cod_Animal
        {
            get => cod_animal; set => cod_animal = value;
        }

        public string Cpf
        {
            get => cpf; set => cpf = value;
        }

        public string CodigoAdo
        {
            get => codigoAdo; set => codigoAdo = value;
        }

        // Construtor sem parâmetros
        public Adocao() { }

        // Construtor com parâmetros
        public Adocao(string cod_animal, string cpf, string codigoAdo)
        {
            this.cod_animal = cod_animal;
            this.cpf = cpf;
            this.codigoAdo = codigoAdo;
        }
    }
}
