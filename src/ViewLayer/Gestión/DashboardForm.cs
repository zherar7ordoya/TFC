using AbstractLayer;

using ControllerLayer;

namespace ViewLayer
{
    /// <summary>Vista de dashboard.</summary>
    public partial class DashboardForm : BaseForm
    {
        /// <summary>Constructor.</summary>
        public DashboardForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<DashboardController>(this);
        }
    }
}
