using System.IO;


namespace ServiceLayer
{
    /// <summary>
    /// Gestiona las banderas de inicio y finalización de la aplicación.
    /// </summary>
    public static class FlagService
    {
        private static readonly string _carpetaBase = ConfigurationService.Configuracion.CarpetaBase;

        //......................................................................

        /// <summary>
        /// Lee el valor de una bandera.
        /// </summary>
        /// <param name="archivo">Archivo a leer.</param>
        /// <returns></returns>
        public static bool LeerFlag(string archivo)
        {
            // Crear la ruta completa del archivo
            string ruta = Path.Combine(_carpetaBase, archivo);

            // Verificar si el archivo existe y leer el valor
            if (!File.Exists(ruta)) return false;

            string flag = File.ReadAllText(ruta);
            return flag == "1";
        }

        /// <summary>
        /// Escribe el valor de una bandera.
        /// </summary>
        /// <param name="archivo">Archivo a escribir.</param>
        /// <param name="bandera">Flag (bandera) a escribir.</param>
        /// <returns></returns>
        public static bool EscribirFlag(string archivo, bool bandera)
        {
            // Asegurarse de que la carpeta base existe
            if (!Directory.Exists(_carpetaBase))
            {
                Directory.CreateDirectory(_carpetaBase);
            }

            // Crear la ruta completa del archivo
            string ruta = Path.Combine(_carpetaBase, archivo);

            // Escribir el valor en el archivo
            File.WriteAllText(ruta, bandera ? "1" : "0");

            return true;
        }
    }
}
