using AbstractLayer;
using ControllerLayer;
using MaterialSkin2Framework.Controls;


namespace ViewLayer
{
    /// <summary>Vista de gestión de empleados.</summary>
    public partial class EmpleadosForm : MaterialForm
    {
        /// <summary>Constructor.</summary>
        public EmpleadosForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<EmpleadosController>(this);
        }
    }
}
