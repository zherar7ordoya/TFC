using AbstractLayer;

using ControllerLayer;

namespace ViewLayer
{
    /// <summary>Vista de gestión de locaciones.</summary>
    public partial class LocacionesForm : BaseForm
    {
        /// <summary>Constructor.</summary>
        public LocacionesForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<LocacionesController>(this);
        }
    }
}
