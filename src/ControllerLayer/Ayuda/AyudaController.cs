using ServiceLayer;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ControllerLayer
{
    /// <summary>
    /// Controlador de AyudaUsuarioForm.
    /// </summary>
    public class AyudaController
    {
        /// <summary>
        /// <see cref="AyudaController"/>
        /// </summary>
        /// <param name="formulario"></param>
        public AyudaController(Form formulario)
        {
            AyudaUsuarioForm = formulario;
            AsignarControles();
            AsignarEventos();
        }

        private readonly Form AyudaUsuarioForm;
        private WebBrowser Navegador;

        //......................................................................

        private void AsignarControles()
        {
            Navegador = GetControl<WebBrowser>("Navegador");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)AyudaUsuarioForm.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            AyudaUsuarioForm.Load += AyudaForm_Load;
        }

        private void AyudaForm_Load(object sender, EventArgs e)
        {
            Navegador.Navigating -= Navegador_Navigating;

            string ruta = Path.Combine(Application.StartupPath, @"Ayuda\index.html");
            MostrarAyuda(ruta);

            Navegador.Navigating += Navegador_Navigating;
        }

        private void MostrarAyuda(string ruta)
        {
            if (File.Exists(ruta))
            {
                string html = File.ReadAllText(ruta);
                Navegador.DocumentText = html;
            }
            else
            {
                MessageBoxService.Error($"El archivo de ayuda no se encontró en la ruta {ruta}");
            }
        }

        private void Navegador_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string ruta = e.Url.LocalPath;

            // TODO: Algún día, investigar el origen de este comportamiento.
            if (ruta == "blank") return;

            ruta = Path.Combine(Application.StartupPath, @"Ayuda\" + ruta);
            MostrarAyuda(ruta);
        }
    }
}
