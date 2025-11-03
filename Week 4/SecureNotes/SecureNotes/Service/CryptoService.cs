using SecureNotes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecureNotes.Service
{
    public static class CryptoService
    {
        private const int KeySize = 32; // 256-bit AES
        private const int SaltSize = 16;
        private const int NonceSize = 12;
        private const int Iterations = 100000;

        public static CryptoFields Encrypt(string plaintext, string password)
        {
            CryptoFields cryptoFields = new CryptoFields();

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] nonce = RandomNumberGenerator.GetBytes(NonceSize);

            byte[] key = DeriveKey(password, salt);

            using (AesGcm aes = new AesGcm(key))
            { 
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] ciphertext = new byte[plaintextBytes.Length];
                byte[] tag = new byte[16];

                aes.Encrypt(nonce, plaintextBytes, ciphertext, tag);

                cryptoFields.Ciphertext = Convert.ToBase64String(ciphertext);
                cryptoFields.Nonce = Convert.ToBase64String(nonce);
                cryptoFields.Tag = Convert.ToBase64String(tag);
                cryptoFields.Salt = Convert.ToBase64String(salt);
            }

            return cryptoFields;
        }

        public static string Decrypt(CryptoFields cryptoFields, string password)
        {
            byte[] salt = Convert.FromBase64String(cryptoFields.Salt);
            byte[] nonce = Convert.FromBase64String(cryptoFields.Nonce);
            byte[] tag = Convert.FromBase64String(cryptoFields.Tag);
            byte[] ciphertext = Convert.FromBase64String(cryptoFields.Ciphertext);

            byte[] key = DeriveKey(password, salt);

            using (AesGcm aes = new AesGcm(key))
            {
                byte[] plaintextBytes = new byte[ciphertext.Length];
                aes.Decrypt(nonce, ciphertext, tag, plaintextBytes);
                return Encoding.UTF8.GetString(plaintextBytes);
            }
        }

        private static byte[] DeriveKey(string passphrase, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(passphrase, salt, Iterations, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(KeySize);
        }

    }
}
