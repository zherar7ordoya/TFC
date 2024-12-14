using System;

namespace AbstractLayer
{
    /// <summary>Contrato para la bitácora de eventos.</summary>
    public interface IBitacora : IEntidadPersistente
    {
        /// <summary>Comentario del evento.</summary>
        string Comentario { get; set; }

        /// <summary>Detalle del evento.</summary>
        string Detalle { get; set; }

        /// <summary>Empleado que generó el evento.</summary>
        string Empleado { get; set; }

        /// <summary>Fecha y hora del evento.</summary>
        DateTime Timestamp { get; set; }

        /// <summary>Tipo de evento.</summary>
        EventoEnum Tipo { get; set; }

        /// <summary>Archivo comprimido en donde se hizo el backup de la base de datos.</summary>
        string Zip { get; set; }

        /// <summary>Formato de salida.</summary>
        string ToString();
    }
}
