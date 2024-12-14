using AbstractLayer;

using EntityLayer;

using LogicLayer;

using MaterialSkin2Framework.Controls;

using ServiceLayer;

using System;
using System.Linq;
using System.Windows.Forms;

namespace ControllerLayer
{
    /// <summary>Controlador para DespachadorForm.</summary>
    public class DespachadorController : ControllerCRU<Despacho>
    {
        /// <summary>Constructor.</summary>
        /// <param name="formulario">DespachadorForm</param>
        public DespachadorController(Form formulario)
        {
            DespachadorForm = formulario;

            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }

        private readonly Form DespachadorForm;

        //
        // Componentes individuales.********************************************
        //

#pragma warning disable CS0649 // El campo nunca se asigna y siempre tendrá el valor predeterminado false.

        // Principal.
        private readonly MaterialCheckbox   PagadaCheckBox;
        private readonly MaterialCheckbox   TransitoCheckBox;
        private readonly TreeView           OrdenesTreeView;
        // Orden.
        private readonly TextBox            OrdenIdTextBox;
        private readonly TextBox            OrigenTextBox;
        private readonly TextBox            FechaMudanzaTextBox;
        private readonly TextBox            DestinoTextBox;
        private readonly TextBox            DistanciaTextBox;
        private readonly TextBox            CamionTextBox;
        private readonly TextBox            LugarCargaTextBox;
        private readonly TextBox            LugarDescargaTextBox;
        private readonly TextBox            ObservacionesTextBox;
        private readonly ListBox            ItemsListBox;
        // Asignaciones.
        private readonly Panel              AsignacionesPanel;
        private readonly ComboBox           CamionComboBox;
        private readonly ComboBox           ChoferComboBox;
        private readonly ComboBox           EstibadorComboBox;
        private readonly Button             QuitarEstibadorButton;
        private readonly Button             AgregarEstibadorButton;
        private readonly ListBox            EstibadoresListBox;
        private readonly TextBox            InsumoTextBox;
        private readonly Button             QuitarInsumoButton;
        private readonly Button             AgregarInsumoButton;
        private readonly ListBox            InsumosListBox;
        // Resultado.
        private readonly Panel              ResultadoPanel;
        private readonly CheckBox           CompletadaCheckBox;
        private readonly CheckBox           ComisionableCheckBox;
        private readonly MaterialButton     GuardarButton;
        // Acciones.
        private readonly Button             CancelarOrdenButton;
        private readonly Button             GenerarDespachoButton;

#pragma warning restore CS0649 // El campo nunca se asigna y siempre tendrá el valor predeterminado false.

        //
        // Inicialización.******************************************************
        //

        private void AsignarControles()
        {
            // Obtenemos los campos privados que son de tipo "control".
            var campos = GetType()
                .GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Where(x => x.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var campo in campos)
            {
                var nombre = campo.Name;
                var control = DespachadorForm.Controls.Find(nombre, true).FirstOrDefault();
                if (control == null) continue;

                // Asignamos el control a la variable correspondiente.
                campo.SetValue(this, control);
            }
        }

        private void AsignarEventos()
        {
            // Interfaz.
            OrdenesTreeView.AfterSelect         += (s, e) => { TreeView_AfterSelect(s, e); };
            PagadaCheckBox.CheckedChanged       += (s, e) => { ActualizarListado(); };
            TransitoCheckBox.CheckedChanged     += (s, e) => { ActualizarListado(); };
            PagadaCheckBox.CheckedChanged       += (s, e) => { EstablecerModo(); };
            TransitoCheckBox.CheckedChanged     += (s, e) => { EstablecerModo(); };
            CompletadaCheckBox.CheckedChanged   += (s, e) => { EstablecerModo(); };
            // Interacción.
            AgregarEstibadorButton.Click        += (s, e) => { AgregarEstibador(); };
            QuitarEstibadorButton.Click         += (s, e) => { QuitarEstibador(); };
            AgregarInsumoButton.Click           += (s, e) => { AgregarInsumo(); };
            QuitarInsumoButton.Click            += (s, e) => { QuitarInsumo(); };
            GenerarDespachoButton.Click         += (s, e) => { GenerarDespacho(); };
            CancelarOrdenButton.Click           += (s, e) => { CancelarOrden(); };
            GuardarButton.Click                 += (s, e) => { FinalizarServicio(); };
        }

        private void InicializarVista()
        {
            ActualizarListado();
            EstablecerModo();
        }

        private void ActualizarListado()
        {
            var logic = GenericFactory.Instanciar<DespachadorLogic>();
            var listado = logic.ObtenerOrdenesProcesables();

            // Filtar según los checkboxes.
            listado = listado.Where(x => 
                (PagadaCheckBox.Checked && x.Estado == EstadoEnum.Pagada) ||
                (TransitoCheckBox.Checked && x.Estado == EstadoEnum.Transito))
                .ToList();
            
            TreeViewService.CargarListaEnTreeView(OrdenesTreeView, listado);
            LimpiarControles();
        }

