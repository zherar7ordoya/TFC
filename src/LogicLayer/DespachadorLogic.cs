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
    /// Clase que se encarga de la logica de negocio del proceso de despacho.
    /// </summary>
    public class DespachadorLogic : LogicCRU<Despacho>
    {
        /// <summary>Obtiene todas las órdenes.</summary>
        public List<Orden> ObtenerOrdenesProcesables()
        {
            // Recuperar órdenes con estado "Pagada" y "Transito".
            var listado = GenericFactory
                .Instanciar<LogicCRU<Orden>>()
                .Read()
                .Where(o => o.Estado == EstadoEnum.Pagada || o.Estado == EstadoEnum.Transito)
                .ToList();

            return listado;
        }

        /// <summary>Obtiene una lista de camiones disponibles para una fecha dada.</summary>
        /// <param name="fecha">Fecha consultada.</param>
        /// <returns>Lista de camiones disponibles.</returns>
        public List<Camion> ObtenerCamionesDisponibles(DateTime fecha)
        {
            // 1. Obtener todas los despachos.
            var despachos = GenericFactory.Instanciar<LogicCRU<Despacho>>().Read();

            // 2. Filtrar los despachos por fecha.
            var filtrados = despachos
                .Where(despacho => despacho.FechaServicio.Date == fecha.Date)
                .ToList();

            // 3. Extraer los camiones asignados a esas fechas.
            var asignados = filtrados
                .Select(despacho => despacho.Camion)
                .Distinct()
                .ToList();

            // 4. Obtener todos los camiones activos (no bloqueados ni eliminados).
            var camiones = GenericFactory.Instanciar<LogicCRU<Camion>>()
                .Read()
                .Where(camion => !camion.Bloqueado && !camion.Eliminado)
                .ToList();

            // 5. Filtrar los camiones disponibles (los que no están asignados).
            var disponibles = camiones
                .Where(camion => !asignados.Any(asignado => asignado.Id == camion.Id))
                .ToList();

            return disponibles;
        }

        /// <summary>Obtiene una lista de choferes disponibles para una fecha dada.</summary>
        /// <param name="fecha">Fecha consultada.</param>
        /// <returns>Una lista de choferes disponibles para la fecha dada.</returns>
        public List<Empleado> ObtenerChoferesDisponibles(DateTime fecha)
        {
            // 1. Obtener todas los despachos.
            var despachos = GenericFactory.Instanciar<LogicCRU<Despacho>>().Read();

            // 2. Filtrar los despachos por fecha.
            var filtrados = despachos
                .Where(despacho => despacho.FechaServicio.Date == fecha.Date)
                .ToList();

            // 3. Extraer los choferes asignados a esas fechas.
            var asignados = filtrados
                .Select(despacho => despacho.Chofer)
                .Distinct()
                .ToList();

            // 4. Obtener todos los choferes activos (no bloqueados ni eliminados).
            var empleados = GenericFactory.Instanciar<LogicCRU<Empleado>>()
                .Read()
                .Where(empleado => !empleado.Bloqueado && !empleado.Eliminado && empleado.Puesto == PuestoEnum.Chofer)
                .ToList();

            // 5. Filtrar los choferes disponibles (los que no están asignados).
            var disponibles = empleados
                .Where(empleado => !asignados.Any(asignado => asignado.Id == empleado.Id))
                .ToList();

            return disponibles;
        }

        /// <summary>Obtiene una lista de estibadores disponibles para una fecha dada.</summary>
        /// <param name="fecha">Fecha consultada.</param>
        /// <returns>Una lista de estibadores disponibles para la fecha dada.</returns>
        public List<Empleado> ObtenerEstibadoresDisponibles(DateTime fecha)
        {
            // 1. Obtener todas los despachos.
            var despachos = GenericFactory.Instanciar<LogicCRU<Despacho>>().Read();

            // 2. Filtrar los despachos por fecha.
            var filtrados = despachos
                .Where(despacho => despacho.FechaServicio.Date == fecha.Date)
                .ToList();

            // 3. Extraer los estibadores asignados a esas fechas y aplanar la lista.
            var asignados = filtrados
                .SelectMany(despacho => despacho.Estibadores) // * Ver nota.
                .Distinct()
                .ToList();
            // * Se usa SelectMany para "aplanar" la lista de listas de estibadores.
            //   Con Select: List<List<Empleado>>
            //   Con SelectMany: List<Empleado>

            // 4. Obtener todos los estibadores activos (no bloqueados ni eliminados).
            var empleados = GenericFactory.Instanciar<LogicCRU<Empleado>>()
                .Read()
                .Where(empleado => !empleado.Bloqueado && !empleado.Eliminado && empleado.Puesto == PuestoEnum.Estibador)
                .ToList();

            // 5. Filtrar los estibadores disponibles (los que no están asignados).
            var disponibles = empleados
                .Where(empleado => !asignados.Any(asignado => asignado.Id == empleado.Id))
                .ToList();

            return disponibles;
        }

        /// <summary>Cancela la orden de mudanza.</summary>
        public bool ActualizarOrden(Orden orden)
        {
            // Actualizar la transacción.
            var cru = GenericFactory.Instanciar<LogicCRU<Transaccion>>();
            var transaccion = cru.Read().FirstOrDefault(x => x.Orden.Id == orden.Id);
            transaccion.Orden = orden;
            dynamic exito = cru.Update(transaccion) ? transaccion : null;
            if (exito == null) return false;

            // Actualizar la orden.
            exito = GenericFactory.Instanciar<LogicCRU<Orden>>().Update(orden);
            return exito;
        }

        /// <summary>Valida el despacho.</summary>
        public bool ValidarDespacho(Despacho despacho)
        {
            var validante = ValidationService.EsValido(despacho, out List<string> errores);

            if (!validante)
            {
                MessageBoxService.Error($"Errores de validación:\n{string.Join("\n", errores)}");
                return false;
            }

            return true;
        }

        /// <summary>Actualiza la transacción con la factura generada.</summary>
        /// <param name="orden">Orden de mudanza.</param>
        /// <param name="despacho">Despacho de mudanza.</param>
        /// <returns>Transacción actualizada.</returns>
        public Transaccion ActualizarTransaccion(Orden orden, Despacho despacho)
        {
            var cru = GenericFactory.Instanciar<LogicCRU<Transaccion>>();
            var transaccion = cru.Read().FirstOrDefault(x => x.Orden.Id == orden.Id);

            transaccion.Orden = orden;
            transaccion.Despacho = despacho;

            return cru.Update(transaccion) ? transaccion : null;
        }

        /// <summary>Imprime el despacho.</summary>
        public bool ImprimirDespacho(Transaccion transaccion)
        {
            // Generar el HTML.
            var html = HtmlGeneratorService.GenerarDespacho(transaccion);

            // Obtener el path de guardado desde la configuración.
            var documentos = ConfigurationService.Configuracion.CarpetaDocumentos;
            var despachos = Path.Combine(documentos, "Despachos");
            var despacho = Path.Combine(despachos, $"Despacho_{transaccion.Despacho.Id:D3}.html");

            // Crear la carpeta si no existe.
            if (!Directory.Exists(despachos))
            {
                Directory.CreateDirectory(despachos);
            }

            try
            {
                // Guardar el archivo.
                File.WriteAllText(despacho, html, Encoding.UTF8);

                // Visualizar el archivo en un Form con WebBrowser.
                using (var visor = new HtmlVisorService(despacho))
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
