using AbstractLayer;
using EntityLayer;
using MaterialSkin2Framework.Controls;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ControllerLayer
{
    /// <summary>Controlador del Form de Empleados.</summary>
    public class EmpleadosController : ControllerCRU<Empleado>
    {
        /// <summary>
        /// Este constructor requiere a EmpleadosForm.
        /// </summary>
        /// <param name="formulario"></param>
        public EmpleadosController(Form formulario)
        {
            EmpleadosForm = formulario;
            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() => _empleados = Read());
            //_empleados = _empleados.OrderBy(x => x.Apellido).ToList();

            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }

        // Estructuras de datos.
        private IList<Empleado> _empleados;
        private Empleado _empleado;
        private bool _actualizando = false,
                     _modificado = false;
        private Dictionary<string, Control> _mapeoControles;

        // Componentes de la vista.
        private readonly Form EmpleadosForm;

        private DataGridView EmpleadosDgv;
        private DateTimePicker FechaNacimientoDtp,
                               FechaCredencialesDtp;
        private ListBox ContraseñasPasadasListBox;
        private MaterialButton BuscarEmpleadoButton,
                               CrearEmpleadoButton,
                               GuardarModificacionesButton;
        private MaterialCheckbox BloqueadoCheckbox,
                                 EliminadoCheckbox;
        private MaterialComboBox PuestoComboBox;
#pragma warning disable IDE0052 // Remove unread private members
        private MaterialTextBox2 IdTextBox,
#pragma warning restore IDE0052 // Remove unread private members
                                 NombreTextBox,
                                 ApellidoTextBox,
                                 TelefonoTextBox,
                                 EmailTextBox,
                                 UsuarioTextBox,
                                 ContraseñaTextBox,
                                 PalabraSecretaTextBox;
        private NumericUpDown DniNumeric,
                              LoginFallidoNumeric;

        //......................................................................

        private void AsignarControles()
        {
            // Componentes con mapeo.
            _mapeoControles = new Dictionary<string, Control>
            {
                [nameof(Empleado.Id)]              = IdTextBox             = GetControl<MaterialTextBox2>("IdTextBox"),
                [nameof(Empleado.Bloqueado)]       = BloqueadoCheckbox     = GetControl<MaterialCheckbox>("BloqueadoCheckbox"),
                [nameof(Empleado.Eliminado)]       = EliminadoCheckbox     = GetControl<MaterialCheckbox>("EliminadoCheckbox"),
                [nameof(Empleado.DNI)]             = DniNumeric            = GetControl<NumericUpDown>("DniNumeric"),
                [nameof(Empleado.FechaNacimiento)] = FechaNacimientoDtp    = GetControl<DateTimePicker>("FechaNacimientoDtp"),
                [nameof(Empleado.Nombre)]          = NombreTextBox         = GetControl<MaterialTextBox2>("NombreTextBox"),
                [nameof(Empleado.Apellido)]        = ApellidoTextBox       = GetControl<MaterialTextBox2>("ApellidoTextBox"),
                [nameof(Empleado.Telefono)]        = TelefonoTextBox       = GetControl<MaterialTextBox2>("TelefonoTextBox"),
                [nameof(Empleado.Email)]           = EmailTextBox          = GetControl<MaterialTextBox2>("EmailTextBox"),
                [nameof(Empleado.Usuario)]         = UsuarioTextBox        = GetControl<MaterialTextBox2>("UsuarioTextBox"),
                [nameof(Empleado.LoginFallido)]    = LoginFallidoNumeric   = GetControl<NumericUpDown>("LoginFallidoNumeric"),
                [nameof(Empleado.ContraseñaFecha)] = FechaCredencialesDtp  = GetControl<DateTimePicker>("FechaCredencialesDtp"),
                [nameof(Empleado.Contraseña)]      = ContraseñaTextBox     = GetControl<MaterialTextBox2>("ContraseñaTextBox"),
                [nameof(Empleado.PalabraSecreta)]  = PalabraSecretaTextBox = GetControl<MaterialTextBox2>("PalabraSecretaTextBox"),
            };

            // Componentes sin mapeo.
            ContraseñaTextBox           = GetControl<MaterialTextBox2>("ContraseñaTextBox");
            PalabraSecretaTextBox       = GetControl<MaterialTextBox2>("PalabraSecretaTextBox");
            EmpleadosDgv                = GetControl<DataGridView>("EmpleadosDgv");
            PuestoComboBox              = GetControl<MaterialComboBox>("PuestoComboBox");
            ContraseñasPasadasListBox   = GetControl<ListBox>("ContraseñasPasadasListBox");
            BuscarEmpleadoButton        = GetControl<MaterialButton>("BuscarEmpleadoButton");
            CrearEmpleadoButton         = GetControl<MaterialButton>("CrearEmpleadoButton");
            GuardarModificacionesButton = GetControl<MaterialButton>("GuardarModificacionesButton");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)EmpleadosForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        //......................................................................

        private void AsignarEventos()
        {
            // Eventos generales
            BloqueadoCheckbox.CheckedChanged    += (s, e) => OnModificado();
            EliminadoCheckbox.CheckedChanged    += (s, e) => OnModificado();
            DniNumeric.ValueChanged             += (s, e) => OnModificado();
            NombreTextBox.TextChanged           += (s, e) => OnModificado();
            ApellidoTextBox.TextChanged         += (s, e) => OnModificado();
            FechaNacimientoDtp.ValueChanged     += (s, e) => OnModificado();
            PuestoComboBox.SelectedIndexChanged += (s, e) => OnModificado();
            TelefonoTextBox.TextChanged         += (s, e) => OnModificado();
            EmailTextBox.TextChanged            += (s, e) => OnModificado();
            UsuarioTextBox.TextChanged          += (s, e) => OnModificado();
            ContraseñaTextBox.TextChanged       += (s, e) => OnModificado();
            LoginFallidoNumeric.ValueChanged    += (s, e) => OnModificado();
            FechaCredencialesDtp.ValueChanged   += (s, e) => OnModificado();
            PalabraSecretaTextBox.TextChanged   += (s, e) => OnModificado();

            // Eventos específicos.
            EmpleadosForm.FormClosing         += (s, e) => FormClosing();
            EmpleadosDgv.RowEnter             += (s, e) => InterceptarDgvPrincipal(e.RowIndex);
            BuscarEmpleadoButton.Click        += (s, e) => BuscarEntidad();
            CrearEmpleadoButton.Click         += (s, e) => CrearEntidad();
            GuardarModificacionesButton.Click += (s, e) => GuardarModificaciones();
        }

        private void OnModificado()
        {
            if (!_actualizando) _modificado = true;
            GuardarModificacionesButton.Enabled = _modificado;
        }

        //......................................................................

        private void InicializarVista()
        {
            _actualizando = true;

            var puestos = EnumeratorService.ListarDescripciones<PuestoEnum>();
            PuestoComboBox.DataSource = puestos;

            EmpleadosDgv.DataSource = null;
            EmpleadosDgv.DataSource = _empleados;
            DataGridViewService.SimularListbox(EmpleadosDgv, "DNI", "Nombre", "Apellido");

            _actualizando = false;
        }

        //......................................................................

        private void InterceptarDgvPrincipal(int index)
        {
            if (_modificado)
            {
                var resultado = MessageBoxService.Confirmar("Tiene cambios sin guardar. ¿Desea guardarlos ahora?");

                if (resultado)
                {
                    GuardarModificaciones();
                }

                _modificado = false;
                EmpleadosDgv.ClearSelection();
                EmpleadosDgv.Rows[index].Selected = true;
                EmpleadosDgv_RowEnter(index);
            }

            EmpleadosDgv_RowEnter(index);
        }

        private void EmpleadosDgv_RowEnter(int index)
        {
            if (index < 0) return;

            _empleado = null;
            _empleado = (Empleado)EmpleadosDgv.Rows[index].DataBoundItem;

            if (_empleado == null) return;

            ActualizarComponentes();
        }

        private void ActualizarComponentes()
        {
            _actualizando = true;

            if (_empleado == null)
            {
                MessageBoxService.Error("No se ha seleccionado ningún ítem.");
                return;
            }

            // Mapeo general
            ComponentService.MapearHaciaComponentes(_empleado, _mapeoControles);

            // Mapeo específico
            var contraseñaDesencriptada = _empleado.Contraseña.Desencriptar();
            var palabraSecretaDesencriptada = _empleado.PalabraSecreta.Desencriptar();
            ContraseñaTextBox.Text = contraseñaDesencriptada;
            PalabraSecretaTextBox.Text = palabraSecretaDesencriptada;

            ContraseñasPasadasListBox.DataSource = _empleado.ContraseñasPasadas ?? new List<string>();

            if (_empleado.Puesto.HasValue)
            {
                var descripcionPuesto        = EnumeratorService.ObtenerDescripcionDeEnum(_empleado.Puesto.Value);
                var indexPuesto              = PuestoComboBox.Items.IndexOf(descripcionPuesto);
                PuestoComboBox.SelectedIndex = indexPuesto;
            }
            else
            {
                PuestoComboBox.SelectedIndex = -1;
            }

            _actualizando = false;
        }

        //......................................................................

        private void BuscarEntidad()
        {
            EmpleadosForm.Visible = false;

            var buscable = new EmpleadoSearch(_empleados);
            var buscador = new SearchService<Empleado>(buscable);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                var seleccionado = buscador.SelectedItem;
                DataGridViewService.SeleccionarFila(EmpleadosDgv, seleccionado);
            }

            EmpleadosForm.Visible = true;
        }

        private void CrearEntidad()
        {
            var respuesta = MessageBoxService.Confirmar("¿Está seguro de crear una nueva entrada?");
            if (!respuesta) return;

            var diasVigencia = ConfigurationService.Configuracion.ContraseñaDiasVigencia;

            var empleado = new Empleado
            {
                Bloqueado       = true,
                Nombre          = "(nuevo nombre)",
                Apellido        = "(nuevo apellido)",
                DNI             = 99999999,
                FechaNacimiento = DateTime.Now,
                Usuario         = RandomCredentialsService.GenerarUsuario(),
                Contraseña      = RandomCredentialsService.GenerarContraseña().Encriptar(),
                PalabraSecreta  = RandomCredentialsService.GenerarPalabraSecreta().Encriptar(),
                LoginFallido    = 0,
                ContraseñaFecha = DateTime.Now.AddDays(-diasVigencia)
            };

            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    var entrada = Create(empleado);
                    InicializarVista();
                    DataGridViewService.SeleccionarFila(EmpleadosDgv, entrada);
                    MessageBoxService.Informar($"Se ha creado la siguiente entrada:\n{entrada}");
                });
        }

        // Comienza «Guardar»...................................................

        private void GuardarModificaciones()
        {
            var confirmacion = MessageBoxService.Confirmar("¿Está seguro de guardar los cambios?");
            if (!confirmacion) return;

            var clon = (Empleado)_empleado.Clone();
            RecuperarDatos(clon);

            if (AprobarDatos(clon))
            {
                _empleado = clon;

                var contraseñaEncriptada = clon.Contraseña.Encriptar();
                var palabraSecretaEncriptada = clon.PalabraSecreta.Encriptar();
                _empleado.Contraseña = contraseñaEncriptada;
                _empleado.PalabraSecreta = palabraSecretaEncriptada;

                GenericFactory
                    .Instanciar<ControllerException>()
                    .ExceptionHandling(() => PersistirEntidad());

                GuardarModificacionesButton.Enabled = false;
                EmpleadosDgv.Refresh();
            }
        }

        private void RecuperarDatos(Empleado empleado)
        {
            ComponentService.MapearHaciaObjeto(ref empleado, _mapeoControles);

            // Recuperar del ComboBox el enumerador basado en su descripción.
            PuestoEnum? puestoEnum = null;

            if (PuestoComboBox.SelectedIndex != -1)
            {
                var descripcion = PuestoComboBox.SelectedItem.ToString();
                puestoEnum = EnumeratorService.ObtenerEnumDeDescripcion<PuestoEnum>(descripcion);
            }

            empleado.Puesto = puestoEnum;
        }

        private bool AprobarDatos(Empleado empleado)
        {
            if (empleado == null)
            {
                MessageBoxService.Error("No se ha seleccionado ningún ítem.");
                return false;
            }

            // Verificar que campos de valor único no se repitan.
            var dniRepetido = _empleados.Any(x => x.Id != empleado.Id && x.DNI == empleado.DNI);
            if (dniRepetido)
            {
                MessageBoxService.Error("El DNI ingresado ya existe.");
                return false;
            }

            var emailRepetido = _empleados.Any(x => x.Id != empleado.Id && x.Email == empleado.Email);
            if (emailRepetido)
            {
                MessageBoxService.Error("El email ingresado ya existe.");
                return false;
            }

            var usuarioRepetido = _empleados.Any(x => x.Id != empleado.Id && x.Usuario == empleado.Usuario);
            if (usuarioRepetido)
            {
                MessageBoxService.Error("El usuario ingresado ya existe.");
                return false;
            }

            // Validar entidad.
            var validado = ValidationService.EsValido(empleado, out List<string> errores);
            if (!validado)
            {
                MessageBoxService.Error($"Errores de validación:\n{string.Join("\n", errores)}");
                return false;
            }

            // Comprobaciones y validaciones terminadas.
            return true;
        }

        private void PersistirEntidad()
        {
            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    var exito = Update(_empleado);
                    if (exito)
                    {
                        _modificado = false;
                        MessageBoxService.Informar("Cambios guardados correctamente.");
                    }
                    else
                    {
                        MessageBoxService.Error("No se han podido guardar los cambios.");
                    }
                });
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
