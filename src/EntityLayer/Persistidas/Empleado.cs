using AbstractLayer;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace EntityLayer
{
    /// <summary>
    /// Entidad primaria.
    /// </summary>
    [Serializable]
    public class Empleado : EntidadPersistente, ICloneable
    {
        // Datos personales.....................................................

        /// <summary>
        /// Documento Nacional de Identidad.
        /// </summary>
        [Required(ErrorMessage = "El DNI es obligatorio.")]
        [RegularExpression(@"^\d{1,8}$", ErrorMessage = "El DNI debe tener entre 1 y 8 dígitos.")]
        public int DNI { get; set; } // Campo 4

        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [CustomValidation(typeof(Empleado), nameof(ValidarEdad))]
        public DateTime FechaNacimiento { get; set; } // Campo 5

        /// <summary>
        /// Nombre del empleado.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(25, ErrorMessage = "El nombre no puede tener más de 25 caracteres.")]
        public string Nombre { get; set; } // Campo 6

        /// <summary>
        /// Apellido del empleado.
        /// </summary>
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(25, ErrorMessage = "El apellido no puede tener más de 25 caracteres.")]
        public string Apellido { get; set; } // Campo 7

        // Datos laborales......................................................

        /// <summary>
        /// Puesto de trabajo.
        /// </summary>
        [Required(ErrorMessage = "El puesto es obligatorio.")]
        public PuestoEnum? Puesto { get; set; } // Campo 8

        // Datos de contacto....................................................

        /// <summary>
        /// Teléfono de contacto.
        /// </summary>
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string Telefono { get; set; } // Campo 9

        /// <summary>
        /// Email de contacto.
        /// </summary>
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; } // Campo 10

        // Authentification.....................................................

        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [RegularExpression(@"^[a-z0-9]{4,}$", ErrorMessage = "El nombre de usuario debe tener al menos 4 caracteres y solo puede contener letras minúsculas y números.")]
        public string Usuario { get; set; } // Campo 11

        /// <summary>
        /// Contraseña de acceso.
        /// </summary>
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [CustomValidation(typeof(Empleado), nameof(ValidarContraseña))]
        public string Contraseña { get; set; } // Campo 12

        /// <summary>
        /// Palabra secreta de recuperación de contraseña.
        /// </summary>
        [Required(ErrorMessage = "La palabra secreta de recuperación de contraseña es obligatoria.")]
        [RegularExpression(@"^[a-zA-Z0-9]{4,}$", ErrorMessage = "La palabra secreta debe tener al menos 4 caracteres y puede contener letras y números.")]
        public string PalabraSecreta { get; set; } // Campo 13

        // Contraseña...........................................................

        /// <summary>
        /// Cantidad de intentos fallidos de inicio de sesión.
        /// </summary>
        public int LoginFallido { get; set; } = 0; // Campo 14

        /// <summary>
        /// Fecha de bloqueo de inicio de sesión.
        /// </summary>
        public DateTime ContraseñaFecha { get; set; } // Campo 15

        /// <summary>
        /// Historial de contraseñas.
        /// </summary>
        public List<string> ContraseñasPasadas { get; set; } // Campo 16

        // Authorization........................................................

        /// <summary>
        /// Permisos y roles de usuario.
        /// </summary>
        [XmlArray("Autorizaciones")]
        [XmlArrayItem("Rol", typeof(Rol))]
        [XmlArrayItem("Permiso", typeof(Permiso))]
        public List<Autorizacion> Autorizaciones { get; set; } // Campo 17

        // Validaciones personalizadas..........................................

        /// <summary>
        /// Expresión regular para validar la contraseña.
        /// </summary>
        public static string RegExContraseña { get; set; }

        /// <summary>
        /// Verifica si la fecha de nacimiento corresponde a alguien mayor de 18 años.
        /// </summary>
        /// <param name="fechaNacimiento"></param>
        /// <returns></returns>
        public static ValidationResult ValidarEdad(DateTime fechaNacimiento)
        {
            // Verifica si la fecha de nacimiento corresponde a alguien mayor de 18 años
            var fechaLimite = DateTime.Now.AddYears(-18);
            if (fechaNacimiento > fechaLimite)
            {
                return new ValidationResult("El empleado debe ser mayor de 18 años.");
            }
            return ValidationResult.Success;
        }

        /// <summary>
        /// Verifica si la contraseña cumple con los requisitos de seguridad.
        /// </summary>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        public static ValidationResult ValidarContraseña(string contraseña)
        {
            // Verificar si la contraseña cumple con la expresión regular
            if (!Regex.IsMatch(contraseña, RegExContraseña))
            {
                return new ValidationResult(
                    "La contraseña no cumple con los requisitos de seguridad.\n" +
                    "La contraseña debe contener al menos:\n" +
                    "una mayúscula, una minúscula, un número y un carácter especial.");
            }
            return ValidationResult.Success;
        }

        // Formato de salida....................................................

        /// <summary>
        /// Entrega el nombre completo del empleado.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{Nombre} {Apellido}");
        }

        // Clonación profunda...................................................

        /// <summary>
        /// Clona el objeto.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            // Clonación de objetos simples
            var clon = (Empleado)MemberwiseClone();

            // Verificar si las listas no son null antes de clonarlas
            clon.ContraseñasPasadas = ContraseñasPasadas != null
                ? new List<string>(ContraseñasPasadas)
                : new List<string>(); // Inicializar como una lista vacía si es null

            clon.Autorizaciones = Autorizaciones != null
                ? new List<Autorizacion>(Autorizaciones)
                : new List<Autorizacion>(); // Inicializar como una lista vacía si es null

            // Entrega el clon del objeto
            return clon;
        }
    }
}
