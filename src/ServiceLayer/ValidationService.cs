using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ServiceLayer
{
    /// <summary>
    /// Servicio de validación que permite validar entidades de dominio.
    /// </summary>
    public static class ValidationService
    {
        /// <summary>
        /// En C#, un parámetro de salida (out) se utiliza para devolver datos
        /// desde un método. En este caso, el método EsValido está utilizando un
        /// parámetro de salida (out) para devolver una lista de errores de
        /// validación.
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="errores"></param>
        /// <returns></returns>
        public static bool EsValido(object entidad, out List<string> errores)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(entidad, serviceProvider: null, items: null);
            bool valido = Validator.TryValidateObject(entidad, contexto, resultados, true);

            errores = new List<string>();

            foreach (var resultado in resultados)
            {
                errores.Add(resultado.ErrorMessage);
            }

            return valido;
        }
    }
}
