using AbstractLayer;
using EntityLayer;
using LogicLayer;
using ServiceLayer;
using System;
using System.Windows.Forms;


namespace ControllerLayer
{
    /// <summary>
    /// Controlador de la pantalla de inicio de la aplicación (SplashScreen).
    /// </summary>
    public class SplashController : ControllerCRU<Archivo>
    {
        /// <summary>
        /// <see cref="SplashController"/>
        /// </summary>
        public SplashController() : base(ConfigurationService.Configuracion.CarpetaBase)
        {
            _archivoStart = ConfigurationService.Configuracion.ArchivoStart;
            _archivoExit  = ConfigurationService.Configuracion.ArchivoExit;
            _carpetaBase  = ConfigurationService.Configuracion.CarpetaBase;
            _crudArchivo  = GenericFactory.Instanciar<LogicCRU<Archivo>>(_carpetaBase);
        }

        private readonly string _archivoStart;
        private readonly string _archivoExit;
        private readonly string _carpetaBase;
        private readonly LogicCRU<Archivo> _crudArchivo;

        /// <summary>
        /// Delegado para el evento de inicio de la aplicación.
        /// </summary>
        public event EventHandler OnStartApplication;

        /// <summary>
        /// Delegado para el evento de cierre de la aplicación.
        /// </summary>
        public event EventHandler OnExitApplication;

        /// <summary>
        /// Delegado para el evento de restauración de la aplicación.
        /// </summary>
        public event EventHandler OnRestoreApplication;

        /// <summary>
        /// Delegado para el evento de actualización de estado.
        /// </summary>
        public event EventHandler<string> OnStatusUpdate;

        //......................................................................

        private void NotifyStatusUpdate(string message)
        {
            OnStatusUpdate?.Invoke(this, message);
        }

        /// <summary>
        /// Al iniciar la aplicación, se verifica el estado de la misma.
        /// </summary>
        public void Start()
        {
            if (OnApplicationStart())
            {
                NotifyStatusUpdate("Aplicación iniciada correctamente.");
                Application.DoEvents();
                OnStartApplication?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                NotifyStatusUpdate("Aplicación no pudo iniciar.");
                Application.DoEvents();
                OnExitApplication?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// Maneja el proceso de inicio de la aplicación garantizando la consistencia
        /// y confiabilidad de los datos, abarcando los siguientes escenarios:
        /// 
        /// 1. **Aplicación activa:** Si la aplicación ya está en ejecución en otro
        ///    entorno, se omite la detección de inconsistencias para evitar redundancias
        ///    y posibles conflictos.
        /// 
        /// 2. **Cierre correcto previo:** Si la aplicación cerró correctamente
        ///    en su último uso:
        ///    - Se verifican los hashes de los archivos para detectar modificaciones
        ///      externas.
        ///    - Si los hashes coinciden, se actualizan los flags y se permite el
        ///      inicio normal.
        ///    - Si se detectan inconsistencias, se notifica al usuario y se ofrece
        ///      restaurar el estado.
        /// 
        /// 3. **Cierre inesperado previo:** Si no hay registro de un cierre limpio:
        ///    - Se advierte al usuario que el estado de la aplicación es potencialmente
        ///      inestable.
        ///    - El usuario puede optar por continuar con un inicio limitado (omitiendo
        ///      la detección de inconsistencias) o cerrar la aplicación para que
        ///      el administrador verifique los archivos respaldados.
        /// 
        /// 4. **Primer inicio:** Si es la primera vez que se ejecuta la aplicación:
        ///    - Se generan hashes iniciales para establecer un estado base confiable.
        ///    - Esto asegura que cualquier cierre futuro permita detectar modificaciones
        ///      externas incluso si la aplicación no fue cerrada correctamente.
        /// 
        /// Este flujo protege la integridad de los datos al proporcionar mecanismos
        /// robustos para detectar y manejar inconsistencias, asegurando que siempre
        /// exista una referencia confiable para validar los archivos.
        /// 
        /// </summary>
        private bool OnApplicationStart()
        {
            if (FlagService.LeerFlag(_archivoStart)) // ------- APLICACIÓN ACTIVA
            {
                NotifyStatusUpdate("La aplicación se encuentra activa en otro entorno.\n" +
                                   "Omitiendo detección de inconsistencias.");
                return true;
            }
            else // ---------------------------------------- APLICACIÓN INACTIVA
            {
                if (FlagService.LeerFlag(_archivoExit)) // -- CERRÓ CORRECTAMENTE
                {
                    if (GenericFactory.Instanciar<FileHashService>(_crudArchivo).CompararHashes(out string mensaje))
                    {
                        FlagService.EscribirFlag(_archivoStart, true);
                        FlagService.EscribirFlag(_archivoExit, false);
                        NotifyStatusUpdate(mensaje);
                        return true;
                    }
                    else
                    {
                        NotifyStatusUpdate("Se detectaron inconsistencias en los archivos.\n" +
                                           "Contacte al administrador del sistema.");
                        MessageBoxService.Error(mensaje);
                        OnRestoreApplication?.Invoke(this, EventArgs.Empty);
                        return false;
                    }
                }
                else // ---------------------------------- CERRÓ INESPERADAMENTE
                {
                    var advertencia =   "En el último uso, la aplicación se cerró inesperadamente.\n" +
                                        "Usted puede elegir continuar, pero no se recomienda.\n" +
                                        "Contacte al administrador para que realize una verificación.\n\n" +
                                        "¿Desea iniciar la aplicación de todos modos?";
                    if (MessageBoxService.Confirmar(advertencia))
                    {
                        NotifyStatusUpdate("La aplicación se encuentra en un estado inestable.\n" +
                                           "Omitiendo detección de inconsistencias.");
                        return true;
                    }
                    else
                    {
                        MessageBoxService.Informar("La aplicación se cerrará.");
                        Application.Exit();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Al cerrar la aplicación, se registran los hashes de los archivos.
        /// </summary>
        public void ExitApplication()
        {
            GenericFactory.Instanciar<FileHashService>(_crudArchivo).RegistrarHashes();
            FlagService.EscribirFlag(ConfigurationService.Configuracion.ArchivoStart, false);
            FlagService.EscribirFlag(ConfigurationService.Configuracion.ArchivoExit, true);
            OnExitApplication?.Invoke(this, EventArgs.Empty);
        }
    }
}
