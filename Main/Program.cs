using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Net;

namespace UniqueKeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite seu nome: ");
                // Padrão de variavel camel case
                string userName = Console.ReadLine();

                if (string.IsNullOrEmpty(userName))
                {
                    Console.WriteLine("O nome não pode estar vazio.");
                    return;
                }

                Console.WriteLine("Digite seu sobrenome: ");
                string userNickname = Console.ReadLine();

                if (string.IsNullOrEmpty(userNickname))
                {
                    Console.WriteLine("O sobrenome não pode estar vazio.");
                    return;
                }

                // Mecanismo para as labels de início e fim da rotina
                Console.WriteLine("Iniciando geração de chave única");
                string singleKey = GenerateSingleKey(userName, userNickname);
                Console.WriteLine("Geração de chave única finalizada");

                Console.WriteLine($"Sua chave única é: {singleKey}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        private static string GenerateSingleKey(string userName, string userNickname)
        {
            string content = userName + userNickname;
            string singleKey = CreateHash(content);

            return singleKey;
        }

        // Tamanho único para indentação 
        public static string CreateHash(string content)
        {
            using (var md5HashAlgorithm = SHA512.Create())
            {
                var contentBytes = Encoding.UTF8.GetBytes(content);
                var hashBytes = md5HashAlgorithm.ComputeHash(contentBytes);
                var hashString = string.Concat(hashBytes.Select(b => b.ToString("x2")));

                return hashString;
            }
        }
    }
}
