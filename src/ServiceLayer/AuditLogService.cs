using AbstractLayer;
using EntityLayer;
using System;
using System.IO;

namespace ServiceLayer
{
    /// <summary>
    /// Gestiona la persistencia de eventos de auditoría en la bitácora.
    /// </summary>
    public class AuditLogService
    {
        /// <summary>
        /// La clase necesita un CRUD para persistir las entradas de bitácora.
        /// </summary>
        /// <param name="crudBitacora"></param>
        public AuditLogService(ICRU<Bitacora> crudBitacora)
        {
            _CRUD = crudBitacora;
        }

        private readonly ICRU<Bitacora> _CRUD;
        private readonly string _carpetaBase = ConfigurationService.Configuracion.CarpetaBase;

        //......................................................................

        // Método auxiliar para persistir una bitácora individual.
        private Bitacora EscribirBitacora(Bitacora entrada)
        {
            // Verificar si la carpeta de bitácoras existe, si no, crearla.
            if (!Directory.Exists(_carpetaBase))
            {
                Directory.CreateDirectory(_carpetaBase);
            }
            return _CRUD.Create(entrada);
        }

        //......................................................................

        /// <summary>
        /// Registra un evento de auditoría en la bitácora.
        /// </summary>
        /// <param name="zip">Nombre del archivo ZIP generado.</param>
        /// <param name="exito">Resultado de la operación de compresión.</param>
        /// <returns>El registro generado en la bitácora.</returns>
        public Bitacora RegistrarBackup(string zip, bool exito)
        {
            var empleado = SessionService.Instancia.Empleado?.ToString() ?? "Desconocido";
            var entrada = new Bitacora
            {
                Tipo = EventoEnum.Backup,
                Timestamp = DateTime.Now,
                Empleado = empleado,
                Detalle = $"Backup realizado en {zip}. Éxito: {exito}",
                Zip = zip
            };
            return EscribirBitacora(entrada);
        }

        /// <summary>
        /// Registra un evento de auditoría en la bitácora.
        /// </summary>
        /// <param name="zip">Nombre del archivo ZIP restaurado.</param>
        /// <param name="exito">Resultado de la operación de compresión.</param>
        /// <returns>El registro generado en la bitácora.</returns>
        public Bitacora RegistrarRestore(string zip, bool exito)
        {
            var empleado = SessionService.Instancia.Empleado?.ToString() ?? "Desconocido";
            var entrada = new Bitacora
            {
                Tipo = EventoEnum.Restore,
                Timestamp = DateTime.Now,
                Empleado = empleado,
                Detalle = $"Restore realizado desde {zip}. Éxito: {exito}",
                Zip = zip,
            };
            return EscribirBitacora(entrada);
        }

        /// <summary>
        /// Registra un evento de auditoría en la bitácora.
        /// </summary>
        /// <param name="exito">Especifica un login exitoso o fallido.</param>
        /// <param name="resultado">Especialmente, tipo de fallo de login.</param>
        /// <returns>El registro generado en la bitácora.</returns>
        public Bitacora RegistrarLogin(bool exito, LoginEnum resultado)
        {
            var empleado = SessionService.Instancia.Empleado?.ToString() ?? "Desconocido";
            var entrada = new Bitacora
            {
                Tipo = EventoEnum.Login,
                Timestamp = DateTime.Now,
                Empleado = empleado,
                Detalle = $"Login {(exito ? "exitoso" : "fallido")}: {resultado}",
                Zip = "No genera",
            };
            return EscribirBitacora(entrada);
        }

        /// <summary>
        /// Registra un evento de auditoría en la bitácora.
        /// </summary>
        /// <param name="empleado">Usuario que acaba de solicitar el logout.</param>
        /// <returns>El registro generado en la bitácora.</returns>
        public Bitacora RegistrarLogout(Empleado empleado)
        {
            var entrada = new Bitacora
            {
                Tipo = EventoEnum.Logout,
                Timestamp = DateTime.Now,
                Empleado = empleado?.ToString() ?? "Desconocido",
                Detalle = "Logout realizado",
                Zip = "No genera",
            };
            return EscribirBitacora(entrada);
        }

        /// <summary>
        /// Registra un evento de auditoría en la bitácora.
        /// </summary>
        /// <param name="ex">Objeto excepción.</param>
        /// <param name="contexto">Método que generó la llamada.</param>
        /// <returns></returns>
        public Bitacora RegistrarExcepcion(Exception ex, string contexto)
        {
            var empleado = SessionService.Instancia.Empleado?.ToString() ?? "Desconocido";
            var entrada = new Bitacora
            {
                Tipo = EventoEnum.Exception,
                Timestamp = DateTime.Now,
                Empleado = empleado,
                Detalle = $"Excepción: {ex.Message}. Contexto: {contexto}. StackTrace: {ex.StackTrace}",
                Zip = "No genera",
            };
            return EscribirBitacora(entrada);
        }
    }
}