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
    /// <summary>Clase que se encarga de la lógica de negocio del proceso de captura.</summary>
    public class CapturadorLogic : LogicCRU<Orden>
    {
        /// <summary>Obtiene una lista de locaciones activas (no bloqueadas o eliminadas).</summary>
        public List<Locacion> ObtenerLocacionesActivas()
        {
            return GenericFactory
                .Instanciar<LogicCRU<Locacion>>()
                .Read()
                .Where(locacion => !locacion.Bloqueado && !locacion.Eliminado)
                .OrderBy(locacion => locacion.Lugar)
                .ToList();
        }

        /// <summary>
        /// Calcula la distancia entre la central y una ubicación en el mapa usando el algoritmo de Manhattan.
        /// </summary>
        /// <param name="locacion">Locación de origen o destino.</param>
        /// <returns>Distancia en kilómetros.</returns>
        public int DistanciarDesdeCentral(Locacion locacion)
        {
            return Math.Abs(locacion.X) + Math.Abs(locacion.Y);
        }

        /// <summary>
        /// Calcula la distancia entre dos ubicaciones en el mapa usando el algoritmo de Manhattan.
        /// </summary>
        /// <param name="origen">Lugar de origen.</param>
        /// <param name="destino">Lugar de destino.</param>
        /// <returns>Distancia en kilómetros.</returns>
        public int DistanciarEntreLocaciones(Locacion origen, Locacion destino)
        {
            int distanciaX = Math.Abs(origen.X - destino.X);
            int distanciaY = Math.Abs(origen.Y - destino.Y);
            return distanciaX + distanciaY;
        }

        /// <summary>Obtiene una lista de camiones disponibles para una fecha dada.</summary>
        /// <param name="fecha">Fecha consultada.</param>
        /// <returns>Lista de camiones disponibles, ordenados por marca y modelo.</returns>
        public List<Camion> ObtenerCamionesDisponibles(DateTime fecha)
        {
            // 1. Obtener todas las órdenes activas (no bloqueadas ni eliminadas).
            var ordenes = ObtenerOrdenesActivas();

            // 2. Filtrar las órdenes "Pagadas" para la fecha especificada.
            var filtradas = ordenes
                .Where(orden => orden.Estado == EstadoEnum.Pagada && orden.FechaMudanza.Date == fecha.Date)
                .ToList();

            // 3. Extraer los camiones asignados a esas órdenes.
            var reservados = filtradas
                .Select(orden => orden.Camion)
                .Distinct()
                .ToList();

            // 4. Obtener todos los camiones activos (no bloqueados ni eliminados).
            var camiones = ObtenerCamionesActivos();

            // 5. Filtrar los camiones disponibles (los que no están reservados).
            var disponibles = camiones
                .Where(camion => !reservados.Any(reservado => reservado.Id == camion.Id))
                .ToList();

            // 6. Ordenar la lista de camiones disponibles por marca y modelo.
            disponibles
                .Sort((camion1, camion2) => camion1.Marca.CompareTo(camion2.Marca) == 0 ?
                camion1.Modelo.CompareTo(camion2.Modelo) :
                camion1.Marca.CompareTo(camion2.Marca));

            return disponibles;
        }


        /// <summary>Obtiene una lista de clientes activos (no bloqueados o eliminados).</summary>
        public List<Cliente> ObtenerClientesActivos()
        {
            return new LogicCRU<Cliente>().Read()
                .Where(cliente => !cliente.Bloqueado && !cliente.Eliminado)
                .ToList();
        }

        /// <summary>
        /// Cotiza un servicio de mudanza en base a la fecha, categoría y cantidad de kilómetros.
        /// </summary>
        /// <param name="fecha">Fecha del servicio.</param>
        /// <param name="categoria">Tarifario a aplicar.</param>
        /// <param name="kilometros">Distancia a recorrer.</param>
        /// <returns>Monto a cobrar según distancia y categoría de cliente.</returns>
        /// <exception cref="Exception"></exception>
        public decimal CotizarServicio(DateTime fecha, NivelTarifarioEnum categoria, int kilometros)
        {
            List<Tarifa> tarifas = GenericFactory
                .Instanciar<LogicCRU<Tarifa>>()
                .Read()
                .Where(x => !x.Bloqueado && !x.Eliminado)
                .ToList();

            Tarifa tarifa = tarifas
                .FirstOrDefault(tar => fecha >= tar.Desde && fecha <= tar.Hasta && tar.Coeficientes
                .Any(coef => coef.NivelTarifario == categoria));

            if (tarifa != null)
            {
                Coeficiente coeficiente = tarifa.Coeficientes
                    .First(x => x.NivelTarifario == categoria);

                return kilometros * tarifa.MontoKilometro * coeficiente.Valor;
            }
            else
            {
                throw new Exception("No se encontró una tarifa válida para la fecha y categoría proporcionadas.");
            }
        }

        /// <summary>
        /// Valida una entidad y muestra un mensaje de error si no es válida.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool ValidarOrden(object entidad)
        {
            var validante = ValidationService.EsValido(entidad, out List<string> errores);

            if (!validante)
            {
                MessageBoxService.Error($"Errores de validación:\n{string.Join("\n", errores)}");
                return false;
            }

            return true;
        }

        /// <summary>Crea una transacción a partir de un cliente y una orden.</summary>
        /// <param name="cliente"></param>
        /// <param name="orden"></param>
        /// <returns>TRUE si se generó correctamente la transacción.</returns>
        public Transaccion CrearTransaccion(Cliente cliente, Orden orden)
        {
            var cru = GenericFactory.Instanciar<LogicCRU<Transaccion>>();

            var datos = new Transaccion
            {
                Cliente = cliente,
                Orden = orden
            };

            var transaccion = cru.Create(datos);

            return transaccion;
        }

        /// <summary>Crea un documento imprimible a partir de un cliente y una orden.</summary>
        /// <param name="transaccion">La transacción que contiene los datos a utilizar.</param>
        /// <returns>TRUE si se generó el imprimible correctamente.</returns>
        public bool ImprimirOrden(Transaccion transaccion)
        {
            // Generar el HTML.
            var html = HtmlGeneratorService.GenerarOrden(transaccion);

            // Obtener el path de guardado desde la configuración.
            var documentos = ConfigurationService.Configuracion.CarpetaDocumentos;
            var ordenes = Path.Combine(documentos, "Órdenes");
            var orden = Path.Combine(ordenes, $"Orden_{transaccion.Orden.Id:D3}.html");

            // Crear la carpeta si no existe.
            if (!Directory.Exists(ordenes))
            {
                Directory.CreateDirectory(ordenes);
            }

            try
            {
                // Guardar el archivo.
                File.WriteAllText(orden, html, Encoding.UTF8);

                // Visualizar el archivo en un Form con WebBrowser.
                using (var visor = new HtmlVisorService(orden))
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
        //
        // Métodos de lógica de negocio adicionales...
        //
        private IList<Orden> ObtenerOrdenesActivas()
        {
            return Read().Where(orden => !orden.Bloqueado && !orden.Eliminado).ToList();
        }

        private List<Camion> ObtenerCamionesActivos()
        {
            return new LogicCRU<Camion>().Read()
                .Where(camion => !camion.Bloqueado && !camion.Eliminado)
                .ToList();
        }
    }
}
