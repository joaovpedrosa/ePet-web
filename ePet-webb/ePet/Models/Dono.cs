using MySql.Data.MySqlClient;
using ePet.Conexões;
namespace ePet.Models
{
    public class Dono
    {
        static string conexao = "Server=ESN509VMYSQL;Database=epet2;User id=aluno;Password=Senai1234;";
        protected string nome, cod_dono, cpf, telefone;

        public string Nome { get => nome; set => nome = value; }
        public string Cod_Dono { get => cod_dono; set => cod_dono = value; }
        public string CPF { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }

        public Dono(string nome, string cod_dono, string cpf, string telefone)
        {
            this.nome = nome;
            this.cod_dono = cod_dono;
            this.cpf = cpf;
            this.telefone = telefone;
        }

        public static string ConexaoOcorrencias()
        {
            //Adicionar no BD
            MySqlConnection con = new MySqlConnection(conexao);
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

        public string CadastrarDono()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO ocorrencia VALUES (@Nome, @Codigo_Dono, @CPF, @Telefone)", con);
                qry.Parameters.AddWithValue("@Nome", nome);
                qry.Parameters.AddWithValue("@Codigo_Dono", cod_dono);
                qry.Parameters.AddWithValue("@CPF", cpf);
                qry.Parameters.AddWithValue("@Telefone", telefone);
                qry.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            return "Inserido com sucesso!";
        }

        public string DeletarDono()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("DELETE FROM Dono WHERE Codigo_Dono = @Codigo_Dono", con);
                qry.Parameters.AddWithValue("@Codigo_Dono", cod_dono);
                qry.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            return "Excluido com sucesso!";
        }

        public static Dono BuscaroDono(string cod_dono)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            Dono resultado = null;
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM Dono WHERE cod_dono = @Codigo_Dono", con);
                qry.Parameters.AddWithValue("@Codigo_Dono", cod_dono);
                MySqlDataReader leitor = qry.ExecuteReader();
                if (leitor.Read())
                {
                    resultado = new Dono(
                         leitor["nome"].ToString(),
                        leitor["cod_dono"].ToString(),
                        leitor["cpf"].ToString(),
                        leitor["telefone"].ToString());
            
                }
                con.Close();

            }
            catch (Exception ex)
            {
                return null;
            }
            return resultado;
        }
    }
}
/* leitor["cod_ocorrencia"].ToString(),
                 leitor["data"].ToString(),
                 leitor["descricao"].ToString(),
                 leitor["lugar"].ToString(),
                 leitor["CPF"].ToString(),
                 leitor["Numero_ID"].ToString());*/
