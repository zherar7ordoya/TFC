using AbstractLayer;
using EntityLayer;
using ServiceLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using System.Windows.Forms;

using System;
using MaterialSkin2Framework.Controls;
using LogicLayer;
using System.Drawing;

namespace ControllerLayer
{
    /// <summary>Controla la captura de órdenes de mudanza.</summary>
    public class CapturadorController : ControllerCRU<Orden>
    {
        /// <summary>Constructor.</summary>
        /// <param name="formulario">CapturadorForm.</param>
        public CapturadorController(Form formulario)
        {
            CapturadorForm = formulario;
            CapturadorForm.Shown += (s, e) => { Form_Shown(); };
        }
        //
        // Componentes generales.***********************************************
        //
        private readonly Form CapturadorForm;
        private readonly List<Locacion> _locaciones = GenericFactory.Instanciar<CapturadorLogic>().ObtenerLocacionesActivas();
        //
        // Componentes individuales.********************************************
        //

        // Mapa.
#pragma warning disable CS0649
        private readonly ComboBox       OrigenComboBox;          // Carga adicional #1.
        private readonly ComboBox       DestinoComboBox;         // Carga adicional #2.
        private readonly TextBox        CentralCargaTextBox;
        private readonly TextBox        CargaDescargaTextBox;
        private readonly TextBox        DescargaCentralTextBox;
        private readonly TextBox        DistanciaTotalTextBox;
        private readonly Label          MonitorLabel;
        private readonly PictureBox     MapaPictureBox;
        // Servicio.
        private readonly DateTimePicker FechaMudanzaDateTimePicker;
        private readonly ComboBox       CamionComboBox;          // Carga adicional #3.
        // Cliente.
        private readonly Button         BuscarClienteButton;
        private readonly Button         CrearClienteButton;
        private readonly TextBox        IdTextBox;
        private readonly TextBox        IdentificadorTextBox;
        private readonly TextBox        NombreTextBox;
        private readonly ComboBox       CondicionFiscalComboBox; // Carga adicional #4.
        private readonly RadioButton    PersonaFisicaRadioButton;
        private readonly RadioButton    PersonaJuridicaRadioButton;
        private readonly ComboBox       NivelTarifarioComboBox;  // Carga adicional #5.
        private readonly TextBox        DireccionTextBox;
        private readonly TextBox        TelefonoTextBox;
        private readonly TextBox        EmailTextBox;
        private readonly Button         GuardarClienteButton;
        // Cotización.
        private readonly MaterialButton CotizarButton;
        private readonly TextBox        CotizacionTextBox;
        // Detalles.
        private readonly TextBox        LugarCargaTextBox;
        private readonly TextBox        LugarDescargaTextBox;
        private readonly TextBox        ObservacionesTextBox;
        // Ítems.
        private readonly TextBox        ItemTextBox;
        private readonly Button         AgregarItemButton;
        private readonly Button         QuitarItemButton;
        private readonly ListBox        ItemsListBox;
        // Operaciones.
        private readonly Button         CancelarOperacionButton;
        private readonly Button         GenerarOrdenButton;
#pragma warning restore CS0649
        //
        // Inicialización.******************************************************
        //
        private void Form_Shown()
        {
            AsignarControles();
            AsignarEventos();
            InaugurarVista();
        }

        private void AsignarControles()
        {
            // Obtenemos los campos privados que son de tipo Control
            var campos = GetType()
                .GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Where(x => x.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var campo in campos)
            {
                var nombre = campo.Name;

                // Usamos Find solo dentro de los controles, excluyendo el formulario
                var control = CapturadorForm.Controls.Find(nombre, true).FirstOrDefault();

                // Si no se encontró el control, continuamos con el siguiente.
                if (control == null) continue;

                // Asigna el control a la variable correspondiente
                campo.SetValue(this, control);
            }
        }

