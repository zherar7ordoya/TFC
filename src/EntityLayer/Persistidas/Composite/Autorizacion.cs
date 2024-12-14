using AbstractLayer;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace EntityLayer
{
    /// <summary>
    /// Implementa el patrón Composite para la gestión de permisos.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Rol))]
    [XmlInclude(typeof(Permiso))]
    public abstract class Autorizacion : EntidadPersistente
    {
        /// <summary>
        /// Descripción de la autorización.
        /// </summary>
        [Required(ErrorMessage = "La descripción no puede estar vacía.")]
        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres.")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene los permisos de la autorización.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<Autorizacion> ObtenerPermisos();
    }
}
