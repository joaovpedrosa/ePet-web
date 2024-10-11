using MySql.Data.MySqlClient;
using ePet.Conexões;
using System.Globalization;
namespace ePet.Models;

public class Animais
{
    protected string nome, codigo_animal, t_animal, idade, comportamento, castracao, raca, porte, peso,  status, autoridade_responsavel;
    static MySqlConnection con = ConectarMySql.getConexao();
    private byte[] arrayBytes;


    public string Nome { get => nome; set => nome = value; }
    public string CodAnimal { get => codigo_animal; set => codigo_animal = value; }
    public string T_Animal { get => t_animal; set => t_animal = value; }
    public string Idade { get => idade; set => idade = value; }
    public string Comportamento { get => comportamento; set => comportamento = value; }
    public string Castracao { get => castracao; set => castracao = value; }
    public string Raca { get => raca; set => raca = value; }
    public string Porte { get => porte; set => porte = value; }
    public string Peso { get => peso; set => peso = value; }
    public string Status { get => status; set => status = value; }
    public string Autoridade_Responsavel { get => autoridade_responsavel; set => autoridade_responsavel = value; }
    public byte[] ArrayBytes { get => arrayBytes; set => arrayBytes = value; }


    public Animais(string codigo_animal, string t_animal, string status, string autoridade_Responsavel, string nome, string idade, string castracao, string raca, string porte, string peso, string comportamento )
    {
        this.codigo_animal = codigo_animal;
        this.t_animal = t_animal;
        this.status = status;
        this.autoridade_responsavel = autoridade_Responsavel;
        this.Nome = nome;
        this.idade = idade;
        this.castracao = castracao;
        this.raca = raca;
        this.peso = peso;
        this.comportamento = comportamento;       
    }

    //construtor só com o cod
    public Animais(string codigo_animal)
    {
        this.codigo_animal = codigo_animal;
    }

    public static string ConexaoAnimal()
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

    public string CadastrarAnimal(IFormFile imagem)
    {
        try
        {
            con.Open();
            MySqlCommand qry = new MySqlCommand("INSERT INTO animal (Idade, Comportamento, Especie, foto, Nome, cod_Animal, Castracao, status,autoridade_responsavel, Peso, Raca, Porte) VALUES (@Idade, @Comportamento, @Especie, @foto, @Nome, @cod_Animal, @Castracao, @status, @email, @Peso, @Raca, @Porte)", con);

            // Adicionando os parâmetros na ordem correta
            qry.Parameters.AddWithValue("@Idade", this.idade);
            qry.Parameters.AddWithValue("@Comportamento", this.comportamento);
            qry.Parameters.AddWithValue("@Especie", this.t_animal);
            byte[] imagemAnimal = ConverterImagem(imagem);
            qry.Parameters.AddWithValue("@foto", imagemAnimal);
            qry.Parameters.AddWithValue("@Nome", this.nome);
            qry.Parameters.AddWithValue("@cod_Animal", this.codigo_animal);
            qry.Parameters.AddWithValue("@Castracao", this.castracao);
            qry.Parameters.AddWithValue("@status", this.status);
            qry.Parameters.AddWithValue("@email", this.autoridade_responsavel);
            qry.Parameters.AddWithValue("@Peso", this.peso);
            qry.Parameters.AddWithValue("@Raca", this.raca);
            qry.Parameters.AddWithValue("@Porte", this.porte);

            qry.ExecuteNonQuery();
            con.Close();
        }

        catch (Exception ex)
        {
            return "Erro: " + ex.Message;
        }
        return "Inserido com sucesso!";
    }

    //Metodo que adiciona uma imagem ao banco de dados
    public byte[] ConverterImagem(IFormFile arq)
    {
        //Descobre qual o tipo de arquivo foi enviado
        String tipoArquivo = arq.ContentType;

        if (tipoArquivo.Contains("image")) //Vê se o arquivo enviado é uma imagem
        {
            MemoryStream s = new MemoryStream();
            arq.CopyTo(s);
            byte[] bytesArquivo = s.ToArray(); //Transforma o arquivo em uma sequencia de bytes para enviar ao banco
            return bytesArquivo;
        }
        else
        {
            return null;
        }

    }
    public string DeletarAnimal()
    {
        try
        {
            con.Open();
            MySqlCommand qry = new MySqlCommand("DELETE FROM animal WHERE Codigo_Animal = @Codigo_Animal", con);
            qry.Parameters.AddWithValue("@Codigo_Animal", codigo_animal);
            qry.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            return "Erro: " + ex.Message;
        }
        return "Excluido com sucesso!";
    }

    public  Animais BuscarAnimal(string codigo_animal)
    {
        Animais resultado = null;
        try
        {
            con.Open();
            MySqlCommand qry = new MySqlCommand("SELECT * FROM animal WHERE Codigo_Animal = @Codigo_Animal", con);
            qry.Parameters.AddWithValue("@Codigo_Animal", codigo_animal);
            MySqlDataReader leitor = qry.ExecuteReader();
            while (leitor.Read())
            {
                resultado = new Animais(
                    leitor["Idade"].ToString(),
                    leitor["comportamento"].ToString(),
                    leitor["especie"].ToString(),
                    leitor["nome"].ToString(),
                    leitor["codigo_animal"].ToString(),
                    leitor["castracao"].ToString(),
                    leitor["status "].ToString(),
                    leitor["autoridade_responsavel"].ToString(),
                    leitor["peso"].ToString(),
                    leitor["raca"].ToString(),
                    leitor["porte"].ToString());
            }
            con.Close();

        }
        catch (Exception ex)
        {
            return null;
        }
        return resultado;
    }

    public static List<Animais> ListarAnimal()
    {
        List<Animais> lista = new List<Animais>();
        try
        {
            con.Open();
            MySqlCommand qry = new MySqlCommand("SELECT * FROM animal", con);
            MySqlDataReader ler = qry.ExecuteReader();
            while (ler.Read())
            {
                //Animais linha = new Animais(
                //ler["nome"].ToString(),
                //ler["codigo_animal"].ToString(),
                //ler["t_animal"].ToString(),
                //ler["t_sanguinio"].ToString(),
                //ler["status"].ToString(),
                //ler["autoridade_responsavel"].ToString());

                //lista.Add(linha);
            }
            con.Close();
        }
        catch (Exception ex)
        {
            return null;
        }
        return lista;
    }

    public void AlterarAnimal(string codigo_animal)
    {
        try
        {
            con.Open();
            MySqlCommand qry = new MySqlCommand("UPDATE animal SET nome = @nome, T_Sanguinio = @T_Sanguinio, autoridade_responsavel = @autoridade_responsavel, Status = @Status WHERE Codigo_Animal = @Codigo_Animal", con);
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

