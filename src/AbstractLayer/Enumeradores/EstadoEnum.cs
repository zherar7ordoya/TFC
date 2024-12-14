namespace AbstractLayer
{
    /// <summary>
    /// Enumerador de los distintos estados que puede tener una orden de mudanza.
    /// </summary>
    public enum EstadoEnum
    {
        /// <summary>Se ha solicitado el servicio.</summary>
        Solicitada,

        /// <summary>Se ha pagado el servicio.</summary>
        Pagada,

        /// <summary>El servicio está siendo procesado.</summary>
        Transito,

        /// <summary>El servicio ha sido completado.</summary>
        Completada,

        /// <summary>El servicio ha sido liquidado.</summary>
        Liquidada,

        /// <summary>El servicio ha sido cancelado.</summary>
        Cancelada
    }
}
