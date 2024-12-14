using AbstractLayer;

using EntityLayer;

using ServiceLayer;

using System;

namespace LogicLayer
{
    internal class LogicException
    {
        /// <summary>Gestor centralizado de excepciones.</summary>
        /// <param name="action">Operaciones que envuelve.</param>
        public void ExceptionHandling(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var carpetaBase = ConfigurationService.Configuracion.CarpetaBase;
                var crudBitacora = GenericFactory.Instanciar<LogicCRU<Bitacora>>(carpetaBase);
                GenericFactory.Instanciar<ExceptionService>(crudBitacora).HandleException(ex);
            }
        }
    }
}
