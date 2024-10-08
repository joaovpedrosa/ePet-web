using ePet.Conexões;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ePet.Models
{
    public class Usuarios
    {
        protected string email, senha, cpf, nome, dataNasc, cep, cidade, telefone, bairro, rua, complemento, isAdm;

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
        public string IsAdm { get => isAdm; set => isAdm = value; }

        public Usuarios(string email, string senha, string cpf, string nome, string dataNasc, string cep, string cidade, string telefone, string bairro, string rua, string complemento, string isAdm)
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

        public Usuarios(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }

        public Usuarios() { }

        public string ConexaoUsuarios()
        {
            try
            {
                con.Open();
                return "Conectado com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public string CadastrarUsuario()
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO usuario (Email, Senha, Cpf, Nome, DataNasc, Cep, Cidade, Telefone, Bairro, Rua, Complemento, isAdm) VALUES (@Email, @Senha, @Cpf, @Nome, @DataNasc, @Cep, @Cidade, @Telefone, @Bairro, @Rua, @Complemento, @IsAdm)", con);
                qry.Parameters.AddWithValue("@Email", this.email);
                qry.Parameters.AddWithValue("@Senha", this.senha);
                qry.Parameters.AddWithValue("@Cpf", this.cpf);
                qry.Parameters.AddWithValue("@Nome", this.nome);
                qry.Parameters.AddWithValue("@DataNasc", this.dataNasc);
                qry.Parameters.AddWithValue("@Cep", this.cep);
                qry.Parameters.AddWithValue("@Cidade", this.cidade);
                qry.Parameters.AddWithValue("@Telefone", this.telefone);
                qry.Parameters.AddWithValue("@Bairro", this.bairro);
                qry.Parameters.AddWithValue("@Rua", this.rua);
                qry.Parameters.AddWithValue("@Complemento", this.complemento);
                qry.Parameters.AddWithValue("@IsAdm", this.isAdm);
                qry.ExecuteNonQuery();
                return "Inserido com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public string DeletarUsuario()
        {
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("DELETE FROM usuario WHERE Cpf = @CPF", con);
                qry.Parameters.AddWithValue("@CPF", cpf);
                qry.ExecuteNonQuery();
                return "Excluído com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
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
                if (ler.Read())
                {
                    resultado = new Usuarios(
                        ler["Email"].ToString(),
                        ler["Senha"].ToString(),
                        ler["Cpf"].ToString(),
                        ler["Nome"].ToString(),
                        ler["DataNasc"].ToString(),
                        ler["Cep"].ToString(),
                        ler["Cidade"].ToString(),
                        ler["Telefone"].ToString(),
                        ler["Bairro"].ToString(),
                        ler["Rua"].ToString(),
                        ler["Complemento"].ToString(),
                        ler["isAdm"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                // Trate a exceção adequadamente
                return null;
            }
            finally
            {
                con.Close();
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
                    Usuarios linha = new Usuarios(
                        ler["Email"].ToString(),
                        ler["Senha"].ToString(),
                        ler["Cpf"].ToString(),
                        ler["Nome"].ToString(),
                        ler["DataNasc"].ToString(),
                        ler["Cep"].ToString(),
                        ler["Cidade"].ToString(),
                        ler["Telefone"].ToString(),
                        ler["Bairro"].ToString(),
                        ler["Rua"].ToString(),
                        ler["Complemento"].ToString(),
                        ler["isAdm"].ToString()
                    );
                    lista.Add(linha);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public Usuarios logarUsuario()
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE Email = @Email", con);
                cmd.Parameters.AddWithValue("@Email", this.email);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string senhaBanco = reader["Senha"].ToString();
                    if (senhaBanco == this.senha) // Verifica se a senha está correta
                    {
                        // Se a senha estiver correta, retorna o objeto Usuarios
                        this.isAdm = reader["isAdm"].ToString(); // Captura o valor de isAdm
                        return this;
                    }
                    else
                    {
                        return null; // Senha incorreta
                    }
                }
                else
                {
                    return null; // Email não cadastrado
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções
                return null; // Ou retornar um erro, conforme sua lógica
            }
            finally
            {
                con.Close();
            }
        }
    }
}

