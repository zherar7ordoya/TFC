using AbstractLayer;

using ControllerLayer;

namespace ViewLayer
{
    /// <summary>Vista de gestión de clientes.</summary>
    public partial class ClientesForm : BaseForm
    {
        /// <summary>Constructor.</summary>
        public ClientesForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<ClientesController>(this);
        }
    }
}
