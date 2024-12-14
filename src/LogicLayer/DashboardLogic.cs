using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LogicLayer
{
    /// <summary>Lógica de negocio para el dashboard.</summary>
    public class DashboardLogic : LogicCRU<Transaccion>
    {
        /// <summary>Lista las transacciones en un rango de fechas.</summary>
        /// <param name="desde">Fecha de inicio del rango.</param>
        /// <param name="hasta">Fecha de fin del rango.</param>
        /// <returns>Una lista de transacciones.</returns>
        public List<Transaccion> ListarTransacciones(DateTime desde, DateTime hasta)
        {
            var transacciones = Read() ?? new List<Transaccion>();  // Evita que sea null
            return transacciones.Where(x => x.Orden.Fecha.Date >= desde && x.Orden.Fecha.Date <= hasta).ToList();
        }

        /// <summary>Obtiene el total de ventas.</summary>
        public decimal CalcularVentasTotales(List<Transaccion> transacciones)
        {
            return transacciones.Sum(x => x.Orden.Cotizacion); 
        }

        /// <summary>Obtiene el total de costos operativos.</summary>
        public decimal CalcularCostosTotales(List<Transaccion> transacciones)
        {
            return transacciones.Where(x => x.Liquidacion != null).Sum(x => x.Liquidacion?.TotalLiquidacion ?? 0);
        }

        /// <summary>Calcula la rentabilidad real.</summary>
        public decimal CalcularRentabilidadReal(decimal ventas, decimal costos)
        {
            return ventas - costos;
        }

        /// <summary>Valida si la lista de transacciones es nula o vacía.</summary>
        public bool ValidarTransacciones(List<Transaccion> transacciones)
        {
            return transacciones == null || !transacciones.Any();
        }
    }
}
