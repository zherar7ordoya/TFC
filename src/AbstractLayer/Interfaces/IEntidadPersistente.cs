/*
 * NOTA
 * ¿Qué es parte de una entrada (registro o elemento) en una base de datos?
 * Algo que no he implementado en este trabajo es el registro de:
 * - Fecha de creación
 * - Fecha de modificación
 * - Fecha de eliminación
 * Queda pendiente para futuras versiones.
 */

namespace AbstractLayer
{
    /// <summary>
    /// Contrato al que están obligadas las entidades a ser persistidas.
    /// </summary>
    public interface IEntidadPersistente
    {
        /// <summary>Primary key de la entidad.</summary>
        int Id { get; set; }

        /// <summary>Indica si la entidad está bloqueada.</summary>
        bool Bloqueado { get; set; }

        /// <summary>Habilita el borrado lógico de la entidad.</summary>
        bool Eliminado { get; set; }

        // NOTA: Queda pendiente para futuras versiones.
        //DateTime FechaCreacion { get; set; }
        //DateTime FechaModificacion { get; set; }
        //DateTime FechaEliminacion { get; set; }
    }
}