        private void AsignarEventos()
        {
            OrigenComboBox.SelectedIndexChanged     += (s, e) => { CalcularDistancia(); };
            DestinoComboBox.SelectedIndexChanged    += (s, e) => { CalcularDistancia(); };
            MapaPictureBox.Paint                    += (s, e) => { PictureBox_Paint(e); };
            FechaMudanzaDateTimePicker.CloseUp      += (s, e) => { DateTimePicker_CloseUp(); };
            BuscarClienteButton.Click               += (s, e) => { BuscarCliente(); };
            CrearClienteButton.Click                += (s, e) => { CrearCliente(); };
            GuardarClienteButton.Click              += (s, e) => { GuardarCliente(); };
            CotizarButton.Click                     += (s, e) => { Cotizar(); };
            AgregarItemButton.Click                 += (s, e) => { AgregarItem(); };
            QuitarItemButton.Click                  += (s, e) => { QuitarItem(); };
            CancelarOperacionButton.Click           += (s, e) => { CancelarOperacion(); };
            GenerarOrdenButton.Click                += (s, e) => { GenerarOrden(); };
        }

        private void InaugurarVista()
        {
            // Crear copias de la lista para evitar que compartan el mismo DataSource
            OrigenComboBox.DataSource = new BindingList<Locacion>(_locaciones.ToList());
            DestinoComboBox.DataSource = new BindingList<Locacion>(_locaciones.ToList());

            // Configurar el DateTimePicker para que no permita fechas anteriores a la actual.
            FechaMudanzaDateTimePicker.MinDate = DateTime.Now.Date;

            CondicionFiscalComboBox.DataSource = Enum.GetValues(typeof(CondicionFiscalEnum));
            NivelTarifarioComboBox.DataSource = Enum.GetValues(typeof(NivelTarifarioEnum));

            CalcularDistancia();
            ObtenerCamionesDisponibles();
            LimpiarFormulario();
        }
        //
        // Operaciones de carga.************************************************
        //
        private void CalcularDistancia()
        {
            var logic = GenericFactory.Instanciar<CapturadorLogic>();
            string origen = OrigenComboBox.SelectedItem?.ToString();
            string destino = DestinoComboBox.SelectedItem?.ToString();

            if (origen != null && destino != null)
            {
                Locacion carga = _locaciones.Find(x => x.Lugar == origen);
                Locacion descarga = _locaciones.Find(x => x.Lugar == destino);

                // Calcula la distancia desde la central (0,0) al punto de carga
                int centralCarga = logic.DistanciarDesdeCentral(carga);
                CentralCargaTextBox.Text = centralCarga.ToString();

                // Calcula la distancia del punto de carga al punto de descarga
                int cargaDescarga = logic.DistanciarEntreLocaciones(carga, descarga);
                CargaDescargaTextBox.Text = cargaDescarga.ToString();

                // Calcula la distancia desde el punto de descarga (hasta) a la central (0,0)
                int descargaCentral = logic.DistanciarDesdeCentral(descarga);
                DescargaCentralTextBox.Text = descargaCentral.ToString();

                // Suma de todas las distancias
                int distanciaTotal = centralCarga + cargaDescarga + descargaCentral;
                DistanciaTotalTextBox.Text = distanciaTotal.ToString();

                // Actualizar etiqueta de monitor y refrescar el mapa.
                if (distanciaTotal == 0)
                {
                    MonitorLabel.ForeColor = Color.Black;
                    MonitorLabel.Text = "Seleccione una locación de origen y una de destino.";
                }
                else if (distanciaTotal > 372)
                {
                    MonitorLabel.ForeColor = Color.DarkRed;
                    MonitorLabel.Text = "La distancia a cubrir excede los 372 kilómetros. Consulte antes de continuar.";
                }
                else
                {
                    MonitorLabel.ForeColor = Color.DarkGreen;
                    MonitorLabel.Text = "La distancia total está dentro del rango inconsulto (372 kilómetros).";
                }

                MapaPictureBox.Refresh();
            }
        }

