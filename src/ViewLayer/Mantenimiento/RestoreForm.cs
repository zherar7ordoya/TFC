using AbstractLayer;
using ControllerLayer;
using MaterialSkin2Framework.Controls;


namespace ViewLayer
{
    /// <summary>
    /// Formulario de restauración de la base de datos.
    /// </summary>
    public partial class RestoreForm : MaterialForm
    {
        /// <summary>
        /// <see cref="RestoreForm"/>
        /// </summary>
        public RestoreForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<RestoreController>(this);
        }
    }
}
