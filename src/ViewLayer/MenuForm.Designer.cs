namespace ViewLayer
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
            this.materialToolStripMenuItem1 = new MaterialSkin2Framework.Controls.MaterialToolStripMenuItem();
            this.ArchivoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogoutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArchivoSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SalirItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VentaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CapturaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FacturacionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogisticaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DespachoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LiquidacionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CamionesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpleadosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocacionesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TarifasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GestoresSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.DashboardItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MantenimientoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RolesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PermisosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BitacoraItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BackupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ConfiguracionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.AcercaDeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.SesionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuPrincipal.SuspendLayout();
            this.BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.AllowMerge = false;
            this.MenuPrincipal.AutoSize = false;
            this.MenuPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.MenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MenuPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialToolStripMenuItem1,
            this.ArchivoMenu,
            this.VentaMenu,
            this.LogisticaMenu,
            this.GestionMenu,
            this.MantenimientoMenu,
            this.AyudaMenu});
            this.MenuPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuPrincipal.Location = new System.Drawing.Point(3, 24);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(894, 82);
            this.MenuPrincipal.TabIndex = 1;
            this.MenuPrincipal.Text = "Menú Principal";
            // 
            // materialToolStripMenuItem1
            // 
            this.materialToolStripMenuItem1.AutoSize = false;
            this.materialToolStripMenuItem1.Enabled = false;
            this.materialToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialToolStripMenuItem1.Name = "materialToolStripMenuItem1";
            this.materialToolStripMenuItem1.Size = new System.Drawing.Size(143, 78);
            this.materialToolStripMenuItem1.Text = "La Mudadora";
            // 
            // ArchivoMenu
            // 
            this.ArchivoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginItem,
            this.LogoutItem,
            this.ArchivoSeparator,
            this.SalirItem});
            this.ArchivoMenu.Image = global::ViewLayer.Properties.Resources.icons8_program_57;
            this.ArchivoMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ArchivoMenu.Name = "ArchivoMenu";
            this.ArchivoMenu.Size = new System.Drawing.Size(69, 78);
            this.ArchivoMenu.Text = "Archivo";
            this.ArchivoMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // LoginItem
            // 
            this.LoginItem.Name = "LoginItem";
            this.LoginItem.Size = new System.Drawing.Size(161, 22);
            this.LoginItem.Text = "Iniciar sesión";
            // 
            // LogoutItem
            // 
            this.LogoutItem.Name = "LogoutItem";
            this.LogoutItem.Size = new System.Drawing.Size(161, 22);
            this.LogoutItem.Text = "Cerrar sesión";
            // 
            // ArchivoSeparator
            // 
            this.ArchivoSeparator.Name = "ArchivoSeparator";
            this.ArchivoSeparator.Size = new System.Drawing.Size(158, 6);
            // 
            // SalirItem
            // 
            this.SalirItem.Name = "SalirItem";
            this.SalirItem.Size = new System.Drawing.Size(161, 22);
            this.SalirItem.Text = "Salir";
            // 
            // VentaMenu
            // 
            this.VentaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CapturaItem,
            this.FacturacionItem});
            this.VentaMenu.Image = global::ViewLayer.Properties.Resources.icons8_sales_performance_57;
            this.VentaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VentaMenu.Name = "VentaMenu";
            this.VentaMenu.Size = new System.Drawing.Size(69, 78);
            this.VentaMenu.Text = "Venta";
            this.VentaMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // CapturaItem
            // 
            this.CapturaItem.Name = "CapturaItem";
            this.CapturaItem.Size = new System.Drawing.Size(150, 22);
            this.CapturaItem.Text = "Captura";
            // 
            // FacturacionItem
            // 
            this.FacturacionItem.Name = "FacturacionItem";
            this.FacturacionItem.Size = new System.Drawing.Size(150, 22);
            this.FacturacionItem.Text = "Facturación";
            // 
            // LogisticaMenu
            // 
            this.LogisticaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DespachoItem,
            this.LiquidacionItem});
            this.LogisticaMenu.Image = global::ViewLayer.Properties.Resources.icons8_package_delivery_logistics_57;
            this.LogisticaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LogisticaMenu.Name = "LogisticaMenu";
            this.LogisticaMenu.Size = new System.Drawing.Size(76, 78);
            this.LogisticaMenu.Text = "Logística";
            this.LogisticaMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // DespachoItem
            // 
            this.DespachoItem.Name = "DespachoItem";
            this.DespachoItem.Size = new System.Drawing.Size(148, 22);
            this.DespachoItem.Text = "Despacho";
            // 
            // LiquidacionItem
            // 
            this.LiquidacionItem.Name = "LiquidacionItem";
            this.LiquidacionItem.Size = new System.Drawing.Size(148, 22);
            this.LiquidacionItem.Text = "Liquidación";
            // 
            // GestionMenu
            // 
            this.GestionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CamionesItem,
            this.ClientesItem,
            this.EmpleadosItem,
            this.LocacionesItem,
            this.TarifasItem,
            this.GestoresSeparator,
            this.DashboardItem});
            this.GestionMenu.Image = global::ViewLayer.Properties.Resources.icons8_manager_57;
            this.GestionMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GestionMenu.Name = "GestionMenu";
            this.GestionMenu.Size = new System.Drawing.Size(69, 78);
            this.GestionMenu.Text = "Gestión";
            this.GestionMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // CamionesItem
            // 
            this.CamionesItem.Name = "CamionesItem";
            this.CamionesItem.Size = new System.Drawing.Size(180, 22);
            this.CamionesItem.Text = "Camiones";
            // 
            // ClientesItem
            // 
            this.ClientesItem.Name = "ClientesItem";
            this.ClientesItem.Size = new System.Drawing.Size(180, 22);
            this.ClientesItem.Text = "Clientes";
            // 
            // EmpleadosItem
            // 
            this.EmpleadosItem.Name = "EmpleadosItem";
            this.EmpleadosItem.Size = new System.Drawing.Size(180, 22);
            this.EmpleadosItem.Text = "Empleados";
            // 
            // LocacionesItem
            // 
            this.LocacionesItem.Name = "LocacionesItem";
            this.LocacionesItem.Size = new System.Drawing.Size(180, 22);
            this.LocacionesItem.Text = "Locaciones";
            // 
            // TarifasItem
            // 
            this.TarifasItem.Name = "TarifasItem";
            this.TarifasItem.Size = new System.Drawing.Size(180, 22);
            this.TarifasItem.Text = "Tarifas";
            // 
            // GestoresSeparator
            // 
            this.GestoresSeparator.Name = "GestoresSeparator";
            this.GestoresSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // DashboardItem
            // 
            this.DashboardItem.Name = "DashboardItem";
            this.DashboardItem.Size = new System.Drawing.Size(180, 22);
            this.DashboardItem.Text = "Dashboard";
            // 
            // MantenimientoMenu
            // 
            this.MantenimientoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RolesItem,
            this.PermisosItem,
            this.toolStripSeparator1,
            this.BitacoraItem,
            this.toolStripSeparator2,
            this.BackupItem,
            this.RestoreItem,
            this.toolStripSeparator3,
            this.ConfiguracionItem});
            this.MantenimientoMenu.Image = global::ViewLayer.Properties.Resources.icons8_maintenance_57;
            this.MantenimientoMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MantenimientoMenu.Name = "MantenimientoMenu";
            this.MantenimientoMenu.Size = new System.Drawing.Size(112, 78);
            this.MantenimientoMenu.Text = "Mantenimiento";
            this.MantenimientoMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // RolesItem
            // 
            this.RolesItem.Name = "RolesItem";
            this.RolesItem.Size = new System.Drawing.Size(205, 22);
            this.RolesItem.Text = "Permisos de rol";
            // 
            // PermisosItem
            // 
            this.PermisosItem.Name = "PermisosItem";
            this.PermisosItem.Size = new System.Drawing.Size(205, 22);
            this.PermisosItem.Text = "Permisos de usuario";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // BitacoraItem
            // 
            this.BitacoraItem.Name = "BitacoraItem";
            this.BitacoraItem.Size = new System.Drawing.Size(205, 22);
            this.BitacoraItem.Text = "Bitácora";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // BackupItem
            // 
            this.BackupItem.Name = "BackupItem";
            this.BackupItem.Size = new System.Drawing.Size(205, 22);
            this.BackupItem.Text = "Backup";
            // 
            // RestoreItem
            // 
            this.RestoreItem.Name = "RestoreItem";
            this.RestoreItem.Size = new System.Drawing.Size(205, 22);
            this.RestoreItem.Text = "Restore";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(202, 6);
            // 
            // ConfiguracionItem
            // 
            this.ConfiguracionItem.Name = "ConfiguracionItem";
            this.ConfiguracionItem.Size = new System.Drawing.Size(205, 22);
            this.ConfiguracionItem.Text = "Configuración";
            // 
            // AyudaMenu
            // 
            this.AyudaMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AyudaItem,
            this.AyudaSeparator,
            this.AcercaDeItem});
            this.AyudaMenu.Image = global::ViewLayer.Properties.Resources.icons8_help_57;
            this.AyudaMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AyudaMenu.Name = "AyudaMenu";
            this.AyudaMenu.Size = new System.Drawing.Size(69, 78);
            this.AyudaMenu.Text = "Ayuda";
            this.AyudaMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // AyudaItem
            // 
            this.AyudaItem.Name = "AyudaItem";
            this.AyudaItem.Size = new System.Drawing.Size(141, 22);
            this.AyudaItem.Text = "Ver ayuda";
            // 
            // AyudaSeparator
            // 
            this.AyudaSeparator.Name = "AyudaSeparator";
            this.AyudaSeparator.Size = new System.Drawing.Size(138, 6);
            // 
            // AcercaDeItem
            // 
            this.AcercaDeItem.Name = "AcercaDeItem";
            this.AcercaDeItem.Size = new System.Drawing.Size(141, 22);
            this.AcercaDeItem.Text = "Acerca de";
            // 
            // BarraEstado
            // 
            this.BarraEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.BarraEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.BarraEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SesionLabel});
            this.BarraEstado.Location = new System.Drawing.Point(3, 425);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(894, 22);
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
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.BarraEstado);
            this.Controls.Add(this.MenuPrincipal);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormStyle = MaterialSkin2Framework.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuPrincipal;
            this.Name = "MenuForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
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
        private System.Windows.Forms.ToolStripStatusLabel SesionLabel;
        private System.Windows.Forms.ToolStripSeparator ArchivoSeparator;
        private System.Windows.Forms.ToolStripMenuItem SalirItem;
        private System.Windows.Forms.ToolStripMenuItem VentaMenu;
        private System.Windows.Forms.ToolStripMenuItem LogisticaMenu;
        private System.Windows.Forms.ToolStripMenuItem AyudaMenu;
        private System.Windows.Forms.ToolStripMenuItem AyudaItem;
        private System.Windows.Forms.ToolStripSeparator AyudaSeparator;
        private System.Windows.Forms.ToolStripMenuItem AcercaDeItem;
        private System.Windows.Forms.ToolStripMenuItem CapturaItem;
        private System.Windows.Forms.ToolStripMenuItem FacturacionItem;
        private System.Windows.Forms.ToolStripMenuItem DespachoItem;
        private System.Windows.Forms.ToolStripMenuItem LiquidacionItem;
        private System.Windows.Forms.ToolStripSeparator GestoresSeparator;
        private System.Windows.Forms.ToolStripMenuItem MantenimientoMenu;
        private System.Windows.Forms.ToolStripMenuItem BackupItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreItem;
        private System.Windows.Forms.ToolStripMenuItem BitacoraItem;
        private System.Windows.Forms.ToolStripMenuItem RolesItem;
        private System.Windows.Forms.ToolStripMenuItem ConfiguracionItem;
        private System.Windows.Forms.ToolStripMenuItem PermisosItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private MaterialSkin2Framework.Controls.MaterialToolStripMenuItem materialToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CamionesItem;
        private System.Windows.Forms.ToolStripMenuItem ClientesItem;
        private System.Windows.Forms.ToolStripMenuItem LocacionesItem;
        private System.Windows.Forms.ToolStripMenuItem TarifasItem;
        private System.Windows.Forms.ToolStripMenuItem DashboardItem;
    }
}