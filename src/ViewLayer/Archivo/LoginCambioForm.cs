using AbstractLayer;

using ControllerLayer;

using System.Windows.Forms;


namespace ViewLayer
{
    /// <summary>
    /// Interfaz para el cambio de contraseña.
    /// </summary>
    public partial class LoginCambioForm : Form
    {
        /// <summary>
        /// La gestión del formulario se traslada al controlador.
        /// </summary>
        public LoginCambioForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<LoginCambioController>(this);
        }
    }
}
