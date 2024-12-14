namespace ViewLayer
{
    partial class AdminAuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAuthForm));
            this.materialLabel1 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.VerCheckBox = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.UsuarioTextBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.ContraseñaTextBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.ComprobarButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(32, 93);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(55, 19);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "Usuario";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(32, 148);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(82, 19);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "Contraseña";
            // 
            // VerCheckBox
            // 
            this.VerCheckBox.AutoSize = true;
            this.VerCheckBox.Depth = 0;
            this.VerCheckBox.Location = new System.Drawing.Point(231, 188);
            this.VerCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.VerCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.VerCheckBox.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.VerCheckBox.Name = "VerCheckBox";
            this.VerCheckBox.ReadOnly = false;
            this.VerCheckBox.Ripple = true;
            this.VerCheckBox.Size = new System.Drawing.Size(141, 37);
            this.VerCheckBox.TabIndex = 7;
            this.VerCheckBox.Text = "Ver contraseña";
            this.VerCheckBox.UseVisualStyleBackColor = true;
            // 
            // UsuarioTextBox
            // 
            this.UsuarioTextBox.AnimateReadOnly = false;
            this.UsuarioTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.UsuarioTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.UsuarioTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UsuarioTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UsuarioTextBox.Depth = 0;
            this.UsuarioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.UsuarioTextBox.HideSelection = true;
            this.UsuarioTextBox.LeadingIcon = null;
            this.UsuarioTextBox.Location = new System.Drawing.Point(122, 86);
            this.UsuarioTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.UsuarioTextBox.MaxLength = 32767;
            this.UsuarioTextBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.UsuarioTextBox.Name = "UsuarioTextBox";
            this.UsuarioTextBox.PasswordChar = '\0';
            this.UsuarioTextBox.PrefixSuffixText = null;
            this.UsuarioTextBox.ReadOnly = false;
            this.UsuarioTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UsuarioTextBox.SelectedText = "";
            this.UsuarioTextBox.SelectionLength = 0;
            this.UsuarioTextBox.SelectionStart = 0;
            this.UsuarioTextBox.ShortcutsEnabled = true;
            this.UsuarioTextBox.Size = new System.Drawing.Size(250, 48);
            this.UsuarioTextBox.TabIndex = 8;
            this.UsuarioTextBox.TabStop = false;
            this.UsuarioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsuarioTextBox.TrailingIcon = null;
            this.UsuarioTextBox.UseSystemPasswordChar = false;
            // 
            // ContraseñaTextBox
            // 
            this.ContraseñaTextBox.AnimateReadOnly = false;
            this.ContraseñaTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ContraseñaTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ContraseñaTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ContraseñaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ContraseñaTextBox.Depth = 0;
            this.ContraseñaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ContraseñaTextBox.HideSelection = true;
            this.ContraseñaTextBox.LeadingIcon = null;
            this.ContraseñaTextBox.Location = new System.Drawing.Point(122, 138);
            this.ContraseñaTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ContraseñaTextBox.MaxLength = 32767;
            this.ContraseñaTextBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.ContraseñaTextBox.Name = "ContraseñaTextBox";
            this.ContraseñaTextBox.PasswordChar = '*';
            this.ContraseñaTextBox.PrefixSuffixText = null;
            this.ContraseñaTextBox.ReadOnly = false;
            this.ContraseñaTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ContraseñaTextBox.SelectedText = "";
            this.ContraseñaTextBox.SelectionLength = 0;
            this.ContraseñaTextBox.SelectionStart = 0;
            this.ContraseñaTextBox.ShortcutsEnabled = true;
            this.ContraseñaTextBox.Size = new System.Drawing.Size(250, 48);
            this.ContraseñaTextBox.TabIndex = 9;
            this.ContraseñaTextBox.TabStop = false;
            this.ContraseñaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ContraseñaTextBox.TrailingIcon = null;
            this.ContraseñaTextBox.UseSystemPasswordChar = false;
            // 
            // ComprobarButton
            // 
            this.ComprobarButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ComprobarButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ComprobarButton.Depth = 0;
            this.ComprobarButton.HighEmphasis = true;
            this.ComprobarButton.Icon = null;
            this.ComprobarButton.Location = new System.Drawing.Point(261, 270);
            this.ComprobarButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ComprobarButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.ComprobarButton.Name = "ComprobarButton";
            this.ComprobarButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ComprobarButton.Size = new System.Drawing.Size(111, 36);
            this.ComprobarButton.TabIndex = 10;
            this.ComprobarButton.Text = "Comprobar";
            this.ComprobarButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ComprobarButton.UseAccentColor = false;
            this.ComprobarButton.UseVisualStyleBackColor = true;
            // 
            // AdminAuthForm
            // 
            this.AcceptButton = this.ComprobarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 322);
            this.Controls.Add(this.ComprobarButton);
            this.Controls.Add(this.ContraseñaTextBox);
            this.Controls.Add(this.UsuarioTextBox);
            this.Controls.Add(this.VerCheckBox);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminAuthForm";
            this.Padding = new System.Windows.Forms.Padding(2, 36, 2, 2);
            this.Text = "credenciales de administrador del sistema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel1;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel2;
        private MaterialSkin2Framework.Controls.MaterialCheckbox VerCheckBox;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 UsuarioTextBox;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 ContraseñaTextBox;
        private MaterialSkin2Framework.Controls.MaterialButton ComprobarButton;
    }
}