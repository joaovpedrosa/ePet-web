﻿using ePet.Conexões;
using ePet.Models;
using MySql.Data.MySqlClient;
using System;

namespace ePet.Repository
{
    public class DenunciarRepository
    {
        private readonly MySqlConnection mySqlConnection;

        public DenunciarRepository()
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

        public string DenunciarAbandono(Denunciar denunciar)
        {
            try
            {
                mySqlConnection.Open();

                // Comando SQL de inserção, com parâmetros para os dados
                MySqlCommand qry = new MySqlCommand(
                    "INSERT INTO denuncia (Descricao, Cidade, Bairro, Rua, Complemento) " +
                    "VALUES (@Descricao, @Cidade, @Bairro, @Rua, @Complemento)", mySqlConnection
                );

                // Adiciona os valores das propriedades do modelo 'Denunciar' como parâmetros
                qry.Parameters.AddWithValue("@Descricao", denunciar.Descricao);
                qry.Parameters.AddWithValue("@Cidade", denunciar.Cidade);
                qry.Parameters.AddWithValue("@Bairro", denunciar.Bairro);
                qry.Parameters.AddWithValue("@Rua", denunciar.Rua);
                qry.Parameters.AddWithValue("@Complemento", denunciar.Complemento);

                // Executa a query no banco
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
    }
}
