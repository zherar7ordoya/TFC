namespace ViewLayer
{
    partial class DespachadorForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.materialLabel2 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.OrigenTextBox = new System.Windows.Forms.TextBox();
            this.DestinoTextBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.OrdenIdTextBox = new System.Windows.Forms.TextBox();
            this.OrdenesTreeView = new System.Windows.Forms.TreeView();
            this.GenerarDespachoButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.CancelarOrdenButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DistanciaTextBox = new System.Windows.Forms.TextBox();
            this.VerticalDivider = new System.Windows.Forms.Label();
            this.TransitoCheckBox = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.PagadaCheckBox = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.LugarCargaTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.LugarDescargaTextBox = new System.Windows.Forms.TextBox();
            this.ObservacionesTextBox = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.CompletadaCheckBox = new System.Windows.Forms.CheckBox();
            this.ComisionableCheckBox = new System.Windows.Forms.CheckBox();
            this.materialLabel4 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.ChoferComboBox = new System.Windows.Forms.ComboBox();
            this.CamionComboBox = new System.Windows.Forms.ComboBox();
            this.EstibadorComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.InsumoTextBox = new System.Windows.Forms.TextBox();
            this.AgregarEstibadorButton = new System.Windows.Forms.Button();
            this.QuitarEstibadorButton = new System.Windows.Forms.Button();
            this.QuitarInsumoButton = new System.Windows.Forms.Button();
            this.AgregarInsumoButton = new System.Windows.Forms.Button();
            this.GuardarButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.EstibadoresListBox = new System.Windows.Forms.ListBox();
            this.InsumosListBox = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CamionTextBox = new System.Windows.Forms.TextBox();
            this.ResultadoPanel = new System.Windows.Forms.Panel();
            this.AsignacionesPanel = new System.Windows.Forms.Panel();
            this.FechaMudanzaTextBox = new System.Windows.Forms.TextBox();
            this.ResultadoPanel.SuspendLayout();
            this.AsignacionesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(373, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 414);
            this.label4.TabIndex = 165;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(381, 13);
            this.materialLabel2.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(91, 19);
            this.materialLabel2.TabIndex = 160;
            this.materialLabel2.Text = "SOLICITADO";
            this.materialLabel2.UseAccent = true;
            // 
            // OrigenTextBox
            // 
            this.OrigenTextBox.Location = new System.Drawing.Point(592, 77);
            this.OrigenTextBox.Name = "OrigenTextBox";
            this.OrigenTextBox.ReadOnly = true;
            this.OrigenTextBox.Size = new System.Drawing.Size(170, 26);
            this.OrigenTextBox.TabIndex = 156;
            // 
            // DestinoTextBox
            // 
            this.DestinoTextBox.Location = new System.Drawing.Point(592, 109);
            this.DestinoTextBox.Name = "DestinoTextBox";
            this.DestinoTextBox.ReadOnly = true;
            this.DestinoTextBox.Size = new System.Drawing.Size(170, 26);
            this.DestinoTextBox.TabIndex = 155;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(381, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 18);
            this.label20.TabIndex = 154;
            this.label20.Text = "Orden/Camión";
            // 
            // OrdenIdTextBox
            // 
            this.OrdenIdTextBox.Location = new System.Drawing.Point(486, 45);
            this.OrdenIdTextBox.Name = "OrdenIdTextBox";
            this.OrdenIdTextBox.ReadOnly = true;
            this.OrdenIdTextBox.Size = new System.Drawing.Size(100, 26);
            this.OrdenIdTextBox.TabIndex = 153;
            // 
            // OrdenesTreeView
            // 
            this.OrdenesTreeView.Location = new System.Drawing.Point(12, 47);
            this.OrdenesTreeView.Name = "OrdenesTreeView";
            this.OrdenesTreeView.Size = new System.Drawing.Size(345, 215);
            this.OrdenesTreeView.TabIndex = 152;
            // 
            // GenerarDespachoButton
            // 
            this.GenerarDespachoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GenerarDespachoButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GenerarDespachoButton.Depth = 0;
            this.GenerarDespachoButton.Enabled = false;
            this.GenerarDespachoButton.HighEmphasis = true;
            this.GenerarDespachoButton.Icon = null;
            this.GenerarDespachoButton.Location = new System.Drawing.Point(99, 413);
            this.GenerarDespachoButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GenerarDespachoButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.GenerarDespachoButton.Name = "GenerarDespachoButton";
            this.GenerarDespachoButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GenerarDespachoButton.Size = new System.Drawing.Size(167, 36);
            this.GenerarDespachoButton.TabIndex = 151;
            this.GenerarDespachoButton.Text = "Generar despacho";
            this.GenerarDespachoButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GenerarDespachoButton.UseAccentColor = true;
            this.GenerarDespachoButton.UseVisualStyleBackColor = true;
            // 
            // CancelarOrdenButton
            // 
            this.CancelarOrdenButton.AutoSize = true;
            this.CancelarOrdenButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelarOrdenButton.Location = new System.Drawing.Point(651, 459);
            this.CancelarOrdenButton.Name = "CancelarOrdenButton";
            this.CancelarOrdenButton.Size = new System.Drawing.Size(111, 28);
            this.CancelarOrdenButton.TabIndex = 150;
            this.CancelarOrdenButton.Text = "Cancelar orden";
            this.CancelarOrdenButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(12, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(344, 2);
            this.label7.TabIndex = 127;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 125;
            this.label5.Text = "Fecha/Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(381, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 124;
            this.label3.Text = "Dist./Destino";
            // 
            // DistanciaTextBox
            // 
            this.DistanciaTextBox.Location = new System.Drawing.Point(486, 109);
            this.DistanciaTextBox.Name = "DistanciaTextBox";
            this.DistanciaTextBox.ReadOnly = true;
            this.DistanciaTextBox.Size = new System.Drawing.Size(100, 26);
            this.DistanciaTextBox.TabIndex = 121;
            // 
            // VerticalDivider
            // 
            this.VerticalDivider.BackColor = System.Drawing.Color.Gray;
            this.VerticalDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.VerticalDivider.Location = new System.Drawing.Point(768, 14);
            this.VerticalDivider.Name = "VerticalDivider";
            this.VerticalDivider.Size = new System.Drawing.Size(2, 414);
            this.VerticalDivider.TabIndex = 120;
            // 
            // TransitoCheckBox
            // 
            this.TransitoCheckBox.AutoSize = true;
            this.TransitoCheckBox.Checked = true;
            this.TransitoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TransitoCheckBox.Depth = 0;
            this.TransitoCheckBox.Location = new System.Drawing.Point(132, 4);
            this.TransitoCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.TransitoCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.TransitoCheckBox.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.TransitoCheckBox.Name = "TransitoCheckBox";
            this.TransitoCheckBox.ReadOnly = false;
            this.TransitoCheckBox.Ripple = true;
            this.TransitoCheckBox.Size = new System.Drawing.Size(111, 37);
            this.TransitoCheckBox.TabIndex = 168;
            this.TransitoCheckBox.Text = "En tránsito";
            this.TransitoCheckBox.UseVisualStyleBackColor = true;
            // 
            // PagadaCheckBox
            // 
            this.PagadaCheckBox.AutoSize = true;
            this.PagadaCheckBox.Checked = true;
            this.PagadaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PagadaCheckBox.Depth = 0;
            this.PagadaCheckBox.Location = new System.Drawing.Point(12, 4);
            this.PagadaCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.PagadaCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.PagadaCheckBox.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.PagadaCheckBox.Name = "PagadaCheckBox";
            this.PagadaCheckBox.ReadOnly = false;
            this.PagadaCheckBox.Ripple = true;
            this.PagadaCheckBox.Size = new System.Drawing.Size(90, 37);
            this.PagadaCheckBox.TabIndex = 169;
            this.PagadaCheckBox.Text = "Pagada";
            this.PagadaCheckBox.UseVisualStyleBackColor = true;
            // 
            // LugarCargaTextBox
            // 
            this.LugarCargaTextBox.Location = new System.Drawing.Point(486, 141);
            this.LugarCargaTextBox.Name = "LugarCargaTextBox";
            this.LugarCargaTextBox.ReadOnly = true;
            this.LugarCargaTextBox.Size = new System.Drawing.Size(276, 26);
            this.LugarCargaTextBox.TabIndex = 174;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(381, 208);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 18);
            this.label18.TabIndex = 172;
            this.label18.Text = "Observaciones";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(381, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 18);
            this.label17.TabIndex = 171;
            this.label17.Text = "Lugar carga";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(381, 176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 18);
            this.label16.TabIndex = 170;
            this.label16.Text = "Lugar descarga";
            // 
            // LugarDescargaTextBox
            // 
            this.LugarDescargaTextBox.Location = new System.Drawing.Point(486, 173);
            this.LugarDescargaTextBox.Name = "LugarDescargaTextBox";
            this.LugarDescargaTextBox.ReadOnly = true;
            this.LugarDescargaTextBox.Size = new System.Drawing.Size(276, 26);
            this.LugarDescargaTextBox.TabIndex = 181;
            // 
            // ObservacionesTextBox
            // 
            this.ObservacionesTextBox.Location = new System.Drawing.Point(486, 205);
            this.ObservacionesTextBox.Multiline = true;
            this.ObservacionesTextBox.Name = "ObservacionesTextBox";
            this.ObservacionesTextBox.ReadOnly = true;
            this.ObservacionesTextBox.Size = new System.Drawing.Size(276, 62);
            this.ObservacionesTextBox.TabIndex = 182;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(9, 306);
            this.materialLabel3.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(91, 19);
            this.materialLabel3.TabIndex = 183;
            this.materialLabel3.Text = "RESULTADO";
            this.materialLabel3.UseAccent = true;
            // 
            // CompletadaCheckBox
            // 
            this.CompletadaCheckBox.AutoSize = true;
            this.CompletadaCheckBox.Location = new System.Drawing.Point(12, 19);
            this.CompletadaCheckBox.Name = "CompletadaCheckBox";
            this.CompletadaCheckBox.Size = new System.Drawing.Size(102, 22);
            this.CompletadaCheckBox.TabIndex = 184;
            this.CompletadaCheckBox.Text = "Completada";
            this.CompletadaCheckBox.UseVisualStyleBackColor = true;
            // 
            // ComisionableCheckBox
            // 
            this.ComisionableCheckBox.AutoSize = true;
            this.ComisionableCheckBox.Location = new System.Drawing.Point(11, 47);
            this.ComisionableCheckBox.Name = "ComisionableCheckBox";
            this.ComisionableCheckBox.Size = new System.Drawing.Size(112, 22);
            this.ComisionableCheckBox.TabIndex = 185;
            this.ComisionableCheckBox.Text = "Comisionable";
            this.ComisionableCheckBox.UseVisualStyleBackColor = true;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(776, 13);
            this.materialLabel4.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(112, 19);
            this.materialLabel4.TabIndex = 187;
            this.materialLabel4.Text = "ASIGNACIONES";
            this.materialLabel4.UseAccent = true;
            // 
            // ChoferComboBox
            // 
            this.ChoferComboBox.FormattingEnabled = true;
            this.ChoferComboBox.Location = new System.Drawing.Point(70, 40);
            this.ChoferComboBox.Name = "ChoferComboBox";
            this.ChoferComboBox.Size = new System.Drawing.Size(196, 26);
            this.ChoferComboBox.TabIndex = 188;
            // 
            // CamionComboBox
            // 
            this.CamionComboBox.FormattingEnabled = true;
            this.CamionComboBox.Location = new System.Drawing.Point(70, 8);
            this.CamionComboBox.Name = "CamionComboBox";
            this.CamionComboBox.Size = new System.Drawing.Size(196, 26);
            this.CamionComboBox.TabIndex = 189;
            // 
            // EstibadorComboBox
            // 
            this.EstibadorComboBox.FormattingEnabled = true;
            this.EstibadorComboBox.Location = new System.Drawing.Point(10, 104);
            this.EstibadorComboBox.Name = "EstibadorComboBox";
            this.EstibadorComboBox.Size = new System.Drawing.Size(182, 26);
            this.EstibadorComboBox.TabIndex = 190;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 18);
            this.label6.TabIndex = 194;
            this.label6.Text = "Camión";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(9, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 18);
            this.label8.TabIndex = 195;
            this.label8.Text = "Chofer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(7, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 196;
            this.label9.Text = "Estibador";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(9, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 18);
            this.label10.TabIndex = 197;
            this.label10.Text = "Insumo";
            // 
            // InsumoTextBox
            // 
            this.InsumoTextBox.Location = new System.Drawing.Point(12, 269);
            this.InsumoTextBox.Name = "InsumoTextBox";
            this.InsumoTextBox.Size = new System.Drawing.Size(182, 26);
            this.InsumoTextBox.TabIndex = 198;
            // 
            // AgregarEstibadorButton
            // 
            this.AgregarEstibadorButton.AutoSize = true;
            this.AgregarEstibadorButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AgregarEstibadorButton.Image = global::ViewLayer.Properties.Resources.Paomedia_Small_N_Flat_Sign_add_24;
            this.AgregarEstibadorButton.Location = new System.Drawing.Point(234, 100);
            this.AgregarEstibadorButton.Name = "AgregarEstibadorButton";
            this.AgregarEstibadorButton.Size = new System.Drawing.Size(30, 30);
            this.AgregarEstibadorButton.TabIndex = 199;
            this.AgregarEstibadorButton.UseVisualStyleBackColor = true;
            // 
            // QuitarEstibadorButton
            // 
            this.QuitarEstibadorButton.AutoSize = true;
            this.QuitarEstibadorButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.QuitarEstibadorButton.Image = global::ViewLayer.Properties.Resources.Paomedia_Small_N_Flat_Sign_delete_24;
            this.QuitarEstibadorButton.Location = new System.Drawing.Point(198, 100);
            this.QuitarEstibadorButton.Name = "QuitarEstibadorButton";
            this.QuitarEstibadorButton.Size = new System.Drawing.Size(30, 30);
            this.QuitarEstibadorButton.TabIndex = 203;
            this.QuitarEstibadorButton.UseVisualStyleBackColor = true;
            // 
            // QuitarInsumoButton
            // 
            this.QuitarInsumoButton.AutoSize = true;
            this.QuitarInsumoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.QuitarInsumoButton.Image = global::ViewLayer.Properties.Resources.Paomedia_Small_N_Flat_Sign_delete_24;
            this.QuitarInsumoButton.Location = new System.Drawing.Point(200, 265);
            this.QuitarInsumoButton.Name = "QuitarInsumoButton";
            this.QuitarInsumoButton.Size = new System.Drawing.Size(30, 30);
            this.QuitarInsumoButton.TabIndex = 205;
            this.QuitarInsumoButton.UseVisualStyleBackColor = true;
            // 
            // AgregarInsumoButton
            // 
            this.AgregarInsumoButton.AutoSize = true;
            this.AgregarInsumoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AgregarInsumoButton.Image = global::ViewLayer.Properties.Resources.Paomedia_Small_N_Flat_Sign_add_24;
            this.AgregarInsumoButton.Location = new System.Drawing.Point(236, 265);
            this.AgregarInsumoButton.Name = "AgregarInsumoButton";
            this.AgregarInsumoButton.Size = new System.Drawing.Size(30, 30);
            this.AgregarInsumoButton.TabIndex = 204;
            this.AgregarInsumoButton.UseVisualStyleBackColor = true;
            // 
            // GuardarButton
            // 
            this.GuardarButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GuardarButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GuardarButton.Depth = 0;
            this.GuardarButton.Enabled = false;
            this.GuardarButton.HighEmphasis = true;
            this.GuardarButton.Icon = null;
            this.GuardarButton.Location = new System.Drawing.Point(135, 71);
            this.GuardarButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GuardarButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GuardarButton.Size = new System.Drawing.Size(88, 36);
            this.GuardarButton.TabIndex = 206;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GuardarButton.UseAccentColor = false;
            this.GuardarButton.UseVisualStyleBackColor = true;
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.HorizontalScrollbar = true;
            this.ItemsListBox.ItemHeight = 18;
            this.ItemsListBox.Location = new System.Drawing.Point(384, 306);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(378, 130);
            this.ItemsListBox.TabIndex = 312;
            // 
            // EstibadoresListBox
            // 
            this.EstibadoresListBox.FormattingEnabled = true;
            this.EstibadoresListBox.ItemHeight = 18;
            this.EstibadoresListBox.Location = new System.Drawing.Point(10, 136);
            this.EstibadoresListBox.Name = "EstibadoresListBox";
            this.EstibadoresListBox.Size = new System.Drawing.Size(254, 94);
            this.EstibadoresListBox.TabIndex = 313;
            // 
            // InsumosListBox
            // 
            this.InsumosListBox.FormattingEnabled = true;
            this.InsumosListBox.HorizontalScrollbar = true;
            this.InsumosListBox.ItemHeight = 18;
            this.InsumosListBox.Location = new System.Drawing.Point(12, 301);
            this.InsumosListBox.Name = "InsumosListBox";
            this.InsumosListBox.Size = new System.Drawing.Size(254, 94);
            this.InsumosListBox.TabIndex = 314;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(381, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 18);
            this.label12.TabIndex = 315;
            this.label12.Text = "Items";
            // 
            // CamionTextBox
            // 
            this.CamionTextBox.Location = new System.Drawing.Point(592, 45);
            this.CamionTextBox.Name = "CamionTextBox";
            this.CamionTextBox.ReadOnly = true;
            this.CamionTextBox.Size = new System.Drawing.Size(170, 26);
            this.CamionTextBox.TabIndex = 316;
            // 
            // ResultadoPanel
            // 
            this.ResultadoPanel.Controls.Add(this.GuardarButton);
            this.ResultadoPanel.Controls.Add(this.CompletadaCheckBox);
            this.ResultadoPanel.Controls.Add(this.ComisionableCheckBox);
            this.ResultadoPanel.Location = new System.Drawing.Point(106, 306);
            this.ResultadoPanel.Name = "ResultadoPanel";
            this.ResultadoPanel.Size = new System.Drawing.Size(250, 130);
            this.ResultadoPanel.TabIndex = 317;
            // 
            // AsignacionesPanel
            // 
            this.AsignacionesPanel.Controls.Add(this.label6);
            this.AsignacionesPanel.Controls.Add(this.GenerarDespachoButton);
            this.AsignacionesPanel.Controls.Add(this.ChoferComboBox);
            this.AsignacionesPanel.Controls.Add(this.CamionComboBox);
            this.AsignacionesPanel.Controls.Add(this.EstibadorComboBox);
            this.AsignacionesPanel.Controls.Add(this.InsumosListBox);
            this.AsignacionesPanel.Controls.Add(this.label8);
            this.AsignacionesPanel.Controls.Add(this.EstibadoresListBox);
            this.AsignacionesPanel.Controls.Add(this.label9);
            this.AsignacionesPanel.Controls.Add(this.label10);
            this.AsignacionesPanel.Controls.Add(this.QuitarInsumoButton);
            this.AsignacionesPanel.Controls.Add(this.InsumoTextBox);
            this.AsignacionesPanel.Controls.Add(this.AgregarInsumoButton);
            this.AsignacionesPanel.Controls.Add(this.AgregarEstibadorButton);
            this.AsignacionesPanel.Controls.Add(this.QuitarEstibadorButton);
            this.AsignacionesPanel.Location = new System.Drawing.Point(776, 35);
            this.AsignacionesPanel.Name = "AsignacionesPanel";
            this.AsignacionesPanel.Size = new System.Drawing.Size(279, 461);
            this.AsignacionesPanel.TabIndex = 318;
            // 
            // FechaMudanzaTextBox
            // 
            this.FechaMudanzaTextBox.Location = new System.Drawing.Point(486, 77);
            this.FechaMudanzaTextBox.Name = "FechaMudanzaTextBox";
            this.FechaMudanzaTextBox.ReadOnly = true;
            this.FechaMudanzaTextBox.Size = new System.Drawing.Size(100, 26);
            this.FechaMudanzaTextBox.TabIndex = 319;
            // 
            // DespachadorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 501);
            this.Controls.Add(this.FechaMudanzaTextBox);
            this.Controls.Add(this.AsignacionesPanel);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.ResultadoPanel);
            this.Controls.Add(this.CamionTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ItemsListBox);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.ObservacionesTextBox);
            this.Controls.Add(this.LugarDescargaTextBox);
            this.Controls.Add(this.LugarCargaTextBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.PagadaCheckBox);
            this.Controls.Add(this.TransitoCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.OrigenTextBox);
            this.Controls.Add(this.DestinoTextBox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.OrdenIdTextBox);
            this.Controls.Add(this.OrdenesTreeView);
            this.Controls.Add(this.CancelarOrdenButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DistanciaTextBox);
            this.Controls.Add(this.VerticalDivider);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "DespachadorForm";
            this.Text = "DESPACHO";
            this.ResultadoPanel.ResumeLayout(false);
            this.ResultadoPanel.PerformLayout();
            this.AsignacionesPanel.ResumeLayout(false);
            this.AsignacionesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TextBox OrigenTextBox;
        private System.Windows.Forms.TextBox DestinoTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox OrdenIdTextBox;
        private System.Windows.Forms.TreeView OrdenesTreeView;
        private MaterialSkin2Framework.Controls.MaterialButton GenerarDespachoButton;
        private System.Windows.Forms.Button CancelarOrdenButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DistanciaTextBox;
        private System.Windows.Forms.Label VerticalDivider;
        private MaterialSkin2Framework.Controls.MaterialCheckbox TransitoCheckBox;
        private MaterialSkin2Framework.Controls.MaterialCheckbox PagadaCheckBox;
        private System.Windows.Forms.TextBox LugarCargaTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox LugarDescargaTextBox;
        private System.Windows.Forms.TextBox ObservacionesTextBox;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.CheckBox CompletadaCheckBox;
        private System.Windows.Forms.CheckBox ComisionableCheckBox;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.ComboBox ChoferComboBox;
        private System.Windows.Forms.ComboBox CamionComboBox;
        private System.Windows.Forms.ComboBox EstibadorComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox InsumoTextBox;
        private System.Windows.Forms.Button AgregarEstibadorButton;
        private System.Windows.Forms.Button QuitarEstibadorButton;
        private System.Windows.Forms.Button QuitarInsumoButton;
        private System.Windows.Forms.Button AgregarInsumoButton;
        private MaterialSkin2Framework.Controls.MaterialButton GuardarButton;
        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.ListBox EstibadoresListBox;
        private System.Windows.Forms.ListBox InsumosListBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CamionTextBox;
        private System.Windows.Forms.Panel ResultadoPanel;
        private System.Windows.Forms.Panel AsignacionesPanel;
        private System.Windows.Forms.TextBox FechaMudanzaTextBox;
    }
}