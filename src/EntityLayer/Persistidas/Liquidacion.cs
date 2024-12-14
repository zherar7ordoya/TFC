using AbstractLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EntityLayer
{
    /// <summary>Clase que representa una liquidación a un chofer.</summary>
    public class Liquidacion : EntidadPersistente
    {
        /// <summary>Fecha de la liquidación.</summary>
        public DateTime Fecha { get; set; }

        /// <summary>Empleado que realiza la liquidación.</summary>
        public string Operador { get; set; }

        //......................................................................

        /// <summary>Lista de comprobantes de gastos que se presenta para el reembolso.</summary>
        public List<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();

        /// <summary>Orden de trabajo a liquidar.</summary>
        [Range(0, double.MaxValue, ErrorMessage = "El monto de la orden no puede ser negativo.")]
        public decimal MontoOrden { get; set; }

        /// <summary>Suma de los gastos presentados en los comprobantes.</summary>
        [Range(0, double.MaxValue, ErrorMessage = "El monto de los comprobantes no puede ser negativo.")]
        public decimal MontoComprobantes { get; set; }

        /// <summary>Total calculado de la comisión sobre la orden servida.</summary>
        [Range(0, double.MaxValue, ErrorMessage = "El total de la comisión no puede ser negativo.")]
        public decimal Comision { get; set; }

        /// <summary>Coincide con la suma de los gastos presentados en los comprobantes.</summary>
        [Range(0, double.MaxValue, ErrorMessage = "El total del reembolso no puede ser negativo.")]
        public decimal Reembolso { get; set; }

        /// <summary>Total de la liquidación, que es la suma de la comisión y el reembolso.</summary>
        [Range(0.01, double.MaxValue, ErrorMessage = "El total de la liquidación no puede ser menor o igual a cero.")]
        public decimal TotalLiquidacion { get; set; }

        //......................................................................

        /// <summary>Devuelve una representación de la entidad en forma de cadena.</summary>
        /// <returns>Cadena que representa la entidad.</returns>
        public override string ToString()
        {
            return $"L-{Id:D3}: {Fecha:dd/MM/yyyy} || ${TotalLiquidacion:C}";
        }
    }
}
