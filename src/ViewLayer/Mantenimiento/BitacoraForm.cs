using AbstractLayer;
using ControllerLayer;
using MaterialSkin2Framework.Controls;


namespace ViewLayer
{
    /// <summary>
    /// Formulario de Bitácora.
    /// </summary>
    public partial class BitacoraForm : MaterialForm
    {
        /// <summary>
        /// <see cref="BitacoraForm"/>
        /// </summary>
        public BitacoraForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<BitacoraController>(this);
        }
    }
}
