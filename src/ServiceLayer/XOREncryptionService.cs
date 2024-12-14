using System;
using System.Text;

namespace ServiceLayer
{
    /// <summary>
    /// Servicio que implementa la encriptación y desencriptación XOR de contraseñas.
    /// </summary>
    public static class XOREncryptionService
    {
        //private static readonly byte Clave = 0xAA; // Clave simple para XOR
        private static readonly byte Clave = ConfigurationService.Configuracion.ContraseñaClaveXOR;

        //......................................................................

        /// <summary>
        /// Encriptar usando XOR (también planteado como método de extensión).
        /// </summary>
        /// <param name="textoPlano">Cadena sin encriptar.</param>
        /// <returns>Cadena encriptada.</returns>
        public static string Encriptar(this string textoPlano)
        {
            byte[] textoBytes = Encoding.UTF8.GetBytes(textoPlano);
            byte[] resultado = new byte[textoBytes.Length];

            for (int i = 0; i < textoBytes.Length; i++)
            {
                resultado[i] = (byte)(textoBytes[i] ^ Clave);
            }

            // Codificar el resultado en Base64 para almacenamiento
            return Convert.ToBase64String(resultado);
        }

        /// <summary>
        /// Desencriptar usando XOR (también planteado como método de extensión).
        /// </summary>
        /// <param name="textoEncriptado">Cadena encriptada.</param>
        /// <returns>Cadena desencriptada.</returns>
        public static string Desencriptar(this string textoEncriptado)
        {
            byte[] textoBytes = Convert.FromBase64String(textoEncriptado);
            byte[] resultado = new byte[textoBytes.Length];

            for (int i = 0; i < textoBytes.Length; i++)
            {
                resultado[i] = (byte)(textoBytes[i] ^ Clave);
            }

            return Encoding.UTF8.GetString(resultado);
        }
    }
}