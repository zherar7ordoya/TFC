using AbstractLayer;
using System;
using System.Collections.Generic;

namespace EntityLayer
{
    /// <summary>Una tarifa.</summary>
    public class Tarifa : EntidadPersistente
    {
        /// <summary>La fecha de inicio de la tarifa.</summary>
        public DateTime Desde { get; set; }

        /// <summary>La fecha de fin de la tarifa.</summary>
        public DateTime Hasta { get; set; }

        /// <summary>El monto por kilómetro.</summary>
        public decimal MontoKilometro { get; set; }

        /// <summary>Los coeficientes de rentabilidad para el periodo.</summary>
        public List<Coeficiente> Coeficientes { get; set; } = new List<Coeficiente>(); // Siempre inicializada

        //......................................................................

        /// <summary>Devuelve una representación de la tarifa.</summary>
        public override string ToString()
        {
            return $"Tarifa {Id}: {Desde.ToShortDateString()} - {Hasta.ToShortDateString()}";
        }
    }
}
