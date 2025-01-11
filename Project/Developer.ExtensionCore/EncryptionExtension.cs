using System;
using System.Security.Cryptography;
using System.Text;

namespace Developer.ExtensionCore
{
    public static class EncryptionExtension
    {
        public static string Encrypt(string key, string text)
        {
            byte[] result;
            UTF8Encoding utf8 = new UTF8Encoding();

            using (TripleDESCryptoServiceProvider provider = ReturnProvider(key))
            {

                byte[] givenToEncrypt = utf8.GetBytes(text);
                using (ICryptoTransform cryptoTransf = provider.CreateEncryptor())
                {
                    result = cryptoTransf.TransformFinalBlock(givenToEncrypt, 0, givenToEncrypt.Length);
                }
            }

            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string key, string text)
        {
            byte[] result;
            UTF8Encoding utf8 = new UTF8Encoding();

            using (TripleDESCryptoServiceProvider provider = ReturnProvider(key))
            {
                byte[] givenToDecrypt = Convert.FromBase64String(text);
                using (ICryptoTransform cryptoTransf = provider.CreateDecryptor())
                {
                    result = cryptoTransf.TransformFinalBlock(givenToDecrypt, 0, givenToDecrypt.Length);
                }
            }

            return utf8.GetString(result);
        }

        private static TripleDESCryptoServiceProvider ReturnProvider(string key)
        {
            using (var hashProvider = new MD5CryptoServiceProvider())
            {
                var provider = new TripleDESCryptoServiceProvider
                {
                    Key = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(key)),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                return provider;
            }
        }
    }
}
