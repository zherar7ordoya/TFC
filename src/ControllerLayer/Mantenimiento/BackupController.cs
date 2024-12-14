using AbstractLayer;
using EntityLayer;
using LogicLayer;
using MaterialSkin2Framework.Controls;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ControllerLayer
{
    /// <summary>
    /// Controlador de BackupForm.
    /// </summary>
    public class BackupController : ControllerCRU<Bitacora>
    {
        /// <summary><see cref="BackupController"/></summary>
        /// <param name="formulario"></param>
        public BackupController(Form formulario) : base(ConfigurationService.Configuracion.CarpetaBase)
        {
            BackupForm = formulario;

            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }

        // Componentes (controles).
        private readonly Form BackupForm;
        private DataGridView BitacorasDgv;
        private MaterialCheckbox BloqueadoCheckBox, EliminadoCheckBox;
        private MaterialTextBox2 IdTextBox, EmpleadoTextBox, DetallesTextBox, ZipTextBox;
        private MaterialComboBox TipoComboBox;
        private DateTimePicker TimestampDtp;
        private MaterialButton BuscarButton, RealizarBackupButton;

        // Estructuras de datos.
        private IList<Bitacora> _bitacoras;

        //......................................................................

        private void AsignarControles()
        {
            // Experimental: ExecuteWithExceptionHandling provee un manejo centralizado de excepciones.
            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    BitacorasDgv         = GetControl<DataGridView>("BitacorasDgv");
                    BloqueadoCheckBox    = GetControl<MaterialCheckbox>("BloqueadoCheckBox");
                    EliminadoCheckBox    = GetControl<MaterialCheckbox>("EliminadoCheckBox");
                    IdTextBox            = GetControl<MaterialTextBox2>("IdTextBox");
                    EmpleadoTextBox      = GetControl<MaterialTextBox2>("EmpleadoTextBox");
                    DetallesTextBox      = GetControl<MaterialTextBox2>("DetallesTextBox");
                    ZipTextBox           = GetControl<MaterialTextBox2>("ZipTextBox");
                    TipoComboBox         = GetControl<MaterialComboBox>("TipoComboBox");
                    TimestampDtp         = GetControl<DateTimePicker>("TimestampDtp");
                    BuscarButton         = GetControl<MaterialButton>("BuscarButton");
                    RealizarBackupButton = GetControl<MaterialButton>("RealizarBackupButton");
                });
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)BackupForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            BitacorasDgv.RowEnter      += (s, e) => BitacorasDgv_RowEnter(e.RowIndex);
            BuscarButton.Click         += (s, e) => BuscarEntidad();
            RealizarBackupButton.Click += (s, e) => RealizarBackup();
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
                                          x.Bloqueado == false &&
                                          x.Eliminado == false &&
                                          x.Tipo == EventoEnum.Restore).ToList();
            BitacorasDgv.DataSource = null;
            BitacorasDgv.DataSource = _bitacoras;
            DataGridViewService.SimularListbox(BitacorasDgv, "Timestamp", "Zip");
        }

        private void CargarTipoComboBox()
        {
            TipoComboBox.DataSource = Enum.GetValues(typeof(EventoEnum));
        }

        //......................................................................

        private void BitacorasDgv_RowEnter(int index)
        {
            if (index < 0) return;

            var bitacora = (Bitacora)BitacorasDgv.Rows[index].DataBoundItem;
            if (bitacora == null) return;

            TranscribirSeleccion(bitacora);
        }

        private void TranscribirSeleccion(Bitacora bitacora)
        {
            BloqueadoCheckBox.Checked = bitacora.Bloqueado;
            EliminadoCheckBox.Checked = bitacora.Eliminado;
            IdTextBox.Text            = bitacora.Id.ToString();
            TipoComboBox.SelectedItem = bitacora.Tipo;
            TimestampDtp.Value        = bitacora.Timestamp;
            EmpleadoTextBox.Text      = bitacora.Empleado;
            DetallesTextBox.Text      = bitacora.Detalle;
            ZipTextBox.Text           = bitacora.Zip;
        }

        //......................................................................

        private void BuscarEntidad()
        {
            BackupForm.Visible = false;

            var buscable = new BitacoraSearch(_bitacoras);
            var buscador = new SearchService<Bitacora>(buscable);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                var seleccionado = buscador.SelectedItem;
                DataGridViewService.SeleccionarFila(BitacorasDgv, seleccionado);
            }

            BackupForm.Visible = true;
        }

        private void RealizarBackup()
        {
            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    var confirmacion = MessageBoxService.Confirmar("¿Desea realizar un backup?");
                    if (!confirmacion) return;

                    var carpetaBase = ConfigurationService.Configuracion.CarpetaBase;
                    var crudBitacora = GenericFactory.Instanciar<LogicCRU<Bitacora>>(carpetaBase);
                    var resultado = GenericFactory.Instanciar<BackupService>(crudBitacora).RealizarBackup();

                    if (resultado != null)
                    {
                        // Nada más por hacer porque el DGV solo muestra los Restore.
                        MessageBoxService.Informar("Backup realizado con éxito.");
                    }
                    else
                    {
                        MessageBoxService.Advertir("No se pudo realizar el backup.");
                    }
                });
        }
    }
}
