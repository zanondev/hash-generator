using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace UniqueKeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite seu nome: ");
                string nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome))
                {
                    Console.WriteLine("O nome não pode estar vazio.");
                    return;
                }

                Console.WriteLine("Digite seu sobrenome: ");
                string sobrenome = Console.ReadLine();
                if (string.IsNullOrEmpty(sobrenome))
                {
                    Console.WriteLine("O sobrenome não pode estar vazio.");
                    return;
                }

                string chaveUnica = GerarChaveUnica(nome, sobrenome);

                Console.WriteLine($"Sua chave única é: {chaveUnica}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        private static string GerarChaveUnica(string nome, string sobrenome)
        {
            string conteudo = nome + sobrenome;
            string chaveUnica = CreateHash(conteudo);

            return chaveUnica;
        }

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