        private void PictureBox_Paint(PaintEventArgs e)
        {
            if (OrigenComboBox.SelectedItem != null && DestinoComboBox.SelectedItem != null)
            {
                string carga = OrigenComboBox.SelectedItem.ToString();
                string descarga = DestinoComboBox.SelectedItem.ToString();

                Locacion origen = _locaciones.Find(x => x.Lugar == carga);
                Locacion destino = _locaciones.Find(x => x.Lugar == descarga);

                MarcarPuntosEnMapa(e.Graphics, origen, destino);
            }
        }

        private void MarcarPuntosEnMapa(Graphics graphics, Locacion origen, Locacion destino)
        {
            List<(Point Punto, string Nombre, Brush Color)> puntos = new List<(Point, string, Brush)>();

            // Definir los puntos
            int x = MapaPictureBox.Width / 2;
            int y = MapaPictureBox.Height / 2;

            Point central = new Point(x, y);
            Point carga = new Point(central.X + origen.X, central.Y - origen.Y);
            Point descarga = new Point(central.X + destino.X, central.Y - destino.Y);

            // Agregar los puntos a la lista con colores y nombres
            puntos.Add((central, "Central", Brushes.Red)); // Central en rojo
            puntos.Add((carga, "Carga", Brushes.Blue));    // Carga en azul
            puntos.Add((descarga, "Descarga", Brushes.Green)); // Descarga en verde

            Pen pen = new Pen(Color.Gray); // Ejes en gris

            // Dibujar ejes cartesianos
            graphics.DrawLine(pen, 0, central.Y, MapaPictureBox.Width, central.Y); // Eje X
            graphics.DrawLine(pen, central.X, 0, central.X, MapaPictureBox.Height); // Eje Y

            Font font = new Font("Calibri", 11);

            foreach (var punto in puntos)
            {
                // Dibujar punto sólido
                graphics.FillEllipse(punto.Color, punto.Punto.X - 5, punto.Punto.Y - 5, 10, 10);

                // Dibujar nombre del punto con el mismo color
                graphics.DrawString(punto.Nombre, font, punto.Color, punto.Punto.X + 10, punto.Punto.Y - 10);
            }

            // Limpiar los recursos
            pen.Dispose();
        }

        private void DateTimePicker_CloseUp()
        {
            ObtenerCamionesDisponibles();
        }

        private void ObtenerCamionesDisponibles()
        {
            var logic = GenericFactory.Instanciar<CapturadorLogic>();
            var camiones = logic.ObtenerCamionesDisponibles(FechaMudanzaDateTimePicker.Value);

            if (!camiones.Any()) MessageBoxService.Informar("No hay camiones disponibles para la fecha seleccionada.");
            else CamionComboBox.DataSource = camiones;
        }
        //
        // Operaciones de usuario.**********************************************
        //
        private void BuscarCliente()
        {
            CapturadorForm.Visible = false;
            var logic = GenericFactory.Instanciar<CapturadorLogic>();
            var clientes = logic.ObtenerClientesActivos();

            var buscable = new ClienteSearch(clientes);
            var buscador = new SearchService<Cliente>(buscable);

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                var cliente = buscador.SelectedItem;
                TranscribirDetallesCliente(cliente);
            }

            CapturadorForm.Visible = true;
        }

        private void CrearCliente()
        {
            var confirmacion = MessageBoxService
                .Confirmar("¿Está seguro de que desea crear una entrada?");

            if (confirmacion)
            {
                var cru = GenericFactory.Instanciar<ControllerCRU<Cliente>>();
                var cliente = cru.Create(new PersonaFisica
                {
                    Bloqueado = true,
                    DNI = "Nuevo DNI",
                    NombreApellido = "Nuevo nombre y apellido"
                });

                TranscribirDetallesCliente(cliente);
                MessageBoxService.Exito("La entrada se ha creado correctamente.");
            }
        }

