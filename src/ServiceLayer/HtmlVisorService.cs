using System;
using System.Windows.Forms;

namespace ServiceLayer
{
    /// <summary>Formulario para visualizar/imprimir archivos HTML.</summary>
    public partial class HtmlVisorService : Form
    {
        /// <summary>Constructor de la clase.</summary>
        /// <param name="ruta">Locación del archivo a ver/imprimir.</param>
        public HtmlVisorService(string ruta)
        {
            InitializeComponent();
            _ruta = ruta;
            Load += Form_Load;
            EmailearButton.Click += Emailear_Click;
            ImprimirButton.Click += Imprimir_Click;
        }

        private readonly string _ruta;

        //......................................................................

        private void Form_Load(object sender, EventArgs e)
        {
            VisorWebBrowser.Navigate(_ruta);
        }

        private void Emailear_Click(object sender, EventArgs e)
        {
            MessageBoxService.Informar("Funcionalidad no implementada.");
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                VisorWebBrowser.Print(); // Imprimir directamente desde el WebBrowser.
            }
            catch (Exception ex)
            {
                MessageBoxService.Error($"Error al imprimir: {ex.Message}");
            }
        }
    }
}
