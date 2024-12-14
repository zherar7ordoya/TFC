using AbstractLayer;

using EntityLayer;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    /// <summary>SearchService para Cliente.</summary>
    public class ClienteSearch : IBuscable<Cliente>
    {
        private readonly IList<Cliente> _clientes;

        /// <summary>Constructor que recibe una lista de Cliente.</summary>
        /// <param name="clientes">Lista de cliente.</param>
        public ClienteSearch(IList<Cliente> clientes)
        {
            _clientes = clientes;
        }

        /// <summary>Busca en la lista de Cliente por el criterio de búsqueda.</summary>
        /// <param name="consulta">Criterio de búsqueda.</param>
        /// <returns>Lista de clientes que coinciden con el criterio.</returns>
        /// 
        /// <remarks>
        /// 
        /// ¿CÓMO FUNCIONA?
        /// Escribo esta nota para explicar cómo funciona el método Buscar.
        /// 
        /// Método .ToLowerInvariant()
        /// Este método es útil cuando se quiere convertir una cadena a minúsculas considerando una cultura invariante,
        /// especialmente cuando se compara cadenas en un contexto internacional.
        /// 
        /// Evaluación de ToLowerInvariant().Contains(consulta)
        /// Ejemplo:
        /// <code>(cliente.Nombre?.ToLowerInvariant().Contains(consulta) ?? false)</code>
        /// 
        /// cliente.Nombre?
        /// El operador condicional nulo (?.) evalúa si cliente.Nombre es null. Si lo es, devuelve null sin intentar 
        /// llamar a ToLowerInvariant(). Esto evita un NullReferenceException.
        /// 
        /// El operador coalescencia nula (??) especifica un valor predeterminado cuando la expresión a la izquierda de
        /// ?? es null.
        /// 
        /// ***SI cliente.Nombre ES null***
        /// Entonces cliente.Nombre?.ToLowerInvariant().Contains(consulta) será null porque el operador ?. interrumpe la
        /// evaluación; y entonces el operador ?? asignará el valor false.
        /// 
        /// ***SI cliente.Nombre NO ES null***
        /// Se evalúa cliente.Nombre.ToLowerInvariant().Contains(consulta) y devuelve true o false, dependiendo de si
        /// encuentra la subcadena consulta.
        /// 
        /// </remarks>
        public IEnumerable<Cliente> Buscar(string consulta)
        {
            if (string.IsNullOrWhiteSpace(consulta))
                throw new ArgumentException("El criterio de búsqueda no puede ser nulo o vacío.", nameof(consulta));

            consulta = consulta.ToLowerInvariant();

            return _clientes.Where(cliente =>
            {
                // Propiedades comunes
                if (cliente.Id.ToString().Contains(consulta )
                || (cliente.Nombre?.ToLowerInvariant().Contains(consulta) ?? false)
                || (cliente.Direccion?.ToLowerInvariant().Contains(consulta) ?? false)
                ||(cliente.Email?.ToLowerInvariant().Contains(consulta) ?? false))
                {
                    return true;
                }

                // Validar el tipo y buscar en las propiedades específicas
                if (cliente is PersonaFisica fisica)
                {
                    return (fisica.DNI?.ToLowerInvariant().Contains(consulta) ?? false) ||
                           (fisica.NombreApellido?.ToLowerInvariant().Contains(consulta) ?? false);
                }
                else if (cliente is PersonaJuridica juridica)
                {
                    return (juridica.CUIT?.ToLowerInvariant().Contains(consulta) ?? false) ||
                           (juridica.RazonSocial?.ToLowerInvariant().Contains(consulta) ?? false);
                }

                return false;
            });
        }

        //......................................................................
    }
}
