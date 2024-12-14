using AbstractLayer;
using ControllerLayer;
using MaterialSkin2Framework.Controls;


namespace ViewLayer
{
    /// <summary>
    /// Formulario de Backup.
    /// </summary>
    public partial class BackupForm : MaterialForm
    {
        /// <summary>
        /// <see cref="BackupForm"/>
        /// </summary>
        public BackupForm()
        {
            InitializeComponent();
            _ = GenericFactory.Instanciar<BackupController>(this);
        }
    }
}
