using AbstractLayer;

using System;
using System.IO;

namespace EntityLayer
{
    /// <summary>
    /// ConfigurationService.
    /// </summary>
    [Serializable]
    public class Configuracion : EntidadPersistente
    {
        // Contraseña...........................................................

        /// <summary>
        /// Límite de veces que se puede intentar ingresar una contraseña incorrecta.
        /// </summary>
        public int ContraseñaIntentosFallidos { get; set; } = 5;

        /// <summary>
        /// Días de vigencia de la contraseña.
        /// </summary>
        public int ContraseñaDiasVigencia { get; set; } = 180;

        /// <summary>
        /// RegEx para validar la contraseña. 
        /// Debe estar coordinado con RandomCredentialsService.
        /// </summary>
        public string ContraseñaRegEx { get; set; } = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&+-]).{4,}$";

        /// <summary>
        /// Clave de ofuscación de la contraseña.
        /// </summary>
        public byte ContraseñaClaveXOR { get; set; } = 0xAA;

        // Archivos de ingreso y salida al/del sistema..........................

        /// <summary>
        /// Archivo de inicio de la aplicación.
        /// </summary>
        public string ArchivoStart { get; set; } = "App.start";

        /// <summary>
        /// Archivo de salida de la aplicación.
        /// </summary>
        public string ArchivoExit { get; set; } = "App.exit";

        // Carpetas.............................................................

        /// <summary>
        /// Carpeta base de la aplicación.
        /// </summary>
        public string CarpetaBase { get; set; } = "Base";

        /// <summary>
        /// Carpeta de datos de la aplicación (base de datos).
        /// </summary>
        public string CarpetaData { get; set; } = "Data";

        /// <summary>
        /// Carpeta de copias de seguridad de la aplicación.
        /// </summary>
        public string CarpetaBackup { get; set; } = "Backup";

        /// <summary>
        /// Carpeta de documentos de la aplicación.
        /// </summary>
        public string CarpetaDocumentos { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "La Mudadora");

        // Impuesto.............................................................

        /// <summary>
        /// Porcentaje de IVA.
        /// </summary>
        public int PorcentajeIVA { get; set; } = 10;

        // Datos de empresa.....................................................

        /// <summary>
        /// Razón social de la empresa.
        /// </summary>
        public string EmpresaRazonSocial { get; set; } = "La Mudadora";

        /// <summary>
        /// Clave Única de Identificación Tributaria (CUIT) de la empresa.
        /// </summary>
        public ulong EmpresaCUIT { get; set; } = 20161760057;

        /// <summary>
        /// Domicilio de la empresa.
        /// </summary>
        public string EmpresaDireccion { get; set; } = "Belgrano esq. Senador Pérez";

        /// <summary>
        /// Teléfono de la empresa.
        /// </summary>
        public string EmpresaTelefono { get; set; } = "1 (888) 512-1984";

        /// <summary>
        /// Condición tributaria de la empresa ante el Impuesto al Valor Agregado (IVA).
        /// </summary>
        public string EmpresaCondicionIVA { get; set; } = "Responsable Inscripto";

        // Impresora

        /// <summary>
        /// Nombre de la impresora por defecto.
        /// </summary>
        public string ImpresoraPredeterminada { get; set; } = "Impresora NULL";
    }
}
