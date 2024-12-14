using AbstractLayer;
using ControllerLayer;
using EntityLayer;
using ServiceLayer;
using System;
using System.Windows.Forms;

namespace ViewLayer
{
    /// <summary>
    /// Formulario de presentación de la aplicación.
    /// </summary>
    public partial class SplashScreen : Form
    {
        /// <summary>
        /// <see cref="SplashScreen"/> constructor."/>
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();

            _controller  = GenericFactory.Instanciar<SplashController>();
            _carpetaBase = ConfigurationService.Configuracion.CarpetaBase;
            _crudArchivo = GenericFactory.Instanciar<ControllerCRU<Archivo>>(_carpetaBase);

            _controller.OnStartApplication   += (s, e) => MostrarMenuForm();
            _controller.OnExitApplication    += (s, e) => Application.Exit();
            _controller.OnRestoreApplication += (s, e) => MostrarRestoreForm();
            _controller.OnStatusUpdate       += (s, mensaje) => ActualizarStatusLabel(mensaje);

            Temporizador.Tick += Temporizador_Tick;
        }

        private readonly ViewException _base = GenericFactory.Instanciar<ViewException>();
        private readonly SplashController _controller;
        private readonly string _carpetaBase;
        private readonly ControllerCRU<Archivo> _crudArchivo;

        //......................................................................

        private void ActualizarStatusLabel(string message)
        {
            StatusLabel.Text = message;
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            ProgresoPanel.Width += 6;

            if (ProgresoPanel.Width >= 285)
            {
                StatusLabel.Text = "Verificando archivos...";
            }

            if (ProgresoPanel.Width >= 575)
            {
                Temporizador.Stop();
                _controller.Start();
            }
        }

        private void MostrarMenuForm()
        {
            var MenuFormulario = GenericFactory.Instanciar<MenuForm>();
            MenuFormulario.FormClosed += (s, e) => _controller.ExitApplication();
            MenuFormulario.Show();
            Hide();
        }

        private void MostrarRestoreForm()
        {
            using (var authForm = new AdminAuthForm())
            {
                if (authForm.ShowDialog() == DialogResult.OK)
                {
                    using (var restoreForm = new RestoreForm())
                    {
                        restoreForm.ShowDialog();
                    }

                    GenericFactory.Instanciar<FileHashService>(_crudArchivo).RegistrarHashes();

                    MessageBoxService.Informar(
                        "Intervención del administrador completada.\n" +
                        "Reinicie la aplicación.");
                }
                else
                {
                    MessageBoxService.Informar(
                        "Contacte al administrador del sistema.\n" +
                        "La aplicación se cerrará.");
                }
                Application.Exit();
            }
        }
    }
}
