using System;

namespace AbstractLayer
{
    /// <summary>Implementa el diseño Generic Factory.</summary>
    public static class GenericFactory
    {
        /// <summary>
        /// Instancia un objeto de tipo T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Instanciar<T>() where T : class, new()
        {
            return new T();
        }

        /// <summary>
        /// Instancia un objeto de tipo T con argumentos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T Instanciar<T>(params object[] args) where T : class
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}