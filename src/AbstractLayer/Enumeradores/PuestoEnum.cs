using System.ComponentModel;

namespace AbstractLayer
{
    /// <summary>
    /// Enumerador de los puestos de trabajo de la empresa.
    /// </summary>
    public enum PuestoEnum
    {
        /// <summary>
        /// Cajero de venta al contado.
        /// </summary>
        [Description("Cajero contado")]
        Cajero,

        /// <summary>
        /// Chofer.
        /// </summary>
        [Description("Chofer")]
        Chofer,

        /// <summary>
        /// Asistente contable.
        /// </summary>
        [Description("Asistente contable")]
        Contable,

        /// <summary>
        /// Estibador.
        /// </summary>
        [Description("Estibador")]
        Estibador,

        /// <summary>
        /// Gerente comercial.
        /// </summary>
        [Description("Gerente Comercial")]
        Gerente,

        /// <summary>
        /// Jefe.
        /// </summary>
        [Description("Jefe Operativo")]
        Jefe,

        /// <summary>
        /// Logístico.
        /// </summary>
        [Description("Logístico")]
        Logístico,

        /// <summary>
        /// Administrador del sistema.
        /// </summary>
        [Description("System Administrator")]
        SYSADMIN,

        /// <summary>
        /// Vendedor.
        /// </summary>
        [Description("Vendedor")]
        Vendedor,
    }
}