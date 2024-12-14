using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ServiceLayer
{
    /// <summary>
    /// Esto se hace para implementar a "Impresora NULL" como una opción de impresora.
    /// 
    /// USO
    /// 
    /// Contenido HTML a imprimir:
    /// <code>string htmlContent = "<html><body><h1>Documento de Prueba</h1><p>Este es un documento de prueba.</p></body></html>";</code>
    /// 
    /// Llamar al método para imprimir el documento:
    /// <code>Impresora.ImprimirDocumento(htmlContent);</code>
    /// </summary>
    [Obsolete("Esta clase está obsoleta. Utilice VisorHtmlForm en su lugar.")]
    public static class PrinterService
    {
        private static readonly string LogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ImpresoraLog.xml");

        /// <summary>
        /// Imprimir un documento HTML en la impresora configurada.
        /// </summary>
        /// <param name="htmlContent"></param>
        public static void ImprimirDocumento(string htmlContent)
        {
            // Obtener la impresora configurada
            var impresoraConfigurada = ConfigurationService.Leer().ImpresoraPredeterminada;

            if (impresoraConfigurada == "Impresora NULL")
            {
                RegistrarLog("Simulación de impresión: Documento no impreso.");
                return;
            }

            // Crear un formulario oculto para usar el WebBrowser
            using (Form printForm = new Form())
            {
                WebBrowser webBrowser = new WebBrowser
                {
                    DocumentText = htmlContent,
                    ScriptErrorsSuppressed = true
                };

                printForm.Controls.Add(webBrowser);
                webBrowser.Dock = DockStyle.Fill;

                webBrowser.DocumentCompleted += (s, e) =>
                {
                    try
                    {
                        // Crear el objeto PrintDocument
                        PrintDocument printDocument = new PrintDocument
                        {
                            PrinterSettings = { PrinterName = impresoraConfigurada }
                        };

                        printDocument.PrintPage += (sender, printArgs) =>
                        {
                            // Imprimir el contenido del WebBrowser
                            webBrowser.Print();
                        };

                        // Iniciar la impresión
                        printDocument.Print();

                        // Registrar en el log
                        RegistrarLog($"Documento impreso en: {impresoraConfigurada}");
                    }
                    catch (Exception ex)
                    {
                        RegistrarLog($"Error al imprimir el documento: {ex.Message}");
                    }
                    finally
                    {
                        // Cerrar el formulario una vez que la impresión esté completa
                        printForm.Close();
                    }
                };

                // Mostrar el formulario para asegurar que el WebBrowser cargue el contenido
                printForm.ShowDialog();
            }
        }

        private static void RegistrarLog(string mensaje)
        {
            // Crear o actualizar el archivo de log XML
            XElement log = new XElement("ImpresionLog",
            new XElement("Fecha", DateTime.Now),
            new XElement("Mensaje", mensaje)
        );

            if (File.Exists(LogFilePath))
            {
                // Leer el archivo existente y agregar el nuevo log
                XDocument doc = XDocument.Load(LogFilePath);
                doc.Root.Add(log);
                doc.Save(LogFilePath);
            }
            else
            {
                // Crear un nuevo archivo de log con el nuevo log
                XDocument doc = new XDocument(new XElement("ImpresionLogs", log));
                doc.Save(LogFilePath);
            }
        }
    }
}
