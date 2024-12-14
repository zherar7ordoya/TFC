using System.Collections.Generic;

namespace AbstractLayer
{
    /// <summary>
    /// Contrato para la persistencia en archivos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPersistidor<T> where T : IEntidadPersistente
    {
        /// <summary>
        /// Lector de archivos.
        /// </summary>
        /// <returns></returns>
        IList<T> Leer();

        /// <summary>
        /// Escritor de archivos.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Escribir(IList<T> datos);
    }
}
