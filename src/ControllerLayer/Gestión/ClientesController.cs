using AbstractLayer;

using EntityLayer;

using ServiceLayer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace ControllerLayer
{
    /// <summary>
    /// Controlador para la gestión de clientes.
    /// Maneja la interacción entre la vista y la lógica CRUD.
    /// </summary>
    public class ClientesController : ControllerCRU<Cliente>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="formulario">ClientesForm</param>
        public ClientesController(Form formulario)
        {
            ClientesForm = formulario;
            _listado = Read().ToList();

            AsignarControles();
            AsignarEventos();
            InaugurarVista();
        }
        //
        // Componentes generales.***********************************************
        //
        private readonly Form ClientesForm;
        private readonly List<Cliente> _listado;
        private readonly BindingSource _vinculante = new BindingSource();
        private bool _actualizando = false;
        private bool _modificado = false;
        //
        // Componentes individuales.********************************************
        //
        private DataGridView ClientesDataGridView;
        private CheckBox     BloqueadoCheckBox;
        private CheckBox     EliminadoCheckBox;
        private TextBox      IdTextBox;
        private RadioButton  PersonaFisicaRadioButton;
        private RadioButton  PersonaJuridicaRadioButton;
        private TextBox      DniTextBox;
        private TextBox      CuitTextBox;
        private TextBox      NombreApellidoTextBox;
        private TextBox      RazonSocialTextBox;
        private ComboBox     CondicionFiscalComboBox;
        private ComboBox     NivelTarifarioComboBox;
        private TextBox      DireccionTextBox;
        private TextBox      TelefonoTextBox;
        private TextBox      EmailTextBox;
        private Button       NuevoClienteButton;
        private Button       GuardarModificacionesButton;
        //
        // Inicialización.******************************************************
        //
        private void AsignarControles()
        {
            ClientesDataGridView        = GetControl<DataGridView>("ClientesDataGridView");
            BloqueadoCheckBox           = GetControl<CheckBox>("BloqueadoCheckBox");
            EliminadoCheckBox           = GetControl<CheckBox>("EliminadoCheckBox");
            IdTextBox                   = GetControl<TextBox>("IdTextBox");
            PersonaFisicaRadioButton    = GetControl<RadioButton>("PersonaFisicaRadioButton");
            PersonaJuridicaRadioButton  = GetControl<RadioButton>("PersonaJuridicaRadioButton");
            DniTextBox                  = GetControl<TextBox>("DniTextBox");
            CuitTextBox                 = GetControl<TextBox>("CuitTextBox");
            NombreApellidoTextBox       = GetControl<TextBox>("NombreApellidoTextBox");
            RazonSocialTextBox          = GetControl<TextBox>("RazonSocialTextBox");
            CondicionFiscalComboBox     = GetControl<ComboBox>("CondicionFiscalComboBox");
            NivelTarifarioComboBox      = GetControl<ComboBox>("NivelTarifarioComboBox");
            DireccionTextBox            = GetControl<TextBox>("DireccionTextBox");
            TelefonoTextBox             = GetControl<TextBox>("TelefonoTextBox");
            EmailTextBox                = GetControl<TextBox>("EmailTextBox");
            NuevoClienteButton          = GetControl<Button>("NuevoClienteButton");
            GuardarModificacionesButton = GetControl<Button>("GuardarModificacionesButton");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)ClientesForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            // Generales.
            ClientesDataGridView.RowEnter             += (s, e) => { InterceptarRowEnter(e.RowIndex); };
            // Estado.
            BloqueadoCheckBox.CheckedChanged          += (s, e) => { OnChange(); };
            EliminadoCheckBox.CheckedChanged          += (s, e) => { OnChange(); };
            PersonaFisicaRadioButton.CheckedChanged   += (s, e) => { OnChange(); };
            PersonaJuridicaRadioButton.CheckedChanged += (s, e) => { OnChange(); };
            DniTextBox.TextChanged                    += (s, e) => { OnChange(); };
            CuitTextBox.TextChanged                   += (s, e) => { OnChange(); };
            NombreApellidoTextBox.TextChanged         += (s, e) => { OnChange(); };
            RazonSocialTextBox.TextChanged            += (s, e) => { OnChange(); };
            CondicionFiscalComboBox.TextChanged       += (s, e) => { OnChange(); };
            NivelTarifarioComboBox.TextChanged        += (s, e) => { OnChange(); };
            DireccionTextBox.TextChanged              += (s, e) => { OnChange(); };
            TelefonoTextBox.TextChanged               += (s, e) => { OnChange(); };
            EmailTextBox.TextChanged                  += (s, e) => { OnChange(); };
            // Específicos.
            NuevoClienteButton.Click                  += (s, e) => { CrearEntrada(); };
            GuardarModificacionesButton.Click         += (s, e) => { GuardarModificaciones(); };
            // Especiales.
            PersonaFisicaRadioButton.CheckedChanged   += (s, e) => { OnNaturalezaJuridicaChanged(); };
            PersonaJuridicaRadioButton.CheckedChanged += (s, e) => { OnNaturalezaJuridicaChanged(); };
        }

        private void OnChange()
        {
            if (_actualizando) return; // Ignorar cambios mientras se actualizan datos.

            try
            {
                _modificado = true;
                GuardarModificacionesButton.Enabled = true;
            }
            finally
            {
                _actualizando = false; // Nos aseguramos de que siempre se libere el estado de actualización
            }
        }

        private void OnNaturalezaJuridicaChanged()
        {
            if (_actualizando) return; // Ignorar cambios mientras se actualizan datos.
            _modificado = true;

            if (PersonaFisicaRadioButton.Checked)
            {
                DniTextBox.Enabled = true;
                NombreApellidoTextBox.Enabled = true;
                CuitTextBox.Text = string.Empty;
                CuitTextBox.Enabled = false;
                RazonSocialTextBox.Text = string.Empty;
                RazonSocialTextBox.Enabled = false;
            }
            else if (PersonaJuridicaRadioButton.Checked)
            {
                DniTextBox.Text = string.Empty;
                DniTextBox.Enabled = false;
                NombreApellidoTextBox.Text = string.Empty;
                NombreApellidoTextBox.Enabled = false;
                CuitTextBox.Enabled = true;
                RazonSocialTextBox.Enabled = true;
            }
        }

        private void InaugurarVista()
        {
            _actualizando = true;
            _vinculante.DataSource = _listado;
            ClientesDataGridView.DataSource = _vinculante;
            CondicionFiscalComboBox.DataSource = Enum.GetValues(typeof(CondicionFiscalEnum));
            NivelTarifarioComboBox.DataSource = Enum.GetValues(typeof(NivelTarifarioEnum));
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
            ClientesDataGridView_RowEnter(index);
            _actualizando = false; // Restablece una vez que todo está listo.
        }

        private void ClientesDataGridView_RowEnter(int index)
        {
            if (index < 0) return;
            var cliente = (Cliente)ClientesDataGridView.Rows[index].DataBoundItem;
            if (cliente != null) TranscribirDetalles(cliente);
        }

        private void TranscribirDetalles(Cliente cliente)
        {
            _actualizando = true;
            try
            {
                IdTextBox.Text            = cliente.Id.ToString();
                BloqueadoCheckBox.Checked = cliente.Bloqueado;
                EliminadoCheckBox.Checked = cliente.Eliminado;

                if (cliente is PersonaFisica fisica)
                {
                    PersonaFisicaRadioButton.Checked = true;
                    PersonaJuridicaRadioButton.Checked = false;
                    DniTextBox.Enabled = true;
                    DniTextBox.Text = fisica.DNI;
                    NombreApellidoTextBox.Enabled = true;
                    NombreApellidoTextBox.Text = fisica.NombreApellido;
                    CuitTextBox.Text = string.Empty;
                    CuitTextBox.Enabled = false;
                    RazonSocialTextBox.Text = string.Empty;
                    RazonSocialTextBox.Enabled = false;
                }
                else if (cliente is PersonaJuridica juridica)
                {
                    PersonaFisicaRadioButton.Checked = false;
                    PersonaJuridicaRadioButton.Checked = true;
                    CuitTextBox.Enabled = true;
                    CuitTextBox.Text = juridica.CUIT;
                    RazonSocialTextBox.Enabled = true;
                    RazonSocialTextBox.Text = juridica.RazonSocial;
                    DniTextBox.Text = string.Empty;
                    DniTextBox.Enabled = false;
                    NombreApellidoTextBox.Text = string.Empty;
                    NombreApellidoTextBox.Enabled = false;
                }

                CondicionFiscalComboBox.Text = cliente.CondicionFiscal.ToString();
                NivelTarifarioComboBox.Text  = cliente.NivelTarifario.ToString();
                DireccionTextBox.Text        = cliente.Direccion;
                TelefonoTextBox.Text         = cliente.Telefono;
                EmailTextBox.Text            = cliente.Email;
            }
            finally { _actualizando = false; }
        }
        //
        // Comportamientos específicos.*****************************************
        //
        private Cliente RecuperarDetalles()
        {
            var cliente = 
                PersonaFisicaRadioButton.Checked ? 
                (Cliente)new PersonaFisica() : 
                new PersonaJuridica();

            if (cliente is PersonaFisica fisica)
            {
                fisica.DNI = DniTextBox.Text;
                fisica.NombreApellido = NombreApellidoTextBox.Text;
            }
            else if (cliente is PersonaJuridica juridica)
            {
                juridica.CUIT = CuitTextBox.Text;
                juridica.RazonSocial = RazonSocialTextBox.Text;
            }

            cliente.Id = int.Parse(IdTextBox.Text);
            cliente.Bloqueado = BloqueadoCheckBox.Checked;
            cliente.Eliminado = EliminadoCheckBox.Checked;
            cliente.CondicionFiscal = (CondicionFiscalEnum)Enum.Parse(typeof(CondicionFiscalEnum), CondicionFiscalComboBox.Text);
            cliente.NivelTarifario = (NivelTarifarioEnum)Enum.Parse(typeof(NivelTarifarioEnum), NivelTarifarioComboBox.Text);
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Telefono = TelefonoTextBox.Text;
            cliente.Email = EmailTextBox.Text;

            return cliente;
        }

        private void CrearEntrada()
        {
            var confirmacion = MessageBoxService
                .Confirmar("¿Está seguro de que desea crear una entrada?");

            if (confirmacion)
            {
                var cliente = Create(new PersonaFisica
                {
                    Bloqueado = true,
                    DNI = "Nuevo DNI",
                    NombreApellido = "Nuevo nombre y apellido"
                });

                _listado.Add(cliente);
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

        private bool ActualizarEntrada(Cliente cliente)
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
            finally
            {
                _actualizando = false; // Libera los eventos una vez que todo se ha actualizado.
            }
        }

        //......................................................................
    }
}
