using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using EntityLayer;

using ServiceLayer;

namespace ControllerLayer
{
    /// <summary>
    /// Controlador para la gestión de locaciones.
    /// Maneja la interacción entre la vista y la lógica CRUD.
    /// </summary>
    public class LocacionesController : ControllerCRU<Locacion>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="formulario">LocacionesForm</param>
        public LocacionesController(Form formulario)
        {
            LocacionesForm = formulario;
            _listado = Read().ToList();

            AsignarControles();
            AsignarEventos();
            InaugurarVista();
        }
        //
        // Componentes generales.***********************************************
        //
        private readonly Form LocacionesForm;
        private readonly List<Locacion> _listado;
        private readonly BindingSource _vinculante = new BindingSource();

        private bool _actualizando = false;
        private bool _modificado = false;
        //
        // Componentes individuales.********************************************
        //
        // Controles fijos superiores.
        private DataGridView  LocacionesDataGridView;
        private CheckBox      BloqueadoCheckBox;
        private CheckBox      EliminadoCheckBox;
        private TextBox       IdTextBox;
        // Controles variables generales.
        // [...]
        // Controles variables específicos.
        private TextBox       LugarTextBox;
        private NumericUpDown XNumericUpDown;
        private NumericUpDown YNumericUpDown;
        // Controles fijos inferiores.
        private Button        NuevaLocacionButton;
        private Button        GuardarModificacionesButton;
        //
        // Inicialización.******************************************************
        //
        private void AsignarControles()
        {
            // Controles fijos superiores.
            LocacionesDataGridView =        GetControl<DataGridView>("LocacionesDataGridView");
            BloqueadoCheckBox =             GetControl<CheckBox>("BloqueadoCheckBox");
            EliminadoCheckBox =             GetControl<CheckBox>("EliminadoCheckBox");
            IdTextBox =                     GetControl<TextBox>("IdTextBox");
            // Controles variables generales.
            // [...]
            // Controles variables específicos.
            LugarTextBox =                  GetControl<TextBox>("LugarTextBox");
            XNumericUpDown =                GetControl<NumericUpDown>("XNumericUpDown");
            YNumericUpDown =                GetControl<NumericUpDown>("YNumericUpDown");

            // Controles finales inferiores.
            NuevaLocacionButton =           GetControl<Button>("NuevaLocacionButton");
            GuardarModificacionesButton =   GetControl<Button>("GuardarModificacionesButton");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)LocacionesForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            // Generales.
            LocacionesDataGridView.RowEnter +=   (s, e) => { InterceptarRowEnter(e.RowIndex); };
            // Estado.
            BloqueadoCheckBox.CheckedChanged +=  (s, e) => { OnChange(); };
            EliminadoCheckBox.CheckedChanged +=  (s, e) => { OnChange(); };
            LugarTextBox.TextChanged +=          (s, e) => { OnChange(); };
            XNumericUpDown.ValueChanged +=       (s, e) => { OnChange(); };
            YNumericUpDown.ValueChanged +=       (s, e) => { OnChange(); };
            // Específicos.
            NuevaLocacionButton.Click +=         (s, e) => { CrearEntrada(); };
            GuardarModificacionesButton.Click += (s, e) => { GuardarModificaciones(); };
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

            _vinculante.DataSource = _listado;
            LocacionesDataGridView.DataSource = _vinculante;

            _actualizando = false;
        }
        //
        // Comportamientos generales.*******************************************
        //
        private void InterceptarRowEnter(int index)
        {
            if (_actualizando) return; // Si estamos actualizando, salimos.

            if (_modificado)
            {
                var resultado = MessageBoxService
                    .Confirmar("¿Desea guardar los cambios antes de continuar?");
                if (resultado) GuardarModificaciones();
                _modificado = false;
            }

            _actualizando = true; // Verdadero mientras manipula el datagrid.
            LocacionesDataGridView_RowEnter(index);
            _actualizando = false; // Restablece una vez que todo está listo.
        }

        private void LocacionesDataGridView_RowEnter(int index)
        {
            if (index < 0) return;
            var cliente = (Locacion)LocacionesDataGridView.Rows[index].DataBoundItem;
            if (cliente != null) TranscribirDetalles(cliente);
        }

        private void TranscribirDetalles(Locacion locacion)
        {
            _actualizando = true;
            try
            {
                // Controles fijos superiores.
                BloqueadoCheckBox.Checked = locacion.Bloqueado;
                EliminadoCheckBox.Checked = locacion.Eliminado;
                IdTextBox.Text =            locacion.Id.ToString();
                // Controles variables generales.
                // [...]
                // Controles variables específicos.
                LugarTextBox.Text =         locacion.Lugar;
                XNumericUpDown.Value =      locacion.X;
                YNumericUpDown.Value =      locacion.Y;
                // Controles finales inferiores.
                // [...]
            }
            finally { _actualizando = false; }
        }
        //
        // Comportamientos específicos.*****************************************
        //
        private Locacion RecuperarDetalles()
        {
            return new Locacion
            {
                Id = int.Parse(IdTextBox.Text),
                Bloqueado = BloqueadoCheckBox.Checked,
                Eliminado = EliminadoCheckBox.Checked,
                Lugar = LugarTextBox.Text,
                X = (int)XNumericUpDown.Value,
                Y = (int)YNumericUpDown.Value
            };
        }

        private void CrearEntrada()
        {
            var confirmacion = MessageBoxService
                .Confirmar("¿Está seguro de que desea crear una entrada?");

            if (confirmacion)
            {
                var locacion = Create(new Locacion
                {
                    Bloqueado = true,
                    Lugar = "Nueva locación"
                });

                _listado.Add(locacion);
                _vinculante.ResetBindings(false);
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
                    MessageBoxService.Informar($"Error inesperado: {ex.Message}");
                }

                // Solo actualizamos la entrada si el guardado fue exitoso.
                if (ActualizarEntrada(seleccionado)) MessageBoxService
                        .Exito("Las modificaciones se han guardado correctamente.");
                else MessageBoxService
                        .Informar("Hubo un error al actualizar los datos.");
            }
        }

        private bool ActualizarEntrada(Locacion cliente)
        {
            try
            {
                _actualizando = true; // Bloquea eventos mientras se actualizan los datos.

                int index = _listado.FindIndex(x => x.Id == cliente.Id);  // Mejor búsqueda de índice
                if (index < 0) return false; // Si no se encuentra, falla.
                _listado[index] = cliente; // Reemplaza la entrada vieja con la nueva en la posición correcta.
                _vinculante.ResetBindings(false);
                _modificado = false;
                GuardarModificacionesButton.Enabled = false;

                return true;
            }
            catch (Exception ex)
            {
                MessageBoxService.Informar($"Error al actualizar la entrada: {ex.Message}");
                return false;
            }
            finally { _actualizando = false; }
        }

        //......................................................................
    }
}
