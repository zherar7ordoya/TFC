using AbstractLayer;
using EntityLayer;
using System;
using System.Diagnostics;

namespace ServiceLayer
{
    /// <summary>Servicio para manejar excepciones.</summary>
    public class ExceptionService
    {
        /// <summary><see cref="ExceptionService"/></summary>
        /// <param name="crudBitacora">CRUD de Bitacora</param>
        public ExceptionService(ICRU<Bitacora> crudBitacora)
        {
            _crudBitacora = crudBitacora;
        }

        private readonly ICRU<Bitacora> _crudBitacora;

        //......................................................................

        /// <summary>Registra y muestra una excepción.</summary>
        /// <param name="ex"></param>
        public void HandleException(Exception ex)
        {
            // Método para obtener el contexto dinámico
            var contexto = ObtenerContexto();
            RegistrarExcepcion(ex, contexto);
            InformarExcepcion(ex);
        }

        private void RegistrarExcepcion(Exception ex, string contexto)
        {
            GenericFactory.Instanciar<AuditLogService>(_crudBitacora).RegistrarExcepcion(ex, contexto);
        }

        private void InformarExcepcion(Exception ex)
        {
            MessageBoxService.Error(ex.Message);
        }

        //......................................................................

        // Método para obtener el contexto dinámico
        // NOTA.................................................................
        // Nivel 0: ObtenerContexto (donde se llama a GetFrame)
        // Nivel 1: Método que llama a ObtenerContexto(donde se manejó la excepción)
        // Nivel 2: Método o clase que lanzó la excepción originalmente
        private string ObtenerContexto()
        {
            // Obtiene la pila de llamadas (call stack)
            var stackTrace = new StackTrace();
            // Toma el frame anterior al llamado a ExceptionService (salta 2 niveles)
            var frame = stackTrace.GetFrame(2);
            // Obtiene el método y su nombre
            var method = frame.GetMethod();
            var className = method.DeclaringType.Name;
            var methodName = method.Name;

            return $"Desde {className}.{methodName}";
        }
    }
}
