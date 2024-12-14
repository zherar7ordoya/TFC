using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EntityLayer
{
    /// <summary>
    /// Composite del Composite Pattern para la gestión de permisos.
    /// </summary>
    [Serializable]
    public class Rol : Autorizacion
    {
        /// <summary>
        /// Permisos del rol.
        /// </summary>
        [XmlArray("Permisos")]
        [XmlArrayItem("Permiso", typeof(Permiso))]
        [XmlArrayItem("Rol", typeof(Rol))]
        public List<Autorizacion> Permisos { get; set; } = new List<Autorizacion>();

        /// <summary>
        /// Implementación del método abstracto de la clase base para obtener los permisos.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Autorizacion> ObtenerPermisos()
        {
            yield return this;

            foreach (var item in Permisos)
            {
                foreach (var permiso in item.ObtenerPermisos())
                {
                    yield return permiso;
                }
            }
        }

        /// <summary>
        /// Formatea la salida de la clase.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id: {0,-2} | Rol: {1,-15}", Id, Descripcion);
        }
    }
}
