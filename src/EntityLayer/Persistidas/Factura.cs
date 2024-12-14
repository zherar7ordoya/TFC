using AbstractLayer;

using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    /// <summary>Clase que representa una factura.</summary>
    public class Factura : EntidadPersistente
    {
        /// <summary>Fecha en la que se creó la factura.</summary>
        public DateTime Fecha { get; set; }

        /// <summary>Nombre del empleado que creó la factura.</summary>
        public string Operador { get; set; }

        //......................................................................

        /// <summary>Total cotizado en la orden.</summary>
        [Required(ErrorMessage = "El campo es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a cero.")]
        public decimal Subtotal { get; set; }

        /// <summary>Impuesto aplicado.</summary>
        [Required(ErrorMessage = "El campo es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a cero.")]
        public decimal Impuesto { get; set; }

        /// <summary>Total a pagar.</summary>
        [Required(ErrorMessage = "El campo es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a cero.")]
        public decimal Total { get; set; }

        //......................................................................

        /// <summary>Devuelve una representación de la entidad en forma de cadena.</summary>
        public override string ToString()
        {
            return $"F-{Id:D3}: {Fecha:dd/MM/yyyy} || {Total:C}";
        }
    }
}
