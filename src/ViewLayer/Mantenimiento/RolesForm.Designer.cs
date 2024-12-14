using System.Drawing;
using System.Windows.Forms;

namespace ViewLayer
{
    partial class RolesForm
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
            this.RolesLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.RolDescripcionTextBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.GuardarModificacionesButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.AgregarPermisoButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.QuitarPermisoButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.DescripcionLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.BloqueadoCheckBox = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.EliminadoCheckBox = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.IdLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.RolIdTextBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.RolesDgv = new System.Windows.Forms.DataGridView();
            this.PermisosDisponiblesDgv = new System.Windows.Forms.DataGridView();
            this.PermisosOtorgadosDgv = new System.Windows.Forms.DataGridView();
            this.CrearRolButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.BuscarRolButton = new MaterialSkin2Framework.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.RolesDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PermisosDisponiblesDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PermisosOtorgadosDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // RolesLabel
            // 
            this.RolesLabel.AutoSize = true;
            this.RolesLabel.Depth = 0;
            this.RolesLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.RolesLabel.Location = new System.Drawing.Point(6, 79);
            this.RolesLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.RolesLabel.Name = "RolesLabel";
            this.RolesLabel.Size = new System.Drawing.Size(40, 19);
            this.RolesLabel.TabIndex = 1;
            this.RolesLabel.Text = "Roles";
            // 
            // RolDescripcionTextBox
            // 
            this.RolDescripcionTextBox.AnimateReadOnly = false;
            this.RolDescripcionTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.RolDescripcionTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.RolDescripcionTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RolDescripcionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.RolDescripcionTextBox.Depth = 0;
            this.RolDescripcionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.RolDescripcionTextBox.HideSelection = true;
            this.RolDescripcionTextBox.LeadingIcon = null;
            this.RolDescripcionTextBox.Location = new System.Drawing.Point(262, 353);
            this.RolDescripcionTextBox.MaxLength = 32767;
            this.RolDescripcionTextBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.RolDescripcionTextBox.Name = "RolDescripcionTextBox";
            this.RolDescripcionTextBox.PasswordChar = '\0';
            this.RolDescripcionTextBox.PrefixSuffixText = null;
            this.RolDescripcionTextBox.ReadOnly = false;
            this.RolDescripcionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RolDescripcionTextBox.SelectedText = "";
            this.RolDescripcionTextBox.SelectionLength = 0;
            this.RolDescripcionTextBox.SelectionStart = 0;
            this.RolDescripcionTextBox.ShortcutsEnabled = true;
            this.RolDescripcionTextBox.Size = new System.Drawing.Size(250, 48);
            this.RolDescripcionTextBox.TabIndex = 6;
            this.RolDescripcionTextBox.TabStop = false;
            this.RolDescripcionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RolDescripcionTextBox.TrailingIcon = null;
            this.RolDescripcionTextBox.UseSystemPasswordChar = false;
            // 
            // GuardarModificacionesButton
            // 
            this.GuardarModificacionesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GuardarModificacionesButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GuardarModificacionesButton.Depth = 0;
            this.GuardarModificacionesButton.Enabled = false;
            this.GuardarModificacionesButton.HighEmphasis = true;
            this.GuardarModificacionesButton.Icon = null;
            this.GuardarModificacionesButton.Location = new System.Drawing.Point(811, 458);
            this.GuardarModificacionesButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GuardarModificacionesButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.GuardarModificacionesButton.Name = "GuardarModificacionesButton";
            this.GuardarModificacionesButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GuardarModificacionesButton.Size = new System.Drawing.Size(213, 36);
            this.GuardarModificacionesButton.TabIndex = 12;
            this.GuardarModificacionesButton.Text = "Guardar modificaciones";
            this.GuardarModificacionesButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GuardarModificacionesButton.UseAccentColor = true;
            this.GuardarModificacionesButton.UseVisualStyleBackColor = true;
            // 
            // AgregarPermisoButton
            // 
            this.AgregarPermisoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AgregarPermisoButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AgregarPermisoButton.Depth = 0;
            this.AgregarPermisoButton.HighEmphasis = true;
            this.AgregarPermisoButton.Icon = null;
            this.AgregarPermisoButton.Location = new System.Drawing.Point(614, 410);
            this.AgregarPermisoButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AgregarPermisoButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.AgregarPermisoButton.Name = "AgregarPermisoButton";
            this.AgregarPermisoButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AgregarPermisoButton.Size = new System.Drawing.Size(154, 36);
            this.AgregarPermisoButton.TabIndex = 9;
            this.AgregarPermisoButton.Text = "Agregar permiso";
            this.AgregarPermisoButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AgregarPermisoButton.UseAccentColor = false;
            this.AgregarPermisoButton.UseVisualStyleBackColor = true;
            // 
            // QuitarPermisoButton
            // 
            this.QuitarPermisoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.QuitarPermisoButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.QuitarPermisoButton.Depth = 0;
            this.QuitarPermisoButton.HighEmphasis = true;
            this.QuitarPermisoButton.Icon = null;
            this.QuitarPermisoButton.Location = new System.Drawing.Point(884, 410);
            this.QuitarPermisoButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.QuitarPermisoButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.QuitarPermisoButton.Name = "QuitarPermisoButton";
            this.QuitarPermisoButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.QuitarPermisoButton.Size = new System.Drawing.Size(140, 36);
            this.QuitarPermisoButton.TabIndex = 11;
            this.QuitarPermisoButton.Text = "Quitar permiso";
            this.QuitarPermisoButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.QuitarPermisoButton.UseAccentColor = false;
            this.QuitarPermisoButton.UseVisualStyleBackColor = true;
            // 
            // DescripcionLabel
            // 
            this.DescripcionLabel.AutoSize = true;
            this.DescripcionLabel.Depth = 0;
            this.DescripcionLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DescripcionLabel.Location = new System.Drawing.Point(262, 331);
            this.DescripcionLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.DescripcionLabel.Name = "DescripcionLabel";
            this.DescripcionLabel.Size = new System.Drawing.Size(84, 19);
            this.DescripcionLabel.TabIndex = 9;
            this.DescripcionLabel.Text = "Descripción";
            // 
            // BloqueadoCheckBox
            // 
            this.BloqueadoCheckBox.AutoSize = true;
            this.BloqueadoCheckBox.Depth = 0;
            this.BloqueadoCheckBox.Location = new System.Drawing.Point(259, 101);
            this.BloqueadoCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.BloqueadoCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.BloqueadoCheckBox.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.BloqueadoCheckBox.Name = "BloqueadoCheckBox";
            this.BloqueadoCheckBox.ReadOnly = false;
            this.BloqueadoCheckBox.Ripple = true;
            this.BloqueadoCheckBox.Size = new System.Drawing.Size(111, 37);
            this.BloqueadoCheckBox.TabIndex = 3;
            this.BloqueadoCheckBox.Text = "Bloqueado";
            this.BloqueadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // EliminadoCheckBox
            // 
            this.EliminadoCheckBox.AutoSize = true;
            this.EliminadoCheckBox.Depth = 0;
            this.EliminadoCheckBox.Location = new System.Drawing.Point(393, 101);
            this.EliminadoCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.EliminadoCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.EliminadoCheckBox.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.EliminadoCheckBox.Name = "EliminadoCheckBox";
            this.EliminadoCheckBox.ReadOnly = false;
            this.EliminadoCheckBox.Ripple = true;
            this.EliminadoCheckBox.Size = new System.Drawing.Size(106, 37);
            this.EliminadoCheckBox.TabIndex = 4;
            this.EliminadoCheckBox.Text = "Eliminado";
            this.EliminadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Depth = 0;
            this.IdLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.IdLabel.Location = new System.Drawing.Point(262, 204);
            this.IdLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(14, 19);
            this.IdLabel.TabIndex = 12;
            this.IdLabel.Text = "Id";
            // 
            // RolIdTextBox
            // 
            this.RolIdTextBox.AnimateReadOnly = false;
            this.RolIdTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.RolIdTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.RolIdTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RolIdTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.RolIdTextBox.Depth = 0;
            this.RolIdTextBox.Enabled = false;
            this.RolIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.RolIdTextBox.HideSelection = true;
            this.RolIdTextBox.LeadingIcon = null;
            this.RolIdTextBox.Location = new System.Drawing.Point(265, 226);
            this.RolIdTextBox.MaxLength = 32767;
            this.RolIdTextBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.RolIdTextBox.Name = "RolIdTextBox";
            this.RolIdTextBox.PasswordChar = '\0';
            this.RolIdTextBox.PrefixSuffixText = null;
            this.RolIdTextBox.ReadOnly = false;
            this.RolIdTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RolIdTextBox.SelectedText = "";
            this.RolIdTextBox.SelectionLength = 0;
            this.RolIdTextBox.SelectionStart = 0;
            this.RolIdTextBox.ShortcutsEnabled = true;
            this.RolIdTextBox.Size = new System.Drawing.Size(62, 48);
            this.RolIdTextBox.TabIndex = 5;
            this.RolIdTextBox.TabStop = false;
            this.RolIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RolIdTextBox.TrailingIcon = null;
            this.RolIdTextBox.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(515, 79);
            this.materialLabel1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(152, 19);
            this.materialLabel1.TabIndex = 14;
            this.materialLabel1.Text = "Permisos disponibles";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(771, 79);
            this.materialLabel2.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(143, 19);
            this.materialLabel2.TabIndex = 15;
            this.materialLabel2.Text = "Permisos otorgados";
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RolesDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RolesDgv.ColumnHeadersHeight = 56;
            this.RolesDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RolesDgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.RolesDgv.EnableHeadersVisualStyles = false;
            this.RolesDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.RolesDgv.Location = new System.Drawing.Point(6, 101);
            this.RolesDgv.MultiSelect = false;
            this.RolesDgv.Name = "RolesDgv";
            this.RolesDgv.ReadOnly = true;
            this.RolesDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RolesDgv.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RolesDgv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.RolesDgv.RowTemplate.Height = 42;
            this.RolesDgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RolesDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RolesDgv.Size = new System.Drawing.Size(250, 300);
            this.RolesDgv.TabIndex = 1;
            // 
            // PermisosDisponiblesDgv
            // 
            this.PermisosDisponiblesDgv.AllowUserToAddRows = false;
            this.PermisosDisponiblesDgv.AllowUserToDeleteRows = false;
            this.PermisosDisponiblesDgv.AllowUserToResizeRows = false;
            this.PermisosDisponiblesDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PermisosDisponiblesDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PermisosDisponiblesDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.PermisosDisponiblesDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PermisosDisponiblesDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.PermisosDisponiblesDgv.ColumnHeadersHeight = 56;
            this.PermisosDisponiblesDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PermisosDisponiblesDgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.PermisosDisponiblesDgv.EnableHeadersVisualStyles = false;
            this.PermisosDisponiblesDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.PermisosDisponiblesDgv.Location = new System.Drawing.Point(518, 101);
            this.PermisosDisponiblesDgv.MultiSelect = false;
            this.PermisosDisponiblesDgv.Name = "PermisosDisponiblesDgv";
            this.PermisosDisponiblesDgv.ReadOnly = true;
            this.PermisosDisponiblesDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PermisosDisponiblesDgv.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PermisosDisponiblesDgv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.PermisosDisponiblesDgv.RowTemplate.Height = 42;
            this.PermisosDisponiblesDgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PermisosDisponiblesDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PermisosDisponiblesDgv.Size = new System.Drawing.Size(250, 300);
            this.PermisosDisponiblesDgv.TabIndex = 8;
            // 
            // PermisosOtorgadosDgv
            // 
            this.PermisosOtorgadosDgv.AllowUserToAddRows = false;
            this.PermisosOtorgadosDgv.AllowUserToDeleteRows = false;
            this.PermisosOtorgadosDgv.AllowUserToResizeRows = false;
            this.PermisosOtorgadosDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PermisosOtorgadosDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PermisosOtorgadosDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.PermisosOtorgadosDgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PermisosOtorgadosDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.PermisosOtorgadosDgv.ColumnHeadersHeight = 56;
            this.PermisosOtorgadosDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PermisosOtorgadosDgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.PermisosOtorgadosDgv.EnableHeadersVisualStyles = false;
            this.PermisosOtorgadosDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.PermisosOtorgadosDgv.Location = new System.Drawing.Point(774, 101);
            this.PermisosOtorgadosDgv.MultiSelect = false;
            this.PermisosOtorgadosDgv.Name = "PermisosOtorgadosDgv";
            this.PermisosOtorgadosDgv.ReadOnly = true;
            this.PermisosOtorgadosDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PermisosOtorgadosDgv.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PermisosOtorgadosDgv.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.PermisosOtorgadosDgv.RowTemplate.Height = 42;
            this.PermisosOtorgadosDgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PermisosOtorgadosDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PermisosOtorgadosDgv.Size = new System.Drawing.Size(250, 300);
            this.PermisosOtorgadosDgv.TabIndex = 10;
            // 
            // CrearRolButton
            // 
            this.CrearRolButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CrearRolButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CrearRolButton.Depth = 0;
            this.CrearRolButton.HighEmphasis = true;
            this.CrearRolButton.Icon = null;
            this.CrearRolButton.Location = new System.Drawing.Point(262, 410);
            this.CrearRolButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CrearRolButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.CrearRolButton.Name = "CrearRolButton";
            this.CrearRolButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CrearRolButton.Size = new System.Drawing.Size(98, 36);
            this.CrearRolButton.TabIndex = 7;
            this.CrearRolButton.Text = "Crear rol";
            this.CrearRolButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CrearRolButton.UseAccentColor = false;
            this.CrearRolButton.UseVisualStyleBackColor = true;
            // 
            // BuscarRolButton
            // 
            this.BuscarRolButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BuscarRolButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BuscarRolButton.Depth = 0;
            this.BuscarRolButton.HighEmphasis = true;
            this.BuscarRolButton.Icon = null;
            this.BuscarRolButton.Location = new System.Drawing.Point(6, 410);
            this.BuscarRolButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BuscarRolButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.BuscarRolButton.Name = "BuscarRolButton";
            this.BuscarRolButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BuscarRolButton.Size = new System.Drawing.Size(108, 36);
            this.BuscarRolButton.TabIndex = 2;
            this.BuscarRolButton.Text = "Buscar rol";
            this.BuscarRolButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BuscarRolButton.UseAccentColor = false;
            this.BuscarRolButton.UseVisualStyleBackColor = true;
            // 
            // PermisosRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 507);
            this.Controls.Add(this.BuscarRolButton);
            this.Controls.Add(this.CrearRolButton);
            this.Controls.Add(this.PermisosOtorgadosDgv);
            this.Controls.Add(this.PermisosDisponiblesDgv);
            this.Controls.Add(this.RolesDgv);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.RolIdTextBox);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.EliminadoCheckBox);
            this.Controls.Add(this.BloqueadoCheckBox);
            this.Controls.Add(this.DescripcionLabel);
            this.Controls.Add(this.QuitarPermisoButton);
            this.Controls.Add(this.AgregarPermisoButton);
            this.Controls.Add(this.GuardarModificacionesButton);
            this.Controls.Add(this.RolDescripcionTextBox);
            this.Controls.Add(this.RolesLabel);
            this.Name = "PermisosRolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "permisos de rol";
            ((System.ComponentModel.ISupportInitialize)(this.RolesDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PermisosDisponiblesDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PermisosOtorgadosDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin2Framework.Controls.MaterialLabel RolesLabel;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 RolDescripcionTextBox;
        private MaterialSkin2Framework.Controls.MaterialButton GuardarModificacionesButton;
        private MaterialSkin2Framework.Controls.MaterialButton AgregarPermisoButton;
        private MaterialSkin2Framework.Controls.MaterialButton QuitarPermisoButton;
        private MaterialSkin2Framework.Controls.MaterialLabel DescripcionLabel;
        private MaterialSkin2Framework.Controls.MaterialCheckbox BloqueadoCheckBox;
        private MaterialSkin2Framework.Controls.MaterialCheckbox EliminadoCheckBox;
        private MaterialSkin2Framework.Controls.MaterialLabel IdLabel;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 RolIdTextBox;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel1;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DataGridView RolesDgv;
        private DataGridView PermisosDisponiblesDgv;
        private DataGridView PermisosOtorgadosDgv;
        private MaterialSkin2Framework.Controls.MaterialButton CrearRolButton;
        private MaterialSkin2Framework.Controls.MaterialButton BuscarRolButton;
    }
}