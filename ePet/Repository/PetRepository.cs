using ePet.Conexões;
using ePet.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ePet.Repository

{
    public class PetRepository
    {
        private readonly MySqlConnection mySqlConnection;

        public PetRepository()
        {
            this.mySqlConnection = ConectarMySql.getConexao();
        }

        public static string ConexaoAnimal(MySqlConnection mySqlConnection)
        {
            try
            {
                mySqlConnection.Open();
                Console.WriteLine("Conectado com sucesso!");
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
                Console.WriteLine(ex.StackTrace);
            }
            return "Inserido com sucesso!";
        }


        public string CadastrarAnimal(Animais animais)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO animal (Idade, Comportamento, Especie, Nome, Castracao, status, Peso, Raca, Porte, Sexo, Foto) VALUES (@Idade, @Comportamento, @Especie, @Nome, @Castracao, @status, @Peso, @Raca, @Porte, @Sexo, @Foto)", mySqlConnection);

                // Adicionando os parâmetros na ordem correta
                qry.Parameters.AddWithValue("@Idade", animais.Idade);
                qry.Parameters.AddWithValue("@Comportamento", animais.Comportamento);
                qry.Parameters.AddWithValue("@Especie", animais.T_Animal);
                qry.Parameters.AddWithValue("@Nome", animais.Nome);
                qry.Parameters.AddWithValue("@Castracao", animais.Castracao);
                qry.Parameters.AddWithValue("@status", animais.Status);
                qry.Parameters.AddWithValue("@Peso", animais.Peso);
                qry.Parameters.AddWithValue("@Raca", animais.Raca);
                qry.Parameters.AddWithValue("@Porte", animais.Porte);
                qry.Parameters.AddWithValue("@Sexo", animais.Sexo);
                qry.Parameters.AddWithValue("@Foto", animais.ArrayBytes);


                qry.ExecuteNonQuery();
                mySqlConnection.Close();
            }

            catch (Exception ex)
            {
                mySqlConnection.Close();
                return "Erro: " + ex.Message;
            }
            return "Inserido com sucesso!";
        }
        public string DeletarAnimal(string codigo_animal)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("DELETE FROM animal WHERE cod_animal = @Codigo_Animal", mySqlConnection);
                qry.Parameters.AddWithValue("@Codigo_Animal", codigo_animal);
                qry.ExecuteNonQuery();
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            return "Excluido com sucesso!";
        }
        public Animais GetPet(string codigoAnimal)
        {
            Animais animal = null;

            try
            {
                mySqlConnection.Open();
                using (var query = new MySqlCommand("SELECT * FROM animal WHERE cod_animal = @Codigo_Animal", mySqlConnection))
                {
                    query.Parameters.AddWithValue("@Codigo_Animal", codigoAnimal);

                    using (var reader = query.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Nenhum registro encontrado para o código: " + codigoAnimal);
                            return null; // Retorna se nenhum dado for encontrado
                        }

                        while (reader.Read())
                        {
                            // Log temporário para depuração
                            Console.WriteLine($"Dados recebidos para o código: {codigoAnimal}");

                            animal = new Animais(
                                codigo_animal: reader["cod_animal"].ToString(),
                                t_animal: reader["Especie"].ToString(),
                                status: reader["status"].ToString(),
                                nome: reader["Nome"].ToString(),
                                idade: reader["idade"].ToString(),
                                castracao: reader["Castracao"].ToString(),
                                raca: reader["Raca"].ToString(),
                                porte: reader["Porte"].ToString(),
                                peso: reader["Peso"].ToString(),
                                comportamento: reader["comportamento"].ToString(),
                                sexo: reader["Sexo"].ToString(),
                                arrayBytes: reader["foto"] != DBNull.Value ? (byte[])reader["Foto"] : null
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no método GetPet: " + ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return animal;
        }

        public Animais BuscarAnimal(string codigo_animal)
        {
            Animais resultado = null;
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM animal WHERE cod_animal = @Codigo_Animal", mySqlConnection);
                qry.Parameters.AddWithValue("@Codigo_Animal", codigo_animal);
                MySqlDataReader leitor = qry.ExecuteReader();
                while (leitor.Read())
                {
                    byte[] imagemBytes = leitor["foto"] != DBNull.Value ? (byte[])leitor["foto"] : null;
                    resultado = new Animais(
                    leitor["cod_animal"].ToString(),
                    leitor["comportamento"].ToString(),
                    leitor["especie"].ToString(),
                    leitor["nome"].ToString(),
                    leitor["Idade"].ToString(),
                    leitor["castracao"].ToString(),
                    leitor["status"].ToString(),
                    leitor["peso"].ToString(),
                    leitor["raca"].ToString(),
                    leitor["porte"].ToString(),
                    leitor["sexo"].ToString(),
                    imagemBytes);

                }
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                return null;
            }
            return resultado;
        }


        public List<Animais> ListarAnimais()
        {
            List<Animais> lista = new List<Animais>();
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM animal", mySqlConnection);
                MySqlDataReader ler = qry.ExecuteReader();
                while (ler.Read())
                {
                    byte[] imagemBytes = ler["foto"] != DBNull.Value ? (byte[])ler["foto"] : null;
                    Animais animais = new Animais(
                    ler["cod_animal"].ToString(),
                    ler["comportamento"].ToString(),
                    ler["especie"].ToString(),
                    ler["nome"].ToString(),
                    ler["Idade"].ToString(),
                    ler["castracao"].ToString(),
                    ler["status"].ToString(),
                    ler["peso"].ToString(),
                    ler["raca"].ToString(),
                    ler["porte"].ToString(),
                    ler["sexo"].ToString(),
                    imagemBytes);
                    lista.Add(animais);
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

        public string AtualizarAnimal(Animais animais)
        {
            try
            {
                mySqlConnection.Open();
                string query = "UPDATE animal SET Comportamento = @Comportamento, Especie = @Especie,Nome = @Nome, Idade = @Idade, Castracao = @Castracao, Status = @Status, Peso = @Peso, Raca = @Raca, Porte = @Porte, Sexo = @Sexo, Foto = @Foto WHERE cod_animal = @Codigo_Animal";

                MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);

                // Atribui os parâmetros ao comando
                cmd.Parameters.AddWithValue("@Codigo_Animal", animais.CodAnimal);
                cmd.Parameters.AddWithValue("@Comportamento", animais.Comportamento);
                cmd.Parameters.AddWithValue("@Especie", animais.T_Animal);
                cmd.Parameters.AddWithValue("@Nome", animais.Nome);
                cmd.Parameters.AddWithValue("@Idade", animais.Idade);
                cmd.Parameters.AddWithValue("@Castracao", animais.Castracao);
                cmd.Parameters.AddWithValue("@Status", animais.Status);
                cmd.Parameters.AddWithValue("@Peso", animais.Peso);
                cmd.Parameters.AddWithValue("@Raca", animais.Raca);
                cmd.Parameters.AddWithValue("@Porte", animais.Porte);
                cmd.Parameters.AddWithValue("@Sexo", animais.Sexo);
                cmd.Parameters.AddWithValue("@Foto", animais.ArrayBytes);

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

        public void AlterarAnimal(string codigo_animal)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("UPDATE animal SET nome = @nome, T_Sanguinio = @T_Sanguinio, autoridade_responsavel = @autoridade_responsavel, Status = @Status WHERE Codigo_Animal = @Codigo_Animal", mySqlConnection);
                //qry.Parameters.AddWithValue("@codigo_animal", codigo_animal);
                //qry.Parameters.AddWithValue("@nome", this.nome);
                //qry.Parameters.AddWithValue("@T_Sanguinio", this.t_sanguinio);
                //qry.Parameters.AddWithValue("@Status", this.status);
                //qry.ExecuteNonQuery();
                //con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }


    }
}
