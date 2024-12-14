using EntityLayer;

namespace ServiceLayer
{
    /// <summary>
    /// Servicio de gestión de sesiones. Implementa el patrón Singleton.
    /// </summary>
    public class SessionService
    {
        // Constructor privado
        private SessionService() { }

        private static readonly object _lock = new object();
        private static SessionService _instancia;

        /// <summary>
        /// Propiedad de acceso a la instancia única de la clase.
        /// </summary>
        public static SessionService Instancia
        {
            get
            {
                // Ver "Double-Check Locking".
                if (_instancia == null)
                {
                    lock (_lock)
                    {
                        if (_instancia == null)
                        {
                            _instancia = new SessionService();
                        }
                    }
                }
                return _instancia;
            }
        }

        private Empleado _empleado;

        /// <summary> Propiedad de acceso al empleado que ha iniciado sesión. </summary>
        public Empleado Empleado
        {
            get { return _empleado; }
            private set { _empleado = value; }
        }

        /// <summary>Inicia sesión con un empleado.</summary>
        /// <param name="empleado"></param>
        public void Login(Empleado empleado) => _empleado = empleado;

        /// <summary> Cierra la sesión actual.</summary>
        public void Logout() => _empleado = null;

        /// <summary> Indica si hay una sesión activa.</summary>
        public bool EstaConectado() => _empleado != null;
    }
}

