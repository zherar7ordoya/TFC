////////10////////20////////30////////40////////50////////60////////70////////80////////90///////100///////110///////120

using AbstractLayer;
using ControllerLayer;
using EntityLayer;
using MaterialSkin2Framework.Controls;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***

NUEVOS FORMULARIOS:
    *) Agregar a MenuPrincipal
    *) Agregar a PermisoEnum
    *) Agregar a Permiso.xml
    *) Agregar a Rol.xml (System Administrator)
    *) Agregar a método AsignarEventos
    *) Agregar a método AsignarPermisos (llamada a VisibilizarItems)

*** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***/

namespace ViewLayer
{
    /// <summary>Formulario principal de la aplicación.</summary>
    public partial class MenuForm : MaterialForm
    {
        /// <summary><see cref="MenuForm"/></summary>
        public MenuForm()
        {
            InitializeComponent();

            // Poner el fondo del MDI en color Indigo 50 (Material Design).
            Controls.OfType<MdiClient>()
                    .FirstOrDefault()
                    .BackColor = Color.FromArgb(232, 234, 246);

            AsignarEventos();
            AsignarPermisos();
        }

        //private readonly BasePresentation _base = Factory.Instanciar<BasePresentation>();
        private readonly Dictionary<Type, Form> _openForms = new Dictionary<Type, Form>();

        //......................................................................

