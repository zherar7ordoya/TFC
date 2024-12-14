namespace ViewLayer
{
    partial class DashboardForm
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of
        /// this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.HoyRadioButton = new System.Windows.Forms.RadioButton();
            this.SemanaRadioButton = new System.Windows.Forms.RadioButton();
            this.MesRadioButton = new System.Windows.Forms.RadioButton();
            this.TrimestreRadioButton = new System.Windows.Forms.RadioButton();
            this.SemestreRadioButton = new System.Windows.Forms.RadioButton();
            this.AñoRadioButton = new System.Windows.Forms.RadioButton();
            this.DesdeCalendar = new System.Windows.Forms.MonthCalendar();
            this.HastaCalendar = new System.Windows.Forms.MonthCalendar();
            this.SeguimientoTreeView = new System.Windows.Forms.TreeView();
            this.materialLabel1 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.VentasTotalesLabel = new System.Windows.Forms.Label();
            this.CostosTotalesLabel = new System.Windows.Forms.Label();
            this.RentabilidadRealLabel = new System.Windows.Forms.Label();
            this.materialLabel4 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.VersusChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.OrdenesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LiquidacionesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.VersusChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiquidacionesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // HoyRadioButton
            // 
            this.HoyRadioButton.AutoSize = true;
            this.HoyRadioButton.Location = new System.Drawing.Point(7, 438);
            this.HoyRadioButton.Name = "HoyRadioButton";
            this.HoyRadioButton.Size = new System.Drawing.Size(50, 22);
            this.HoyRadioButton.TabIndex = 0;
            this.HoyRadioButton.TabStop = true;
            this.HoyRadioButton.Text = "Hoy";
            this.HoyRadioButton.UseVisualStyleBackColor = true;
            // 
            // SemanaRadioButton
            // 
            this.SemanaRadioButton.AutoSize = true;
            this.SemanaRadioButton.Location = new System.Drawing.Point(126, 440);
            this.SemanaRadioButton.Name = "SemanaRadioButton";
            this.SemanaRadioButton.Size = new System.Drawing.Size(102, 22);
            this.SemanaRadioButton.TabIndex = 1;
            this.SemanaRadioButton.TabStop = true;
            this.SemanaRadioButton.Text = "Esta semana";
            this.SemanaRadioButton.UseVisualStyleBackColor = true;
            // 
            // MesRadioButton
            // 
            this.MesRadioButton.AutoSize = true;
            this.MesRadioButton.Location = new System.Drawing.Point(245, 440);
            this.MesRadioButton.Name = "MesRadioButton";
            this.MesRadioButton.Size = new System.Drawing.Size(81, 22);
            this.MesRadioButton.TabIndex = 2;
            this.MesRadioButton.TabStop = true;
            this.MesRadioButton.Text = "Este mes";
            this.MesRadioButton.UseVisualStyleBackColor = true;
            // 
            // TrimestreRadioButton
            // 
            this.TrimestreRadioButton.AutoSize = true;
            this.TrimestreRadioButton.Location = new System.Drawing.Point(7, 462);
            this.TrimestreRadioButton.Name = "TrimestreRadioButton";
            this.TrimestreRadioButton.Size = new System.Drawing.Size(113, 22);
            this.TrimestreRadioButton.TabIndex = 3;
            this.TrimestreRadioButton.TabStop = true;
            this.TrimestreRadioButton.Text = "Este trimestre";
            this.TrimestreRadioButton.UseVisualStyleBackColor = true;
            // 
            // SemestreRadioButton
            // 
            this.SemestreRadioButton.AutoSize = true;
            this.SemestreRadioButton.Location = new System.Drawing.Point(126, 462);
            this.SemestreRadioButton.Name = "SemestreRadioButton";
            this.SemestreRadioButton.Size = new System.Drawing.Size(113, 22);
            this.SemestreRadioButton.TabIndex = 4;
            this.SemestreRadioButton.TabStop = true;
            this.SemestreRadioButton.Text = "Este semestre";
            this.SemestreRadioButton.UseVisualStyleBackColor = true;
            // 
            // AñoRadioButton
            // 
            this.AñoRadioButton.AutoSize = true;
            this.AñoRadioButton.Location = new System.Drawing.Point(245, 461);
            this.AñoRadioButton.Name = "AñoRadioButton";
            this.AñoRadioButton.Size = new System.Drawing.Size(78, 22);
            this.AñoRadioButton.TabIndex = 5;
            this.AñoRadioButton.TabStop = true;
            this.AñoRadioButton.Text = "Este año";
            this.AñoRadioButton.UseVisualStyleBackColor = true;
            // 
            // DesdeCalendar
            // 
            this.DesdeCalendar.Location = new System.Drawing.Point(7, 31);
            this.DesdeCalendar.Name = "DesdeCalendar";
            this.DesdeCalendar.TabIndex = 6;
            // 
            // HastaCalendar
            // 
            this.HastaCalendar.Location = new System.Drawing.Point(259, 31);
            this.HastaCalendar.Name = "HastaCalendar";
            this.HastaCalendar.TabIndex = 7;
            // 
            // SeguimientoTreeView
            // 
            this.SeguimientoTreeView.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeguimientoTreeView.Location = new System.Drawing.Point(7, 230);
            this.SeguimientoTreeView.Name = "SeguimientoTreeView";
            this.SeguimientoTreeView.Size = new System.Drawing.Size(500, 204);
            this.SeguimientoTreeView.TabIndex = 10;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(4, 208);
            this.materialLabel1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(104, 19);
            this.materialLabel1.TabIndex = 16;
            this.materialLabel1.Text = "SEGUIMIENTO";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(256, 9);
            this.materialLabel2.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(52, 19);
            this.materialLabel2.TabIndex = 17;
            this.materialLabel2.Text = "HASTA";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(4, 9);
            this.materialLabel3.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(51, 19);
            this.materialLabel3.TabIndex = 18;
            this.materialLabel3.Text = "DESDE";
            // 
            // VentasTotalesLabel
            // 
            this.VentasTotalesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VentasTotalesLabel.Location = new System.Drawing.Point(513, 437);
            this.VentasTotalesLabel.Name = "VentasTotalesLabel";
            this.VentasTotalesLabel.Size = new System.Drawing.Size(280, 21);
            this.VentasTotalesLabel.TabIndex = 19;
            this.VentasTotalesLabel.Text = "Ventas Totales";
            this.VentasTotalesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CostosTotalesLabel
            // 
            this.CostosTotalesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostosTotalesLabel.Location = new System.Drawing.Point(512, 461);
            this.CostosTotalesLabel.Name = "CostosTotalesLabel";
            this.CostosTotalesLabel.Size = new System.Drawing.Size(280, 21);
            this.CostosTotalesLabel.TabIndex = 20;
            this.CostosTotalesLabel.Text = "Costos Totales";
            this.CostosTotalesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RentabilidadRealLabel
            // 
            this.RentabilidadRealLabel.AutoSize = true;
            this.RentabilidadRealLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RentabilidadRealLabel.Location = new System.Drawing.Point(784, 450);
            this.RentabilidadRealLabel.Name = "RentabilidadRealLabel";
            this.RentabilidadRealLabel.Size = new System.Drawing.Size(213, 32);
            this.RentabilidadRealLabel.TabIndex = 21;
            this.RentabilidadRealLabel.Text = "Rentabilidad Real";
            this.RentabilidadRealLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(510, 9);
            this.materialLabel4.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(206, 19);
            this.materialLabel4.TabIndex = 22;
            this.materialLabel4.Text = "ANÁLISIS DE RENTABILIDAD";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(935, 9);
            this.materialLabel5.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(270, 19);
            this.materialLabel5.TabIndex = 23;
            this.materialLabel5.Text = "TOP CLIENTES: VENTAS VS. COSTOS";
            // 
            // VersusChart
            // 
            this.VersusChart.BorderlineColor = System.Drawing.SystemColors.ControlDark;
            this.VersusChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea1";
            this.VersusChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.VersusChart.Legends.Add(legend4);
            this.VersusChart.Location = new System.Drawing.Point(513, 31);
            this.VersusChart.Name = "VersusChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.VersusChart.Series.Add(series4);
            this.VersusChart.Size = new System.Drawing.Size(419, 403);
            this.VersusChart.TabIndex = 24;
            this.VersusChart.Text = "Versus";
            // 
            // OrdenesChart
            // 
            this.OrdenesChart.BorderlineColor = System.Drawing.SystemColors.ControlDark;
            this.OrdenesChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea5.Name = "ChartArea1";
            this.OrdenesChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.OrdenesChart.Legends.Add(legend5);
            this.OrdenesChart.Location = new System.Drawing.Point(938, 31);
            this.OrdenesChart.Name = "OrdenesChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.OrdenesChart.Series.Add(series5);
            this.OrdenesChart.Size = new System.Drawing.Size(278, 198);
            this.OrdenesChart.TabIndex = 25;
            this.OrdenesChart.Text = "Órdenes";
            // 
            // LiquidacionesChart
            // 
            this.LiquidacionesChart.BorderlineColor = System.Drawing.SystemColors.ControlDark;
            this.LiquidacionesChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea6.Name = "ChartArea1";
            this.LiquidacionesChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.LiquidacionesChart.Legends.Add(legend6);
            this.LiquidacionesChart.Location = new System.Drawing.Point(938, 236);
            this.LiquidacionesChart.Name = "LiquidacionesChart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.LiquidacionesChart.Series.Add(series6);
            this.LiquidacionesChart.Size = new System.Drawing.Size(278, 198);
            this.LiquidacionesChart.TabIndex = 26;
            this.LiquidacionesChart.Text = "Liquidaciones";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(1224, 514);
            this.Controls.Add(this.LiquidacionesChart);
            this.Controls.Add(this.OrdenesChart);
            this.Controls.Add(this.VersusChart);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.RentabilidadRealLabel);
            this.Controls.Add(this.CostosTotalesLabel);
            this.Controls.Add(this.VentasTotalesLabel);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.SeguimientoTreeView);
            this.Controls.Add(this.HastaCalendar);
            this.Controls.Add(this.DesdeCalendar);
            this.Controls.Add(this.AñoRadioButton);
            this.Controls.Add(this.SemestreRadioButton);
            this.Controls.Add(this.TrimestreRadioButton);
            this.Controls.Add(this.MesRadioButton);
            this.Controls.Add(this.SemanaRadioButton);
            this.Controls.Add(this.HoyRadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DashboardForm";
            this.Text = "DASHBOARD";
            ((System.ComponentModel.ISupportInitialize)(this.VersusChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdenesChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiquidacionesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton HoyRadioButton;
        private System.Windows.Forms.RadioButton SemanaRadioButton;
        private System.Windows.Forms.RadioButton MesRadioButton;
        private System.Windows.Forms.RadioButton TrimestreRadioButton;
        private System.Windows.Forms.RadioButton SemestreRadioButton;
        private System.Windows.Forms.RadioButton AñoRadioButton;
        private System.Windows.Forms.MonthCalendar DesdeCalendar;
        private System.Windows.Forms.MonthCalendar HastaCalendar;
        private System.Windows.Forms.TreeView SeguimientoTreeView;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel1;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel2;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.Label VentasTotalesLabel;
        private System.Windows.Forms.Label CostosTotalesLabel;
        private System.Windows.Forms.Label RentabilidadRealLabel;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel4;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart VersusChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart OrdenesChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart LiquidacionesChart;
    }
}
