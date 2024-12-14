using System.Collections.Generic;

namespace AbstractLayer
{
    /// <summary>
    /// Interfaz al servicio de búsqueda de entidades (SearchService).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBuscable<T>
    {
        /// <summary>
        /// Busca entidades en la base de datos.
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        IEnumerable<T> Buscar(string consulta);
    }
}
