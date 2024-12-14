using AbstractLayer;
using System;

namespace EntityLayer
{
    /// <summary>
    /// Log de eventos de la aplicación.
    /// </summary>
    [Serializable]
    public class Bitacora : EntidadPersistente, IBitacora
    {
        /// <summary>
        /// Enumeración de tipos de eventos.
        /// </summary>
        public EventoEnum Tipo { get; set; } // 1

        /// <summary>
        /// Fecha y hora del evento.
        /// </summary>
        public DateTime Timestamp { get; set; } // 2

        /// <summary>
        /// Usuario que generó el evento.
        /// </summary>
        public string Empleado { get; set; } // 3

        /// <summary>
        /// Detalle del evento.
        /// </summary>
        public string Detalle { get; set; } // 4

        /// <summary>
        /// Archivo comprimido en donde se hizo el backup de la base de datos.
        /// </summary>
        public string Zip { get; set; } // 5

        /// <summary>
        /// Observaciones del evento.
        /// </summary>
        public string Comentario { get; set; } // 6

        // Formato de salida....................................................

        /// <summary>
        /// Formato de salida.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id: {0,-3} | Empleado: {1,-15} | Detalle: {2}",
                                 Id, Empleado, Detalle);
        }
    }
}
