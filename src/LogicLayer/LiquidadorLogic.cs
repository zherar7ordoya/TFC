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
    /// Clase que se encarga de la logica de negocio del proceso de liquidación.
    /// </summary>
    public class LiquidadorLogic : LogicCRU<Liquidacion>
    {

        /// <summary>Obtiene todas las órdenes con estado "Completada".</summary>
        /// <returns>Una lista de órdenes con estado "Completada".</returns>
        /// <remarks>
        /// ¿Por qué no filtro además los registros "Bloqueado" o "Eliminado"?
        /// El planteo de Battaglia acerca de los descriptores de la clase cambió
        /// el enfoque. Las entiddes de negocio están gobernadas por la trazabilidad
        /// que provee la transacción. Es decir, un ABM, así, no es trivial. Y al
        /// no haber ABM de las entidades de negocio, no hay entidades bloqueadas
        /// o eliminadas. Por lo tanto, no es necesario filtrarlas.
        /// </remarks>
        public List<Orden> ObtenerOrdenesProcesables()
        {
            // Recuperar órdenes con estado "Completada". <== AYUDA-MEMORIA, no critiquen.
            var listado = GenericFactory
                .Instanciar<LogicCRU<Orden>>()
                .Read()
                .Where(x => x.Estado == EstadoEnum.Completada)
                .ToList();

            return listado;
        }


        /// <summary>Valida un comprobante antes de ser guardado.</summary>
        /// <param name="comprobante"></param>
        /// <returns></returns>
        public bool ValidarComprobante(Comprobante comprobante)
        {
            var validante = ValidationService.EsValido(comprobante, out List<string> errores);

            if (!validante)
            {
                MessageBoxService.Error($"Errores de validación:\n{string.Join("\n", errores)}");
                return false;
            }

            return true;
        }



        /// <summary>Valida una liquidación antes de ser guardada.</summary>
        /// <param name="liquidacion"></param>
        /// <returns>Booleano que indica si la liquidación es válida.</returns>
        public bool ValidarLiquidacion(Liquidacion liquidacion)
        {
            var validante = ValidationService.EsValido(liquidacion, out List<string> errores);

            if (!validante)
            {
                MessageBoxService.Error($"Errores de validación:\n{string.Join("\n", errores)}");
                return false;
            }

            return true;
        }

        /// <summary>Saca de circulación una orden de trabajo.</summary>
        /// <param name="orden"></param>
        /// <returns></returns>
        public bool ActualizarOrden(Orden orden)
        {
            var cru = GenericFactory.Instanciar<LogicCRU<Orden>>();
            var exito = cru.Update(orden);
            return exito;
        }



        /// <summary>Actualiza la transacción con la liquidación generada.</summary>
        /// <param name="orden"></param>
        /// <param name="liquidacion"></param>
        /// <returns></returns>
        public Transaccion ActualizarTransaccion(Orden orden, Liquidacion liquidacion)
        {
            var cru = GenericFactory.Instanciar<LogicCRU<Transaccion>>();
            var transaccion = cru.Read().FirstOrDefault(x => x.Orden.Id == orden.Id);

            transaccion.Orden = orden;
            transaccion.Liquidacion = liquidacion;

            return cru.Update(transaccion) ? transaccion : null;
        }

        /// <summary>Imprime la liquidación.</summary>
        /// <param name="transaccion"></param>
        /// <returns></returns>
        public bool ImprimirLiquidacion(Transaccion transaccion)
        {
            // Generar el HTML.
            var html = HtmlGeneratorService.GenerarLiquidacion(transaccion);

            // Obtener el path de guardado desde la configuración.
            var documentos = ConfigurationService.Configuracion.CarpetaDocumentos;
            var liquidaciones = Path.Combine(documentos, "Liquidaciones");
            var liquidacion = Path.Combine(liquidaciones, $"Liquidación_{transaccion.Liquidacion.Id:D3}.html");

            // Crear la carpeta si no existe.
            if (!Directory.Exists(liquidaciones))
            {
                Directory.CreateDirectory(liquidaciones);
            }

            try
            {
                // Guardar el archivo.
                File.WriteAllText(liquidacion, html, Encoding.UTF8);

                // Visualizar el archivo en un Form con WebBrowser.
                using (var visor = new HtmlVisorService(liquidacion))
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

        //......................................................................
    }
}
