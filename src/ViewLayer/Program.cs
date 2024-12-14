using AbstractLayer;

using EntityLayer;

using ServiceLayer;
using System;
using System.Windows.Forms;


namespace ViewLayer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var basePresentation = GenericFactory.Instanciar<ViewException>();

            basePresentation.ExceptionHandling(() =>
            {
                ConfigurationService.Configuracion = ConfigurationService.Leer();
                Empleado.RegExContraseña = ConfigurationService.Configuracion.ContraseñaRegEx;
                Application.Run(new SplashScreen());
            });
        }
    }
}

