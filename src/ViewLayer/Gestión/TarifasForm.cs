using AbstractLayer;

using ControllerLayer;

namespace ViewLayer
{
    /// <summary>Vista de gestión de tarifas.</summary>
    public partial class TarifasForm : BaseForm
    {
        /// <summary>Constructor.</summary>
        public TarifasForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<TarifasController>(this);
        }
    }
}
