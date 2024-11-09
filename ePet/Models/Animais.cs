﻿using MySql.Data.MySqlClient;
using ePet.Conexões;
using System.Globalization;
namespace ePet.Models;

public class Animais
{
    protected string nome, codigo_animal, t_animal, idade, comportamento, castracao, raca, porte, peso, status, sexo;
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
    public string Sexo { get => sexo; set => sexo = value; }
    public byte[] ArrayBytes { get => arrayBytes; set => arrayBytes = value; }


    public Animais(string codigo_animal, string t_animal, string status, string nome, string idade, string castracao, string raca, string porte, string peso, string comportamento, string sexo)
    {
        this.codigo_animal = codigo_animal;
        this.t_animal = t_animal;
        this.status = status;
        this.Nome = nome;
        this.idade = idade;
        this.castracao = castracao;
        this.raca = raca;
        this.peso = peso;
        this.comportamento = comportamento;
        this.Sexo = sexo;


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
}

