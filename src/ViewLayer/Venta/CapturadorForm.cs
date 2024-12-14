using AbstractLayer;

using ControllerLayer;

namespace ViewLayer
{
    /// <summary>
    /// Formulario de captura de datos de venta.
    /// </summary>
    public partial class CapturadorForm : BaseForm
    {
        /// <summary>
        /// <see cref="CapturadorForm"/>
        /// </summary>
        public CapturadorForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<CapturadorController>(this);
        }
    }
}
