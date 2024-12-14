using AbstractLayer;
using EntityLayer;
using LogicLayer;
using MaterialSkin2Framework.Controls;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace ControllerLayer
{
    /// <summary>
    /// Controlador de PermisosForm.
    /// </summary>
    public class PermisosController : ControllerCRU<Empleado>
    {
        /// <summary>
        /// <see cref="PermisosController"/>
        /// </summary>
        /// <param name="formulario"></param>
        public PermisosController(Form formulario)
        {
            PermisosForm   = formulario;

            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    _empleados = Read().Where(x => !x.Bloqueado && !x.Eliminado).ToList();
                    _roles = GenericFactory.Instanciar<LogicCRU<Rol>>().Read().Where(x => !x.Bloqueado && !x.Eliminado).ToList();
                    _permisos = GenericFactory.Instanciar<LogicCRU<Permiso>>().Read().ToList();
                });
            
            _empleadoSeleccionado = new Empleado();
            _empleadoRevertidor   = new Empleado();

            // Inicialización de la vista
            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }

        // Estructuras de datos
        // No ha validación porque el usuario no ingresa datos:
        //_comprobador = new Empleado();
        //_actualizando = false;
        private Empleado _empleadoSeleccionado,
                         _empleadoRevertidor;
        private List<Empleado> _empleados;
        private List<Rol> _roles;
        private List<Permiso> _permisos;
        private bool _modificado = false;

        // Componentes de la vista
        private readonly Form PermisosForm;

        DataGridView EmpleadosDgv,
                     RolesDgv,
                     PermisosDgv;

        TreeView AutorizacionesTree;

        MaterialButton BuscarEmpleadoButton,
                       AgregarRolButton,
                       AgregarPermisoButton,
                       QuitarRolPermisoButton,
                       GuardarModificacionesButton;

        //......................................................................

        private void AsignarControles()
        {
            EmpleadosDgv                = GetControl<DataGridView>("EmpleadosDgv");
            RolesDgv                    = GetControl<DataGridView>("RolesDgv");
            PermisosDgv                 = GetControl<DataGridView>("PermisosDgv");
            AutorizacionesTree          = GetControl<TreeView>("AutorizacionesTree");
            AgregarRolButton            = GetControl<MaterialButton>("AgregarRolButton");
            AgregarPermisoButton        = GetControl<MaterialButton>("AgregarPermisoButton");
            QuitarRolPermisoButton      = GetControl<MaterialButton>("QuitarRolPermisoButton");
            GuardarModificacionesButton = GetControl<MaterialButton>("GuardarModificacionesButton");
            BuscarEmpleadoButton        = GetControl<MaterialButton>("BuscarEmpleadoButton");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)PermisosForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            PermisosForm.FormClosing      += (s, e) => FormClosing();
            EmpleadosDgv.RowEnter               += (s, e) => InterceptarDgvPrincipal(e.RowIndex);
            BuscarEmpleadoButton.Click          += (s, e) => BuscarEntidad();
            AgregarRolButton.Click              += (s, e) => AgregarRol();
            AgregarPermisoButton.Click          += (s, e) => AgregarPermiso();
            QuitarRolPermisoButton.Click        += (s, e) => QuitarRolPermiso();
            GuardarModificacionesButton.Click   += (s, e) => GuardarModificaciones();
        }

        private void InicializarVista()
        {
            EmpleadosDgv.DataSource = null;
            EmpleadosDgv.DataSource = _empleados;
            DataGridViewService.SimularListbox(EmpleadosDgv, "Nombre", "Apellido");
        }

        //\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\\

        private void InterceptarDgvPrincipal(int index)
        {
            if (_modificado)
            {
                var resultado = MessageBoxService.Advertir("Tiene cambios sin guardar. ¿Desea guardarlos antes de cambiar de rol?");
                if (resultado == DialogResult.Yes)
                {
                    GuardarModificaciones();
                    OnModificado(false);
                }
                else if (resultado == DialogResult.No)
                {
                    EmpleadosDgv.ClearSelection();
                    EmpleadosDgv.Rows[index].Selected = true;
                    OnModificado(false);
                    EmpleadosDgv_RowEnter(index, revertir: true);
                }
                else
                {
                    EmpleadosDgv.ClearSelection();
                    EmpleadosDgv.Rows[index].Selected = true;
                    return;
                }
            }
            else { EmpleadosDgv_RowEnter(index, revertir: false); }
        }

        private void EmpleadosDgv_RowEnter(int index, bool revertir = false)
        {
            if (index < 0) return;

            _empleadoSeleccionado = (Empleado)EmpleadosDgv.Rows[index].DataBoundItem;

            if (_empleadoSeleccionado != null)
            {
                // Revertir los cambios desde el rol revertidor.
                if (revertir && _empleadoRevertidor != null)
                {
                    _empleadoSeleccionado.Id = _empleadoRevertidor.Id;
                    _empleadoSeleccionado.Autorizaciones = new List<Autorizacion>(_empleadoRevertidor.Autorizaciones);
                }

                // Crear una copia del rol para revertir cambios si es necesario.
                _empleadoRevertidor = new Empleado
                {
                    Id = _empleadoSeleccionado.Id,
                    Autorizaciones = new List<Autorizacion>(_empleadoSeleccionado.Autorizaciones)
                };
                EmpleadoSeleccionado_ActualizarVista();
            }
        }

        private void EmpleadoSeleccionado_ActualizarVista()
        {
            CargarListado(_empleadoSeleccionado.Autorizaciones.OfType<Rol>().ToList(),
                          _roles,
                          RolesDgv);
            CargarListado(_empleadoSeleccionado.Autorizaciones.OfType<Permiso>().ToList(),
                          _permisos,
                          PermisosDgv);
            CargarAutorizaciones(_empleadoSeleccionado);
        }

        private void CargarListado<T>(List<T> otorgados,
                                      List<T> disponibles,
                                      DataGridView dgv) where T : Autorizacion
        {
            var disponiblesFiltrados = disponibles.Where(x => !otorgados.Any(y => y.Id == x.Id)).ToList();
            dgv.DataSource = null;
            dgv.DataSource = disponiblesFiltrados;
            DataGridViewService.SimularListbox(dgv, "Descripcion");
        }

        // Una carga directa, sin necesidad del bendito "root".
        // ¿Nodo nuevo (permiso)? Se agrega directamente a Control.Nodes
        // NOTA: En el TreeView, se cargan descripciones.
        // Por lo tanto, para recuperar se hace desde descripciones.
        //private void CargarAutorizaciones(Empleado empleado)
        //{
        //    AutorizacionesTree.Nodes.Clear();

        //    foreach (var autorizacion in empleado.Autorizaciones)
        //    {
        //        if (autorizacion is Rol rol)
        //        {
        //            var rolNode = new TreeNode(_roles.Find(x => x.Id == rol.Id).Descripcion);

        //            foreach (var item in rol.ObtenerPermisos())
        //            {
        //                if (item is Permiso permiso)
        //                {
        //                    var permisoNode = new TreeNode(_permisos.Find(x => x.Id == permiso.Id).Descripcion);
        //                    rolNode.Nodes.Add(permisoNode);
        //                }
        //            }
        //            AutorizacionesTree.Nodes.Add(rolNode);
        //        }
        //        else if (autorizacion is Permiso permiso)
        //        {
        //            var permisoNode = new TreeNode(permiso.Descripcion);
        //            AutorizacionesTree.Nodes.Add(permisoNode);
        //        }
        //    }

        //    AutorizacionesTree.ExpandAll();
        //}

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
        AuthorizationService.ObtenerPermisos(...)                         
        PermisosUsuarioController.CargarAutorizaciones(...)               [aquí]
        */
        //......................................................................

        private void CargarAutorizaciones(Empleado empleado)
        {
            AutorizacionesTree.Nodes.Clear();

            // Obtener roles actualizados desde el archivo XML
            var rolesActualizados = GenericFactory.Instanciar<LogicCRU<Rol>>().Read().ToList();
            var permisosActualizados = GenericFactory.Instanciar<LogicCRU<Permiso>>().Read().ToList();

            foreach (var autorizacion in empleado.Autorizaciones)
            {
                if (autorizacion is Rol rol)
                {
                    // En lugar de usar el rol del empleado, busca el rol actualizado en el archivo XML
                    var rolActualizado = rolesActualizados.FirstOrDefault(r => r.Id == rol.Id);
                    if (rolActualizado != null)
                    {
                        var rolNode = new TreeNode(rolActualizado.Descripcion);

                        foreach (var item in rolActualizado.ObtenerPermisos())
                        {
                            if (item is Permiso permiso)
                            {
                                var permisoNode = new TreeNode(permisosActualizados.FirstOrDefault(p => p.Id == permiso.Id)?.Descripcion ?? permiso.Descripcion);
                                rolNode.Nodes.Add(permisoNode);
                            }
                        }
                        AutorizacionesTree.Nodes.Add(rolNode);
                    }
                }
                else if (autorizacion is Permiso permiso)
                {
                    var permisoNode = new TreeNode(permiso.Descripcion);
                    AutorizacionesTree.Nodes.Add(permisoNode);
                }
            }

            AutorizacionesTree.ExpandAll();
        }


        //......................................................................

        private void BuscarEntidad()
        {
            PermisosForm.Visible = false;

            var buscable = new EmpleadoSearch(_empleados);
            var buscador = new SearchService<Empleado>(buscable);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                var seleccionado = buscador.SelectedItem;
                DataGridViewService.SeleccionarFila(EmpleadosDgv, seleccionado);
            }

            PermisosForm.Visible = true;
        }

        private void AgregarRol()
        {
            if (RolesDgv.CurrentRow == null)
            {
                MessageBoxService.Informar("Seleccione un rol para agregar.");
                return;
            }
            var rol = (Rol)RolesDgv.CurrentRow.DataBoundItem;
            _empleadoSeleccionado.Autorizaciones.Add(rol);
            OnModificado(true);
            EmpleadoSeleccionado_ActualizarVista();
        }

        private void AgregarPermiso()
        {
            if (PermisosDgv.CurrentRow == null)
            {
                MessageBoxService.Informar("Seleccione un permiso para agregar.");
                return;
            }
            var permiso = (Permiso)PermisosDgv.CurrentRow.DataBoundItem;
            _empleadoSeleccionado.Autorizaciones.Add(permiso);
            OnModificado(true);
            EmpleadoSeleccionado_ActualizarVista();
        }

        // En el TreeView, se cargan descripciones.
        // Por lo tanto, para recuperar se hace desde descripciones.
        private void QuitarRolPermiso()
        {
            if (AutorizacionesTree.SelectedNode == null)
            {
                MessageBoxService.Informar("Seleccione un rol o permiso para quitar.");
                return;
            }

            if (AutorizacionesTree.SelectedNode != null)
            {
                var descripcion = AutorizacionesTree.SelectedNode.Text;
                var autorizacion = _empleadoSeleccionado.Autorizaciones.FirstOrDefault(x => x.Descripcion == descripcion);

                if (autorizacion != null)
                {
                    _empleadoSeleccionado.Autorizaciones.Remove(autorizacion);
                    OnModificado(true);
                    EmpleadoSeleccionado_ActualizarVista();
                }
            }
        }

        // Comienza «Guardar»...................................................

        private void GuardarModificaciones()
        {
            if (MessageBoxService.Confirmar("¿Desea guardar los cambios realizados?"))
            {
                GenericFactory
                    .Instanciar<ControllerException>()
                    .ExceptionHandling(() =>
                    {
                        bool exito = Update(_empleadoSeleccionado);

                        if (exito)
                        {
                            OnModificado(false);
                            MessageBoxService.Informar("Cambios guardados correctamente.");
                        }
                        else { MessageBoxService.Advertir("Error al guardar los cambios. Por favor, inténtelo de nuevo."); }

                    });
            }
            else { MessageBoxService.Informar("Cambios no guardados."); }
        }

        // Termina «Guardar»....................................................

        private void OnModificado(bool modificado)
        {
            _modificado = modificado;
            GuardarModificacionesButton.Enabled = modificado;
        }

        private void FormClosing()
        {
            if (_modificado)
            {
                var resultado = MessageBoxService.Advertir("Tiene cambios sin guardar. ¿Desea guardarlos antes de cerrar?");

                if (resultado == DialogResult.Yes)
                {
                    GuardarModificaciones();
                }
            }
        }
    }
}
