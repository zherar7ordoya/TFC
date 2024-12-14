using EntityLayer;

using ServiceLayer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ControllerLayer
{
    /// <summary>
    /// Controlador para la gestión de camiones.
    /// Maneja la interacción entre la vista y la lógica CRUD.
    /// </summary>
    public class CamionesController : ControllerCRU<Camion>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="formulario">CamionesForm</param>
        public CamionesController(Form formulario)
        {
            CamionesForm = formulario;
            _listado = Read().ToList();

            AsignarControles();
            AsignarEventos();
            InaugurarVista();
        }
        //
        // Componentes generales.***********************************************
        //
        private readonly Form CamionesForm;
        private readonly List<Camion> _listado;
        private readonly BindingSource _vinculante = new BindingSource();

        private bool _actualizando = false;
        private bool _modificado = false;
        //
        // Componentes individuales.********************************************
        //
        private DataGridView CamionesDataGridView;
        private CheckBox BloqueadoCheckBox;
        private CheckBox EliminadoCheckBox;
        private TextBox IdTextBox;
        private TextBox MarcaTextBox;
        private TextBox ModeloTextBox;
        private TextBox DominioTextBox;
        private TextBox ObservacionesTextBox;
        private Button NuevoCamionButton;
        private Button GuardarModificacionesButton;
        //
        // Inicialización.******************************************************
        //
        private void AsignarControles()
        {
            CamionesDataGridView        = GetControl<DataGridView>("CamionesDataGridView");
            BloqueadoCheckBox           = GetControl<CheckBox>("BloqueadoCheckBox");
            EliminadoCheckBox           = GetControl<CheckBox>("EliminadoCheckBox");
            IdTextBox                   = GetControl<TextBox>("IdTextBox");
            MarcaTextBox                = GetControl<TextBox>("MarcaTextBox");
            ModeloTextBox               = GetControl<TextBox>("ModeloTextBox");
            DominioTextBox              = GetControl<TextBox>("DominioTextBox");
            ObservacionesTextBox        = GetControl<TextBox>("ObservacionesTextBox");
            NuevoCamionButton           = GetControl<Button>("NuevoCamionButton");
            GuardarModificacionesButton = GetControl<Button>("GuardarModificacionesButton");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)CamionesForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            // Generales.
            CamionesDataGridView.RowEnter     += (s, e) => { InterceptarRowEnter(e.RowIndex); };
            // Estado.
            BloqueadoCheckBox.CheckedChanged  += (s, e) => { OnChange(); };
            EliminadoCheckBox.CheckedChanged  += (s, e) => { OnChange(); };
            MarcaTextBox.TextChanged          += (s, e) => { OnChange(); };
            ModeloTextBox.TextChanged         += (s, e) => { OnChange(); };
            DominioTextBox.TextChanged        += (s, e) => { OnChange(); };
            ObservacionesTextBox.TextChanged  += (s, e) => { OnChange(); };
            // Específicos.
            NuevoCamionButton.Click           += (s, e) => { CrearEntrada(); };
            GuardarModificacionesButton.Click += (s, e) => { GuardarModificaciones(); };
        }

        private void OnChange()
        {
            if (_actualizando) return; // Ignorar cambios mientras se actualizan datos.
            _modificado = true;
            GuardarModificacionesButton.Enabled = true;
        }

        private void InaugurarVista()
        {
            _vinculante.DataSource = _listado;
            CamionesDataGridView.DataSource = _vinculante;
            CamionesDataGridView.Refresh();
        }
        //
        // Comportamientos generales.*******************************************
        //
        private void InterceptarRowEnter(int index)
        {
            if (_actualizando) return; // Si estamos actualizando, salimos.

            if (_modificado)
            {
                var resultado = MessageBoxService.Confirmar("¿Desea guardar los cambios antes de continuar?");
                if (resultado) GuardarModificaciones();
                _modificado = false;
            }
            
            _actualizando = true; // Verdadero mientras manipula el datagrid.
            CamionesDataGridView_RowEnter(index);
            _actualizando = false; // Restablece una vez que todo está listo.
        }

        private void CamionesDataGridView_RowEnter(int index)
        {
            if (index < 0) return;
            var camion = (Camion)CamionesDataGridView.Rows[index].DataBoundItem;
            if (camion != null) TranscribirDetalles(camion);
        }

        private void TranscribirDetalles(Camion camion)
        {
            _actualizando = true;
            try
            {
                IdTextBox.Text = camion.Id.ToString();
                BloqueadoCheckBox.Checked = camion.Bloqueado;
                EliminadoCheckBox.Checked = camion.Eliminado;
                MarcaTextBox.Text = camion.Marca;
                ModeloTextBox.Text = camion.Modelo;
                DominioTextBox.Text = camion.Dominio;
                ObservacionesTextBox.Text = camion.Observaciones;
            }
            finally { _actualizando = false; }
        }
        //
        // Comportamientos específicos.*****************************************
        //
        private Camion RecuperarDetalles()
        {
            var recuperado = new Camion
            {
                Id = int.Parse(IdTextBox.Text),
                Bloqueado = BloqueadoCheckBox.Checked,
                Eliminado = EliminadoCheckBox.Checked,
                Marca = MarcaTextBox.Text,
                Modelo = ModeloTextBox.Text,
                Dominio = DominioTextBox.Text,
                Observaciones = ObservacionesTextBox.Text
            };
            return recuperado;
        }

        private void CrearEntrada()
        {
            var confirmacion = MessageBoxService.Confirmar("¿Está seguro de que desea crear una entrada?");

            if (confirmacion)
            {
                var camion = Create(new Camion
                {
                    Bloqueado = true,
                    Marca = "Nueva marca",
                    Modelo = "Nuevo modelo",
                    Dominio = "Nuevo dominio"
                });

                _listado.Add(camion);
                _vinculante.ResetBindings(false);
                MessageBoxService.Exito("La entrada se ha creado correctamente.");
            }
        }

        private void GuardarModificaciones()
        {
            var seleccionado = RecuperarDetalles();
            var confirmacion = MessageBoxService.Confirmar("¿Está seguro de que desea guardar los cambios?");

            if (confirmacion)
            {
                bool exito = Update(seleccionado);
                if (!exito)
                {
                    MessageBoxService.Informar("Hubo un error al guardar. Intente nuevamente.");
                    return;
                }

                // Solo actualizamos la entrada si el guardado fue exitoso.
                if (ActualizarEntrada(seleccionado)) MessageBoxService.Exito("Las modificaciones se han guardado correctamente.");
                else MessageBoxService.Informar("Hubo un error al actualizar los datos.");
            }
        }

        private bool ActualizarEntrada(Camion camion)
        {
            try
            {
                _actualizando = true; // Bloquea eventos mientras se actualizan los datos.

                int index = _listado.FindIndex(x => x.Id == camion.Id);  // Mejor búsqueda de índice
                if (index < 0) return false; // Si no se encuentra, falla.
                _listado[index] = camion; // Reemplaza la entrada vieja con la nueva en la posición correcta.
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
            finally
            {
                _actualizando = false; // Libera los eventos una vez que todo se ha actualizado.
            }
        }

        //......................................................................
    }
}
