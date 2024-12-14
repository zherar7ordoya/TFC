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
    /// <summary>
    /// Controlador para la gestión de facturas.
    /// Maneja la interacción entre la vista y la lógica CRUD.
    /// </summary>
    public class FacturadorController : ControllerCRU<Factura>
    {
        /// <summary>Constructor.</summary>
        /// <param name="formulario">FacturadorForm</param>
        public FacturadorController(Form formulario)
        {
            FacturadorForm = formulario;
            FacturadorForm.Shown += (s, e) => { Form_Shown(); };
        }
        //
        // Componentes generales.***********************************************
        //
        private readonly Form FacturadorForm;
        //
        // Componentes individuales.********************************************
        //
#pragma warning disable CS0649
        // Principal.
        private readonly TreeView        OrdenesTreeView;
        // Cliente.
        private readonly TextBox         ClienteIdTextBox;
        private readonly TextBox         IdentificadorTextBox;
        private readonly TextBox         NombreTextBox;
        private readonly TextBox         DireccionTextBox;
        private readonly TextBox         TelefonoTextBox;
        private readonly TextBox         EmailTextBox;
        private readonly RadioButton     FisicaRadioButton;
        private readonly RadioButton     JuridicaRadioButton;
        private readonly TextBox         CondicionFiscalTextBox;
        private readonly TextBox         NivelTarifarioTextBox;
        // Orden.
        private readonly TextBox         OrdenIdTextBox;
        private readonly TextBox         OrigenTextBox;
        private readonly TextBox         DestinoTextBox;
        private readonly TextBox         DistanciaTextBox;
        private readonly TextBox         FechaMudanzaTextBox;
        // Pago.
        private readonly RadioButton     EfectivoRadioButton;
        private readonly RadioButton     TransferenciaRadioButton;
        private readonly TextBox         CodigoTextBox;
        private readonly Button          VerificarTransferenciaButton;
        private readonly CheckBox        EnCajaCheckBox;
        // Totales.
        private readonly TextBox         SubtotalTextBox;
        private readonly TextBox         ImpuestoTextBox;
        private readonly TextBox         TotalTextBox;
        // Operaciones.
        private readonly Button          CancelarOrdenButton;
        private readonly MaterialButton  GenerarFacturaButton;
#pragma warning restore CS0649
        //
        // Inicialización.******************************************************
        //
        private void Form_Shown()
        {
            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }

        private void AsignarControles()
        {
            // Obtenemos los campos privados que son de tipo "control".
            var campos = GetType()
                .GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Where(x => x.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var campo in campos)
            {
                var nombre = campo.Name;
                var control = FacturadorForm.Controls.Find(nombre, true).FirstOrDefault();
                if (control == null) continue;

                // Asignamos el control a la variable correspondiente.
                campo.SetValue(this, control);
            }
        }

        private void AsignarEventos()
        {
            // Principal.
            OrdenesTreeView.AfterSelect         += (s, e) => TreeView_AfterSelect(s, e);
            // Comportamientos.
            EfectivoRadioButton.CheckedChanged  += (s, e) => EnCajaCheckBox.Enabled = EfectivoRadioButton.Checked;
            VerificarTransferenciaButton.Click  += (s, e) => VerificarTransferencia();
            EnCajaCheckBox.CheckedChanged       += (s, e) => GenerarFacturaButton.Enabled = EnCajaCheckBox.Checked;
            GenerarFacturaButton.Click          += (s, e) => GenerarFactura();
            CancelarOrdenButton.Click           += (s, e) => CancelarOrden();
        }

        private void InicializarVista()
        {
            try
            {
                var logic = GenericFactory.Instanciar<FacturadorLogic>();
                var ordenes = logic.ObtenerOrdenesSolicitadas();
                ReiniciarPago();
                LimpiarFormulario();
                TreeViewService.CargarListaEnTreeView(OrdenesTreeView, ordenes);
            }
            catch { MessageBoxService.Error($"Error al inicializar."); }
        }

        private void ReiniciarPago()
        {
            EfectivoRadioButton.Checked = false;
            TransferenciaRadioButton.Checked = false;
            CodigoTextBox.Text = string.Empty;
            EnCajaCheckBox.Checked = false;
            EnCajaCheckBox.Enabled = false;
        }
        //
        // Comportamientos generales.*******************************************
        //
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);

            if (orden != null)
            {
                TranscribirDetalles(orden);
                CalcularTotal();
                ReiniciarPago();
            }
        }

        private void TranscribirDetalles(Orden orden)
        {
            try
            {
                // Cliente.
                ClienteIdTextBox.Text = orden.Cliente.Id.ToString();

                if(orden.Cliente is PersonaFisica fisica)
                {
                    IdentificadorTextBox.Text = fisica.DNI;
                    NombreTextBox.Text        = fisica.NombreApellido;
                    FisicaRadioButton.Checked = true;
                }
                else if (orden.Cliente is PersonaJuridica juridica)
                {
                    IdentificadorTextBox.Text   = juridica.CUIT;
                    NombreTextBox.Text          = juridica.RazonSocial;
                    JuridicaRadioButton.Checked = true;
                }

                DireccionTextBox.Text       = orden.Cliente.Direccion;
                TelefonoTextBox.Text        = orden.Cliente.Telefono;
                EmailTextBox.Text           = orden.Cliente.Email;
                CondicionFiscalTextBox.Text = orden.Cliente.CondicionFiscal.ToString();
                NivelTarifarioTextBox.Text  = orden.Cliente.NivelTarifario.ToString();

                // Orden.
                OrdenIdTextBox.Text             = orden.Id.ToString();
                OrigenTextBox.Text              = orden.Origen;
                DestinoTextBox.Text             = orden.Destino;
                DistanciaTextBox.Text           = orden.Distancia.ToString();
                FechaMudanzaTextBox.Text        = orden.FechaMudanza.ToString("ddd dd-MMMM-yyyy");
            }
            catch { MessageBoxService.Error($"Error al transcribir la orden."); }
        }

        private void CalcularTotal()
        {
            try
            {
                var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);
                if (orden == null) return;

                var (subtotal, impuesto, total) = CalcularTotales(orden.Cotizacion);

                SubtotalTextBox.Text = subtotal.ToString("C");
                ImpuestoTextBox.Text = impuesto.ToString("C");
                TotalTextBox.Text    = total.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBoxService.Error($"Error al calcular totales: {ex.Message}");
            }
        }
        //
        // Comportamientos específicos.*****************************************
        //
        private void VerificarTransferencia()
        {
            if (EfectivoRadioButton.Checked)
            {
                MessageBoxService.Informar("No es necesario verificar el pago en efectivo.");
                return;
            }

            if (CodigoTextBox.Text == string.Empty)
            {
                MessageBoxService.Informar("Debe ingresar un código de transferencia.");
                return;
            }

            MessageBoxService.Informar("Verificación de pago no implementada.\n\nSimulando...\n\nVerificación correcta.");
            EnCajaCheckBox.Enabled = true;
        }

        private void GenerarFactura()
        {
            // 1. Validar factura.
            var logic = GenericFactory.Instanciar<FacturadorLogic>();
            var datos = RecuperarDetalleFactura();
            if (!logic.ValidarFactura(datos)) return;

            // 2. Confirmar acción.
            if (!MessageBoxService.Confirmar("¿Confirma que desea generar la factura?")) return;

            try
            {
                // 3. Crear la factura.
                var factura = Create(datos); // Create devuelve la entidad creada...

                if (factura == null)         // ...y por eso no uso un bool.
                {
                    MessageBoxService.Error("Hubo un error al crear la orden. Intente nuevamente.");
                    return;
                }

                // 4. Actualizar la orden.
                var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);
                orden.Estado = EstadoEnum.Pagada;
                bool resultado = logic.ActualizarOrden(orden);

                if (!resultado) // En lógica hago que devuelva un bool (es más eficiente).
                {
                    MessageBoxService.Error("Hubo un error al actualizar la orden. Intente nuevamente.");
                    return;
                }

                // 5. Actualizar la transacción.
                var transaccion = logic.ActualizarTransaccion(orden, factura);

                if (transaccion == null) // Pero, en este caso, necesito la entidad...
                {
                    MessageBoxService.Error("Hubo un error al guardar la transacción. Intente nuevamente.");
                    return;
                }

                if (!logic.ImprimirFactura(transaccion)) // ...para imprimir el documento.
                {
                    MessageBoxService.Error("Hubo un error al imprimir el documento. Intente nuevamente.");
                    return;
                }

                MessageBoxService.Exito("Operaciones ejecutadas correctamente.");
            }
            catch (Exception ex) { MessageBoxService.Error($"Se produjo un error inesperado: {ex.Message}"); }
            finally { InicializarVista(); }
        }

        private void CancelarOrden()
        {
            var confirmacion = MessageBoxService.Confirmar("¿Está seguro de que desea cancelar la orden?");

            if (confirmacion)
            {
                var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);

                if (orden == null)
                {
                    MessageBoxService.Informar("No hay ninguna orden seleccionada.");
                    return;
                }

                var logic = GenericFactory.Instanciar<FacturadorLogic>();
                bool exito = logic.CancelarOrden(orden);

                if (exito) MessageBoxService.Exito("La orden ha sido cancelada correctamente.");
                else MessageBoxService.Informar("Hubo un error al cancelar la orden.");

                InicializarVista();
            }
        }
        //
        // Métodos auxiliares.**************************************************
        //
        private (decimal subtotal, decimal impuesto, decimal total) CalcularTotales(decimal cotizacion)
        {
            decimal iva = ConfigurationService.Configuracion.PorcentajeIVA;
            decimal impuesto = cotizacion * iva / 100;
            decimal total = cotizacion + impuesto;
            return (cotizacion, impuesto, total);
        }

        private Factura RecuperarDetalleFactura()
        {
            var orden = TreeViewService.ObtenerObjetoSeleccionado<Orden>(OrdenesTreeView);

            if (orden != null)
            {
                var (subtotal, impuesto, total) = CalcularTotales(orden.Cotizacion);

                return new Factura
                {
                    Fecha    = DateTime.Now,
                    Operador = SessionService.Instancia.Empleado.ToString(),
                    Subtotal = subtotal,
                    Impuesto = impuesto,
                    Total    = total
                };
            }

            return null;
        }

        private void LimpiarFormulario()
        {
            foreach (Control control in FacturadorForm.Controls)
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

                    case PictureBox pictureBox:
                        pictureBox.Image = null;
                        break;

                    case DataGridView dataGridView:
                        dataGridView.Rows.Clear();
                        break;

                    case ListBox listBox:
                        listBox.Items.Clear();
                        break;
                }
            }
        }
        //......................................................................
    }
}