        private void AsignarEventos()
        {
            AsignarEventos(
                //
                // Menú Archivo
                //
                (LoginItem,  () => MostrarFormulario<LoginAccesoForm>()),
                (LogoutItem, () => Logout()),
                (SalirItem,  () => OnClosing(this, new FormClosingEventArgs(CloseReason.UserClosing, false))),
                //
                // Menú Venta
                //
                (CapturaItem,     () => MostrarFormulario<CapturadorForm>()),
                (FacturacionItem, () => MostrarFormulario<FacturadorForm>()),
                //
                // Menú Logística
                //
                (DespachoItem,    () => MostrarFormulario<DespachadorForm>()),
                (LiquidacionItem, () => MostrarFormulario<LiquidadorForm>()),
                //
                // Menú Gestión
                //
                (CamionesItem,      () => MostrarFormulario<CamionesForm>()),
                (ClientesItem,      () => MostrarFormulario<ClientesForm>()),
                (EmpleadosItem,     () => MostrarFormulario<EmpleadosForm>()),
                (LocacionesItem,    () => MostrarFormulario<LocacionesForm>()),
                (TarifasItem,       () => MostrarFormulario<TarifasForm>()),
                (DashboardItem,     () => MostrarFormulario<DashboardForm>()),
                //
                // Menú Mantenimiento
                //
                (RolesItem,         () => MostrarFormulario<RolesForm>()),
                (PermisosItem,      () => MostrarFormulario<PermisosForm>()),
                (BitacoraItem,      () => MostrarFormulario<BitacoraForm>()),
                (BackupItem,        () => MostrarFormulario<BackupForm>()),
                (RestoreItem,       () => MostrarFormulario<RestoreForm>()),
                (ConfiguracionItem, () => MostrarFormulario<ConfiguracionForm>()),
                //
                // Menú Ayuda
                //
                (AyudaItem,    () => MostrarFormulario<AyudaForm>()),
                (AcercaDeItem, () => MostrarFormulario<AboutForm>())
            );

            FormClosing += OnClosing;

            // Capturar tecla ESC para cerrar la aplicación
            KeyPreview = true;
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    OnClosing(this,
                              new FormClosingEventArgs(CloseReason.UserClosing, false));
                };
            };
        }

        // Este método recibe por parámetro un array de tuplas.
        private void AsignarEventos(params (ToolStripMenuItem MenuItem, Action Action)[] items)
        {
            foreach (var (item, action) in items) { item.Click += (sender, e) => action(); }
        }

        /// <summary>
        /// Implementa un «Multiton Pattern» para mostrar formularios.
        /// Este patrón es una extensión del patrón Singleton, permitiendo
        /// múltiples instancias únicas controladas por un identificador.
        /// Aquí, gestiona instancias únicas basadas en el tipo de Form.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// "new()" asegura que T tiene un constructor público sin parámetros.
        /// [Es decir, se puede crear una nueva instancia de T usando new T().]
        /// </typeparam>
        private void MostrarFormulario<T>() where T : Form, new()
        {
            if (_openForms.TryGetValue(typeof(T), out var formulario)
                && formulario != null
                && !formulario.IsDisposed)
            {
                formulario.BringToFront();
            }
            else
            {
                formulario = new T { MdiParent = this };
                _openForms[typeof(T)] = formulario;

                // El formulario se borra a sí mismo del diccionario al cierre.
                formulario.FormClosed += (s, e) => _openForms.Remove(typeof(T));
                formulario.Show();
            }
        }

        /// <summary>
        /// Habilita o deshabilita los elementos del menú según los permisos del usuario.
        /// </summary>
        public void AsignarPermisos()
        {
            if (SessionService.Instancia.EstaConectado())
            {
                var empleado = SessionService.Instancia.Empleado;
                SesionLabel.Text = $"Sesión de {empleado}";
            }
            else { SesionLabel.Text = "[Sesión inactiva]"; }

            // Menú Archivo
            LoginItem.Visible = !SessionService.Instancia.EstaConectado();
            LogoutItem.Visible = SessionService.Instancia.EstaConectado();

            var crudRol = GenericFactory.Instanciar<ControllerCRU<Rol>>();
            var permissionService = new AuthorizationService(SessionService.Instancia);
            var permisos = permissionService.ObtenerPermisos(activos: true, crudRol);

            VisibilizarItems(permisos,
                            //            
                            // Menú Venta
                            //
                            (CapturaItem,       PermisoEnum.CapturadorForm),
                            (FacturacionItem,   PermisoEnum.FacturadorForm),
                            //
                            // Menú Logística
                            //
                            (DespachoItem,      PermisoEnum.DespachadorForm),
                            (LiquidacionItem,   PermisoEnum.LiquidadorForm),
                            //
                            // Menú Gestión
                            //
                            (CamionesItem,      PermisoEnum.CamionesForm),
                            (ClientesItem,      PermisoEnum.ClientesForm),
                            (EmpleadosItem,     PermisoEnum.EmpleadosForm),
                            (LocacionesItem,    PermisoEnum.LocacionesForm),
                            (TarifasItem,       PermisoEnum.TarifasForm),
                            (DashboardItem,     PermisoEnum.DashboardForm),
                            //
                            // Menú Mantenimiento
                            //
                            (RolesItem,         PermisoEnum.RolesForm),
                            (PermisosItem,      PermisoEnum.PermisosForm),
                            (BitacoraItem,      PermisoEnum.BitacoraForm),
                            (BackupItem,        PermisoEnum.BackupForm),
                            (RestoreItem,       PermisoEnum.RestoreForm),
                            (ConfiguracionItem, PermisoEnum.ConfiguracionForm)
                            );

            VentaMenu.Visible = VisibilizarMenus(permisos,
                                                         PermisoEnum.CapturadorForm,
                                                         PermisoEnum.FacturadorForm);

            LogisticaMenu.Visible = VisibilizarMenus(permisos,
                                                         PermisoEnum.DespachadorForm,
                                                         PermisoEnum.LiquidadorForm);

            GestionMenu.Visible = VisibilizarMenus(permisos,
                                                         PermisoEnum.CamionesForm,
                                                         PermisoEnum.ClientesForm,
                                                         PermisoEnum.EmpleadosForm,
                                                         PermisoEnum.LocacionesForm,
                                                         PermisoEnum.TarifasForm,
                                                         PermisoEnum.DashboardForm);

            MantenimientoMenu.Visible = VisibilizarMenus(permisos,
                                                         PermisoEnum.RolesForm,
                                                         PermisoEnum.PermisosForm,
                                                         PermisoEnum.BitacoraForm,
                                                         PermisoEnum.BackupForm,
                                                         PermisoEnum.RestoreForm,
                                                         PermisoEnum.ConfiguracionForm);
        }

        // Mostrar u ocultar los items de menú basándose en la lista de permisos.
        private void VisibilizarItems(HashSet<PermisoEnum> permisos,
                                      params (ToolStripMenuItem Item,
                                      PermisoEnum Permiso)[] items)
        {
            foreach (var (item, permiso) in items)
            {
                item.Visible = permisos.Contains(permiso);
            }
        }

        // Mostrar u ocultar los menús primarios basándose en la lista de permisos.
        private bool VisibilizarMenus(HashSet<PermisoEnum> permisos,
                                      params PermisoEnum[] menu)
        {
            return menu.Any(permisos.Contains);
        }

        private void Logout(bool exit = false)
        {
            var crudEmpleado = GenericFactory.Instanciar<ControllerCRU<Empleado>>();
            var carpetaBase = ConfigurationService.Configuracion.CarpetaBase;
            var crudBitacora = GenericFactory.Instanciar<ControllerCRU<Bitacora>>(carpetaBase);

            if (exit) GenericFactory.Instanciar<AuthenticationService>(crudEmpleado).Logout(crudBitacora, exit);
            else GenericFactory.Instanciar<AuthenticationService>(crudEmpleado).Logout(crudBitacora);

            // Cerrar todos los formularios abiertos.
            // ToList() crea una copia para evitar excepción de "diccionario modificado".
            foreach (var formulario in _openForms.Values.ToList())
            {
                formulario.Close();
            }
            AsignarPermisos();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
                FormClosing -= OnClosing; // Desconecta el evento para evitar un bucle.

                if (MessageBoxService.Confirmar("¿Confirma que desea salir de la aplicación?"))
                {
                    if (SessionService.Instancia.EstaConectado()) Logout(true);
                    Close();
                }
                else
                {
                    e.Cancel = true;
                    FormClosing += OnClosing; // Reconecta el evento para un cauce normal.
                }
        }
    }
}
