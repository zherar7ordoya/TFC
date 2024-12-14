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
    /// Controlador de PermisosRolForm.
    /// </summary>
    public class RolesController : ControllerCRU<Rol>
    {
        /// <summary>
        /// Constructor para un control total de la vista.
        /// </summary>
        /// <param name="formulario"></param>
        public RolesController(Form formulario)
        {
            PermisosRolForm = formulario;

            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    _roles = Read().ToList();
                    _permisos = GenericFactory.Instanciar<LogicCRU<Permiso>>().Read().ToList();
                });

            _revertidor = new Rol();
            _comprobador = new Rol();

            _otorgado = new Permiso();
            _disponible = new Permiso();

            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }

        // Estructuras de datos
        private List<Rol> _roles;
        private List<Permiso> _permisos;
        private Rol _revertidor, _comprobador;
        private Permiso _disponible, _otorgado;
        private bool _actualizando = false, _modificado = false;

        // Componentes de la vista
        private readonly Form PermisosRolForm;
        private DataGridView RolesDgv, PermisosDisponiblesDgv, PermisosOtorgadosDgv;
        private MaterialCheckbox BloqueadoCheckBox, EliminadoCheckBox;
        private MaterialTextBox2 RolIdTextBox, RolDescripcionTextBox;
        private MaterialButton BuscarRolButton, CrearRolButton, AgregarPermisoButton, QuitarPermisoButton, GuardarModificacionesButton;

        //......................................................................

        private void AsignarControles()
        {
            RolesDgv                    = GetControl<DataGridView>("RolesDgv");
            PermisosDisponiblesDgv      = GetControl<DataGridView>("PermisosDisponiblesDgv");
            PermisosOtorgadosDgv        = GetControl<DataGridView>("PermisosOtorgadosDgv");
            BloqueadoCheckBox           = GetControl<MaterialCheckbox>("BloqueadoCheckBox");
            EliminadoCheckBox           = GetControl<MaterialCheckbox>("EliminadoCheckBox");
            RolIdTextBox                = GetControl<MaterialTextBox2>("RolIdTextBox");
            RolDescripcionTextBox       = GetControl<MaterialTextBox2>("RolDescripcionTextBox");
            BuscarRolButton             = GetControl<MaterialButton>("BuscarRolButton");
            CrearRolButton              = GetControl<MaterialButton>("CrearRolButton");
            AgregarPermisoButton        = GetControl<MaterialButton>("AgregarPermisoButton");
            QuitarPermisoButton         = GetControl<MaterialButton>("QuitarPermisoButton");
            GuardarModificacionesButton = GetControl<MaterialButton>("GuardarModificacionesButton");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)PermisosRolForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            PermisosRolForm.FormClosing       += (s, e) => FormClosing();
            RolesDgv.RowEnter                 += (s, e) => InterceptarDgvPrincipal(e.RowIndex);
            PermisosDisponiblesDgv.RowEnter   += (s, e) => _disponible = SeleccionarPermiso(PermisosDisponiblesDgv, e.RowIndex);
            PermisosOtorgadosDgv.RowEnter     += (s, e) => _otorgado = SeleccionarPermiso(PermisosOtorgadosDgv, e.RowIndex);
            BuscarRolButton.Click             += (s, e) => BuscarEntidad();
            CrearRolButton.Click              += (s, e) => CrearEntidad();
            GuardarModificacionesButton.Click += (s, e) => GuardarModificaciones();
            AgregarPermisoButton.Click        += (s, e) => AgregarQuitarPermiso(_disponible, agregar: true);
            QuitarPermisoButton.Click         += (s, e) => AgregarQuitarPermiso(_otorgado, agregar: false);
            BloqueadoCheckBox.CheckedChanged  += (s, e) => OnModificado();
            EliminadoCheckBox.CheckedChanged  += (s, e) => OnModificado();
            RolDescripcionTextBox.TextChanged += (s, e) => OnModificado();
        }

        private void OnModificado()
        {
            if (!_actualizando) _modificado = true;
            GuardarModificacionesButton.Enabled = _modificado;
        }

        private void OnModificado(bool modificado)
        {
            _modificado = modificado;
            GuardarModificacionesButton.Enabled = modificado;
        }

        private void InicializarVista()
        {
            RolesDgv.DataSource = null;
            RolesDgv.DataSource = _roles;
            DataGridViewService.SimularListbox(RolesDgv, "Descripcion");
        }

        //......................................................................

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
                    RolesDgv.ClearSelection();
                    RolesDgv.Rows[index].Selected = true;
                    OnModificado(false);
                    RolesDgv_RowEnter(index, revertir: true);
                }
                else
                {
                    RolesDgv.ClearSelection();
                    RolesDgv.Rows[index].Selected = true;
                    return;
                }
            }
            else
            {
                RolesDgv_RowEnter(index, revertir: false);
            }
        }

        private void RolesDgv_RowEnter(int index, bool revertir = false)
        {
            if (index < 0) return;

            var rol = (Rol)RolesDgv.Rows[index].DataBoundItem;
            if (rol == null) return;

            if (revertir)
            {
                RevertirModificaciones(rol);
                RolesDgv.Rows[index].Selected = true;
            }

            ActualizarRevertidor(rol);
            TranscribirSeleccion(rol);
            ActualizarPermisosDgv(rol);
        }

        private void RevertirModificaciones(Rol rol)
        {
            if (_revertidor == null)
            {
                MessageBoxService.Error("Error al tratar de revertir.");
                return;
            }

            rol.Id = _revertidor.Id;
            rol.Descripcion = _revertidor.Descripcion;
            rol.Bloqueado = _revertidor.Bloqueado;
            rol.Eliminado = _revertidor.Eliminado;
            rol.Permisos = new List<Autorizacion>(_revertidor.Permisos);
        }

        private void ActualizarRevertidor(Rol rol)
        {
            _revertidor = new Rol
            {
                Id = rol.Id,
                Descripcion = rol.Descripcion,
                Bloqueado = rol.Bloqueado,
                Eliminado = rol.Eliminado,
                Permisos = new List<Autorizacion>(rol.Permisos)
            };
        }

        private void TranscribirSeleccion(Rol rol)
        {
            _actualizando = true;
            try
            {
                RolIdTextBox.Text = rol.Id.ToString();
                RolDescripcionTextBox.Text = rol.Descripcion;
                BloqueadoCheckBox.Checked = rol.Bloqueado;
                EliminadoCheckBox.Checked = rol.Eliminado;
            }
            finally { _actualizando = false; }
        }

        private void ActualizarPermisosDgv(Rol rol)
        {
            var grabados = rol.ObtenerPermisos().OfType<Permiso>().ToList();

            // ¿Por qué no usar grabados? Porque la descripción de los permisos se
            // grabaron al momento de otorgarlos, y por ende, están desactualizados.
            var otorgados = _permisos.Where(x => grabados.Any(y => y.Id == x.Id)).ToList();
            var disponibles = _permisos.Where(x => !grabados.Any(y => y.Id == x.Id)).ToList();

            ActualizarPermisosDgv(PermisosOtorgadosDgv, otorgados);
            ActualizarPermisosDgv(PermisosDisponiblesDgv, disponibles);
        }

        private void ActualizarPermisosDgv(DataGridView dgv, List<Permiso> permisos)
        {
            dgv.DataSource = null;
            dgv.DataSource = permisos;
            DataGridViewService.SimularListbox(dgv, "Descripcion");
        }

        //......................................................................

        private Permiso SeleccionarPermiso(DataGridView dgv, int index)
        {
            return index >= 0 ? (Permiso)dgv.Rows[index].DataBoundItem : null;
        }

        //......................................................................

        private void BuscarEntidad()
        {
            PermisosRolForm.Visible = false;

            var buscable = new RolSearch(_roles);
            var buscador = new SearchService<Rol>(buscable);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                var seleccionado = buscador.SelectedItem;
                DataGridViewService.SeleccionarFila(RolesDgv, seleccionado);
            }

            PermisosRolForm.Visible = true;
        }

        private void CrearEntidad()
        {
            var respuesta = MessageBoxService.Confirmar("¿Está seguro de crear una nueva entrada?");
            if (!respuesta) return;

            var rol = new Rol
            {
                Bloqueado = true,
                Descripcion = "(nuevo rol)",
            };

            // Recordatorio: agregar entrada a Xml, agregar entrada a List,
            // seleccionar entrada en el DGV. Es decir, trabajar con "entrada".
            var entrada = Create(rol);
            _roles.Add(entrada);

            InicializarVista();
            DataGridViewService.SeleccionarFila(RolesDgv, entrada);
            MessageBoxService.Informar($"Se ha creado la siguiente entrada:\n{entrada}");
        }


        private void AgregarQuitarPermiso(Permiso permiso, bool agregar)
        {
            var rol = (Rol)RolesDgv.CurrentRow?.DataBoundItem;

            if (rol != null && permiso != null)
            {
                if (agregar) rol.Permisos.Add(permiso);
                else 
                {
                    //rol.Permisos.Remove(permiso); 
                    var permisoARemover = rol.Permisos.FirstOrDefault(p => p.Id == permiso.Id);
                    if (permisoARemover != null)
                    {
                        rol.Permisos.Remove(permisoARemover);
                    }
                }

                OnModificado(true);
                ActualizarPermisosDgv(rol);
            }
        }

        // Comienza «Guardar»...................................................
        private void GuardarModificaciones()
        {
            _comprobador = RecuperarDatos();
            if (VerificarDatos(out var rol)) PersistirEntidad(rol);
        }

        private Rol RecuperarDatos()
        {
            return new Rol
            {
                Id = int.Parse(RolIdTextBox.Text),
                Descripcion = RolDescripcionTextBox.Text,
                Bloqueado = BloqueadoCheckBox.Checked,
                Eliminado = EliminadoCheckBox.Checked
            };
        }

        private bool VerificarDatos(out Rol rol)
        {
            rol = (Rol)RolesDgv.CurrentRow?.DataBoundItem;
            if (rol == null)
            {
                MessageBoxService.Error("Debe seleccionar un ítem.");
                return false;
            }

            var respuesta = MessageBoxService.Confirmar("¿Está seguro de que desea guardar los cambios?");
            if (!respuesta) return false;

            /*** ..............Acaba "out", entra _comprobador..............***/

            // Comprobar que campos de valor único no se repitan.
            var repetido = _roles.Any(x => x.Id != _comprobador.Id && x.Descripcion == _comprobador.Descripcion);
            if (repetido)
            {
                MessageBoxService.Error("La descripción ya existe.");
                return false;
            }

            // Comprobaciones finalizadas.
            return true;
        }

        // En caso de refactorizar, seguir el modelo de EmpleadosController.
        private void PersistirEntidad(Rol rol)
        {
            if (ValidationService.EsValido(_comprobador, out List<string> errores))
            {
                ActualizarEntidad(rol);

                GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    var exito = Update(rol);

                    if (exito)
                    {
                        OnModificado(false);
                        RolesDgv.Refresh();
                        DataGridViewService.SeleccionarFila(RolesDgv, rol);
                        MessageBoxService.Informar("Cambios guardados correctamente.");
                    }
                    else { MessageBoxService.Error("No se han podido guardar los cambios."); }
                });
            }
            else { MessageBoxService.Error($"Errores de validación:\n{string.Join("\n", errores)}"); }
        }

        private void ActualizarEntidad(Rol rol)
        {
            rol.Id = _comprobador.Id;
            rol.Descripcion = _comprobador.Descripcion;
            rol.Bloqueado = _comprobador.Bloqueado;
            rol.Eliminado = _comprobador.Eliminado;
        }
        // Termina «Guardar»....................................................

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
