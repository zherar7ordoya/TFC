using AbstractLayer;

using ControllerLayer;

namespace ViewLayer
{
    /// <summary>Vista de gestión de camiones.</summary>
    public partial class CamionesForm : BaseForm
    {
        /// <summary>Constructor.</summary>
        public CamionesForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<CamionesController>(this);
        }
    }
}
