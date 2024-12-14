using AbstractLayer;
using ControllerLayer;
using System.Windows.Forms;


namespace ViewLayer
{
    /// <summary>
    /// Formulario de olvido de contraseña
    /// </summary>
    public partial class LoginOlvidoForm : Form
    {
        /// <summary>
        /// <see cref="LoginOlvidoForm"/>
        /// </summary>
        public LoginOlvidoForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<LoginOlvidoController>(this);
        }
    }
}