        private void GuardarCliente()
        {
            var logic = GenericFactory.Instanciar<CapturadorLogic>();
            var cliente = RecuperarDetallesCliente();

            if (!logic.ValidarOrden(cliente)) return;

            var confirmacion = MessageBoxService
                .Confirmar("¿Confirma que desea generar el documento?");

            if (confirmacion)
            {
                try
                {
                    var cru = GenericFactory.Instanciar<ControllerCRU<Cliente>>();
                    bool exito = cru.Update(cliente);

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

                MessageBoxService.Exito("Las modificaciones se han guardado correctamente.");
            }
        }

        private decimal Cotizar()
        {
            try
            {
                var fecha = FechaMudanzaDateTimePicker.Value;
                var categoria = (NivelTarifarioEnum)Enum.Parse(typeof(NivelTarifarioEnum), NivelTarifarioComboBox.Text);
                var kilometros = int.Parse(DistanciaTotalTextBox.Text);

                var logic = GenericFactory.Instanciar<CapturadorLogic>();
                var cotizacion = logic.CotizarServicio(fecha, categoria, kilometros);
                CotizacionTextBox.Text = cotizacion.ToString("C");

                return cotizacion;
            }
            catch
            {
                MessageBoxService.Error("No se pudo cotizar el servicio. Verifique los datos ingresados.");
                return 0;
            }
        }

        private void AgregarItem()
        {
            var items = ItemsListBox.Items.Cast<string>().ToList();
            string item = ItemTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(item))
            {
                MessageBoxService.Error("El ítem no puede estar vacío.");
                return;
            }

            if (items.Contains(item))
            {
                MessageBoxService.Error("El ítem ya existe en la lista.");
                return;
            }

            // ¿Por qué agregué esta línea?
            items.Add(item);               // Agregar el ítem a la lista.
            ItemsListBox.Items.Add(item);   // Agregar el ítem al ListBox.

            ItemTextBox.Clear(); // Limpiar el campo de texto para el siguiente ítem.
            ItemTextBox.Focus(); // Devolver el foco al campo de texto.
        }

        private void QuitarItem()
        {
            var items = ItemsListBox.Items.Cast<string>().ToList();

            if (ItemsListBox.SelectedItem == null)
            {
                MessageBoxService.Error("Seleccione un ítem a eliminar.");
                return;
            }

            string item = ItemsListBox.SelectedItem.ToString();
            items.Remove(item);
            ItemsListBox.Items.Remove(item);
        }

        private void CancelarOperacion()
        {
            var confirmacion = MessageBoxService.Confirmar("¿Está seguro de que desea cancelar?");
            if (confirmacion) LimpiarFormulario();
        }

