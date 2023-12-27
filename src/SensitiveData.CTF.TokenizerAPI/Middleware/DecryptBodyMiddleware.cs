using System.Security.Cryptography;
using System.Text;

namespace SensitiveData.CTF.TokenizerAPI.Middleware
{
    public class DecryptBodyMiddleware
    {

        private readonly RequestDelegate _next;
        public DecryptBodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string encryptedBody = await GetBodyAsync(context);
            string decryptedBody = DecryptString(encryptedBody);
            using (var memStream = new MemoryStream(Encoding.UTF8.GetBytes(decryptedBody)))
            {
                context.Request.Body = memStream;
                memStream.Position = 0;
                await _next(context);
            }
        }
        private async Task<string> GetBodyAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            using var reader = new StreamReader(
                context.Request.Body,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true);
            return await reader.ReadToEndAsync();
        }
        public static string DecryptString(string cipherText, string keyString = "75b7391b2cbade4fe8bbb1e292167db5")
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);

            byte[] iv = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            byte[] key = Encoding.UTF8.GetBytes(keyString);

            using (Aes aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }    
    }
}
