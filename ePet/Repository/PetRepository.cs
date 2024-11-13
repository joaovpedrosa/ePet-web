﻿using ePet.Conexões;
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
                MySqlCommand qry = new MySqlCommand("DELETE FROM animal WHERE Codigo_Animal = @Codigo_Animal", mySqlConnection);
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
        public Animais BuscarAnimal(string codigo_animal)
        {
            Animais resultado = null;
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM animal WHERE Codigo_Animal = @Codigo_Animal", mySqlConnection);
                qry.Parameters.AddWithValue("@Codigo_Animal", codigo_animal);
                MySqlDataReader leitor = qry.ExecuteReader();
                while (leitor.Read())
                {
                    //resultado = new Animais(
                    //    leitor["Idade"].ToString(),
                    //    leitor["comportamento"].ToString(),
                    //    leitor["especie"].ToString(),
                    //    leitor["nome"].ToString(),
                    //    leitor["codigo_animal"].ToString(),
                    //    leitor["castracao"].ToString(),
                    //    leitor["status "].ToString(),
                    //    leitor["peso"].ToString(),
                    //    leitor["raca"].ToString(),
                    //    leitor["porte"].ToString(),
                    //    leitor["sexo"].ToString());

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
                    ler["Idade"].ToString(),
                    ler["comportamento"].ToString(),
                    ler["especie"].ToString(),
                    ler["nome"].ToString(),
                    ler["cod_animal"].ToString(),
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
