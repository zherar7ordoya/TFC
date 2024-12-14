using EntityLayer;
using System.IO;
using System.Xml.Serialization;

/*** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***
*                                                                              *
*   Dear maintainer:                                                           *
*                                                                              *
*   Once you are done trying to 'optimize' this routine, and have realized     *
*   what a terrible mistake that was, please increment the following counter   *
*   as a warning to the next guy:                                              *
*                                                                              *
*                         total_hours_wasted_here = 42                         *
*                                                                              *
*** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***/

namespace ServiceLayer
{
    /// <summary>
    /// ConfiguracionService es una clase estática que se encarga de la lectura
    /// y escritura de la configuración de la aplicación.
    /// Uso: <code>ConfigurationService.Configuracion.[Propiedad]</code>
    /// </summary>
    public static class ConfigurationService
    {
        static ConfigurationService()
        {
            Configuracion = Leer();
        }

        private static readonly string _ruta = @"Base\Configuracion.xml";

        /// <summary>
        /// Propiedad estática que contiene la configuración de la aplicación.
        /// </summary>
        public static Configuracion Configuracion { get; set; }

        //......................................................................

        /// <summary>
        /// Abre el archivo de configuración y lo deserializa.
        /// Si el archivo no existe, retorna una nueva instancia con valores por defecto.
        /// </summary>
        /// <returns></returns>
        public static Configuracion Leer()
        {
            // Retorna una nueva instancia si el archivo no existe
            if (!File.Exists(_ruta))
            {
                return new Configuracion();
            }

            var serializer = new XmlSerializer(typeof(Configuracion));

            using (var reader = new StreamReader(_ruta))
            {
                return (Configuracion)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Escribe la configuración modificada en el archivo de configuración.
        /// </summary>
        /// <param name="configuracion"></param>
        /// <returns></returns>
        public static bool Escribir(Configuracion configuracion)
        {
            if (MessageBoxService.Confirmar(
                "¿Desea guardar la configuración actual?\n" +
                "Los cambios son irreversibles y afectarán a toda la aplicación."))
            {
                // Verificar si el directorio existe y crearlo si es necesario.
                string carpeta = Path.GetDirectoryName(_ruta);

                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                var serializer = new XmlSerializer(typeof(Configuracion));

                using (var writer = new StreamWriter(_ruta))
                {
                    serializer.Serialize(writer, configuracion);
                }
                return true;
            }
            return false;
        }
    }
}
