using AbstractLayer;

using EntityLayer;

using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    /// <summary>
    /// Servicio de gestión de permisos. Implementa el patrón Composite.
    /// </summary>
    public class AuthorizationService
    {
        private readonly SessionService _sessionService;

        /// <summary>
        /// Constructor que recibe una instancia de SessionService.
        /// </summary>
        /// <param name="sessionService"></param>
        public AuthorizationService(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        //......................................................................
        /*
        DIFERENCIA ENTRE MODELO JERÁRQUICO Y MODELO RELACIONAL
        En este sistema, el modelo jerárquico (XML) presenta una limitación en 
        comparación con el modelo relacional (SQL). En un sistema relacional, 
        cuando los permisos de un rol son actualizados, esos cambios se reflejan
        automáticamente en todos los empleados que tienen asignado dicho rol.
        Sin embargo, en el modelo jerárquico, los permisos asignados a los roles
        de los empleados no se actualizan automáticamente. Para asegurar que los
        permisos sean siempre correctos y estén actualizados, es necesario
        ignorar los permisos almacenados en el objeto "Empleado" y, en su lugar,
        consultar los permisos directamente desde el archivo XML de roles.
        Esta reconstrucción de los permisos de rol se hace en:
        AuthorizationService.ObtenerPermisos(...)                         [aquí]
        PermisosUsuarioController.CargarAutorizaciones(...)
        */
        //......................................................................

        /// <summary>
        /// Gestiona los permisos de un empleado.
        /// </summary>
        /// <param name="activos"></param>
        /// <param name="crud"></param>
        /// <returns></returns>
        public HashSet<PermisoEnum> ObtenerPermisos(bool activos, ICRU<Rol> crud)
        {
            var empleado = _sessionService.Empleado;
            if (empleado == null) return new HashSet<PermisoEnum>();

            var roles = crud.Read().ToList();

            if (activos)
            {
                roles = roles.Where(rol => !rol.Bloqueado && !rol.Eliminado).ToList();
            }

            var permisos = new HashSet<PermisoEnum>();

            foreach (var autorizacion in empleado.Autorizaciones)
            {
                if (autorizacion is Rol rol)
                {
                    var tipo = roles.FirstOrDefault(x => x.Id == rol.Id);

                    if (tipo != null)
                    {
                        permisos.UnionWith(tipo.ObtenerPermisos().OfType<Permiso>().Select(x => x.Tipo));
                    }
                }
                else
                {
                    permisos.Add(((Permiso)autorizacion).Tipo);
                }
            }

            return permisos;
        }
    }
}
