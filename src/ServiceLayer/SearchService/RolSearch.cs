using AbstractLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ServiceLayer
{
    /// <summary>
    /// SearchService para Rol.
    /// </summary>
    public class RolSearch : IBuscable<Rol>
    {
        private readonly List<Rol> _roles;

        /// <summary>
        /// Constructor que recibe una lista de Rol.
        /// </summary>
        /// <param name="roles"></param>
        public RolSearch(List<Rol> roles)
        {
            _roles = roles;
        }

        /// <summary>
        /// Busca en la lista de Rol por el criterio de búsqueda.
        /// <![CDATA[El campo de búsqueda no puede ser nulo.]]>
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public IEnumerable<Rol> Buscar(string consulta)
        {
            return _roles.Where(x =>
                x.Descripcion.IndexOf(consulta, StringComparison.OrdinalIgnoreCase) >= 0 ||
                x.Id.ToString().IndexOf(consulta, StringComparison.OrdinalIgnoreCase) >= 0
            );
        }
    }




}

