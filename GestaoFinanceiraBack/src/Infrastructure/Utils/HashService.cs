using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Utils
{
    public class HashService
    {
        private static readonly int KeySize = 256;
        private static readonly int BlockSize = 128;

        public static string Encrypt(string textToEncrypt, IConfiguration configuration)
        {
            var key =
                Environment.GetEnvironmentVariable("HASH_KEY") ??
                configuration["Hash:Key"] ??
                "H9FfKD9B4pBl5U5KefxPfWcdB8Z6Vc8JCHQ2IzOgQxI=";

            using Aes aesAlg = Aes.Create();

            aesAlg.Key = DeriveKey(key, KeySize / 8);
            aesAlg.IV = DeriveKey(key, BlockSize / 8);

            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                swEncrypt.Write(textToEncrypt);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string Decrypt(string textToDecrypt, IConfiguration configuration)
        {
            var key =
                Environment.GetEnvironmentVariable("HASH_KEY") ??
                configuration["Hash:Key"] ??
                "H9FfKD9B4pBl5U5KefxPfWcdB8Z6Vc8JCHQ2IzOgQxI=";

            using Aes aesAlg = Aes.Create();

            aesAlg.Key = DeriveKey(key, KeySize / 8);
            aesAlg.IV = DeriveKey(key, BlockSize / 8);

            using MemoryStream msDecrypt = new(Convert.FromBase64String(textToDecrypt));
            using CryptoStream csDecrypt = new(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);

            return srDecrypt.ReadToEnd();
        }

        private static byte[] DeriveKey(string key, int size)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] hash = SHA256.HashData(keyBytes);

            Array.Resize(ref hash, size);

            return hash;
        }
    }
}