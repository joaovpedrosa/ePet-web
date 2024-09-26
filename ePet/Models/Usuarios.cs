using ePet.Conexões;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace ePet.Models
{
    public class Usuarios
    {
        protected string nome, email, telefone, endereco, cpf, senha;
        protected string v;

        static MySqlConnection con = ConectarMySql.getConexao();


        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Senha { get => senha; set => senha = value; }



        public Usuarios(string nome, string email, string telefone, string endereco, string cpf, string senha)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.endereco = endereco;
            this.cpf = cpf;
            this.senha = senha;

        }

        public Usuarios(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }

        public Usuarios() { }

        public static string ConexaoUsuarios()
        {

            try
            {
                con.Open();
                Console.WriteLine("Conectado com sucesso!");
                con.Close();
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
                Console.WriteLine(ex.StackTrace);
            }
            return "Inserido com sucesso!";
        }

        public string CadastrarUsuario()
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO usuario (Nome, Email, Telefone, Rua, CPF, Senha) VALUES (@Nome, @Email, @Telefone, @Rua, @CPF, @Senha)", con);
                qry.Parameters.AddWithValue("@Nome", this.nome);
                qry.Parameters.AddWithValue("@Email", this.email);
                qry.Parameters.AddWithValue("@Telefone", this.telefone);
                qry.Parameters.AddWithValue("@Rua", this.endereco);
                qry.Parameters.AddWithValue("@CPF", this.cpf);
                qry.Parameters.AddWithValue("@Senha", this.senha);
                qry.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                return "Erro: " + ex.Message;
            }
            return "Inserido com sucesso!";
        }

        public string DeletarUsuario()
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("DELETE FROM usuario WHERE Cpf = @CPF", con);
                qry.Parameters.AddWithValue("@CPF", cpf);
                qry.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            return "Excluido com sucesso!";
        }

        public Usuarios BuscarUsuario(string cpf)
        {
            Usuarios resultado = null;
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM usuario WHERE Cpf = @CPF", con);
                qry.Parameters.AddWithValue("@CPF", cpf);
                MySqlDataReader ler = qry.ExecuteReader();
                while (ler.Read())
                {
                    resultado = new Usuarios(ler["nome"].ToString(),
                    ler["email"].ToString(),
                    ler["telefone"].ToString(),
                    ler["endereco"].ToString(),
                    ler["cpf"].ToString(),
                    ler["senha"].ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                return null;
            }
            return resultado;
        }

        public static List<Usuarios> ListarUsuario()
        {
            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM usuario", con);
                MySqlDataReader ler = qry.ExecuteReader();
                while (ler.Read())
                {
                    Usuarios linha = new Usuarios(ler["nome"].ToString(),
                    ler["email"].ToString(),
                    ler["telefone"].ToString(),
                    ler["endereco"].ToString(),
                    ler["cpf"].ToString(),
                    ler["senha"].ToString());
                    lista.Add(linha);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                return null;
            }
            return lista;
        }

        public string logarUsuario()
        {
            //Variável que vai devolver o estado do login
            string situacao = "";

            try
            {
                con.Open();

                //CRIANDO COMANDO DE INSERIR USUÁRIOS NO BANCO DE DADOS
                MySqlCommand buscarUsuario = new MySqlCommand("SELECT * FROM USUARIO", con);
                MySqlDataReader listaUsuario = buscarUsuario.ExecuteReader();

                while (listaUsuario.Read())
                {
                    Usuarios usuario = new Usuarios((string)listaUsuario["telefone"], (string)listaUsuario["senha"]);
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
