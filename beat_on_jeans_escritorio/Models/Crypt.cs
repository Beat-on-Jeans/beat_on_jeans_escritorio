using System;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;

namespace beat_on_jeans_escritorio.Models
{
    public class BlowfishEncryptor
    {
        // Clave secreta para el cifrado: = "keuh10lt14bbeuc2"
        private readonly string secretKey; 

        public BlowfishEncryptor(string key)
        {
            secretKey = key;
        }

        public string EncryptPassword(string password)
        {
            // Configurar el motor Blowfish
            var engine = new BlowfishEngine();
            var blockCipher = new PaddedBufferedBlockCipher(engine, new Pkcs7Padding());

            // Convertir la clave a bytes
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            blockCipher.Init(true, new KeyParameter(keyBytes));

            // Convertir la contraseña a bytes
            var inputBytes = Encoding.UTF8.GetBytes(password);

            // Preparar el buffer de salida
            var outputBytes = new byte[blockCipher.GetOutputSize(inputBytes.Length)];

            // Procesar los bytes
            int length = blockCipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
            length += blockCipher.DoFinal(outputBytes, length);

            // Convertir a Base64 y devolver
            return Convert.ToBase64String(outputBytes, 0, length);
        }

        public string DecryptPassword(string encryptedPassword)
        {
            try
            {
                var engine = new BlowfishEngine();
                var blockCipher = new PaddedBufferedBlockCipher(engine, new Pkcs7Padding());

                var keyBytes = Encoding.UTF8.GetBytes(secretKey);
                blockCipher.Init(false, new KeyParameter(keyBytes));

                var inputBytes = Convert.FromBase64String(encryptedPassword);
                var outputBytes = new byte[blockCipher.GetOutputSize(inputBytes.Length)];

                int length = blockCipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
                length += blockCipher.DoFinal(outputBytes, length);

                return Encoding.UTF8.GetString(outputBytes, 0, length);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desencriptar la contraseña", ex);
            }
        }
    }
}
