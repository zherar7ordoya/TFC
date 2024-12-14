using AbstractLayer;
using ControllerLayer;
using MaterialSkin2Framework.Controls;


namespace ViewLayer
{
    /// <summary>
    /// Documentos de ayuda para el usuario.
    /// </summary>
    public partial class AyudaForm : MaterialForm
    {
        /// <summary>
        /// <see cref="AyudaForm"/>
        /// </summary>
        public AyudaForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<AyudaController>(this);
        }
    }
}
