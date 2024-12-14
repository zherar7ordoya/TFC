using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    /// <summary>Un cliente persona física.</summary>
    public class PersonaFisica : Cliente
    {
        /// <summary>El nombre y apellido del cliente.</summary>
        [Required(ErrorMessage = "El nombre y apellido son obligatorios.")]
        public string NombreApellido { get; set; }

        /// <summary>El DNI del cliente.</summary>
        [Required(ErrorMessage = "El DNI es obligatorio.")]
        [RegularExpression(@"^\d{1,8}$", ErrorMessage = "El DNI debe tener entre 1 y 8 dígitos.")]
        public string DNI { get; set; }

        //......................................................................

        /// <summary>Devuelve una representación de la entidad en forma de cadena.</summary>
        public override string ToString()
        {
            return $"C-{Id:D3}: {NombreApellido} ({DNI}) {Direccion}";
        }
    }
}
