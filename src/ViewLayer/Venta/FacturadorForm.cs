using AbstractLayer;
using ControllerLayer;


namespace ViewLayer
{
    /// <summary>
    /// Formulario de facturación de contado.
    /// </summary>
    public partial class FacturadorForm : BaseForm
    {
        /// <summary>
        /// <see cref="FacturadorForm"/>
        /// </summary>
        public FacturadorForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<FacturadorController>(this);
        }
    }
}
