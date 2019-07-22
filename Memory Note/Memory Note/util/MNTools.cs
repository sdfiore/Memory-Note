using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Memory_Note.util
{
    /// <summary>
    /// Contains the functionality for the "Tools" MenuItem
    /// </summary>
    internal class MNTools
    {
        private static string password;

        /// <summary>
        /// Creates a password that is used for encryptFile and decryptFile
        /// </summary>
        public MNTools()
        {
            password = "$#d3m8g03x>()";
        }

        /// <summary>
        /// Encryption algorithm used in EncryptFile.
        /// </summary>
        /// <param name="bytesToBeEncrypted"></param>
        /// <param name="passwordBytes"></param>
        /// <returns>encryptedBytes</returns>
        private byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        /// <summary>
        /// Decryption algorithm used in DecryptFile.
        /// </summary>
        /// <param name="bytesToBeDecrypted"></param>
        /// <param name="passwordBytes"></param>
        /// <returns>decryptedBytes</returns>
        private byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }

        /// <summary>
        /// Encrypts a given file.
        /// </summary>
        /// <param name="filename">The file that is encrypted.</param>
        public void EncryptFile(string filename)
        {
            byte[] bytesToBeEncrypted = File.ReadAllBytes(filename);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
            File.WriteAllBytes(filename, bytesEncrypted);   // This is where the file encryption occurs.
        }

        /// <summary>
        /// Decrypts a given file.
        /// </summary>
        /// <param name="filename">The file that is decrypted.</param>
        public void DecryptFile(string filename)
        {
            byte[] bytesToBeDecrypted = File.ReadAllBytes(filename);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            File.WriteAllBytes(filename, bytesDecrypted);   // This is where the file decryption occurs.
        }
    }
}
