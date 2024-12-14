using AbstractLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    /// <summary>Clase que representa una orden de mudanza.</summary>
    public class Orden : EntidadPersistente, IValidatableObject
    {
        //......................................................................

        /// <summary>Fecha en la que se creó la orden.</summary>
        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime Fecha { get; set; }

        /// <summary>Nombre del empleado que creó la orden.</summary>
        [Required(ErrorMessage = "El operador es obligatorio.")]
        public string Operador { get; set; }

        //......................................................................

        /*
        Ésta fue una decisión difícil pero, retrospectivamente, obvia. Como
        descriptor, el cliente ciertamente es un atributo de la orden. ¿Por qué
        entonces la mantengo en la transacción? Fundamentalmente, porque los
        documentos se generan desde la transacción. Y, en definitiva, una
        transacción da cuenta de cada entidad interviniente. ¿Es posible un
        diseño más eficiente? Sí, pero no es el objetivo de este proyecto.
        */
        /// <summary>Cliente que solicita la mudanza.</summary>
        public Cliente Cliente { get; set; }

        /// <summary>Fecha en la que se realizará la mudanza.</summary>
        [Required(ErrorMessage = "La fecha de la mudanza es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de la mudanza debe ser válida.")]
        public DateTime FechaMudanza { get; set; }

        /// <summary>Camión.</summary>
        [Required(ErrorMessage = "El camión es obligatorio.")]
        public Camion Camion { get; set; }

        /// <summary>Locación de origen de la mudanza.</summary>
        [Required(ErrorMessage = "El lugar de origen es obligatorio.")]
        [StringLength(100, ErrorMessage = "El lugar de origen no puede exceder los 100 caracteres.")]
        public string Origen { get; set; }

        /// <summary>Locación de destino de la mudanza.</summary>
        [Required(ErrorMessage = "El lugar de destino es obligatorio.")]
        [StringLength(100, ErrorMessage = "El lugar de destino no puede exceder los 100 caracteres.")]
        public string Destino { get; set; }

        /// <summary>Distancia entre el origen y el destino de la mudanza.</summary>
        [Required(ErrorMessage = "La distancia es obligatoria.")]
        //[Range(1, 372, ErrorMessage = "La distancia debe estar entre 1 y 372 kilómetros.")]
        public int Distancia { get; set; }

        /// <summary>Dirección en origen de carga.</summary>
        [Required(ErrorMessage = "La dirección de carga es obligatoria.")]
        [StringLength(200, ErrorMessage = "La dirección de carga no puede exceder los 200 caracteres.")]
        public string LugarCarga { get; set; }

        /// <summary>Dirección en destino de descarga.</summary>
        [Required(ErrorMessage = "La dirección de descarga es obligatoria.")]
        [StringLength(200, ErrorMessage = "La dirección de descarga no puede exceder los 200 caracteres.")]
        public string LugarDescarga { get; set; }

        /// <summary>Anotaciones adicionales que hacen al servicio.</summary>
        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder los 500 caracteres.")]
        public string Observaciones { get; set; }

        /// <summary>Lista de ítems a ser transportados.</summary>
        public List<string> Items { get; set; } = new List<string>();

        /// <summary>Monto total de la orden.</summary>
        [Required(ErrorMessage = "La cotización es obligatoria.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public decimal Cotizacion { get; set; }

        /// <summary>Booleano que indica si la orden es comisionable o no.</summary>
        public bool Comisionable { get; set; } = false;

        /// <summary>Estado actual de la orden.</summary>
        [Required(ErrorMessage = "El estado de la orden es obligatorio.")]
        public EstadoEnum Estado { get; set; }

        //......................................................................

        /// <summary>
        /// Forma de validar que una lista de ítems tenga al menos un ítem.
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validar que haya al menos un ítem.
            if (Items == null || Items.Count < 1)
            {
                yield return new ValidationResult(
                    "Debe haber al menos un ítem en la lista.",
                    new[] { nameof(Items) }
                );
            }
        }

        //......................................................................

        /// <summary>Devuelve una representación en cadena de la orden.</summary>
        public override string ToString()
        {
            return $"O-{Id:D3}: {Fecha:dd/MM/yyyy} || {Cotizacion:C}";
        }
    }
}
