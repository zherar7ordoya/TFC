using AbstractLayer;
using System;
using System.Collections.Generic;

namespace EntityLayer
{
    /// <summary>
    /// Leaf del Composite Pattern para la gestión de permisos.
    /// </summary>
    [Serializable]
    public class Permiso : Autorizacion
    {
        /// <summary>
        /// Enumerado que define el tipo de permiso.
        /// </summary>
        public PermisoEnum Tipo { get; set; }

        /// <summary>
        /// Implementación del método abstracto de la clase base para obtener los permisos.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Autorizacion> ObtenerPermisos() => new[] { this };
    }
}
