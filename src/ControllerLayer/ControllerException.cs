using AbstractLayer;

using EntityLayer;

using LogicLayer;

using ServiceLayer;

using System;


namespace ControllerLayer
{
    internal class ControllerException
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
