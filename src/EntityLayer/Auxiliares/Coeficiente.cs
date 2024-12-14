using AbstractLayer;

namespace EntityLayer
{
    /// <summary>Una tarifa.</summary>
    public class Coeficiente
    {
        /// <summary>El tipo de tarifa.</summary>
        public NivelTarifarioEnum NivelTarifario { get; set; }

        /// <summary>El valor del coeficiente.</summary>
        public decimal Valor { get; set; }

        //......................................................................

        /// <summary>Devuelve una representación del coeficiente.</summary>
        public override string ToString()
        {
            return $"Tarifario: {NivelTarifario}, Valor: {Valor}";
        }
    }
}
