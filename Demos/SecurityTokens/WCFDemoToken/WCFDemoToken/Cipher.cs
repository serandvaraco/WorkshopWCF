using System;
using System.Security.Cryptography;
using System.Text;

namespace WCFDemoToken
{
    public sealed class Cipher
    {
        /// <summary>
        /// Permite encriptar en algoritmo DES
        /// </summary>
        /// <param name="message">mensaje</param>
        /// <param name="key">llave</param>
        /// <returns>valor cifrado</returns>
        public static string DESEncrypt(string message, out string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            key = Convert.ToBase64String(des.Key);
            des.Mode = CipherMode.ECB;

            ICryptoTransform encryptor = des.CreateEncryptor();

            byte[] data = Encoding.Unicode.GetBytes(message);

            byte[] dataEncrypted = encryptor.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(dataEncrypted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DESDecrypt(string message, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = Convert.FromBase64String(key);
            des.Mode = CipherMode.ECB;

            ICryptoTransform decryptor = des.CreateDecryptor();

            byte[] data = Convert.FromBase64String(message);

            byte[] dataDecrypted = decryptor.TransformFinalBlock(data, 0, data.Length);

            return Encoding.Unicode.GetString(dataDecrypted);
        }

        /// <summary>
        /// permite generar llaves de seguridad
        /// </summary>
        /// <param name="algorithm">define el algoritmo</param>
        /// <param name="keySize">tamaño del algoritmo</param>
        /// <returns></returns>
        public static string GenerateKey(SymmetricAlgorithm algorithm, int keySize)
        {
            if (algorithm.ValidKeySize(keySize))
            {
                algorithm.KeySize = keySize;
                algorithm.GenerateKey();

                return Convert.ToBase64String(algorithm.Key);
            }
            else
                throw new ArgumentException("Tamaño de Llave Invalido");
        }

        /// <summary>
        /// permite cifrar el contenido
        /// </summary>
        /// <param name="message">mensaje a recibir</param>
        /// <param name="algorithm">algoritmo a usar</param>
        /// <param name="key">llave para cifrar y resolver</param>
        /// <returns>contenido cifrado</returns>
        public static string Encrypt(string message, SymmetricAlgorithm algorithm, string key)
        {
            algorithm.Key = Convert.FromBase64String(key);
            algorithm.Mode = CipherMode.ECB;

            ICryptoTransform encryptor = algorithm.CreateEncryptor();

            byte[] data = Encoding.Unicode.GetBytes(message);

            byte[] dataEncrypted = encryptor.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(dataEncrypted);
        }

        public static string Decrypt(string message, SymmetricAlgorithm algorithm, string key)
        {
            algorithm.Key = Convert.FromBase64String(key);
            algorithm.Mode = CipherMode.ECB;

            ICryptoTransform decryptor = algorithm.CreateDecryptor();

            try
            {
                byte[] data = Convert.FromBase64String(message);

                byte[] dataDecrypted = decryptor.TransformFinalBlock(data, 0, data.Length);

                return Encoding.Unicode.GetString(dataDecrypted);
            }
            catch { return string.Empty; }

        }

        /// <summary>
        /// Permite generar un hash basado en sha256
        /// </summary>
        /// <param name="message">valor a cifrar</param>
        /// <returns>hash retornado</returns>
        public string GenerateHashSHA(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
                hashString += String.Format("{0:x2}", x);
            return hashString;
        }

        /// <summary>
        /// Permite codificar a Base64
        /// </summary>
        /// <param name="plainText">recibe el texto a codificar a base64</param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        /// <summary>
        /// Permite decodificar a base64
        /// </summary>
        /// <param name="base64EncodedData">texto codificado en base 64</param>
        /// <returns></returns>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}