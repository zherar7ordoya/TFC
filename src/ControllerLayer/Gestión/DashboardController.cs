using AbstractLayer;

using EntityLayer;

using LogicLayer;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace ControllerLayer
{
    /// <summary>Controlador para la vista de Dashboard.</summary>
    public class DashboardController : ControllerCRU<Transaccion>
    {
        /// <summary>Constructor que recibe un formulario.</summary>
        public DashboardController(Form formulario)
        {
            DashboardForm = formulario;

            AsignarControles();
            AsignarEventos();
            InicializarVista();
        }
        private readonly Form DashboardForm;

        //
        // Controles.***********************************************************
        //

#pragma warning disable CS0649 // Campo no asignado.

        private readonly MonthCalendar DesdeCalendar;
        private readonly MonthCalendar HastaCalendar;
        private readonly Chart VersusChart;
        private readonly Chart OrdenesChart;
        private readonly Chart LiquidacionesChart;
        private readonly TreeView SeguimientoTreeView;
        private readonly RadioButton HoyRadioButton;
        private readonly RadioButton SemanaRadioButton;
        private readonly RadioButton MesRadioButton;
        private readonly RadioButton TrimestreRadioButton;
        private readonly RadioButton SemestreRadioButton;
        private readonly RadioButton AñoRadioButton;
        private readonly Label VentasTotalesLabel;
        private readonly Label CostosTotalesLabel;
        private readonly Label RentabilidadRealLabel;

#pragma warning restore CS0649 // Campo no asignado.

        //
        // Inicialización.******************************************************
        //

        private void AsignarControles()
        {
            var campos = GetType()          // Obtenemos los campos privados que son de tipo "control".
                .GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Where(x => x.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var campo in campos)
            {
                var nombre = campo.Name;
                var control = DashboardForm.Controls.Find(nombre, true).FirstOrDefault();
                if (control == null) continue;  // (Para evitar el llamado al form mismo).
                campo.SetValue(this, control);  // Asignamos el control a la variable correspondiente.
            }
        }

        private void AsignarEventos()
        {
            // Eventos de controles.
            DesdeCalendar.DateChanged += (sender, e) => EstablecerMinDate();
            HastaCalendar.DateChanged += (sender, e) => EstablecerMaxDate();
            DesdeCalendar.DateSelected += (sender, e) => ListarPersonalizado();
            HastaCalendar.DateSelected += (sender, e) => ListarPersonalizado();

            // Interacción con la vista.
            HoyRadioButton.CheckedChanged += (sender, e) => ListarHoy();
            SemanaRadioButton.CheckedChanged += (sender, e) => ListarSemana();
            MesRadioButton.CheckedChanged += (sender, e) => ListarMes();
            TrimestreRadioButton.CheckedChanged += (sender, e) => ListarTrimestre();
            SemestreRadioButton.CheckedChanged += (sender, e) => ListarSemestre();
            AñoRadioButton.CheckedChanged += (sender, e) => ListarAño();
        }

        private void InicializarVista()
        {
            EstablecerMinDate();
            EstablecerMaxDate();
            ListarHoy();
        }

        //
        // Eventos de controles.************************************************
        //

        private void EstablecerMinDate()
        {
            HastaCalendar.MinDate = DesdeCalendar.SelectionStart;
        }

        private void EstablecerMaxDate()
        {
            DesdeCalendar.MaxDate = HastaCalendar.SelectionStart;
        }

        //
        // Métodos de interacción.**********************************************
        //

        private void ListarHoy()
        {
            var hoy = DateTime.Today;
            ActualizarVista(hoy, hoy);
        }

        private void ListarSemana()
        {
            var hoy = DateTime.Today;
            var desde = hoy.AddDays(-(int)hoy.DayOfWeek);
            var hasta = desde.AddDays(6);
            ActualizarVista(desde, hasta);
        }

        private void ListarMes()
        {
            var hoy = DateTime.Today;
            var desde = new DateTime(hoy.Year, hoy.Month, 1);
            var hasta = desde.AddMonths(1).AddDays(-1);
            ActualizarVista(desde, hasta);
        }

        private void ListarTrimestre()
        {
            var hoy = DateTime.Today;
            var mes = hoy.Month;
            var desde = new DateTime(hoy.Year, mes - (mes - 1) % 3, 1);
            var hasta = desde.AddMonths(3).AddDays(-1);
            ActualizarVista(desde, hasta);
        }

        private void ListarSemestre()
        {
            var hoy = DateTime.Today;
            var mes = hoy.Month;
            var desde = new DateTime(hoy.Year, mes - (mes - 1) % 6, 1);
            var hasta = desde.AddMonths(6).AddDays(-1);
            ActualizarVista(desde, hasta);
        }

        private void ListarAño()
        {
            var hoy = DateTime.Today;
            var desde = new DateTime(hoy.Year, 1, 1);
            var hasta = desde.AddYears(1).AddDays(-1);
            ActualizarVista(desde, hasta);
        }

        private void ListarPersonalizado()
        {
            var desde = DesdeCalendar.SelectionStart;
            var hasta = HastaCalendar.SelectionStart;
            ActualizarVista(desde, hasta);
        }

        //
        // Métodos de la vista.**************************************************
        //

        private void ActualizarVista(DateTime desde, DateTime hasta)
        {
            var logic = GenericFactory.Instanciar<DashboardLogic>();
            var transacciones = logic.ListarTransacciones(desde, hasta);

            TreeViewService.CargarListaEnTreeView(SeguimientoTreeView, transacciones);
            ActualizarGraficos(transacciones, desde, hasta);
        }

        private void ActualizarGraficos(List<Transaccion> transacciones, DateTime desde, DateTime hasta)
        {
            ActualizarVersusChart(transacciones, desde, hasta);
            ActualizarOrdenesChart(transacciones);
            ActualizarLiquidacionesChart(transacciones);
        }

        private void ActualizarVersusChart(List<Transaccion> transacciones, DateTime desde, DateTime hasta)
        {
            var logic = GenericFactory.Instanciar<DashboardLogic>();

            // Verificar si hay transacciones
            if (logic.ValidarTransacciones(transacciones))
            {
                // Limpiar el gráfico
                VersusChart.Series.Clear();
                VersusChart.Titles.Clear();
                VersusChart.Legends.Clear();

                // Agregar mensaje de "Sin datos"
                VersusChart.Titles.Add("Sin datos para mostrar");
                VersusChart.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);
                VersusChart.Titles[0].ForeColor = Color.Gray;

                // Limpiar etiquetas
                VentasTotalesLabel.Text = "Ventas Totales: $0.00";
                CostosTotalesLabel.Text = "Costos Totales: $0.00";
                RentabilidadRealLabel.Text = "Rentabilidad Real: $0.00";
                RentabilidadRealLabel.ForeColor = Color.Black;

                return;
            }

            // Calcular las ventas totales (órdenes)
            var ventas = logic.CalcularVentasTotales(transacciones);

            // Calcular los costos operativos (liquidaciones)
            var costos = logic.CalcularCostosTotales(transacciones);

            // Limpiar series existentes
            VersusChart.Series.Clear();

            // Crear la serie de datos
            var serie = new Series("Rentabilidad Real")
            {
                ChartType = SeriesChartType.Pie
            };

            // Agregar los datos al gráfico
            serie.Points.AddXY("Ventas", ventas);
            serie.Points.AddXY("Costos Operativos", costos);

            // Etiquetas en el gráfico
            foreach (var point in serie.Points)
            {
                double porcentaje = (ventas + costos) > 0
                    ? (double)(decimal.Divide((decimal)point.YValues[0], ventas + costos) * 100)
                    : 0;
                point.Label = $"{point.AxisLabel}: {point.YValues[0]:C} ({porcentaje:F2}%)";
                point.LegendText = point.AxisLabel; // Relacionar con la leyenda
            }

            // Agregar la serie al gráfico
            VersusChart.Series.Add(serie);

            // Título del gráfico
            VersusChart.Titles.Clear();
            VersusChart.Titles.Add($"{desde:dd/MM/yyyy} al {hasta:dd/MM/yyyy}");
            VersusChart.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            VersusChart.Titles[0].ForeColor = Color.DarkBlue;

            // Leyenda del gráfico
            VersusChart.Legends.Clear();
            var legend = new Legend("Leyenda")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            VersusChart.Legends.Add(legend);

            // Mostrar datos adicionales
            decimal rentabilidad = logic.CalcularRentabilidadReal(ventas, costos);
            VentasTotalesLabel.Text = $"Ventas Totales: {ventas:C}";
            CostosTotalesLabel.Text = $"Costos Totales: {costos:C}";
            RentabilidadRealLabel.Text = $"Rentabilidad Real: {rentabilidad:C}";

            // Ajustar colores para resaltar valores
            RentabilidadRealLabel.ForeColor = rentabilidad >= 0 ? Color.Green : Color.Red;
        }

        private void ActualizarOrdenesChart(List<Transaccion> transacciones)
        {
            var topClientes = transacciones
                .Where(x => x.Cliente != null && x.Orden != null) // Asegurarse de que Cliente y Orden no sean nulos
                .GroupBy(x => x.Cliente)
                .Select(grupo => new
                {
                    Cliente = grupo.Key,
                    TotalOrdenes = grupo.Sum(x => x.Orden?.Cotizacion ?? 0) // Si Orden es nulo, usar 0
                })
                .OrderByDescending(x => x.TotalOrdenes)
                .Take(3)
                .ToList();

            OrdenesChart.Series.Clear();

            // Configurar título
            OrdenesChart.Titles.Clear();
            var titulo = OrdenesChart.Titles.Add("Top Clientes por Órdenes");
            titulo.ForeColor = Color.DarkBlue;
            titulo.Font = new Font("Arial", 12, FontStyle.Bold);
            titulo.Alignment = ContentAlignment.MiddleCenter;

            // Configurar serie
            var serie = new Series("Órdenes")
            {
                ChartType = SeriesChartType.Bar
            };

            // Agregar datos al gráfico
            foreach (var cliente in topClientes)
            {
                serie.Points.AddXY(cliente.Cliente.Nombre, cliente.TotalOrdenes);
            }

            OrdenesChart.Series.Add(serie);

            // Leyenda del gráfico
            OrdenesChart.Legends.Clear();
        }

        private void ActualizarLiquidacionesChart(List<Transaccion> transacciones)
        {

            var topClientes = transacciones
                .Where(x => x.Liquidacion != null) // Asegurar que tengan liquidación
                .GroupBy(x => x.Cliente)
                .Select(grupo => new
                {
                    Cliente = grupo.Key,
                    TotalLiquidaciones = grupo.Sum(x => x.Liquidacion.TotalLiquidacion)
                })
                .OrderByDescending(x => x.TotalLiquidaciones)
                .Take(3)
                .ToList();

            LiquidacionesChart.Series.Clear();

            // Configurar título
            LiquidacionesChart.Titles.Clear();
            var titulo = LiquidacionesChart.Titles.Add("Top Clientes por Liquidaciones");
            titulo.ForeColor = Color.DarkBlue;
            titulo.Font = new Font("Arial", 12, FontStyle.Bold);
            titulo.Alignment = ContentAlignment.MiddleCenter;

            // Configurar serie
            var serie = new Series("Liquidaciones")
            {
                ChartType = SeriesChartType.Bar
            };

            // Agregar datos al gráfico
            foreach (var cliente in topClientes)
            {
                serie.Points.AddXY(cliente.Cliente.Nombre, cliente.TotalLiquidaciones);
            }

            LiquidacionesChart.Series.Add(serie);

            // Leyenda del gráfico
            LiquidacionesChart.Legends.Clear();
        }

        //......................................................................

    }
}
// Soy la línea 360, la última antes de proceder a trabajar en la capa lógica.