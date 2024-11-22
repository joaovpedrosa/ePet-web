using ePet.Conexões;
using MySql.Data.MySqlClient;

namespace ePet.Models
{
    public class Denunciar
    {
        protected string descricao, cidade, bairro, rua, numero, complemento;
        static MySqlConnection con = ConectarMySql.getConexao();
     

      
        public string Descricao { get => descricao; set => descricao = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Complemento { get => complemento; set => complemento = value; }
    


        public Denunciar(string descricao, string cidade, string bairro, string rua, string numero, string complemento)
        {
            this.descricao = descricao;
            this.cidade = cidade;
            this.bairro = bairro;
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
          
        }



     

       
    }

}
