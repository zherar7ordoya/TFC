using AbstractLayer;

namespace EntityLayer
{
    /// <summary>Representa una transacción para un cliente.</summary>
    public class Transaccion : EntidadPersistente
    {
        /// <summary>Establece el cliente de la transacción.</summary>
        public Cliente Cliente { get; set; }

        /// <summary>Establece la orden de la transacción.</summary>
        public Orden Orden { get; set; }

        /// <summary>Establece la factura de la transacción.</summary>
        public Factura Factura { get; set; }

        /// <summary>Establece el despacho de la transacción.</summary>
        public Despacho Despacho { get; set; }

        /// <summary>Establece la liquidación de la transacción.</summary>
        public Liquidacion Liquidacion { get; set; }

        //......................................................................

        /// <summary>Formato de impresión de la transacción.</summary>
        /// <returns>Cadena de texto.</returns>
        public override string ToString()
        {
            string cotizacion = Orden?.Cotizacion.ToString("C") ?? "N/A";
            string liquidacion = Liquidacion?.TotalLiquidacion.ToString("C") ?? "N/A";
            string diferencia = (Orden?.Cotizacion - Liquidacion?.TotalLiquidacion)?.ToString("C") ?? "N/A";

            //return $"T{Id:D3}: {cotizacion} - {liquidacion} = {diferencia}";
            // Ajustar los textos a columnas de longitud fija
            return $"T-{Id:D3}  {cotizacion,-15}  {liquidacion,-15}  {diferencia,-15}";
        }
    }
}
