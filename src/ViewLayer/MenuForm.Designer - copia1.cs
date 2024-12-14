namespace DesktopPresentation
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.ArchivoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogoutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArchivoSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SalirItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VentaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CapturaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FacturacionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VentaSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.VentasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogisticaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DespachoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LiquidacionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogisticaSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.LogisticasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpleadosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestoresSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.RolesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PermisosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MantenimientoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ItemAcerca = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.SesionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuPrincipal.SuspendLayout();
            this.BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.AllowMerge = false;
            this.MenuPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.MenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MenuPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ArchivoMenu,
            this.VentaMenu,
            this.LogisticaMenu,
            this.GestionMenu,
            this.MantenimientoMenu,
            this.AyudaMenu});
            this.MenuPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuPrincipal.Location = new System.Drawing.Point(3, 64);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(994, 65);
            this.MenuPrincipal.TabIndex = 1;
            this.MenuPrincipal.Text = "Menú Principal";
            // 
            // ArchivoMenu
            // 
            this.ArchivoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginItem,
            this.LogoutItem,
            this.ArchivoSeparator,
            this.SalirItem});
            this.ArchivoMenu.Image = global::DesktopPresentation.Properties.Resources.icons8_program_57;
            this.ArchivoMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ArchivoMenu.Name = "ArchivoMenu";
            this.ArchivoMenu.Size = new System.Drawing.Size(124, 61);
            this.ArchivoMenu.Text = "Archivo";
            // 
            // LoginItem
            // 
            this.LoginItem.Name = "LoginItem";
            this.LoginItem.Size = new System.Drawing.Size(180, 22);
            this.LoginItem.Text = "Iniciar sesión";
            // 
            // LogoutItem
            // 
            this.LogoutItem.Name = "LogoutItem";
            this.LogoutItem.Size = new System.Drawing.Size(180, 22);
            this.LogoutItem.Text = "Cerrar sesión";
            // 
            // ArchivoSeparator
            // 
            this.ArchivoSeparator.Name = "ArchivoSeparator";
            this.ArchivoSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // SalirItem
            // 
            this.SalirItem.Name = "SalirItem";
            this.SalirItem.Size = new System.Drawing.Size(180, 22);
            this.SalirItem.Text = "Salir";
            // 
            // VentaMenu
            // 
            this.VentaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CapturaItem,
            this.FacturacionItem,
            this.VentaSeparator,
            this.VentasItem});
            this.VentaMenu.Image = global::DesktopPresentation.Properties.Resources.icons8_sales_performance_57;
            this.VentaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VentaMenu.Name = "VentaMenu";
            this.VentaMenu.Size = new System.Drawing.Size(114, 61);
            this.VentaMenu.Text = "Venta";
            // 
            // CapturaItem
            // 
            this.CapturaItem.Name = "CapturaItem";
            this.CapturaItem.Size = new System.Drawing.Size(214, 22);
            this.CapturaItem.Text = "Captura";
            // 
            // FacturacionItem
            // 
            this.FacturacionItem.Name = "FacturacionItem";
            this.FacturacionItem.Size = new System.Drawing.Size(214, 22);
            this.FacturacionItem.Text = "Facturación";
            // 
            // VentaSeparator
            // 
            this.VentaSeparator.Name = "VentaSeparator";
            this.VentaSeparator.Size = new System.Drawing.Size(211, 6);
            // 
            // VentasItem
            // 
            this.VentasItem.Name = "VentasItem";
            this.VentasItem.Size = new System.Drawing.Size(214, 22);
            this.VentasItem.Text = "Dashboard de Ventas";
            // 
            // LogisticaMenu
            // 
            this.LogisticaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DespachoItem,
            this.LiquidacionItem,
            this.LogisticaSeparator,
            this.LogisticasItem});
            this.LogisticaMenu.Image = global::DesktopPresentation.Properties.Resources.icons8_package_delivery_logistics_57;
            this.LogisticaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LogisticaMenu.Name = "LogisticaMenu";
            this.LogisticaMenu.Size = new System.Drawing.Size(133, 61);
            this.LogisticaMenu.Text = "Logística";
            // 
            // DespachoItem
            // 
            this.DespachoItem.Name = "DespachoItem";
            this.DespachoItem.Size = new System.Drawing.Size(233, 22);
            this.DespachoItem.Text = "Despacho";
            // 
            // LiquidacionItem
            // 
            this.LiquidacionItem.Name = "LiquidacionItem";
            this.LiquidacionItem.Size = new System.Drawing.Size(233, 22);
            this.LiquidacionItem.Text = "Liquidación";
            // 
            // LogisticaSeparator
            // 
            this.LogisticaSeparator.Name = "LogisticaSeparator";
            this.LogisticaSeparator.Size = new System.Drawing.Size(230, 6);
            // 
            // LogisticasItem
            // 
            this.LogisticasItem.Name = "LogisticasItem";
            this.LogisticasItem.Size = new System.Drawing.Size(233, 22);
            this.LogisticasItem.Text = "Dashboard de Logísticas";
            // 
            // GestionMenu
            // 
            this.GestionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EmpleadosItem,
            this.GestoresSeparator,
            this.RolesItem,
            this.PermisosItem});
            this.GestionMenu.Image = global::DesktopPresentation.Properties.Resources.icons8_manager_57;
            this.GestionMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GestionMenu.Name = "GestionMenu";
            this.GestionMenu.Size = new System.Drawing.Size(126, 61);
            this.GestionMenu.Text = "Gestión";
            // 
            // EmpleadosItem
            // 
            this.EmpleadosItem.Name = "EmpleadosItem";
            this.EmpleadosItem.Size = new System.Drawing.Size(200, 22);
            this.EmpleadosItem.Text = "ABM de empleados";
            // 
            // GestoresSeparator
            // 
            this.GestoresSeparator.Name = "GestoresSeparator";
            this.GestoresSeparator.Size = new System.Drawing.Size(197, 6);
            // 
            // RolesItem
            // 
            this.RolesItem.Name = "RolesItem";
            this.RolesItem.Size = new System.Drawing.Size(200, 22);
            this.RolesItem.Text = "ABM de roles";
            // 
            // PermisosItem
            // 
            this.PermisosItem.Name = "PermisosItem";
            this.PermisosItem.Size = new System.Drawing.Size(200, 22);
            this.PermisosItem.Text = "Gestor de permisos";
            // 
            // MantenimientoMenu
            // 
            this.MantenimientoMenu.Image = global::DesktopPresentation.Properties.Resources.icons8_maintenance_57;
            this.MantenimientoMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MantenimientoMenu.Name = "MantenimientoMenu";
            this.MantenimientoMenu.Size = new System.Drawing.Size(169, 61);
            this.MantenimientoMenu.Text = "Mantenimiento";
            // 
            // AyudaMenu
            // 
            this.AyudaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AyudaItem,
            this.AyudaSeparator,
            this.ItemAcerca});
            this.AyudaMenu.Image = global::DesktopPresentation.Properties.Resources.icons8_help_57;
            this.AyudaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AyudaMenu.Name = "AyudaMenu";
            this.AyudaMenu.Size = new System.Drawing.Size(117, 61);
            this.AyudaMenu.Text = "Ayuda";
            // 
            // AyudaItem
            // 
            this.AyudaItem.Name = "AyudaItem";
            this.AyudaItem.Size = new System.Drawing.Size(180, 22);
            this.AyudaItem.Text = "Ver ayuda";
            // 
            // AyudaSeparator
            // 
            this.AyudaSeparator.Name = "AyudaSeparator";
            this.AyudaSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // ItemAcerca
            // 
            this.ItemAcerca.Name = "ItemAcerca";
            this.ItemAcerca.Size = new System.Drawing.Size(180, 22);
            this.ItemAcerca.Text = "Acerca de";
            // 
            // BarraEstado
            // 
            this.BarraEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.BarraEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.BarraEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SesionLabel});
            this.BarraEstado.Location = new System.Drawing.Point(3, 475);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(994, 22);
            this.BarraEstado.TabIndex = 2;
            this.BarraEstado.Text = "Barra de Estado";
            // 
            // SesionLabel
            // 
            this.SesionLabel.Name = "SesionLabel";
            this.SesionLabel.Size = new System.Drawing.Size(118, 17);
            this.SesionLabel.Text = "Gerardo Tordoya";
            // 
            // MenuForm
            // 
            this.AccentColor = MaterialSkin2Framework.Accent.Red700;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.BarraEstado);
            this.Controls.Add(this.MenuPrincipal);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuPrincipal;
            this.Name = "MenuForm";
            this.PrimaryColor = MaterialSkin2Framework.Primary.Green400;
            this.PrimaryDarkColor = MaterialSkin2Framework.Primary.Green700;
            this.PrimaryLightColor = MaterialSkin2Framework.Primary.Green100;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Mudadora";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            this.BarraEstado.ResumeLayout(false);
            this.BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.StatusStrip BarraEstado;
        private System.Windows.Forms.ToolStripMenuItem ArchivoMenu;
        private System.Windows.Forms.ToolStripMenuItem GestionMenu;
        private System.Windows.Forms.ToolStripMenuItem LoginItem;
        private System.Windows.Forms.ToolStripMenuItem LogoutItem;
        private System.Windows.Forms.ToolStripMenuItem EmpleadosItem;
        private System.Windows.Forms.ToolStripMenuItem PermisosItem;
        private System.Windows.Forms.ToolStripStatusLabel SesionLabel;
        private System.Windows.Forms.ToolStripSeparator ArchivoSeparator;
        private System.Windows.Forms.ToolStripMenuItem SalirItem;
        private System.Windows.Forms.ToolStripMenuItem VentaMenu;
        private System.Windows.Forms.ToolStripMenuItem LogisticaMenu;
        private System.Windows.Forms.ToolStripMenuItem AyudaMenu;
        private System.Windows.Forms.ToolStripMenuItem AyudaItem;
        private System.Windows.Forms.ToolStripSeparator AyudaSeparator;
        private System.Windows.Forms.ToolStripMenuItem ItemAcerca;
        private System.Windows.Forms.ToolStripMenuItem CapturaItem;
        private System.Windows.Forms.ToolStripMenuItem FacturacionItem;
        private System.Windows.Forms.ToolStripMenuItem VentasItem;
        private System.Windows.Forms.ToolStripMenuItem DespachoItem;
        private System.Windows.Forms.ToolStripMenuItem LiquidacionItem;
        private System.Windows.Forms.ToolStripMenuItem LogisticasItem;
        private System.Windows.Forms.ToolStripMenuItem RolesItem;
        private System.Windows.Forms.ToolStripSeparator VentaSeparator;
        private System.Windows.Forms.ToolStripSeparator LogisticaSeparator;
        private System.Windows.Forms.ToolStripSeparator GestoresSeparator;
        private System.Windows.Forms.ToolStripMenuItem MantenimientoMenu;
    }
}