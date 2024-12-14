using AbstractLayer;

using System;

namespace EntityLayer
{
    /// <summary>
    /// ConfigurationService.
    /// </summary>
    [Serializable]
    public class Archivo : EntidadPersistente
    {
        /// <summary>
        /// Fecha en la que se genera el hash del archivo.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Nombre del archivo del cual se genera el hash.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Hash del archivo.
        /// </summary>
        public string Hash { get; set; }
    }
}
