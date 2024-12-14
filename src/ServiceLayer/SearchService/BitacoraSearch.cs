using AbstractLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ServiceLayer
{
    /// <summary>
    /// SearchService para Bitácora
    /// </summary>
    public class BitacoraSearch : IBuscable<Bitacora>
    {
        /// <summary>
        /// Constructor que recibe una lista de Bitácora.
        /// </summary>
        /// <param name="bitacoras"></param>
        public BitacoraSearch(IList<Bitacora> bitacoras)
        {
            _bitacoras = bitacoras;
        }

        private readonly IList<Bitacora> _bitacoras;

        /// <summary>
        /// Busca en la lista de Bitácora por el criterio de búsqueda.
        /// <![CDATA[El campo de búsqueda no puede ser nulo.]]>
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public IEnumerable<Bitacora> Buscar(string consulta)
        {
            return _bitacoras.Where(x => x.Id.ToString().IndexOf(consulta, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                         x.Timestamp.ToString("yyyy-MM-dd HH:mm:ss").IndexOf(consulta, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                        (x.Empleado?.IndexOf(consulta, StringComparison.OrdinalIgnoreCase) ?? -1) >= 0 ||
                                        (x.Detalle?.IndexOf(consulta, StringComparison.OrdinalIgnoreCase) ?? -1) >= 0 ||
                                        (x.Zip?.IndexOf(consulta, StringComparison.OrdinalIgnoreCase) ?? -1) >= 0);
        }
    }
}
