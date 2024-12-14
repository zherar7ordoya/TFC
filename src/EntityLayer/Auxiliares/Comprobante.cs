using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    /// <summary>Un comprobante.</summary>
    public class Comprobante
    {
        /// <summary>La fecha del comprobante.</summary>
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha es inválido.")]
        [CustomValidation(typeof(Comprobante), nameof(ValidarFechaFutura))]
        public DateTime Fecha { get; set; }

        /// <summary>El número del comprobante.</summary>
        [Required(ErrorMessage = "El número del comprobante es obligatorio.")]
        [StringLength(20, ErrorMessage = "El número no debe superar los 20 caracteres.")]
        public string Numero { get; set; }

        /// <summary>El emisor del comprobante.</summary>
        [Required(ErrorMessage = "El emisor es obligatorio.")]
        [StringLength(100, ErrorMessage = "El emisor no debe superar los 100 caracteres.")]
        public string Emisor { get; set; }

        /// <summary>El detalle del comprobante.</summary>
        [Required(ErrorMessage = "El concepto es obligatorio.")]
        [StringLength(200, ErrorMessage = "El concepto no debe superar los 200 caracteres.")]
        public string Concepto { get; set; }

        /// <summary>El monto del comprobante.</summary>
        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, 1000000, ErrorMessage = "El monto debe estar entre 0.01 y 1,000,000.")]
        public decimal Monto { get; set; }

        /// <summary>
        /// Validación personalizada para evitar fechas futuras.
        /// </summary>
        public static ValidationResult ValidarFechaFutura(DateTime fecha, ValidationContext context)
        {
            return fecha <= DateTime.Now
                ? ValidationResult.Success
                : new ValidationResult("La fecha no puede ser futura.");
        }
    }
}
