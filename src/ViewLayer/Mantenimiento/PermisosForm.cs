using AbstractLayer;
using ControllerLayer;
using MaterialSkin2Framework.Controls;


namespace ViewLayer
{
    /// <summary>
    /// Formulario de Permisos de Usuario.
    /// </summary>
    public partial class PermisosForm : MaterialForm
    {
        /// <summary>
        /// <see cref="PermisosForm"/>
        /// </summary>
        public PermisosForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<PermisosController>(this);
        }
    }
}
