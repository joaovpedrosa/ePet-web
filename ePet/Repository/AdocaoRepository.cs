using ePet.Conexões;
using ePet.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ePet.Repository
{
    public class AdocaoRepository
    {

        private readonly MySqlConnection mySqlConnection;

        public AdocaoRepository()
        {
            this.mySqlConnection = ConectarMySql.getConexao();
        }

        public List<Adocao> ListaAdocao()
        {
            List<Adocao> lista = new List<Adocao>();

            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM adocao", mySqlConnection);
                MySqlDataReader ler = qry.ExecuteReader();
                while (ler.Read())
                {
                    Adocao adocao = new Adocao(
                        ler["Cod_Animal"].ToString(),
                        ler["Cpf"].ToString(),
                        ler["CodigoAdo"].ToString());
                    lista.Add(adocao);
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

        public string DeletarAdocao(string codigoAdo)
        {
            try
            {
                mySqlConnection.Open();
                MySqlCommand qry = new MySqlCommand("DELETE FROM adocao WHERE CodigoADO = @CodigoAdo", mySqlConnection);
                qry.Parameters.AddWithValue("@CodigoAdo", codigoAdo);
                qry.ExecuteNonQuery();
                return "Excluído com sucesso!";
            }
            catch (MySqlException ex)
            {
                return "Erro ao excluir: " + ex.Message;
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

    }
}
