using ePet.Conexões;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace ePet.Models
{
   
     public class Usuarios
    {
        protected string email, senha, cpf, nome, dataNasc, cep, cidade, telefone, bairro, rua, complemento;
        protected string v;


        static MySqlConnection con = ConectarMySql.getConexao();


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


        public Usuarios(string email, string senha, string cpf, string nome, string dataNasc, string cep, string cidade, string telefone, string bairro, string rua, string complemento)
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
                MySqlCommand qry = new MySqlCommand("INSERT INTO usuario (Email,Senha, Cpf, Nome, DataNasc,Cep,Cidade, Telefone, Bairro,Rua, Complemento) VALUES (@Email,@Senha,@CPF,@Nome,@DataNasc,@Cep,@Cidade,@Telefone,@Bairro,@Rua,@Complemento)", con);
                qry.Parameters.AddWithValue("@Email", this.email);
                qry.Parameters.AddWithValue("@Senha", this.senha);
                qry.Parameters.AddWithValue("@CPF", this.cpf);
                qry.Parameters.AddWithValue("@CPF", this.nome);
                qry.Parameters.AddWithValue("@CPF", this.dataNasc);
                qry.Parameters.AddWithValue("@CPF", this.cep);
                qry.Parameters.AddWithValue("@CPF", this.cidade);
                qry.Parameters.AddWithValue("@CPF", this.telefone);
                qry.Parameters.AddWithValue("@CPF", this.bairro);
                qry.Parameters.AddWithValue("@CPF", this.rua);
                qry.Parameters.AddWithValue("@CPF", this.complemento);
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
                    resultado = new Usuarios(
                    ler["email"].ToString(),
                    ler["senha"].ToString(),
                    ler["cpf"].ToString(),
                    ler["nome"].ToString(),
                    ler["dataNasc"].ToString(),
                    ler["cep"].ToString(),
                    ler["cidade"].ToString(),
                    ler["telefone"].ToString(),
                    ler["bairro"].ToString(),
                    ler["rua"].ToString(),
                    ler["complemento"].ToString());
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
                    Usuarios linha = new Usuarios(ler["email"].ToString(),
                    ler["senha"].ToString(),
                    ler["cpf"].ToString(),
                    ler["nome"].ToString(),
                    ler["dataNasc"].ToString(),
                    ler["cep"].ToString(),
                    ler["cidade"].ToString(),
                    ler["telefone"].ToString(),
                    ler["bairro"].ToString(),
                    ler["rua"].ToString(),
                    ler["complemento"].ToString());
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
