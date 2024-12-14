using AbstractLayer;

using EntityLayer;

using LogicLayer;

using MaterialSkin2Framework.Controls;

using ServiceLayer;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ControllerLayer
{
    /// <summary>Controlador para LiquidadorForm.</summary>
    public class LiquidadorController : ControllerCRU<Liquidacion>
    {
        /// <summary>Constructor.</summary>
        /// <param name="formulario">LiquidadorForm</param>
        public LiquidadorController(Form formulario)
        {
            LiquidadorForm = formulario;

            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }

        private readonly Form LiquidadorForm;
        private const decimal COEF_COMISION = 0.1m;
        private const decimal COEF_REEMBOLSO = 1m;

        //
        // Controles.***********************************************************
        //

#pragma warning disable CS0649 // Campo no asignado.

        // Órdenes.
        private readonly TreeView OrdenesTreeView;
        private readonly TextBox OrdenIdTextBox;
        private readonly MaterialCheckbox ComisionableCheckBox;
        // Comprobantes.
        private readonly DateTimePicker ComprobanteFechaDateTimePicker;
        private readonly TextBox ComprobanteNumeroTextBox;
        private readonly TextBox ComprobanteEmisorTextBox;
        private readonly TextBox ComprobanteConceptoTextBox;
        private readonly TextBox ComprobanteMontoTextBox;
        private readonly Button QuitarComprobanteButton;
        private readonly Button AgregarComprobanteButton;
        private readonly DataGridView ComprobantesDataGridView;
        // Liquidación.
        private readonly TextBox MontoOrdenTextBox;
        private readonly TextBox MontoComprobantesTextBox;
        private readonly TextBox CoeficienteComisionTextBox;
        private readonly TextBox CoeficienteReembolsoTextBox;
        private readonly TextBox ComisionTextBox;
        private readonly TextBox ReembolsoTextBox;
        private readonly MaterialTextBox2 TotalLiquidacionTextBox;
        private readonly Button CancelarOperacionButton;
        private readonly MaterialButton GenerarLiquidacionButton;
        private readonly Button ArchivarOrdenButton;
        private readonly Button ActualizarListadoButton;

#pragma warning restore CS0649 // Campo no asignado.

        //
        // Inicialización.******************************************************
        //

        private void AsignarControles()
        {
            var campos = GetType()          // Obtenemos los campos privados que son de tipo "control".
                .GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Where(x => x.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var campo in campos)
            {
                var nombre = campo.Name;
                var control = LiquidadorForm.Controls.Find(nombre, true).FirstOrDefault();
                if (control == null) continue;  // (Para evitar el llamado al form mismo).
                campo.SetValue(this, control);  // Asignamos el control a la variable correspondiente.
            }
        }

        private void AsignarEventos()
        {
            // Eventos de controles.
            OrdenesTreeView.AfterSelect          += OrdenesTreeView_AfterSelect;
            ComprobantesDataGridView.RowsAdded   += SumarComprobantes;
            ComprobantesDataGridView.RowsRemoved += SumarComprobantes;
            MontoOrdenTextBox.TextChanged        += CalcularComision;
            MontoComprobantesTextBox.TextChanged += CalcularReembolso;

            // Interacción con la vista.
            AgregarComprobanteButton.Click       += AgregarComprobanteButton_Click;
            QuitarComprobanteButton.Click        += QuitarComprobanteButton_Click;
            CancelarOperacionButton.Click        += CancelarOperacionButton_Click;
            GenerarLiquidacionButton.Click       += GenerarLiquidacionButton_Click;
            ArchivarOrdenButton.Click            += ArchivarOrdenButton_Click;
            ActualizarListadoButton.Click        += (s ,e) => InicializarVista();
        }

        private void InicializarVista()
        {
            var logic = GenericFactory.Instanciar<LiquidadorLogic>();
            var listado = logic.ObtenerOrdenesProcesables();
            TreeViewService.CargarListaEnTreeView(OrdenesTreeView, listado);

            MontoOrdenTextBox.Text = 0.ToString("F2");
            MontoComprobantesTextBox.Text = 0.ToString("F2");
            CoeficienteComisionTextBox.Text = COEF_COMISION.ToString("F2");
            CoeficienteReembolsoTextBox.Text = COEF_REEMBOLSO.ToString("F2");
            ComisionTextBox.Text = 0.ToString("F2");
            ReembolsoTextBox.Text = 0.ToString("F2");
            TotalLiquidacionTextBox.Text = 0.ToString("C");
        }

        //
        // Eventos de controles.************************************************
        //

        private void OrdenesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);
                if (orden == null) return;

                OrdenIdTextBox.Text = orden.Id.ToString();
                ComisionableCheckBox.Checked = orden.Comisionable;

                if (orden.Comisionable) MontoOrdenTextBox.Text = orden.Cotizacion.ToString("F2");
                else MontoOrdenTextBox.Text = 0.ToString("F2");
            }
            catch { MessageBoxService.Error("Seleccione una orden válida."); }
        }

        private void CalcularComision(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(MontoOrdenTextBox.Text, out decimal monto))
                {
                    var comision = monto * COEF_COMISION;
                    ComisionTextBox.Text = comision.ToString("F2");
                    TotalLiquidacionTextBox.Text = (comision + decimal.Parse(ReembolsoTextBox.Text)).ToString("C");
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.Error($"Se produjo un error al calcular la comisión: {ex.Message}");
            }
        }

        private void CalcularReembolso(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(MontoComprobantesTextBox.Text, out decimal comprobantes))
                {
                    ReembolsoTextBox.Text = (comprobantes * COEF_REEMBOLSO).ToString("F2");
                    TotalLiquidacionTextBox.Text = (comprobantes + decimal.Parse(ComisionTextBox.Text)).ToString("C");
                }
            }
            catch (Exception ex)
            {
                MessageBoxService.Error($"Se produjo un error al calcular el reembolso: {ex.Message}");
            }
        }

        // Es más sencillo y elegante apelar a la sobrecarga de métodos que a los argumentos opcionales.
        private void SumarComprobantes(object sender, DataGridViewRowsAddedEventArgs e) => SumarComprobantes();
        private void SumarComprobantes(object sender, DataGridViewRowsRemovedEventArgs e) => SumarComprobantes();
        private void SumarComprobantes()
        {
            if (ComprobantesDataGridView.Rows.Count == 0) return;

            try
            {
                decimal total = 0;

                foreach (DataGridViewRow row in ComprobantesDataGridView.Rows)
                {
                    if (row.Cells["Monto"].Value != null
                        && decimal.TryParse(row.Cells["Monto"].Value.ToString(),
                        out decimal monto)) total += monto;
                }

                MontoComprobantesTextBox.Text = total.ToString("F2"); // Formato con 2 decimales
            }
            catch (Exception ex)
            {
                MessageBoxService.Error($"Se produjo un error al calcular el total de los comprobantes: {ex.Message}");
            }
        }

        //
        // Interacción con la vista.********************************************
        //

        private void AgregarComprobanteButton_Click(object sender, EventArgs e)
        {
            var comprobante = CrearComprobante();
            if (comprobante == null) return;

            var logic = GenericFactory.Instanciar<LiquidadorLogic>();
            if (!logic.ValidarComprobante(comprobante))
            {
                MessageBoxService.Error("Revise los datos ingresados.");
                return;
            }

            if (!(ComprobantesDataGridView.DataSource is List<Comprobante> comprobantes)) comprobantes = new List<Comprobante>();
            comprobantes.Add(comprobante);

            ComprobantesDataGridView.DataSource = null;
            ComprobantesDataGridView.DataSource = comprobantes;
        }

        private void QuitarComprobanteButton_Click(object sender, EventArgs e)
        {
            var comprobantes = ComprobantesDataGridView.DataSource as List<Comprobante>;

            if (!(ComprobantesDataGridView.CurrentRow.DataBoundItem is Comprobante comprobante))
            {
                MessageBoxService.Error("Seleccione un comprobante.");
                return;
            }

            comprobantes.Remove(comprobante);
            ComprobantesDataGridView.DataSource = null;
            ComprobantesDataGridView.DataSource = comprobantes;
        }

        private void CancelarOperacionButton_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBoxService.Confirmar("¿Desea cancelar la operación?");
            if (confirmacion) LimpiarControles();
        }

        private void GenerarLiquidacionButton_Click(object sender, EventArgs e)
        {
            var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);

            if (orden == null)
            {
                MessageBoxService.Informar("No hay ninguna orden seleccionada.");
                return;
            }

            // 1. Validar liquidación.
            var logic = GenericFactory.Instanciar<LiquidadorLogic>();
            var datos = CrearLiquidacion();
            if (!logic.ValidarLiquidacion(datos))
            {
                MessageBoxService.Error("Revise los datos ingresados.");
                return;
            }

            // 2. Confirmar acción.
            if (!MessageBoxService.Confirmar("¿Confirma que desea generar la liquidación?")) return;

            try
            {
                // 3. Crear liquidación.
                var liquidacion = Create(datos); // Create devuelve la entidad creada...

                if (liquidacion == null)         // ...y por eso no uso un bool.
                {
                    MessageBoxService.Error("Hubo un error al crear la liquidación. Intente nuevamente.");
                    return;
                }

                // 4. Actualizar orden.
                orden.Estado = EstadoEnum.Liquidada;
                if (!logic.ActualizarOrden(orden))
                {
                    MessageBoxService.Error("Hubo un error al actualizar la orden. Intente nuevamente.");
                    return;
                }

                // 5. Actualizar la transacción.
                var transaccion = logic.ActualizarTransaccion(orden, liquidacion);

                if (transaccion == null) // Pero, en este caso, necesito la entidad...
                {
                    MessageBoxService.Error("Hubo un error al actualizar la transacción. Intente nuevamente.");
                    return;
                }

                // 6. Imprimir liquidación.
                if (!logic.ImprimirLiquidacion(transaccion)) // ...para imprimir el documento.
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

        private void ArchivarOrdenButton_Click(object sender, EventArgs e)
        {
            var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);
            if (orden == null)
            {
                MessageBoxService.Informar("No hay ninguna orden seleccionada.");
                return;
            }

            if (orden.Comisionable)
            {
                MessageBoxService.Error("No se puede archivar una orden comisionable.");
                return;
            }

            if (!MessageBoxService.Confirmar("¿Confirma que desea archivar la orden?")) return;
            var logic = GenericFactory.Instanciar<LiquidadorLogic>();
            orden.Estado = EstadoEnum.Liquidada;
            var liquidacion = CrearLiquidacion();
            if (logic.ActualizarOrden(orden) && logic.ActualizarTransaccion(orden, liquidacion) != null)
            {
                MessageBoxService.Exito("Orden archivada correctamente.");
                LimpiarControles();
                InicializarVista();
            }
            else MessageBoxService.Error("Hubo un error al archivar la orden. Intente nuevamente.");
        }

        //
        // Métodos auxiliares.**************************************************
        //

        private Comprobante CrearComprobante()
        {
            try
            {
                var comprobante = new Comprobante
                {
                    Fecha = ComprobanteFechaDateTimePicker.Value,
                    Numero = ComprobanteNumeroTextBox.Text,
                    Emisor = ComprobanteEmisorTextBox.Text,
                    Concepto = ComprobanteConceptoTextBox.Text,
                    Monto = decimal.Parse(ComprobanteMontoTextBox.Text)
                };
                return comprobante;
            }
            catch
            {
                MessageBoxService.Error("Compruebe los datos del comprobante.");
                return null;
            }
        }

        private Liquidacion CrearLiquidacion()
        {
            try
            {
                if (!(ComprobantesDataGridView.DataSource is List<Comprobante> comprobantes) || comprobantes.Count == 0) comprobantes = new List<Comprobante>();

                var liquidacion = new Liquidacion
                {
                    Fecha = DateTime.Now,
                    Operador = SessionService.Instancia.Empleado.ToString(),
                    Comprobantes = comprobantes,
                    MontoOrden = decimal.Parse(MontoOrdenTextBox.Text),
                    MontoComprobantes = decimal.Parse(MontoComprobantesTextBox.Text),
                    Comision = decimal.Parse(ComisionTextBox.Text),
                    Reembolso = decimal.Parse(ReembolsoTextBox.Text),
                    TotalLiquidacion = decimal.Parse(TotalLiquidacionTextBox.Text, NumberStyles.Currency, CultureInfo.CurrentCulture)
                };
                return liquidacion;
            }
            catch
            {
                MessageBoxService.Error("Compruebe los datos de la liquidación.");
                return null;
            }
        }

        private void LimpiarControles()
        {
            // Éstos, a mano, pues hay textboxes que están sujetos a eventos.
            OrdenIdTextBox.Clear();
            ComisionableCheckBox.Checked = false;
            ComprobanteNumeroTextBox.Clear();
            ComprobanteEmisorTextBox.Clear();
            ComprobanteConceptoTextBox.Clear();
            ComprobanteMontoTextBox.Clear();

            foreach (Control control in LiquidadorForm.Controls)
            {
                switch (control)
                {
                    //case TextBox textBox:
                    //    textBox.Clear();
                    //    break;

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
                        dataGridView.DataSource = null;
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
