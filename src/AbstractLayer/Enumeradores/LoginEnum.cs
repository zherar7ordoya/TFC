using System.ComponentModel;

namespace AbstractLayer
{
    /// <summary>
    /// Enumerador que contiene los posibles resultados de un login.
    /// </summary>
    public enum LoginEnum
    {
        /// <summary>
        /// La contraseña ha expirado.
        /// </summary>
        [Description("La contraseña ha expirado.")]
        ContraseñaExpirada,

        /// <summary>
        /// La contraseña no coincide.
        /// </summary>
        [Description("La contraseña no coincide.")]
        ContraseñaNoCoincide,

        /// <summary>
        /// Error desconocido.
        /// </summary>
        [Description("Error desconocido.")]
        ErrorDesconocido,

        /// <summary>
        /// Login válido.
        /// </summary>
        [Description("Login válido.")]
        LoginValido,

        /// <summary>
        /// No existe sesión activa.
        /// </summary>
        [Description("No existe sesión activa.")]
        NoExisteSesion,

        /// <summary>
        /// Usuario bloqueado.
        /// </summary>
        [Description("Usuario bloqueado.")]
        UsuarioBloqueado,

        /// <summary>
        /// Usuario eliminado.
        /// </summary>
        [Description("Usuario eliminado.")]
        UsuarioEliminado,

        /// <summary>
        /// Usuario no encontrado.
        /// </summary>
        [Description("Usuario no encontrado.")]
        UsuarioNoEncontrado,

        /// <summary>
        /// El usuario ya tiene una sesión abierta.
        /// </summary>
        [Description("El usuario ya tiene una sesión abierta.")]
        YaExisteSesion,
    }
}