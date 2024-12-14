using System.Collections.Generic;

namespace AbstractLayer
{
    /// <summary>
    /// Contrato para las operaciones CRUD.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICRU<T> where T : IEntidadPersistente
    {
        /// <summary>
        /// Agrega una entidad a la colección.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        T Create(T entidad);

        /// <summary>
        /// Consulta las entidades de la colección.
        /// </summary>
        /// <returns></returns>
        IList<T> Read();

        /// <summary>
        /// Modifica una entidad de la colección.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        bool Update(T entidad);
        
        // Por decisión de diseño, se implementa el borrado lógico.
        //bool Delete(T entidad);
    }
}
