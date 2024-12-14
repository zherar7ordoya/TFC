using AbstractLayer;

using EntityLayer;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;

namespace ControllerLayer
{
    /// <summary>Controlador de AuthenticationForm.</summary>
    public class AuthenticationController : ControllerCRU<Empleado>
    {
        /// <summary>
        /// Accede al CRUD de Empleado para verificar las credenciales del usuario.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool VerificarCredenciales(string username, string password)
        {
            var empleados = new List<Empleado>();


            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    empleados = (List<Empleado>)Read();
                });
            
            var empleado = empleados.FirstOrDefault(e => e.Usuario == username && e.Contraseña == password.Encriptar());

            if (empleado == null) return false;
            if (empleado.Bloqueado) return false;
            if (empleado.Eliminado) return false;

            bool isAdmin = false;

            foreach (var autorizacion in empleado.Autorizaciones)
            {
                if (autorizacion is Rol rol && rol.Descripcion == "SYSADMIN")
                {
                    isAdmin = true;
                    break;
                }
            }
            return isAdmin;
        }
    }
}
