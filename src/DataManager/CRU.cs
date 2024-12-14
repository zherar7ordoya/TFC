using AbstractLayer;
using DataAccess;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataManager
{
    /// <summary>CRUD genérico para entidades que implementen IEntidad.</summary>
    /// <typeparam name="T">Entidad para persistencia.</typeparam>
    public class CRU<T> : ICRU<T> where T : IEntidadPersistente
    {
        /// <summary><see cref="CRU{T}"/></summary>
        public CRU() : this(null) { }

        /// <summary><see cref="CRU{T}"/></summary>
        /// <param name="carpeta">Especifica una carpeta diferente de la predeterminada.</param>
        public CRU(string carpeta)
        {
            _carpeta = carpeta ?? ConfigurationService.Configuracion.CarpetaData;
            _acceso = GenericFactory.Instanciar<PersistidorXml<T>>(_carpeta);
            _listado = _acceso.Leer() ?? new List<T>();
        }

        private readonly IPersistidor<T> _acceso;
        private readonly IList<T> _listado;
        private readonly string _carpeta;

        //......................................................................

        /// <summary>
        /// Acondiciona la entrada para ser agregada y la envía al escritor de la persistencia.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public T Create(T entidad)
        {
            entidad.Id = _listado.Count > 0 ? _listado.Max(x => x.Id) + 1 : 1;
            _listado.Add(entidad);
            _acceso.Escribir(_listado);
            return entidad;
        }

        /// <summary>Accede al lector de la persistencia.</summary>
        /// <returns>Regresa un <![CDATA[IList<entidad>]]></returns>
        public IList<T> Read() => _listado;

        /// <summary>
        /// Acondiciona la entrada para ser modificada y la envía al escritor de la persistencia.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public bool Update(T entidad)
        {
            var item = _listado.FirstOrDefault(x => x.Id.Equals(entidad.Id));

            if (item == null)
            {
                throw new KeyNotFoundException("No se encontró el elemento a actualizar.");
            }

            if (item.Eliminado)
            {
                throw new InvalidOperationException("El elemento está eliminado y no se puede actualizar.");
            }

            int index = _listado.IndexOf(item);
            _listado[index] = entidad;
            _acceso.Escribir(_listado);
            return true;
        }
    }
}
