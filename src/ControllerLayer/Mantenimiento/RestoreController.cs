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
    /// Controlador de RestoreForm.
    /// </summary>
    public class RestoreController : ControllerCRU<Bitacora>
    {
        /// <summary>
        /// <see cref="RestoreController"/>
        /// </summary>
        /// <param name="formulario"></param>
        public RestoreController(Form formulario) : base(ConfigurationService.Configuracion.CarpetaBase)
        {
            RestoreForm = formulario;

            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }

        // Estructuras de datos.
        private IList<Bitacora> _bitacoras;
        private IBitacora _bitacora;

        // Componentes de la vista.
        private readonly Form RestoreForm;
        private DataGridView BitacorasDgv;
        private MaterialCheckbox BloqueadoCheckBox, EliminadoCheckBox;
        private MaterialTextBox2 IdTextBox, EmpleadoTextBox, DetallesTextBox, ZipTextBox;
        private MaterialComboBox TipoComboBox;
        private DateTimePicker TimestampDtp;
        private MaterialButton BuscarButton, RealizarRestoreButton;

        //......................................................................

        private void AsignarControles()
        {
            BitacorasDgv          = GetControl<DataGridView>("BitacorasDgv");
            BloqueadoCheckBox     = GetControl<MaterialCheckbox>("BloqueadoCheckBox");
            EliminadoCheckBox     = GetControl<MaterialCheckbox>("EliminadoCheckBox");
            IdTextBox             = GetControl<MaterialTextBox2>("IdTextBox");
            EmpleadoTextBox       = GetControl<MaterialTextBox2>("EmpleadoTextBox");
            DetallesTextBox       = GetControl<MaterialTextBox2>("DetallesTextBox");
            ZipTextBox            = GetControl<MaterialTextBox2>("ZipTextBox");
            TipoComboBox          = GetControl<MaterialComboBox>("TipoComboBox");
            TimestampDtp          = GetControl<DateTimePicker>("TimestampDtp");
            BuscarButton          = GetControl<MaterialButton>("BuscarButton");
            RealizarRestoreButton = GetControl<MaterialButton>("RealizarRestoreButton");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)RestoreForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            BitacorasDgv.RowEnter += (s, e) => BitacorasDgv_RowEnter(e.RowIndex);
            BuscarButton.Click += (s, e) => BuscarEntidad();
            RealizarRestoreButton.Click += (s, e) => RealizarRestore();
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
                x.Tipo == EventoEnum.Backup
            ).ToList();

            BitacorasDgv.DataSource = null;
            BitacorasDgv.DataSource = _bitacoras;
            DataGridViewService.SimularListbox(BitacorasDgv, "Tipo", "Timestamp");
        }

        private void CargarTipoComboBox()
        {
            TipoComboBox.DataSource = Enum.GetValues(typeof(EventoEnum));
        }

        //......................................................................

        private void BitacorasDgv_RowEnter(int index)
        {
            if (index < 0) return;

            _bitacora = (Bitacora)BitacorasDgv.Rows[index].DataBoundItem;
            if (_bitacora == null) return;

            TranscribirSeleccion(_bitacora);
        }

        private void TranscribirSeleccion(IBitacora bitacora)
        {
            BloqueadoCheckBox.Checked = bitacora.Bloqueado;
            EliminadoCheckBox.Checked = bitacora.Eliminado;
            IdTextBox.Text = bitacora.Id.ToString();
            TipoComboBox.SelectedItem = bitacora.Tipo;
            TimestampDtp.Value = bitacora.Timestamp;
            EmpleadoTextBox.Text = bitacora.Empleado;
            DetallesTextBox.Text = bitacora.Detalle;
            ZipTextBox.Text = bitacora.Zip;
        }

        //......................................................................

        private void BuscarEntidad()
        {
            RestoreForm.Visible = false;

            var buscable = new BitacoraSearch(_bitacoras);
            var buscador = new SearchService<Bitacora>(buscable);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                var seleccionado = buscador.SelectedItem;
                DataGridViewService.SeleccionarFila(BitacorasDgv, seleccionado);
            }

            RestoreForm.Visible = true;
        }

        private void RealizarRestore()
        {
            if (_bitacora == null)
            {
                MessageBoxService.Error("No ha seleccionado un backup para restore.");
                return;
            }

            var confirmacion = MessageBoxService.Confirmar("¿Desea realizar un restore del backup seleccionado?");
            if (!confirmacion) return;

            var carpetaBase = ConfigurationService.Configuracion.CarpetaBase;
            var crudBitacora = GenericFactory.Instanciar<LogicCRU<Bitacora>>(carpetaBase);
            var resultado = GenericFactory.Instanciar<BackupService>(crudBitacora).RealizarRestore(_bitacora.Zip);

            if (resultado is null)
            {
                MessageBoxService.Error("No se pudo realizar el restore.");
                return;
            }

            // Nada más por hacer porque el DGV solo muestra los Backup.
            MessageBoxService.Informar("Restore realizado con éxito.");
        }
    }
}
