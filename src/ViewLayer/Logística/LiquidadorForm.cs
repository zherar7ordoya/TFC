using AbstractLayer;

using ControllerLayer;

namespace ViewLayer
{
    /// <summary>
    /// Formulario para el caso de uso Liquidacion.
    /// </summary>
    public partial class LiquidadorForm : BaseForm
    {
        /// <summary>
        /// <see cref="LiquidadorForm"/>
        /// </summary>
        public LiquidadorForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<LiquidadorController>(this);
        }
    }
}
