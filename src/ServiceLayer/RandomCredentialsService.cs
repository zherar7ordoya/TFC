using System;
using System.Data;
using System.Linq;

namespace ServiceLayer
{
    /// <summary>Genera credenciales aleatorias para usuarios.</summary>
    public static class RandomCredentialsService
    {
        private const string Mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Minusculas = "abcdefghijklmnopqrstuvwxyz";
        private const string Digitos = "0123456789";
        
        /// <summary>
        /// El contenido de esta cadena debe coincidir con la propiedad ContraseñaRegEx de Configuracion.
        /// </summary>
        private const string Especiales = "@$!%*?&";

        /// <summary>
        /// Genera un usuario aleatorio.
        /// </summary>
        /// <param name="longitud">Largo de la cadena a retornar.</param>
        /// <returns></returns>
        public static string GenerarUsuario(int longitud = 8)
        {
            string caracteres = Minusculas + Digitos;
            Random aleatorio = new Random();

            char[] usuario = new char[longitud];
            usuario[0] = Minusculas[aleatorio.Next(Minusculas.Length)];
            usuario[1] = Digitos[aleatorio.Next(Digitos.Length)]; // x será 2

            // Comienza en 2 para que exista al menos un caracter de cada tipo.
            for (int i = 2; i < longitud; i++)
            {
                usuario[i] = caracteres[aleatorio.Next(caracteres.Length)];
            }

            return new string(usuario);
        }

        /// <summary>
        /// Genera (aleatoriamente) una contraseña o una palabra secreta.
        /// </summary>
        /// <param name="longitud">Largo de la cadena a retornar.</param>
        /// <returns></returns>
        public static string GenerarContraseña(int longitud = 8)
        {
            string caracteres = Mayusculas + Minusculas + Digitos + Especiales;
            Random aleatorio = new Random();

            char[] contraseña = new char[longitud];

            contraseña[0] = Mayusculas[aleatorio.Next(Mayusculas.Length)];
            contraseña[1] = Minusculas[aleatorio.Next(Minusculas.Length)];
            contraseña[2] = Digitos[aleatorio.Next(Digitos.Length)];
            contraseña[3] = Especiales[aleatorio.Next(Especiales.Length)]; // x será 4

            // Comienza en 4 para que exista al menos un caracter de cada tipo.
            for (int x = 4; x < longitud; x++)
            {
                contraseña[x] = caracteres[aleatorio.Next(caracteres.Length)];
            }

            return new string(contraseña.OrderBy(x => aleatorio.Next()).ToArray());
        }

        /// <summary>
        /// Genera una palabra secreta aleatoria.
        /// </summary>
        /// <param name="longitud"></param>
        /// <returns></returns>
        public static string GenerarPalabraSecreta(int longitud = 8)
        {
            string caracteres = Mayusculas + Minusculas + Digitos;
            Random aleatorio = new Random();

            char[] palabraSecreta = new char[longitud];

            palabraSecreta[0] = Mayusculas[aleatorio.Next(Mayusculas.Length)];
            palabraSecreta[1] = Minusculas[aleatorio.Next(Minusculas.Length)];
            palabraSecreta[2] = Digitos[aleatorio.Next(Digitos.Length)]; // x será 3

            // Comienza en 3 para que exista al menos un caracter de cada tipo.
            for (int x = 3; x < longitud; x++)
            {
                palabraSecreta[x] = caracteres[aleatorio.Next(caracteres.Length)];
            }

            return new string(palabraSecreta.OrderBy(x => aleatorio.Next()).ToArray());
        }
    }
}
