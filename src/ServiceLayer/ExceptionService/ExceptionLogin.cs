using AbstractLayer;
using System;

namespace ServiceLayer
{
    /// <summary>
    /// Excepciones al servicio de LoginService.
    /// </summary>
    public class ExceptionLogin : Exception
    {
        /// <summary>
        /// Constructor que recibe el resultado de la operación.
        /// </summary>
        /// <param name="resultado"></param>
        public ExceptionLogin(LoginEnum resultado)
        {
            Resultado = resultado;
        }

        /// <summary>
        /// Resultado de la operación.
        /// </summary>
        public LoginEnum Resultado { get; private set; }
    }
}
