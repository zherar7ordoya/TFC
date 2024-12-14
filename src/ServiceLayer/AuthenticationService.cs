using AbstractLayer;
using EntityLayer;
using System;
using System.Linq;

namespace ServiceLayer
{
    /// <summary>
    /// Servicio para manejar el login y logout de los empleados.
    /// </summary>
    public class AuthenticationService
    {
        /// <summary>
        /// Constructor que recibe una instancia de CRUD de Empleado.
        /// </summary>
        /// <param name="crudEmpleado"></param>
        public AuthenticationService(ICRU<Empleado> crudEmpleado)
        {
            _crudEmpleado = crudEmpleado;
        }

        private readonly ICRU<Empleado> _crudEmpleado;
        private readonly int MaximoIntentosFallidos = ConfigurationService.Configuracion.ContraseñaIntentosFallidos;
        private readonly int MaximoDiasVigencia = ConfigurationService.Configuracion.ContraseñaDiasVigencia;

        //......................................................................

        /// <summary>
        /// Loguea a un empleado con un usuario y contraseña.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionLogin"></exception>
        public LoginEnum Login(string usuario, string contraseña)
        {
            var empleado = _crudEmpleado.Read().FirstOrDefault(x => x.Usuario.Equals(usuario));

            // Comprobaciones.
            if (empleado == null) throw new ExceptionLogin(LoginEnum.UsuarioNoEncontrado);
            if (SessionService.Instancia.EstaConectado()) throw new ExceptionLogin(LoginEnum.YaExisteSesion);
            if (empleado.Eliminado) throw new ExceptionLogin(LoginEnum.UsuarioEliminado);
            if (empleado.Bloqueado) throw new ExceptionLogin(LoginEnum.UsuarioBloqueado);
            if (empleado.ContraseñaFecha <= DateTime.Now.AddDays(-MaximoDiasVigencia))  throw new ExceptionLogin(LoginEnum.ContraseñaExpirada);

            // Todo correcto, comprobar contraseña.
            if (contraseña.Encriptar().Equals(empleado.Contraseña))
            {
                SessionService.Instancia.Login(empleado);

                // Restablecer y persistir el contador de intentos fallidos a 0.
                empleado.LoginFallido = 0;
                _crudEmpleado.Update(empleado);

                return LoginEnum.LoginValido;
            }
            else
            {
                // Incrementar y persistir el contador de intentos fallidos.
                empleado.LoginFallido++;
                _crudEmpleado.Update(empleado);

                if (empleado.LoginFallido >= MaximoIntentosFallidos)
                {
                    empleado.Bloqueado = true;
                    _crudEmpleado.Update(empleado);
                    throw new ExceptionLogin(LoginEnum.UsuarioBloqueado);
                }
                throw new ExceptionLogin(LoginEnum.ContraseñaNoCoincide);
            }
        }

        /// <summary>
        /// Desloguea a un empleado.
        /// </summary>
        /// <param name="crudBitacora"></param>
        /// <param name="exit">Bandera para cuando cierra la aplicación.</param>
        /// <exception cref="ExceptionLogin"></exception>
        public void Logout(ICRU<Bitacora> crudBitacora, bool exit = false)
        {
            if (SessionService.Instancia.EstaConectado())
            {
                if (exit || MessageBoxService.Confirmar("¿Confirma que desea cerrar la sesión?"))
                {
                    var empleado = SessionService.Instancia.Empleado;
                    SessionService.Instancia.Logout();
                    GenericFactory.Instanciar<AuditLogService>(crudBitacora).RegistrarLogout(empleado);
                }
            }
            else
            {
                throw new ExceptionLogin(LoginEnum.NoExisteSesion);
            }
        }
    }
}
