using AbstractLayer;

using EntityLayer;

using ServiceLayer;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LogicLayer
{
    /// <summary>
    /// Clase que se encarga de la logica de negocio del proceso de facturación.
    /// </summary>
    public class FacturadorLogic : LogicCRU<Factura>
    {
        /// <summary>Obtiene ordenes con estado "Solicitada".</summary>
        public List<Orden> ObtenerOrdenesSolicitadas()
        {
            var listado = GenericFactory
                .Instanciar<LogicCRU<Orden>>()
                .Read()
                .Where(orden => orden.Estado == EstadoEnum.Solicitada)
                .ToList();
            return listado;
        }

        /// <summary>Valida la factura.</summary>
        public bool ValidarFactura(Factura factura)
        {
            var validante = ValidationService.EsValido(factura, out List<string> errores);

            if (!validante)
            {
                MessageBoxService.Error($"Errores de validación:\n{string.Join("\n", errores)}");
                return false;
            }

            return true;
        }

        /// <summary>Actualiza el estado de la orden.</summary>
        public bool ActualizarOrden(Orden orden)
        {
            return GenericFactory.Instanciar<LogicCRU<Orden>>().Update(orden);
        }

        /// <summary>
        /// Actualiza la transacción con la factura generada.
        /// </summary>
        /// <param name="orden"></param>
        /// <param name="factura"></param>
        /// <returns></returns>
        public Transaccion ActualizarTransaccion(Orden orden, Factura factura)
        {
            var cru = GenericFactory.Instanciar<LogicCRU<Transaccion>>();
            var transaccion = cru.Read().FirstOrDefault(t => t.Orden.Id == orden.Id);
            
            transaccion.Orden = orden;
            transaccion.Factura = factura;
            
            return cru.Update(transaccion) ? transaccion : null;
        }

        /// <summary>Imprime la factura.</summary>
        public bool ImprimirFactura(Transaccion transaccion)
        {
            // Generar el HTML.
            var html = HtmlGeneratorService.GenerarFactura(transaccion);

            // Obtener el path de guardado desde la configuración.
            var documentos = ConfigurationService.Configuracion.CarpetaDocumentos;
            var facturas = Path.Combine(documentos, "Facturas");
            var factura = Path.Combine(facturas, $"Factura_{transaccion.Factura.Id:D3}.html");

            // Crear la carpeta si no existe.
            if (!Directory.Exists(facturas))
            {
                Directory.CreateDirectory(facturas);
            }

            try
            {
                // Guardar el archivo.
                File.WriteAllText(factura, html, Encoding.UTF8);

                // Visualizar el archivo en un Form con WebBrowser.
                using (var visor = new HtmlVisorService(factura))
                {
                    visor.ShowDialog();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBoxService.Error($"Error al generar el documento: {ex.Message}");
                return false;
            }
        }

        /// <summary>Cancela la orden de mudanza.</summary>
        public bool CancelarOrden(Orden orden)
        {
            orden.Estado = EstadoEnum.Cancelada;
            return GenericFactory.Instanciar<LogicCRU<Orden>>().Update(orden);
        }
    }
}
