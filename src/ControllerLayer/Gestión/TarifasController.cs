using AbstractLayer;

using EntityLayer;

using ServiceLayer;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ControllerLayer
{
    /// <summary>
    /// Controlador para la gestión de tarifas.
    /// Maneja la interacción entre la vista y la lógica CRUD.
    /// </summary>
    public class TarifasController : ControllerCRU<Tarifa>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="formulario">TarifasForm</param>
        public TarifasController(Form formulario)
        {
            TarifasForm = formulario;
            _listado = Read().ToList();

            AsignarControles();
            AsignarEventos();
            InaugurarVista();
        }
        //
        // Componentes generales.***********************************************
        //
        private readonly Form TarifasForm;
        private readonly List<Tarifa> _listado;
        private readonly BindingSource _vinculante = new BindingSource(); // Para el DataGridView.

        private bool _actualizando = false;
        private bool _modificado = false;
        //
        // Componentes individuales.********************************************
        //
        // Controles fijos superiores.
        private TreeView       TarifasTreeView;
        private CheckBox       BloqueadoCheckBox;
        private CheckBox       EliminadoCheckBox;
        private TextBox        IdTextBox;
        // Controles variables generales.
        // [...]
        // Controles variables específicos.
        private DateTimePicker DesdeDateTimePicker;
        private DateTimePicker HastaDateTimePicker;
        private TextBox        MontoKmTextBox;

        private ComboBox       NivelTarifarioComboBox;
        private TextBox        ValorTextBox;

        private Button         AgregarCoeficienteButton;
        private Button         QuitarCoeficienteButton;
        private DataGridView   CoeficientesDataGridView;
        // Controles fijos inferiores.
        private Button         NuevaTarifaButton;
        private Button         GuardarModificacionesButton;
        //
        // Inicialización.******************************************************
        //
        private void AsignarControles()
        {
            // Controles fijos superiores.
            TarifasTreeView             = GetControl<TreeView>("TarifasTreeView");
            BloqueadoCheckBox           = GetControl<CheckBox>("BloqueadoCheckBox");
            EliminadoCheckBox           = GetControl<CheckBox>("EliminadoCheckBox");
            IdTextBox                   = GetControl<TextBox>("IdTextBox");
            // Controles variables generales.
            // [...]
            // Controles variables específicos.
            DesdeDateTimePicker         = GetControl<DateTimePicker>("DesdeDateTimePicker");
            HastaDateTimePicker         = GetControl<DateTimePicker>("HastaDateTimePicker");
            MontoKmTextBox              = GetControl<TextBox>("MontoKmTextBox");

            NivelTarifarioComboBox      = GetControl<ComboBox>("NivelTarifarioComboBox");
            ValorTextBox                = GetControl<TextBox>("ValorTextBox");

            AgregarCoeficienteButton    = GetControl<Button>("AgregarCoeficienteButton");
            QuitarCoeficienteButton     = GetControl<Button>("QuitarCoeficienteButton");
            CoeficientesDataGridView    = GetControl<DataGridView>("CoeficientesDataGridView");
            // Controles fijos inferiores.
            NuevaTarifaButton           = GetControl<Button>("NuevaTarifaButton");
            GuardarModificacionesButton = GetControl<Button>("GuardarModificacionesButton");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)TarifasForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            // Generales.
            TarifasTreeView.AfterSelect         += (s, e) => { TreeView_AfterSelect(s, e); };
            // Estado.
            BloqueadoCheckBox.CheckedChanged    += (s, e) => { OnChange(); };
            EliminadoCheckBox.CheckedChanged    += (s, e) => { OnChange(); };
            DesdeDateTimePicker.ValueChanged    += (s, e) => { OnChange(); };
            HastaDateTimePicker.ValueChanged    += (s, e) => { OnChange(); };
            MontoKmTextBox.TextChanged          += (s, e) => { OnChange(); };
            NivelTarifarioComboBox.TextChanged  += (s, e) => { OnChange(); };
            ValorTextBox.TextChanged            += (s, e) => { OnChange(); };
            // Específicos.
            AgregarCoeficienteButton.Click      += (s, e) => { AgregarCoeficiente(); };
            QuitarCoeficienteButton.Click       += (s, e) => { QuitarCoeficiente(); };
            NuevaTarifaButton.Click             += (s, e) => { CrearEntrada(); };
            GuardarModificacionesButton.Click   += (s, e) => { GuardarModificaciones(); };
        }

        private void OnChange()
        {
            if (_actualizando) return; // Ignorar cambios mientras se actualizan datos.

            try
            {
                _modificado = true;
                GuardarModificacionesButton.Enabled = true;
            }
            finally { _actualizando = false; }
        }

        private void InaugurarVista()
        {
            _actualizando = true;

            TreeViewService.CargarListaEnTreeView(TarifasTreeView, _listado);
            NivelTarifarioComboBox.DataSource = Enum.GetValues(typeof(NivelTarifarioEnum));

            _actualizando = false;
        }
        //
        // Comportamientos generales.*******************************************
        //
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_modificado)
            {
                var confirmacion = MessageBoxService.Confirmar(
                    "Hay cambios sin guardar.\n" +
                    "¿Seguro que deseas continuar?");
                if (!confirmacion) return;
            }

            var seleccionado = TreeViewService.ObtenerObjetoSeleccionado<Tarifa>(TarifasTreeView);
            
            if (seleccionado != null)
            {
                TranscribirDetalles(seleccionado);
            }
        }

        private void TranscribirDetalles(Tarifa tarifa)
        {
            _actualizando = true;

            try
            {
                BloqueadoCheckBox.Checked = tarifa.Bloqueado;
                EliminadoCheckBox.Checked = tarifa.Eliminado;
                IdTextBox.Text = tarifa.Id.ToString();
                DesdeDateTimePicker.Value = tarifa.Desde;
                HastaDateTimePicker.Value = tarifa.Hasta;
                MontoKmTextBox.Text = tarifa.MontoKilometro.ToString();

                _vinculante.DataSource = new BindingList<Coeficiente>(tarifa.Coeficientes);
                CoeficientesDataGridView.DataSource = _vinculante;
            }
            finally { _actualizando = false; }
        }
        //
        // Comportamientos específicos.*****************************************
        //
        private Tarifa RecuperarDetalles()
        {
            var coeficientes = _vinculante.List.Cast<Coeficiente>().ToList();

            return new Tarifa
            {
                Id = int.Parse(IdTextBox.Text),
                Bloqueado = BloqueadoCheckBox.Checked,
                Eliminado = EliminadoCheckBox.Checked,

                Desde = DesdeDateTimePicker.Value,
                Hasta = HastaDateTimePicker.Value,
                MontoKilometro = decimal.Parse(MontoKmTextBox.Text),

                Coeficientes = coeficientes
            };
        }
        //......................................................................
        private void AgregarCoeficiente()
        {
            var bindingList = (BindingList<Coeficiente>)_vinculante.DataSource;
            bindingList.Add(new Coeficiente
            {
                NivelTarifario = (NivelTarifarioEnum)NivelTarifarioComboBox.SelectedItem,
                Valor = decimal.Parse(ValorTextBox.Text)
            });

            TreeViewService.CargarListaEnTreeView(TarifasTreeView, _listado);
            _modificado = true;
            GuardarModificacionesButton.Enabled = true;
        }

        private void QuitarCoeficiente()
        {
            if (CoeficientesDataGridView.CurrentRow == null) return;

            var bindingList = (BindingList<Coeficiente>)_vinculante.DataSource;
            var coeficiente = (Coeficiente)CoeficientesDataGridView.CurrentRow.DataBoundItem;

            bindingList.Remove(coeficiente);

            TreeViewService.CargarListaEnTreeView(TarifasTreeView, _listado);
            _modificado = true;
            GuardarModificacionesButton.Enabled = true;
        }
        //......................................................................
        private void CrearEntrada()
        {
            var confirmacion = MessageBoxService
        .Confirmar("¿Está seguro de que desea crear una entrada?");

            if (confirmacion)
            {
                var tarifa = Create(new Tarifa
                {
                    Bloqueado = true,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now,
                    MontoKilometro = 1,
                    Coeficientes = new List<Coeficiente>() // Aseguramos que nunca sea null
                });

                _listado.Add(tarifa);
                _vinculante.ResetBindings(false);

                TreeViewService.CargarListaEnTreeView(TarifasTreeView, _listado);
                MessageBoxService.Exito("La entrada se ha creado correctamente.");
            }
        }

        private void GuardarModificaciones()
        {
            var seleccionado = RecuperarDetalles();
            var confirmacion = MessageBoxService
                .Confirmar("¿Está seguro de que desea guardar los cambios?");

            if (confirmacion)
            {
                try
                {
                    bool exito = Update(seleccionado);
                    if (!exito)
                    {
                        MessageBoxService
                            .Informar("Hubo un error al guardar. Intente nuevamente.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxService.Error($"{ex.Message}");
                    return;
                }

                // Solo actualizamos la entrada si el guardado fue exitoso.
                if (ActualizarEntrada(seleccionado)) MessageBoxService
                        .Exito("Las modificaciones se han guardado correctamente.");
                else MessageBoxService
                        .Informar("Hubo un error al actualizar los datos.");
            }
        }

        private bool ActualizarEntrada(Tarifa tarifa)
        {
            try
            {
                _actualizando = true; // Bloquea eventos mientras se actualizan los datos.

                int index = _listado.FindIndex(x => x.Id == tarifa.Id); // La mejor forma de buscar el índice.
                if (index < 0) return false;
                _listado[index] = tarifa; // Reemplaza la entrada vieja con la nueva en la posición correcta.
                TreeViewService.CargarListaEnTreeView(TarifasTreeView, _listado); // Actualiza el TreeView.
                _modificado = false;
                GuardarModificacionesButton.Enabled = false;

                return true;
            }
            catch (Exception ex)
            {
                MessageBoxService.Informar($"Error al actualizar la entrada: {ex.Message}");
                return false;
            }
            finally
            {
                _actualizando = false; // Libera los eventos una vez que todo se ha actualizado.
            }
        }
        //......................................................................
    }
}
