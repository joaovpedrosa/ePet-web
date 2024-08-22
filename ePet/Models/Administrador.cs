using ePet.Conexões;
using MySql.Data.MySqlClient;

namespace ePet.Models
{
    public class Administrador
    {
        private string email;
        private string senha;

        static MySqlConnection con = ConectarMySql.getConexao();

        public Administrador(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }

        protected string Senha { get => senha; set => senha = value; }
        protected string Email { get => email; set => email = value; }


        public string logarUsuario()
        {
            //Variável que vai devolver o estado do login
            string situacao = "";

            try
            {
                con.Open();

                //CRIANDO COMANDO DE INSERIR USUÁRIOS NO BANCO DE DADOS
                MySqlCommand buscarUsuario = new MySqlCommand("SELECT * FROM ADMINISTRADOR", con);
                MySqlDataReader listaUsuario = buscarUsuario.ExecuteReader();

                while (listaUsuario.Read())
                {
                    Administrador usuario = new Administrador((string)listaUsuario["email"], (string)listaUsuario["senha"]);
                    //CONFERINDO SE AQUELE USUÁRIO EXISTE NO BANCO
                    if (usuario.Email == Email)
                    {
                        //A SENHA É A SENHA CADASTRADA PELO USUÁRIO?
                        if (usuario.Senha == Senha)
                        {
                            situacao = "logado";

                            //Pegar o id do banco
                            break;
                        }
                        else
                        {
                            situacao = "Senha incorreta!";

                            break;
                        }
                    }
                    else
                    {
                        situacao = "Email não cadastrado!";

                    }
                }

            }
            catch (Exception e)
            {
                situacao = "Erro de conexão!" + e;
            }
            finally
            {
                con.Close();
            }

            return situacao;
        }
    }
}
