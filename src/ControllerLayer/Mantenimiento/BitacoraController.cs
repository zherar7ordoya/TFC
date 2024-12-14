using AbstractLayer;
using EntityLayer;
using MaterialSkin2Framework.Controls;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ControllerLayer
{
    /// <summary>Controlador de BitacoraForm.</summary>
    public class BitacoraController : ControllerCRU<Bitacora>
    {
        /// <summary><see cref="BitacoraController"/></summary>
        /// <param name="formulario"></param>
        public BitacoraController(Form formulario) : base(ConfigurationService.Configuracion.CarpetaBase)
        {
            BitacoraForm = formulario;

            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }

        // Componentes (controles).
        private readonly Form       BitacoraForm;
        private DataGridView        BitacorasDgv;
        private MaterialCheckbox    BloqueadoCheckBox, EliminadoCheckBox, BackupCheckBox, ExceptionCheckBox, LoginCheckBox, LogoutCheckBox, RestoreCheckBox;
        private MaterialTextBox2    IdTextBox, EmpleadoTextBox, ZipTextBox;
        private MaterialComboBox    TipoComboBox;
        private DateTimePicker      TimestampDtp;
        private MaterialButton      BuscarButton, GuardarModificacionesButton;
        private TextBox             DetalleTextBox, ComentarioTextBox;
        private MaterialCheckbox    FiltroBloqueadoCheckBox, FiltroEliminadoCheckBox;

        // Estructuras de datos.
        //private readonly string _carpetaBase;
        private IList<Bitacora> _bitacoras;
        private bool _actualizando = false, _modificado = false;
        private IBitacora _revertidor, _comprobador;

        private void AsignarControles()
        {
            BitacorasDgv                = GetControl<DataGridView>("BitacorasDgv");
            BloqueadoCheckBox           = GetControl<MaterialCheckbox>("BloqueadoCheckBox");
            EliminadoCheckBox           = GetControl<MaterialCheckbox>("EliminadoCheckBox");
            BackupCheckBox              = GetControl<MaterialCheckbox>("BackupCheckBox");
            ExceptionCheckBox           = GetControl<MaterialCheckbox>("ExceptionCheckBox");
            LoginCheckBox               = GetControl<MaterialCheckbox>("LoginCheckBox");
            LogoutCheckBox              = GetControl<MaterialCheckbox>("LogoutCheckBox");
            RestoreCheckBox             = GetControl<MaterialCheckbox>("RestoreCheckBox");
            IdTextBox                   = GetControl<MaterialTextBox2>("IdTextBox");
            EmpleadoTextBox             = GetControl<MaterialTextBox2>("EmpleadoTextBox");
            ZipTextBox                  = GetControl<MaterialTextBox2>("ZipTextBox");
            TipoComboBox                = GetControl<MaterialComboBox>("TipoComboBox");
            TimestampDtp                = GetControl<DateTimePicker>("TimestampDtp");
            BuscarButton                = GetControl<MaterialButton>("BuscarButton");
            GuardarModificacionesButton = GetControl<MaterialButton>("GuardarModificacionesButton");
            DetalleTextBox              = GetControl<TextBox>("DetalleTextBox");
            ComentarioTextBox           = GetControl<TextBox>("ComentarioTextBox");
            FiltroBloqueadoCheckBox     = GetControl<MaterialCheckbox>("FiltroBloqueadoCheckBox");
            FiltroEliminadoCheckBox     = GetControl<MaterialCheckbox>("FiltroEliminadoCheckBox");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)BitacoraForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            BitacoraForm.FormClosing               += (s, e) => FormClosing();
            BitacorasDgv.RowEnter                  += (s, e) => InterceptarDgvPrincipal(e.RowIndex);
            FiltroBloqueadoCheckBox.CheckedChanged += (s, e) => CargarDgvPrincipal();
            FiltroEliminadoCheckBox.CheckedChanged += (s, e) => CargarDgvPrincipal();
            BackupCheckBox.CheckedChanged          += (s, e) => CargarDgvPrincipal();
            ExceptionCheckBox.CheckedChanged       += (s, e) => CargarDgvPrincipal();
            LoginCheckBox.CheckedChanged           += (s, e) => CargarDgvPrincipal();
            LogoutCheckBox.CheckedChanged          += (s, e) => CargarDgvPrincipal();
            RestoreCheckBox.CheckedChanged         += (s, e) => CargarDgvPrincipal();
            BuscarButton.Click                     += (s, e) => BuscarEntidad();
            GuardarModificacionesButton.Click      += (s, e) => GuardarModificaciones();
            BloqueadoCheckBox.CheckedChanged       += (s, e) => OnModificado();
            EliminadoCheckBox.CheckedChanged       += (s, e) => OnModificado();
            ComentarioTextBox.TextChanged          += (s, e) => OnModificado();
        }

        private void InicializarVista()
        {
            CargarDgvPrincipal();
            CargarTipoComboBox();
        }

        private void CargarDgvPrincipal()
        {
            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() => _bitacoras = Read());

            _bitacoras = _bitacoras.Where(x =>
                (FiltroBloqueadoCheckBox.Checked && x.Bloqueado) ||
                (FiltroEliminadoCheckBox.Checked && x.Eliminado) ||
                (BackupCheckBox.Checked && x.Tipo    == EventoEnum.Backup) ||
                (ExceptionCheckBox.Checked && x.Tipo == EventoEnum.Exception) ||
                (LoginCheckBox.Checked && x.Tipo     == EventoEnum.Login) ||
                (LogoutCheckBox.Checked && x.Tipo    == EventoEnum.Logout) ||
                (RestoreCheckBox.Checked && x.Tipo   == EventoEnum.Restore)).ToList();

            BitacorasDgv.DataSource = null;
            BitacorasDgv.DataSource = _bitacoras;
            DataGridViewService.SimularListbox(BitacorasDgv, "Id", "Tipo", "Timestamp");
        }

        private void CargarTipoComboBox()
        {
            TipoComboBox.DataSource = Enum.GetValues(typeof(EventoEnum));
        }

        //......................................................................

        private void OnModificado()
        {
            if (!_actualizando) _modificado = true;
            GuardarModificacionesButton.Enabled = _modificado;
        }

        private void InterceptarDgvPrincipal(int index)
        {
            if (_modificado)
            {
                var resultado = MessageBoxService.Advertir("Tiene cambios sin guardar. ¿Desea guardarlos antes de cambiar de rol?");

                if (resultado == DialogResult.Yes)
                {
                    GuardarModificaciones();
                    _modificado = false;
                }
                else if (resultado == DialogResult.No)
                {
                    BitacorasDgv.ClearSelection();
                    BitacorasDgv.Rows[index].Selected = true;
                    _modificado = false;
                    BitacorasDgv_RowEnter(index, revertir: true);
                }
                else
                {
                    BitacorasDgv.ClearSelection();
                    BitacorasDgv.Rows[index].Selected = true;
                    return;
                }
            }
            else
            {
                BitacorasDgv_RowEnter(index, revertir: false);
            }
        }

        private void BitacorasDgv_RowEnter(int index, bool revertir = false)
        {
            if (index < 0) return;

            var bitacora = (Bitacora)BitacorasDgv.Rows[index].DataBoundItem;
            if (bitacora == null) return;

            if (revertir)
            {
                RevertirModificaciones(bitacora);
                BitacorasDgv.Rows[index].Selected = true;
            }
            ActualizarRevertidor(bitacora);
            TranscribirSeleccion(bitacora);
        }


        private void RevertirModificaciones(Bitacora bitacora)
        {
            if (_revertidor == null)
            {
                MessageBoxService.Error("Error al tratar de revertir.");
                return;
            }

            bitacora.Bloqueado  = _revertidor.Bloqueado;
            bitacora.Eliminado  = _revertidor.Eliminado;
            bitacora.Id         = _revertidor.Id;
            bitacora.Tipo       = _revertidor.Tipo;
            bitacora.Timestamp  = _revertidor.Timestamp;
            bitacora.Empleado   = _revertidor.Empleado;
            bitacora.Detalle    = _revertidor.Detalle;
            bitacora.Zip        = _revertidor.Zip;
            bitacora.Comentario = _revertidor.Comentario;
        }

        private void ActualizarRevertidor(Bitacora bitacora)
        {
            _revertidor    = new Bitacora {
                Bloqueado  = bitacora.Bloqueado,
                Eliminado  = bitacora.Eliminado,
                Id         = bitacora.Id,
                Tipo       = bitacora.Tipo,
                Timestamp  = bitacora.Timestamp,
                Empleado   = bitacora.Empleado,
                Detalle    = bitacora.Detalle,
                Zip        = bitacora.Zip,
                Comentario = bitacora.Comentario
            };
        }

        private void TranscribirSeleccion(Bitacora bitacora)
        {
            _actualizando = true;
            try
            {
                BloqueadoCheckBox.Checked = bitacora.Bloqueado;
                EliminadoCheckBox.Checked = bitacora.Eliminado;
                IdTextBox.Text            = bitacora.Id.ToString();
                TipoComboBox.SelectedItem = bitacora.Tipo;
                TimestampDtp.Value        = bitacora.Timestamp;
                EmpleadoTextBox.Text      = bitacora.Empleado;
                DetalleTextBox.Text       = bitacora.Detalle;
                ZipTextBox.Text           = bitacora.Zip;
                ComentarioTextBox.Text    = bitacora.Comentario;
            }
            finally { _actualizando = false; }
        }

        //......................................................................

        private void BuscarEntidad()
        {
            BitacoraForm.Visible = false;

            var buscable = new BitacoraSearch(_bitacoras);
            var buscador = new SearchService<Bitacora>(buscable);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                var seleccionado = buscador.SelectedItem;
                DataGridViewService.SeleccionarFila(BitacorasDgv, seleccionado);
            }

            BitacoraForm.Visible = true;
        }

        // Comienza «Guardar»...................................................
        private void GuardarModificaciones()
        {
            _comprobador = RecuperarDatos();
            if (VerificarDatos(out var bitacora)) PersistirEntidad(bitacora);
        }

        /// <summary>Recupera los datos de los controles.</summary>
        /// <remark>El recupero debe ser completo.</remark>
        /// <returns>La entidad Bitacora con los datos recuperados.</returns>
        private Bitacora RecuperarDatos()
        {
            return new Bitacora {
                Id         = int.Parse(IdTextBox.Text),
                Bloqueado  = BloqueadoCheckBox.Checked,
                Eliminado  = EliminadoCheckBox.Checked,
                Tipo       = (EventoEnum)TipoComboBox.SelectedItem,
                Timestamp  = TimestampDtp.Value,
                Empleado   = EmpleadoTextBox.Text,
                Detalle    = DetalleTextBox.Text,
                Zip        = ZipTextBox.Text,
                Comentario = ComentarioTextBox.Text
            };
        }

        private bool VerificarDatos(out Bitacora bitacora)
        {
            bitacora = (Bitacora)BitacorasDgv.CurrentRow?.DataBoundItem;
            if (bitacora == null)
            {
                MessageBoxService.Error("Debe seleccionar un ítem.");
                return false;
            }

            var respuesta = MessageBoxService.Confirmar("¿Está seguro de que desea guardar los cambios?");
            if (!respuesta) return false;

            /*** ..............Acaba "out", entra _comprobador..............***/

            // Comprobar que campos de valor único no se repitan.

            // Comprobaciones finalizadas.
            return true;
        }

        private void PersistirEntidad(Bitacora bitacora)
        {
            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    if (ValidationService.EsValido(_comprobador, out List<string> errores))
                    {
                        ActualizarEntidad(bitacora);
                        var exito = Update(bitacora);

                        if (exito)
                        {
                            _modificado = false;
                            BitacorasDgv.Refresh();
                            DataGridViewService.SeleccionarFila(BitacorasDgv, bitacora);
                            MessageBoxService.Informar("Cambios guardados correctamente.");
                        }
                        else { MessageBoxService.Error("No se han podido guardar los cambios."); }
                    }
                    else { MessageBoxService.Error($"Errores de validación:\n{string.Join("\n", errores)}"); }
                });
        }

        private void ActualizarEntidad(Bitacora bitacora)
        {
            bitacora.Id         = _comprobador.Id;
            bitacora.Bloqueado  = _comprobador.Bloqueado;
            bitacora.Eliminado  = _comprobador.Eliminado;
            bitacora.Tipo       = _comprobador.Tipo;
            bitacora.Timestamp  = _comprobador.Timestamp;
            bitacora.Empleado   = _comprobador.Empleado;
            bitacora.Detalle    = _comprobador.Detalle;
            bitacora.Zip        = _comprobador.Zip;
            bitacora.Comentario = _comprobador.Comentario;
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
