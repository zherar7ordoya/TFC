using EntityLayer;
using MaterialSkin2Framework.Controls;
using ServiceLayer;
using System;
using System.Drawing.Printing;


namespace ViewLayer
{
    /// <summary>
    /// Formulario de configuración de la aplicación.
    /// </summary>
    public partial class ConfiguracionForm : MaterialForm
    {
        /// <summary>
        /// <see cref="ConfiguracionForm"/>
        /// </summary>
        public ConfiguracionForm()
        {
            InitializeComponent();
            CargarImpresoras();

            Load += CargarConfiguracion;
            GuardarConfiguracionButton.Click += GuardarConfiguracion;
        }

        private Configuracion _configuracion;

        //......................................................................

        private void CargarImpresoras()
        {
            ImpresoraComboBox.Items.Add("Impresora NULL");
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                ImpresoraComboBox.Items.Add(printer);
            }
        }

        private void CargarConfiguracion(object sender, EventArgs e)
        {
            _configuracion = ConfigurationService.Leer();
            //
            // Contraseña
            //
            ContraseñaMaximoFallosNumeric.Value = _configuracion.ContraseñaIntentosFallidos;
            ContraseñaDiasVigenciaNumeric.Value = _configuracion.ContraseñaDiasVigencia;
            ContraseñaRegExTextBox.Text = _configuracion.ContraseñaRegEx;
            ContraseñaClaveXORNumeric.Value = (decimal)_configuracion.ContraseñaClaveXOR;
            //
            // Archivos
            //
            ArchivoStartTextBox.Text = _configuracion.ArchivoStart;
            ArchivoExitTextBox.Text = _configuracion.ArchivoExit;
            //
            // Carpetas
            //
            CarpetaBaseTextBox.Text = _configuracion.CarpetaBase;
            CarpetaDataTextBox.Text = _configuracion.CarpetaData;
            CarpetaBackupTextBox.Text = _configuracion.CarpetaBackup;
            CarpetaDocumentosTextBox.Text = _configuracion.CarpetaDocumentos;
            //
            // Impuesto
            //
            PorcentajeIVANumeric.Value = _configuracion.PorcentajeIVA;
            //
            // Empresa
            //
            NombreTextBox.Text = _configuracion.EmpresaRazonSocial;
            CuitNumeric.Value = _configuracion.EmpresaCUIT;
            DireccionTextBox.Text = _configuracion.EmpresaDireccion;
            TelefonoTextBox.Text = _configuracion.EmpresaTelefono;
            CondicionIvaTextBox.Text = _configuracion.EmpresaCondicionIVA;
            //
            // Impresora
            //
            ImpresoraComboBox.SelectedItem = _configuracion.ImpresoraPredeterminada;
        }

        private void GuardarConfiguracion(object sender, EventArgs e)
        {
            //
            // Contraseña
            //
            _configuracion.ContraseñaIntentosFallidos = (int)ContraseñaMaximoFallosNumeric.Value;
            _configuracion.ContraseñaDiasVigencia = (int)ContraseñaDiasVigenciaNumeric.Value;
            _configuracion.ContraseñaRegEx = ContraseñaRegExTextBox.Text;
            _configuracion.ContraseñaClaveXOR = (byte)ContraseñaClaveXORNumeric.Value;
            //
            // Archivos
            //
            _configuracion.ArchivoStart = ArchivoStartTextBox.Text;
            _configuracion.ArchivoExit = ArchivoExitTextBox.Text;
            //
            // Carpetas
            //
            _configuracion.CarpetaBase = CarpetaBaseTextBox.Text;
            _configuracion.CarpetaData = CarpetaDataTextBox.Text;
            _configuracion.CarpetaBackup = CarpetaBackupTextBox.Text;
            _configuracion.CarpetaDocumentos = CarpetaDocumentosTextBox.Text;
            //
            // Impuesto
            //
            _configuracion.PorcentajeIVA = (int)PorcentajeIVANumeric.Value;
            //
            // Empresa
            //
            _configuracion.EmpresaRazonSocial = NombreTextBox.Text;
            _configuracion.EmpresaCUIT = (ulong)CuitNumeric.Value;
            _configuracion.EmpresaDireccion = DireccionTextBox.Text;
            _configuracion.EmpresaTelefono = TelefonoTextBox.Text;
            _configuracion.EmpresaCondicionIVA = CondicionIvaTextBox.Text;
            //
            // Impresora
            //
            _configuracion.ImpresoraPredeterminada = ImpresoraComboBox.SelectedItem.ToString();
            //
            //..................................................................
            //
            var resultado = ConfigurationService.Escribir(_configuracion);
            if (resultado)
            {
                MessageBoxService.Informar("Configuración guardada correctamente.");
            }
            else
            {
                MessageBoxService.Error("No se guardó la configuración.");
            }
        }
    }
}
