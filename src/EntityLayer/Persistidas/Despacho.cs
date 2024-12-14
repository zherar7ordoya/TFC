using AbstractLayer;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    /// <summary>Clase que representa un despacho (asignaciones) para una mudanza.</summary>
    public class Despacho : EntidadPersistente, IValidatableObject
    {
        /// <summary>Fecha en la que se realizó el despacho.</summary>
        public DateTime Fecha { get; set; }

        /// <summary>Empleado que realizó el despacho.</summary>
        public string Operador { get; set; }

        //......................................................................

        /// <summary>Fecha del servicio de mudanza.</summary>
        public DateTime FechaServicio { get; set; }

        /// <summary>Camión que se utilizó para la mudanza.</summary>
        public Camion Camion { get; set; }

        /// <summary>Empleado que fue el chofer del camión.</summary>
        public Empleado Chofer { get; set; }

        /// <summary>Empleados que fueron los ayudantes del chofer.</summary>
        public List<Empleado> Estibadores { get; set; } = new List<Empleado>();

        /// <summary>Lista de insumos que se utilizaron en la mudanza.</summary>
        public List<string> Insumos { get; set; } = new List<string>();

        //......................................................................

        /// <summary>Validaciones personalizadas para asegurar que las listas no estén vacías.</summary>
        /// <param name="validationContext">Contexto de validación.</param>
        /// <returns>Resultados de validación.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validar que la lista de estibadores no esté vacía
            if (Estibadores == null || Estibadores.Count < 1)
            {
                yield return new ValidationResult(
                    "Debe haber al menos un estibador en la lista.",
                    new[] { nameof(Estibadores) }
                );
            }

            // Validar que la lista de insumos no esté vacía
            if (Insumos == null || Insumos.Count < 1)
            {
                yield return new ValidationResult(
                    "Debe haber al menos un insumo en la lista.",
                    new[] { nameof(Insumos) }
                );
            }
        }

        //......................................................................

        /// <summary>Devuelve una representación en cadena del despacho.</summary>
        public override string ToString()
        {
            return $"D-{Id:D3}: {Fecha:dd/MM/yyyy} || {Camion} || {Chofer} || {Estibadores.Count} estibador/es";
        }
    }
}
