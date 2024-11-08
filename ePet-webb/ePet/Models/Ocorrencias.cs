using MySql.Data.MySqlClient;

namespace ePet.Models
{
    public class Ocorrencias
    {
        static string conexao = "Server=ESN509VMYSQL;Database=epet2;User id=aluno;Password=Senai1234;";
        protected string cod_ocorrencia, data, descricao, lugar, cpf, numero_id;

        public string CodOcorrencia { get => cod_ocorrencia; set => cod_ocorrencia = value; }
        public string Data { get => data; set => data = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public string CPF { get => cpf; set => cpf = value; }
        public string Numero_ID { get => numero_id; set => numero_id = value; }

        public Ocorrencias(string cod_ocorrencia, string data, string descricao, string lugar, string cpf, string numero_id)
        {
            this.cod_ocorrencia = cod_ocorrencia;
            this.data = data;
            this.descricao = descricao;
            this.lugar = lugar;
            this.cpf = cpf;
            this.numero_id = numero_id;
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

        public string CadastrarOcorrencia()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("INSERT INTO ocorrencia VALUES (@Cod_Ocorrencia, @Data, @Descricao, @Lugar, @CPF, @Numero_ID)", con);
                qry.Parameters.AddWithValue("@Cod_Ocorrencia", cod_ocorrencia);
                qry.Parameters.AddWithValue("@Data", data);
                qry.Parameters.AddWithValue("@Descricao", descricao);
                qry.Parameters.AddWithValue("@Lugar", lugar);
                qry.Parameters.AddWithValue("@CPF", cpf);
                qry.Parameters.AddWithValue("@Numero_ID", numero_id);
                qry.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            return "Inserido com sucesso!";
        }

        public string DeletarOcorrencia()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("DELETE FROM ocorrencia WHERE Cod_Ocorrencia = @Cod_Ocorrencia", con);
                qry.Parameters.AddWithValue("@Cod_Ocorrencia", cod_ocorrencia);
                qry.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
            return "Excluido com sucesso!";
        }

        public static Ocorrencias BuscarOcorrencia(string cod_ocorrencia)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            Ocorrencias resultado = null;
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM ocorrencia WHERE Cod_Ocorrencia = @Cod_Ocorrencia", con);
                qry.Parameters.AddWithValue("@Cod_Ocorrencia", cod_ocorrencia);
                MySqlDataReader leitor = qry.ExecuteReader();
                if (leitor.Read())
                {
                    resultado = new Ocorrencias(
                        leitor["cod_ocorrencia"].ToString(),
                        leitor["data"].ToString(),
                        leitor["descricao"].ToString(),
                        leitor["lugar"].ToString(),
                        leitor["CPF"].ToString(),
                        leitor["Numero_ID"].ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                return null;
            }
            return resultado;
        }

        public static List<Ocorrencias> ListarOcorrencia()
        {
            List<Ocorrencias> lista = new List<Ocorrencias>();
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand("SELECT * FROM ocorrencia", con);
                MySqlDataReader ler = qry.ExecuteReader();
                while (ler.Read())
                {
                    Ocorrencias linha = new Ocorrencias(
                        ler["cod_ocorrencia"].ToString(),
                        ler["data"].ToString(),
                        ler["descricao"].ToString(),
                        ler["lugar"].ToString(),
                        ler["cpf"].ToString(),
                        ler["numero_id"].ToString());

                    lista.Add(linha);
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
            return lista;
        }
    }
}
