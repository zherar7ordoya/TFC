using AbstractLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    /// <summary>SearchService para Empleado.</summary>
    public class EmpleadoSearch : IBuscable<Empleado>
    {
        /// <summary>Constructor que recibe una lista de Empleado.</summary>
        /// <param name="empleados">Lista de empleados.</param>
        public EmpleadoSearch(IList<Empleado> empleados)
        {
            _empleados = empleados;
        }

        private readonly IList<Empleado> _empleados;

        /// <summary>
        /// Busca en la lista de Empleado por el criterio de búsqueda.
        /// <![CDATA[El campo de búsqueda no puede ser nulo.]]>
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public IEnumerable<Empleado> Buscar(string consulta)
        {
            return _empleados
                .Where(x => x.Id.ToString().IndexOf(consulta, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            x.DNI.ToString().IndexOf(consulta, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            (x.Nombre?.IndexOf(consulta, StringComparison.OrdinalIgnoreCase) ?? -1) >= 0 ||
                            (x.Apellido?.IndexOf(consulta, StringComparison.OrdinalIgnoreCase) ?? -1) >= 0 ||
                            (x.Usuario?.IndexOf(consulta, StringComparison.OrdinalIgnoreCase) ?? -1) >= 0
                );
        }
    }
}
