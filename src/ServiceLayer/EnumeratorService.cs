using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;


namespace ServiceLayer
{
    /// <summary>
    /// Conversor de enumeradores a descripciones y viceversa.
    /// </summary>
    public static class EnumeratorService
    {
        /// <summary>
        /// Obtiene la descripción de un enumerador.
        /// </summary>
        /// <param name="enumerador"></param>
        /// <returns></returns>
        public static string ObtenerDescripcionDeEnum(this Enum enumerador)
        {
            FieldInfo field = enumerador.GetType().GetField(enumerador.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute == null ? enumerador.ToString() : attribute.Description;
        }

        /// <summary>
        /// Obtiene las descripciones de una lista de enumeradores.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> ListarDescripciones<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<Enum>().Select(ObtenerDescripcionDeEnum).ToList();
        }

        /// <summary>
        /// Obtiene un enumerador a partir de su descripción.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public static T? ObtenerEnumDeDescripcion<T>(string descripcion) where T : struct, Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .FirstOrDefault(x => ObtenerDescripcionDeEnum(x) == descripcion);
        }
    }
}
