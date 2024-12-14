using AbstractLayer;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace EntityLayer
{
    /// <summary>Un cliente.</summary>
    [XmlInclude(typeof(PersonaFisica))]
    [XmlInclude(typeof(PersonaJuridica))]
    public abstract class Cliente : EntidadPersistente
    {
        //......................................................................

        /// <summary>Propiedad calculada para Nombre o Razón Social.</summary>
        public string Nombre
        {
            get
            {
                if (this is PersonaFisica fisica)
                    return fisica.NombreApellido;
                if (this is PersonaJuridica juridica)
                    return juridica.RazonSocial;
                return string.Empty;
            }
        }

        /// <summary>Propiedad calculada para DNI o CUIT.</summary>
        public string Identificador
        {
            get
            {
                if (this is PersonaFisica fisica)
                    return fisica.DNI;
                if (this is PersonaJuridica juridica)
                    return juridica.CUIT;
                return string.Empty;
            }
        }

        //......................................................................

        /// <summary>La condición fiscal del cliente.</summary>
        [Required(ErrorMessage = "La condición fiscal es obligatoria.")]
        public CondicionFiscalEnum CondicionFiscal { get; set; }

        /// <summary>El nivel tarifario del cliente.</summary>
        [Required(ErrorMessage = "El nivel tarifario es obligatorio.")]
        public NivelTarifarioEnum NivelTarifario { get; set; }

        /// <summary>La dirección del cliente.</summary>
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }

        /// <summary>El teléfono del cliente.</summary>
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }

        /// <summary>Correo electrónico del cliente.</summary>
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; }
    }
}
