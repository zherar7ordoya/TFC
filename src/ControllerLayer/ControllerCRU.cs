using AbstractLayer;

using LogicLayer;

using System.Collections.Generic;

namespace ControllerLayer
{
    /// <summary>"Pasamanos" hacia el CRUD</summary>
    /// <typeparam name="T">Entidad de persistencia</typeparam>
    public class ControllerCRU<T> : ICRU<T> where T : IEntidadPersistente
    {
        /// <summary><see cref="ControllerCRU{T}"/></summary>
        public ControllerCRU() : this(null) { }

        /// <summary><see cref="ControllerCRU{T}"/></summary>
        /// <param name="carpeta">Especificar carpeta si no la predeterminada</param>
        public ControllerCRU(string carpeta)
        {
            _accesoCRUD = GenericFactory.Instanciar<LogicCRU<T>>(carpeta);
        }

        private readonly ICRU<T> _accesoCRUD;

        //......................................................................

        /// <summary>Forwarder de la operación Create de la capa de lógica.</summary>
        /// <param name="entidad">Entidad de persistencia.</param>
        /// <returns>T</returns>
        public T Create(T entidad) => _accesoCRUD.Create(entidad);

        /// <summary>Forwarder de la operación Delete de la capa de lógica.</summary>
        /// <returns><![CDATA[List<T>]]></returns>
        public IList<T> Read() => _accesoCRUD.Read();

        /// <summary>Forwarder de la operación Read de la capa de lógica.</summary>
        /// <param name="entidad">Entidad de persistencia.</param>
        /// <returns>Booleano de actualización exitosa</returns>
        public bool Update(T entidad) => _accesoCRUD.Update(entidad);
    }
}
