using AbstractLayer;

using ControllerLayer;

namespace ViewLayer
{
    /// <summary>
    /// Formulario para el caso de uso Despacho.
    /// </summary>
    public partial class DespachadorForm : BaseForm
    {
        /// <summary>
        /// <see cref="DespachadorForm"/>
        /// </summary>
        public DespachadorForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<DespachadorController>(this);
        }
    }
}
