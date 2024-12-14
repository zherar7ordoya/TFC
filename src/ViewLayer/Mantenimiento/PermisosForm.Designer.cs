namespace ViewLayer
{
    partial class PermisosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AutorizacionesTree = new System.Windows.Forms.TreeView();
            this.materialLabel1 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.GuardarModificacionesButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.QuitarRolPermisoButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.AgregarPermisoButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.AgregarRolButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.EmpleadosDgv = new System.Windows.Forms.DataGridView();
            this.RolesDgv = new System.Windows.Forms.DataGridView();
            this.PermisosDgv = new System.Windows.Forms.DataGridView();
            this.BuscarEmpleadoButton = new MaterialSkin2Framework.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.EmpleadosDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RolesDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PermisosDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // AutorizacionesTree
            // 
            this.AutorizacionesTree.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutorizacionesTree.Location = new System.Drawing.Point(773, 98);
            this.AutorizacionesTree.Name = "AutorizacionesTree";
            this.AutorizacionesTree.Size = new System.Drawing.Size(250, 300);
            this.AutorizacionesTree.TabIndex = 5;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(514, 76);
            this.materialLabel1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(140, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Todos los permisos";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(770, 76);
            this.materialLabel2.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(205, 19);
            this.materialLabel2.TabIndex = 9;
            this.materialLabel2.Text = "Autorizaciones del empleado";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(258, 76);
            this.materialLabel3.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(109, 19);
            this.materialLabel3.TabIndex = 10;
            this.materialLabel3.Text = "Todos los roles";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(2, 76);
            this.materialLabel4.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(153, 19);
            this.materialLabel4.TabIndex = 11;
            this.materialLabel4.Text = "Todos los empleados";
            // 
            // GuardarModificacionesButton
            // 
            this.GuardarModificacionesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GuardarModificacionesButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GuardarModificacionesButton.Depth = 0;
            this.GuardarModificacionesButton.Enabled = false;
            this.GuardarModificacionesButton.HighEmphasis = true;
            this.GuardarModificacionesButton.Icon = null;
            this.GuardarModificacionesButton.Location = new System.Drawing.Point(810, 455);
            this.GuardarModificacionesButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GuardarModificacionesButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.GuardarModificacionesButton.Name = "GuardarModificacionesButton";
            this.GuardarModificacionesButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GuardarModificacionesButton.Size = new System.Drawing.Size(213, 36);
            this.GuardarModificacionesButton.TabIndex = 16;
            this.GuardarModificacionesButton.Text = "Guardar modificaciones";
            this.GuardarModificacionesButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GuardarModificacionesButton.UseAccentColor = true;
            this.GuardarModificacionesButton.UseVisualStyleBackColor = true;
            // 
            // QuitarRolPermisoButton
            // 
            this.QuitarRolPermisoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.QuitarRolPermisoButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.QuitarRolPermisoButton.Depth = 0;
            this.QuitarRolPermisoButton.HighEmphasis = true;
            this.QuitarRolPermisoButton.Icon = null;
            this.QuitarRolPermisoButton.Location = new System.Drawing.Point(850, 407);
            this.QuitarRolPermisoButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.QuitarRolPermisoButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.QuitarRolPermisoButton.Name = "QuitarRolPermisoButton";
            this.QuitarRolPermisoButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.QuitarRolPermisoButton.Size = new System.Drawing.Size(173, 36);
            this.QuitarRolPermisoButton.TabIndex = 17;
            this.QuitarRolPermisoButton.Text = "Quitar rol/permiso";
            this.QuitarRolPermisoButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.QuitarRolPermisoButton.UseAccentColor = false;
            this.QuitarRolPermisoButton.UseVisualStyleBackColor = true;
            // 
            // AgregarPermisoButton
            // 
            this.AgregarPermisoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AgregarPermisoButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AgregarPermisoButton.Depth = 0;
            this.AgregarPermisoButton.HighEmphasis = true;
            this.AgregarPermisoButton.Icon = null;
            this.AgregarPermisoButton.Location = new System.Drawing.Point(613, 407);
            this.AgregarPermisoButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AgregarPermisoButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.AgregarPermisoButton.Name = "AgregarPermisoButton";
            this.AgregarPermisoButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AgregarPermisoButton.Size = new System.Drawing.Size(154, 36);
            this.AgregarPermisoButton.TabIndex = 18;
            this.AgregarPermisoButton.Text = "Agregar permiso";
            this.AgregarPermisoButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AgregarPermisoButton.UseAccentColor = false;
            this.AgregarPermisoButton.UseVisualStyleBackColor = true;
            // 
            // AgregarRolButton
            // 
            this.AgregarRolButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AgregarRolButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AgregarRolButton.Depth = 0;
            this.AgregarRolButton.HighEmphasis = true;
            this.AgregarRolButton.Icon = null;
            this.AgregarRolButton.Location = new System.Drawing.Point(392, 407);
            this.AgregarRolButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AgregarRolButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.AgregarRolButton.Name = "AgregarRolButton";
            this.AgregarRolButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AgregarRolButton.Size = new System.Drawing.Size(119, 36);
            this.AgregarRolButton.TabIndex = 19;
            this.AgregarRolButton.Text = "Agregar rol";
            this.AgregarRolButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AgregarRolButton.UseAccentColor = false;
            this.AgregarRolButton.UseVisualStyleBackColor = true;
            // 
            // EmpleadosDgv
            // 
            this.EmpleadosDgv.AllowUserToAddRows = false;
            this.EmpleadosDgv.AllowUserToDeleteRows = false;
            this.EmpleadosDgv.AllowUserToResizeRows = false;
            this.EmpleadosDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EmpleadosDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.EmpleadosDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.EmpleadosDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmpleadosDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.EmpleadosDgv.ColumnHeadersHeight = 56;
            this.EmpleadosDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EmpleadosDgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.EmpleadosDgv.EnableHeadersVisualStyles = false;
            this.EmpleadosDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.EmpleadosDgv.Location = new System.Drawing.Point(5, 98);
            this.EmpleadosDgv.MultiSelect = false;
            this.EmpleadosDgv.Name = "EmpleadosDgv";
            this.EmpleadosDgv.ReadOnly = true;
            this.EmpleadosDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.EmpleadosDgv.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.EmpleadosDgv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.EmpleadosDgv.RowTemplate.Height = 42;
            this.EmpleadosDgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EmpleadosDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmpleadosDgv.Size = new System.Drawing.Size(250, 300);
            this.EmpleadosDgv.TabIndex = 20;
            // 
            // RolesDgv
            // 
            this.RolesDgv.AllowUserToAddRows = false;
            this.RolesDgv.AllowUserToDeleteRows = false;
            this.RolesDgv.AllowUserToResizeRows = false;
            this.RolesDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RolesDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RolesDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.RolesDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RolesDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.RolesDgv.ColumnHeadersHeight = 56;
            this.RolesDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RolesDgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.RolesDgv.EnableHeadersVisualStyles = false;
            this.RolesDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.RolesDgv.Location = new System.Drawing.Point(261, 98);
            this.RolesDgv.MultiSelect = false;
            this.RolesDgv.Name = "RolesDgv";
            this.RolesDgv.ReadOnly = true;
            this.RolesDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RolesDgv.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RolesDgv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.RolesDgv.RowTemplate.Height = 42;
            this.RolesDgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RolesDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RolesDgv.Size = new System.Drawing.Size(250, 300);
            this.RolesDgv.TabIndex = 21;
            // 
            // PermisosDgv
            // 
            this.PermisosDgv.AllowUserToAddRows = false;
            this.PermisosDgv.AllowUserToDeleteRows = false;
            this.PermisosDgv.AllowUserToResizeRows = false;
            this.PermisosDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PermisosDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PermisosDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.PermisosDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PermisosDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.PermisosDgv.ColumnHeadersHeight = 56;
            this.PermisosDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PermisosDgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.PermisosDgv.EnableHeadersVisualStyles = false;
            this.PermisosDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.PermisosDgv.Location = new System.Drawing.Point(517, 98);
            this.PermisosDgv.MultiSelect = false;
            this.PermisosDgv.Name = "PermisosDgv";
            this.PermisosDgv.ReadOnly = true;
            this.PermisosDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PermisosDgv.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PermisosDgv.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.PermisosDgv.RowTemplate.Height = 42;
            this.PermisosDgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PermisosDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PermisosDgv.Size = new System.Drawing.Size(250, 300);
            this.PermisosDgv.TabIndex = 22;
            // 
            // BuscarEmpleadoButton
            // 
            this.BuscarEmpleadoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BuscarEmpleadoButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BuscarEmpleadoButton.Depth = 0;
            this.BuscarEmpleadoButton.HighEmphasis = true;
            this.BuscarEmpleadoButton.Icon = null;
            this.BuscarEmpleadoButton.Location = new System.Drawing.Point(5, 407);
            this.BuscarEmpleadoButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BuscarEmpleadoButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.BuscarEmpleadoButton.Name = "BuscarEmpleadoButton";
            this.BuscarEmpleadoButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BuscarEmpleadoButton.Size = new System.Drawing.Size(158, 36);
            this.BuscarEmpleadoButton.TabIndex = 23;
            this.BuscarEmpleadoButton.Text = "Buscar empleado";
            this.BuscarEmpleadoButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BuscarEmpleadoButton.UseAccentColor = false;
            this.BuscarEmpleadoButton.UseVisualStyleBackColor = true;
            // 
            // PermisosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 506);
            this.Controls.Add(this.BuscarEmpleadoButton);
            this.Controls.Add(this.PermisosDgv);
            this.Controls.Add(this.RolesDgv);
            this.Controls.Add(this.EmpleadosDgv);
            this.Controls.Add(this.AgregarRolButton);
            this.Controls.Add(this.AgregarPermisoButton);
            this.Controls.Add(this.QuitarRolPermisoButton);
            this.Controls.Add(this.GuardarModificacionesButton);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.AutorizacionesTree);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PermisosForm";
            this.Padding = new System.Windows.Forms.Padding(2, 46, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "permisos de usuario";
            ((System.ComponentModel.ISupportInitialize)(this.EmpleadosDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RolesDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PermisosDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView AutorizacionesTree;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel1;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel2;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel3;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel4;
        private MaterialSkin2Framework.Controls.MaterialButton GuardarModificacionesButton;
        private MaterialSkin2Framework.Controls.MaterialButton QuitarRolPermisoButton;
        private MaterialSkin2Framework.Controls.MaterialButton AgregarPermisoButton;
        private MaterialSkin2Framework.Controls.MaterialButton AgregarRolButton;
        private System.Windows.Forms.DataGridView EmpleadosDgv;
        private System.Windows.Forms.DataGridView RolesDgv;
        private System.Windows.Forms.DataGridView PermisosDgv;
        private MaterialSkin2Framework.Controls.MaterialButton BuscarEmpleadoButton;
    }
}