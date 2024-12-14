using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    /// <summary>Un cliente persona jurídica.</summary>
    public class PersonaJuridica : Cliente
    {
        /// <summary>La razón social del cliente.</summary>
        [Required(ErrorMessage = "La Razón Social es obligatoria.")]
        public string RazonSocial { get; set; }

        /// <summary>La CUIT del cliente.</summary>
        [Required(ErrorMessage = "La CUIT es obligatoria.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "La CUIT debe tener 11 dígitos.")]
        public string CUIT { get; set; }

        //......................................................................

        /// <summary>Devuelve una representación de la entidad en forma de cadena.</summary>
        public override string ToString()
        {
            return $"C-{Id:D3}: {RazonSocial} ({CUIT}) {Direccion}";
        }
    }
}
