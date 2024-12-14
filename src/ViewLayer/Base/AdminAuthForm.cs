using AbstractLayer;
using ControllerLayer;

using MaterialSkin2Framework.Controls;

using ServiceLayer;
using System;
using System.Windows.Forms;


namespace ViewLayer
{
    /// <summary>
    /// Interfaz gráfica para autenticar a un administrador.
    /// </summary>
    public partial class AdminAuthForm : MaterialForm
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AdminAuthForm"/>.
        /// </summary>
        public AdminAuthForm()
        {
            InitializeComponent();

            VerCheckBox.CheckedChanged += VerCheckBox_CheckedChanged;
            ComprobarButton.Click += VerificarCredencialesButton_Click;
        }

        private readonly AuthenticationController _controller = GenericFactory.Instanciar<AuthenticationController>();

        //......................................................................

        private void VerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ContraseñaTextBox.PasswordChar = VerCheckBox.Checked ? '\0' : '*';
        }

        private void VerificarCredencialesButton_Click(object sender, EventArgs e)
        {
            string username = UsuarioTextBox.Text;
            string password = ContraseñaTextBox.Text;

            if (_controller.VerificarCredenciales(username, password))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBoxService.Error("Nombre de usuario o contraseña incorrectos.");
            }
        }
    }
}
