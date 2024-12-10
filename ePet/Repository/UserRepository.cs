using ePet.Conexões;
using ePet.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ePet.Repository
{
    public class UserRepository
    {
        private readonly MySqlConnection mySqlConnection;

        public UserRepository()
        {
            this.mySqlConnection = ConectarMySql.getConexao(); // Conexão com o banco
        }



        public string CadastrarUsuario(Usuarios usuario)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO usuario (Nome, Telefone, Cep, Cidade, Bairro, Rua, Complemento, Cpf, Email, DataNasc, Senha, IsAdm) VALUES (@Nome, @Telefone, @Cep, @Cidade, @Bairro, @Rua, @Complemento, @Cpf, @Email, @DataNasc, @Senha, @IsAdm)", mySqlConnection);

                qry.Parameters.AddWithValue("@Nome", usuario.Nome);
                qry.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                qry.Parameters.AddWithValue("@Cep", usuario.Cep);
                qry.Parameters.AddWithValue("@Cidade", usuario.Cidade);
                qry.Parameters.AddWithValue("@Bairro", usuario.Bairro);
                qry.Parameters.AddWithValue("@Rua", usuario.Rua);
                qry.Parameters.AddWithValue("@Complemento", usuario.Complemento);
                qry.Parameters.AddWithValue("@Cpf", usuario.Cpf);
                qry.Parameters.AddWithValue("@Email", usuario.Email);
                qry.Parameters.AddWithValue("@DataNasc", usuario.DataNasc);
                qry.Parameters.AddWithValue("@Senha", usuario.Senha);
                qry.Parameters.AddWithValue("@IsAdm", usuario.IsAdm);

                qry.ExecuteNonQuery();
                return "Inserido com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public string DeletarUsuario(string cpf)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("DELETE FROM usuario WHERE Cpf = @CPF", mySqlConnection);
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
                mySqlConnection.Close();
            }
        }

        // Método para buscar usuário por CPF
        public Usuarios BuscarUsuario(string cpf)
        {
            Usuarios resultado = null;
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM usuario WHERE Cpf = @CPF", mySqlConnection);
                qry.Parameters.AddWithValue("@CPF", cpf);
                MySqlDataReader ler = qry.ExecuteReader();
                if (ler.Read())
                {
                    resultado = new Usuarios(
                        ler["Nome"].ToString(),
                        ler["Telefone"].ToString(),
                        ler["Cep"].ToString(),
                        ler["Cidade"].ToString(),
                        ler["Bairro"].ToString(),
                        ler["Rua"].ToString(),
                        ler["Complemento"].ToString(),
                        ler["Cpf"].ToString(),
                        ler["Email"].ToString(),
                        ler["DataNasc"].ToString(),
                        ler["Senha"].ToString(),
                        ler["IsAdm"].ToString());
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
            return resultado;
        }


        public List<Usuarios> ListarUsuarios()
        {
            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM usuario", mySqlConnection);
                MySqlDataReader ler = qry.ExecuteReader();
                while (ler.Read())
                {
                    Usuarios usuario = new Usuarios(
                        ler["Nome"].ToString(),
                        ler["Telefone"].ToString(),
                        ler["Cep"].ToString(),
                        ler["Cidade"].ToString(),
                        ler["Bairro"].ToString(),
                        ler["Rua"].ToString(),
                        ler["Complemento"].ToString(),
                        ler["Cpf"].ToString(),
                        ler["Email"].ToString(),
                        ler["DataNasc"].ToString(),
                        ler["Senha"].ToString(),
                        ler["IsAdm"].ToString());
                    lista.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                mySqlConnection.Close();
            }
            return lista;
        }

        public string AtualizarUsuario(Usuarios usuario)
        {
            try
            {
                mySqlConnection.Open();
                string query = "UPDATE usuario SET Nome = @Nome, Telefone = @Telefone, Cep = @Cep, Cidade = @Cidade, Bairro = @Bairro, Rua = @Rua, Complemento = @Complemento, Email = @Email, DataNasc = @DataNasc, Senha = @Senha WHERE Cpf = @Cpf";
                MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);

                // Atribui os parâmetros ao comando
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                cmd.Parameters.AddWithValue("@Cep", usuario.Cep);
                cmd.Parameters.AddWithValue("@Cidade", usuario.Cidade);
                cmd.Parameters.AddWithValue("@Bairro", usuario.Bairro);
                cmd.Parameters.AddWithValue("@Rua", usuario.Rua);
                cmd.Parameters.AddWithValue("@Complemento", usuario.Complemento);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@DataNasc", usuario.DataNasc);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf);

                cmd.ExecuteNonQuery();
                return "Atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }


        public Usuarios LogarUsuario(string email, string senha)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE Email = @Email", mySqlConnection);
                cmd.Parameters.AddWithValue("@Email", email);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string senhaBanco = reader["Senha"].ToString();
                    if (senhaBanco == senha) // Verifica se a senha está correta
                    {
                        return new Usuarios(
                            reader["Nome"].ToString(),
                            reader["Telefone"].ToString(),
                            reader["Cep"].ToString(),
                            reader["Cidade"].ToString(),
                            reader["Bairro"].ToString(),
                            reader["Rua"].ToString(),
                            reader["Complemento"].ToString(),
                            reader["Cpf"].ToString(),
                            reader["Email"].ToString(),
                            reader["DataNasc"].ToString(),
                            senhaBanco, // Armazena a senha do banco para o retorno
                            reader["IsAdm"].ToString()); // Captura o valor de isAdm
                    }
                }
            }
            catch (Exception ex)
            {
                return null; // Ou lidar com o erro conforme sua lógica
            }
            finally
            {
                mySqlConnection.Close();
            }
            return null; // Retorna null se não encontrar ou falhar
        }
    }
}
