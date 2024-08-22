using System;
using ePet.Models;
using MySql.Data.MySqlClient;

namespace ePet.Conexões
{
    public class ConectarMySql
    {
        static string conexao = "cc";

        public static MySqlConnection getConexao()
        {
            return new MySqlConnection(
                Configuration().GetConnectionString("Default"));

            //Casa
            //Default
        }

        private static IConfigurationRoot Configuration()
        {
            IConfigurationBuilder builder =
                new ConfigurationBuilder().SetBasePath(
                    Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            return builder.Build();
        }
    }
}

