namespace AbstractLayer
{
    /// <summary>
    /// Enumerador de las distintas condiciones fiscales que puede tener un cliente
    /// </summary>
    public enum CondicionFiscalEnum
    {
        /// <summary>Condición fiscal de un cliente autónomo</summary>
        Autonomo,

        /// <summary>Condición fiscal de un cliente consumidor final</summary>
        ConsumidorFinal,

        /// <summary>Condición fiscal de un cliente exento</summary>
        Exento,

        /// <summary>Condición fiscal de un cliente monotributista</summary>
        Monotributista,

        /// <summary>Condición fiscal de un cliente no alcanzado</summary>
        NoAlcanzado,

        /// <summary>Condición fiscal de un cliente no responsable</summary>
        ResponsableInscripto
    }
}