        private void GenerarOrden()
        {
            // 1. Validar
            var logic = GenericFactory.Instanciar<CapturadorLogic>();
            var datos = RecuperarDetalleOrden();
            if (datos == null) return;

            if (!logic.ValidarOrden(datos)) return;

            // 2. Confirmar operación
            if (!MessageBoxService.Confirmar("¿Confirma que desea generar el documento?")) return;

            try
            {
                // 3. Crear la orden
                var orden = Create(datos);

                if (orden == null)
                {
                    MessageBoxService.Error("Hubo un error al guardar la orden. Intente nuevamente.");
                    return;
                }

                // 4. Crear la transacción
                var cliente = RecuperarDetallesCliente();
                if (cliente == null) return;
                var transaccion = logic.CrearTransaccion(cliente, orden);

                if (transaccion == null)
                {
                    MessageBoxService.Error("Hubo un error al guardar la transacción. Intente nuevamente.");
                    return;
                }

                // 5. Crear documento imprimible (Opcionalmente puedes delegar esto también)
                if (!logic.ImprimirOrden(transaccion))
                {
                    MessageBoxService.Error("Hubo un error al imprimir el documento. Intente nuevamente.");
                    return;
                }

                // 6. Informar éxito
                MessageBoxService.Exito("Operaciones ejecutadas correctamente.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBoxService.Error($"Se produjo un error inesperado: {ex.Message}");
            }
        }
        //
        // Métodos auxiliares.**************************************************
        //
        private void TranscribirDetallesCliente(Cliente cliente)
        {
            IdTextBox.Text               = cliente.Id.ToString();
            CondicionFiscalComboBox.Text = cliente.CondicionFiscal.ToString();
            NivelTarifarioComboBox.Text  = cliente.NivelTarifario.ToString();
            DireccionTextBox.Text        = cliente.Direccion;
            TelefonoTextBox.Text         = cliente.Telefono;
            EmailTextBox.Text            = cliente.Email;

            if (cliente is PersonaFisica fisica)
            {
                IdentificadorTextBox.Text        = fisica.DNI;
                NombreTextBox.Text               = fisica.NombreApellido;
                PersonaFisicaRadioButton.Checked = true;
            }
            else if (cliente is PersonaJuridica juridica)
            {
                IdentificadorTextBox.Text          = juridica.CUIT;
                NombreTextBox.Text                 = juridica.RazonSocial;
                PersonaJuridicaRadioButton.Checked = true;
            }
        }

        private Cliente RecuperarDetallesCliente()
        {
            try
            {
                var cliente =
                    PersonaFisicaRadioButton.Checked ?
                    (Cliente)new PersonaFisica() :
                    new PersonaJuridica();

                cliente.Id              = int.Parse(IdTextBox.Text);
                cliente.CondicionFiscal = (CondicionFiscalEnum)Enum.Parse(typeof(CondicionFiscalEnum), CondicionFiscalComboBox.Text);
                cliente.NivelTarifario  = (NivelTarifarioEnum)Enum.Parse(typeof(NivelTarifarioEnum), NivelTarifarioComboBox.Text);
                cliente.Direccion       = DireccionTextBox.Text;
                cliente.Telefono        = TelefonoTextBox.Text;
                cliente.Email           = EmailTextBox.Text;

                if (cliente is PersonaFisica fisica)
                {
                    fisica.DNI            = IdentificadorTextBox.Text;
                    fisica.NombreApellido = NombreTextBox.Text;
                }
                else if (cliente is PersonaJuridica juridica)
                {
                    juridica.CUIT        = IdentificadorTextBox.Text;
                    juridica.RazonSocial = NombreTextBox.Text;
                }

                return cliente;
            }
            catch
            {
                MessageBoxService.Error("Datos de cliente incompletos.");
                return null;
            }
        }

        private Orden RecuperarDetalleOrden()
        {
            try
            {
                var items      = ItemsListBox.Items.Cast<string>().ToList();
                var cotizacion = Cotizar(); // ¿Por qué no lo recupero del control? Por el formato currency.

                return new Orden
                {
                    Fecha         = DateTime.Now,
                    Operador      = SessionService.Instancia.Empleado.ToString(),
                    Cliente       = RecuperarDetallesCliente(),
                    FechaMudanza  = FechaMudanzaDateTimePicker.Value,
                    Camion        = (Camion)CamionComboBox.SelectedItem,
                    Origen        = OrigenComboBox.Text,
                    Destino       = DestinoComboBox.Text,
                    Distancia     = int.Parse(DistanciaTotalTextBox.Text),
                    LugarCarga    = LugarCargaTextBox.Text,
                    LugarDescarga = LugarDescargaTextBox.Text,
                    Observaciones = ObservacionesTextBox.Text,
                    Items         = items,
                    Cotizacion    = cotizacion,
                    Estado        = EstadoEnum.Solicitada
                };
            }
            catch
            {
                MessageBoxService.Error("Datos de mudanza incompletos.");
                return null;
            }
        }

        private void LimpiarFormulario()
        {
            foreach (Control control in CapturadorForm.Controls)
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
    //..........................................................................
    }
}
