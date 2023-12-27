using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace SensitiveData.CTF.BlackBox
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if(args.Length != 2)
            {
                Console.WriteLine("-url [url]");
                Environment.Exit(0);
            }
            string body = EncryptString(CreateRequest(), "75b7391b2cbade4fe8bbb1e292167db5");
            HttpClient client = new HttpClient();
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            request.Headers.Add("Authentication", "CTF2023");
            HttpResponseMessage response = await client.PostAsync(args[1], request);
            await Console.Out.WriteLineAsync(response.StatusCode + " " + await response.Content.ReadAsStringAsync());
        }

        public static string EncryptString(string text, string keyString)
        {
            byte[] key = Encoding.UTF8.GetBytes(keyString);
            using (Aes aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        byte[] iv = aesAlg.IV;
                        byte[] decryptedContent = msEncrypt.ToArray();
                        byte[] result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string  CreateRequest()
        {
            return System.Text.Json.JsonSerializer.Serialize(new 
            {
                email = new 
                {
                  value = "john.doe@bamboopayment.com" 
                },
                pan = new
                {
                  value = "4456530000100001"
                },
                cvv = new 
                {
                  value = "512"
                },
                expiration = new 
                {
                  value = "10/25"
                },
                cardOwner = new
                {
                  name = "John Doe"
                }
            });
        }
    }
}