        private void EstablecerModo()
        {
            GenerarDespachoButton.Enabled = PagadaCheckBox.Checked && !TransitoCheckBox.Checked;
            AsignacionesPanel.Visible = PagadaCheckBox.Checked && !TransitoCheckBox.Checked;

            GuardarButton.Enabled = !PagadaCheckBox.Checked && TransitoCheckBox.Checked && CompletadaCheckBox.Checked;
            ResultadoPanel.Visible = !PagadaCheckBox.Checked && TransitoCheckBox.Checked;
        }

        //
        // Comportamientos de interfaz.*****************************************
        //

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);

            if (orden != null)
            {
                TranscribirOrden(orden);
                ActualizarComboBoxes(orden);
            }
        }

        private void TranscribirOrden(Orden orden)
        {
            try
            {
                OrdenIdTextBox.Text = orden.Id.ToString();
                FechaMudanzaTextBox.Tag = orden.FechaMudanza;
                FechaMudanzaTextBox.Text = orden.FechaMudanza.ToString("dd/MMM/yyyy");
                OrigenTextBox.Text = orden.Origen;
                DestinoTextBox.Text = orden.Destino;
                DistanciaTextBox.Text = orden.Distancia.ToString();
                LugarCargaTextBox.Text = orden.LugarCarga;
                LugarDescargaTextBox.Text = orden.LugarDescarga;
                ObservacionesTextBox.Text = orden.Observaciones;
                ItemsListBox.DataSource = orden.Items;
                CamionTextBox.Text = orden.Camion.ToString();
            }
            catch { MessageBoxService.Error($"Error al transcribir la orden."); }
        }

        private void ActualizarComboBoxes(Orden orden)
        {
            var logic = GenericFactory.Instanciar<DespachadorLogic>();

            CamionComboBox.DataSource = logic.ObtenerCamionesDisponibles(orden.FechaMudanza);
            ChoferComboBox.DataSource = logic.ObtenerChoferesDisponibles(orden.FechaMudanza);
            EstibadorComboBox.DataSource = logic.ObtenerEstibadoresDisponibles(orden.FechaMudanza);
        }

        //
        // Comportamientos de interacción.*****************************************
        //

        private void AgregarEstibador()
        {
            var disponibles = EstibadorComboBox.Items.Cast<Empleado>().ToList();
            var asignados = EstibadoresListBox.Items.Cast<Empleado>().ToList();

            if (!(EstibadorComboBox.SelectedItem is Empleado estibador))
            {
                MessageBoxService.Error("No hay estibador a agregar.");
                return;
            }

            asignados.Add(estibador);
            disponibles.Remove(estibador);

            // Actualizar el DataSource después de modificar las listas
            EstibadorComboBox.DataSource = null; // Limpiar el DataSource
            EstibadorComboBox.DataSource = disponibles; // Asignar la nueva lista de disponibles

            EstibadoresListBox.DataSource = null; // Limpiar el DataSource
            EstibadoresListBox.DataSource = asignados; // Asignar la nueva lista de asignados

            EstibadorComboBox.SelectedIndex = -1;
        }

        private void QuitarEstibador()
        {
            if (EstibadoresListBox.SelectedItem == null)
            {
                MessageBoxService.Error("Seleccione un ítem a eliminar.");
                return;
            }

            var disponibles = EstibadorComboBox.Items.Cast<Empleado>().ToList();
            var asignados = EstibadoresListBox.Items.Cast<Empleado>().ToList();

            var estibador = EstibadoresListBox.SelectedItem as Empleado;

            disponibles.Add(estibador);
            asignados.Remove(estibador);

            // Actualizar el DataSource después de modificar las listas
            EstibadorComboBox.DataSource = null; // Limpiar el DataSource
            EstibadorComboBox.DataSource = disponibles; // Asignar la nueva lista de disponibles

            EstibadoresListBox.DataSource = null; // Limpiar el DataSource
            EstibadoresListBox.DataSource = asignados; // Asignar la nueva lista de asignados
        }

        private void AgregarInsumo()
        {
            var insumos = InsumosListBox.Items.Cast<string>().ToList();
            string insumo = InsumoTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(insumo))
            {
                MessageBoxService.Error("No hay insumo a agregar.");
                return;
            }

            if (insumos.Contains(insumo))
            {
                MessageBoxService.Error("El insumo ya está en la lista.");
                return;
            }

            InsumosListBox.Items.Add(insumo);
            InsumoTextBox.Clear();
            InsumoTextBox.Focus();
        }

        private void QuitarInsumo()
        {
            if (InsumosListBox.SelectedItem == null)
            {
                MessageBoxService.Error("Seleccione un ítem a eliminar.");
                return;
            }

            string insumo = InsumosListBox.SelectedItem.ToString();
            InsumosListBox.Items.Remove(insumo);
        }

        private void CancelarOrden()
        {
            var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);

            if (orden == null)
            {
                MessageBoxService.Informar("No hay ninguna orden seleccionada.");
                return;
            }

            var confirmacion = MessageBoxService.Confirmar("¿Está seguro de que desea cancelar la orden?");

            if (confirmacion)
            {
                // Campos a actualizar.
                orden.Estado = EstadoEnum.Cancelada;

                // Actualización.
                var logic = GenericFactory.Instanciar<DespachadorLogic>();
                bool exito = logic.ActualizarOrden(orden);

                if (exito) MessageBoxService.Exito("La orden ha sido cancelada correctamente.");
                else MessageBoxService.Informar("Hubo un error al cancelar la orden.");

                LimpiarControles();
                InicializarVista();
            }
        }

        private void FinalizarServicio()
        {
            var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);

            if (orden == null)
            {
                MessageBoxService.Informar("No hay ninguna orden seleccionada.");
                return;
            }

            var confirmacion = MessageBoxService.Confirmar("¿Está seguro de que desea guardar los cambios?");

            if (confirmacion)
            {
                // Campos a actualizar.
                if (CompletadaCheckBox.Checked) orden.Estado = EstadoEnum.Completada;

                if (ComisionableCheckBox.Checked) orden.Comisionable = true;
                else orden.Comisionable = false;

                // Actualización.
                var logic = GenericFactory.Instanciar<DespachadorLogic>();
                bool exito = logic.ActualizarOrden(orden);

                if (exito) MessageBoxService.Exito("La orden ha sido actualizada.");
                else MessageBoxService.Informar("Hubo un error al guardar la orden.");

                LimpiarControles();
                InicializarVista();
            }
        }

        private void GenerarDespacho()
        {
            var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);

            if (orden == null)
            {
                MessageBoxService.Informar("No hay ninguna orden seleccionada.");
                return;
            }

            // 1. Validar despacho.
            var logic = GenericFactory.Instanciar<DespachadorLogic>();
            var datos = RecuperarDespacho();
            if (!logic.ValidarDespacho(datos))
            {
                MessageBoxService.Error("El despacho no es válido. Revise los datos ingresados.");
                return;
            }

            // 2. Confirmar acción.
            if (!MessageBoxService.Confirmar("¿Confirma que desea generar el despacho?")) return;

            try
            {
                // 3. Crear despacho.
                var despacho = Create(datos); // Create devuelve la entidad creada...

                if (despacho == null)         // ...y por eso no uso un bool.
                {
                    MessageBoxService.Error("Hubo un error al crear el despacho. Intente nuevamente.");
                    return;
                }

                // 4. Actualizar la orden.
                orden.Camion = despacho.Camion;
                orden.Estado = EstadoEnum.Transito;
                bool resultado = logic.ActualizarOrden(orden);

                if (!resultado) // En lógica hago que devuelva un bool (es más eficiente).
                {
                    MessageBoxService.Error("Hubo un error al actualizar la orden. Intente nuevamente.");
                    return;
                }

                // 5. Actualizar la transacción.
                var transaccion = logic.ActualizarTransaccion(orden, despacho);

                if (transaccion == null) // Pero, en este caso, necesito la entidad...
                {
                    MessageBoxService.Error("Hubo un error al guardar la transacción. Intente nuevamente.");
                    return;
                }

                if (!logic.ImprimirDespacho(transaccion)) // ...para imprimir el documento.
                {
                    MessageBoxService.Error("Hubo un error al imprimir el documento. Intente nuevamente.");
                    return;
                }

                MessageBoxService.Exito("Operaciones ejecutadas correctamente.");
            }
            catch (Exception ex) { MessageBoxService.Error($"Se produjo un error inesperado: {ex.Message}"); }
            finally 
            {
                LimpiarControles();
                InicializarVista(); 
            }
        }

        //
        // Comportamientos auxiliares.******************************************
        //
        
        private Despacho RecuperarDespacho()
        {
            try
            {
                var estibadores = EstibadoresListBox.Items.Cast<Empleado>().ToList();
                var insumos = InsumosListBox.Items.Cast<string>().ToList();

                return new Despacho
                {
                    Fecha = DateTime.Now,
                    Operador = SessionService.Instancia.Empleado.ToString(),
                    FechaServicio = (DateTime)FechaMudanzaTextBox.Tag,
                    Camion = CamionComboBox.SelectedItem as Camion,
                    Chofer = ChoferComboBox.SelectedItem as Empleado,
                    Estibadores = estibadores,
                    Insumos = insumos
                };
            }
            catch
            {
                MessageBoxService.Error("Error al recuperar los detalles.");
                return null;
            }
        }

        private void LimpiarControles()
        {
            // Controles específicos que no se limpian con el método general.
            CompletadaCheckBox.Checked = false;
            ComisionableCheckBox.Checked = false;
            EstibadoresListBox.DataSource = null;
            InsumosListBox.Items.Clear();

            foreach (Control control in DespachadorForm.Controls)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Clear();
                        break;

                    case ComboBox comboBox:
                        comboBox.SelectedIndex = -1;
                        break;

                    case RadioButton radioButton:
                        radioButton.Checked = false;
                        break;

                    case DateTimePicker dateTimePicker:
                        dateTimePicker.Value = DateTime.Now;
                        break;

                    case DataGridView dataGridView:
                        dataGridView.Rows.Clear();
                        break;

                    case ListBox listBox:
                        listBox.DataSource = null;
                        listBox.Items.Clear();
                        break;
                }
            }
        }

        //......................................................................
    }
}
