using System.ComponentModel;

namespace AbstractLayer
{
    /// <summary>
    /// Enumerador de eventos del sistema.
    /// </summary>
    public enum EventoEnum
    {
        /// <summary>
        /// Backup de datos.
        /// </summary>
        [Description("Backup de datos")]
        Backup,

        /// <summary>
        /// Excepción del sistema.
        /// </summary>
        [Description("Excepción del sistema")]
        Exception,

        /// <summary>
        /// Inicio de sesión.
        /// </summary>
        [Description("Inicio de sesión")]
        Login,

        /// <summary>
        /// Cierre de sesión.
        /// </summary>
        [Description("Cierre de sesión")]
        Logout,

        /// <summary>
        /// Restauración de datos.
        /// </summary>
        [Description("Restauración de datos")]
        Restore,
    }
}