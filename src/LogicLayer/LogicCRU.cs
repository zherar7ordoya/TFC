using AbstractLayer;
using DataManager;
using System.Collections.Generic;


namespace LogicLayer
{
    /// <summary>
    /// Acceso a la capa gestora datos para realizar operaciones CRUD.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LogicCRU<T> : ICRU<T> where T : IEntidadPersistente
    {
        /// <summary>
        /// <see cref="LogicCRU{T}"/>
        /// </summary>
        public LogicCRU() : this(null) { }

        /// <summary>
        /// <see cref="LogicCRU{T}"/>
        /// </summary>
        /// <param name="carpeta"></param>
        public LogicCRU(string carpeta)
        {
            _CRUD = GenericFactory.Instanciar<CRU<T>>(carpeta);
        }

        private readonly ICRU<T> _CRUD;

        //......................................................................

        /// <summary>
        /// Acceso al método Create de la capa gestora de datos.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public T Create(T entidad) => _CRUD.Create(entidad);

        /// <summary>
        /// Acceso al método Read de la capa gestora de datos.
        /// </summary>
        /// <returns></returns>
        public IList<T> Read() => _CRUD.Read();

        /// <summary>
        /// Acceso al método Update de la capa gestora de datos.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Update(T entidad) => _CRUD.Update(entidad);
    }
}