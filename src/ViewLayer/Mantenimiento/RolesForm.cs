using AbstractLayer;
using ControllerLayer;
using MaterialSkin2Framework.Controls;


namespace ViewLayer
{
    /// <summary>
    /// Formulario de gestión de permisos de rol.
    /// </summary>
    public partial class RolesForm : MaterialForm
    {
        /// <summary>
        /// <see cref="RolesForm"/> para la gestión de roles.
        /// </summary>
        public RolesForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<RolesController>(this);
        }
    }
}
