namespace ViewLayer
{
    partial class CapturadorForm
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
            this.VerticalDivider = new System.Windows.Forms.Label();
            this.DistanciaTotalTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OrigenComboBox = new System.Windows.Forms.ComboBox();
            this.DestinoComboBox = new System.Windows.Forms.ComboBox();
            this.MapaPictureBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FechaMudanzaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.CamionComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BuscarClienteButton = new System.Windows.Forms.Button();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.IdentificadorTextBox = new System.Windows.Forms.TextBox();
            this.PersonaFisicaRadioButton = new System.Windows.Forms.RadioButton();
            this.PersonaJuridicaRadioButton = new System.Windows.Forms.RadioButton();
            this.NivelTarifarioComboBox = new System.Windows.Forms.ComboBox();
            this.DireccionTextBox = new System.Windows.Forms.TextBox();
            this.TelefonoTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.GuardarClienteButton = new System.Windows.Forms.Button();
            this.CrearClienteButton = new System.Windows.Forms.Button();
            this.CotizacionTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CondicionFiscalComboBox = new System.Windows.Forms.ComboBox();
            this.CotizarButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.LugarCargaTextBox = new System.Windows.Forms.TextBox();
            this.LugarDescargaTextBox = new System.Windows.Forms.TextBox();
            this.ObservacionesTextBox = new System.Windows.Forms.TextBox();
            this.ItemTextBox = new System.Windows.Forms.TextBox();
            this.AgregarItemButton = new System.Windows.Forms.Button();
            this.CancelarOperacionButton = new System.Windows.Forms.Button();
            this.GenerarOrdenButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.QuitarItemButton = new System.Windows.Forms.Button();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DescargaCentralTextBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.CargaDescargaTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.CentralCargaTextBox = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.MonitorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MapaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // VerticalDivider
            // 
            this.VerticalDivider.BackColor = System.Drawing.Color.Gray;
            this.VerticalDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.VerticalDivider.Location = new System.Drawing.Point(895, 13);
            this.VerticalDivider.Name = "VerticalDivider";
            this.VerticalDivider.Size = new System.Drawing.Size(2, 460);
            this.VerticalDivider.TabIndex = 1;
            // 
            // DistanciaTotalTextBox
            // 
            this.DistanciaTotalTextBox.Location = new System.Drawing.Point(131, 259);
            this.DistanciaTotalTextBox.Name = "DistanciaTotalTextBox";
            this.DistanciaTotalTextBox.ReadOnly = true;
            this.DistanciaTotalTextBox.Size = new System.Drawing.Size(83, 26);
            this.DistanciaTotalTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Locación de origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Locación de destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Distancia total";
            // 
            // OrigenComboBox
            // 
            this.OrigenComboBox.FormattingEnabled = true;
            this.OrigenComboBox.Location = new System.Drawing.Point(12, 30);
            this.OrigenComboBox.Name = "OrigenComboBox";
            this.OrigenComboBox.Size = new System.Drawing.Size(202, 26);
            this.OrigenComboBox.TabIndex = 1;
            // 
            // DestinoComboBox
            // 
            this.DestinoComboBox.FormattingEnabled = true;
            this.DestinoComboBox.Location = new System.Drawing.Point(12, 80);
            this.DestinoComboBox.Name = "DestinoComboBox";
            this.DestinoComboBox.Size = new System.Drawing.Size(202, 26);
            this.DestinoComboBox.TabIndex = 9;
            // 
            // MapaPictureBox
            // 
            this.MapaPictureBox.BackgroundImage = global::ViewLayer.Properties.Resources.Mapa;
            this.MapaPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapaPictureBox.Image = global::ViewLayer.Properties.Resources.Mapa;
            this.MapaPictureBox.InitialImage = null;
            this.MapaPictureBox.Location = new System.Drawing.Point(220, 12);
            this.MapaPictureBox.Name = "MapaPictureBox";
            this.MapaPictureBox.Size = new System.Drawing.Size(416, 416);
            this.MapaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MapaPictureBox.TabIndex = 11;
            this.MapaPictureBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Fecha de mudanza";
            // 
            // FechaMudanzaDateTimePicker
            // 
            this.FechaMudanzaDateTimePicker.CustomFormat = "ddd dd-MMMM-yyyy";
            this.FechaMudanzaDateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.FechaMudanzaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaMudanzaDateTimePicker.Location = new System.Drawing.Point(15, 342);
            this.FechaMudanzaDateTimePicker.Name = "FechaMudanzaDateTimePicker";
            this.FechaMudanzaDateTimePicker.Size = new System.Drawing.Size(202, 26);
            this.FechaMudanzaDateTimePicker.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Camiones disponibles";
            // 
            // CamionComboBox
            // 
            this.CamionComboBox.FormattingEnabled = true;
            this.CamionComboBox.Location = new System.Drawing.Point(12, 402);
            this.CamionComboBox.Name = "CamionComboBox";
            this.CamionComboBox.Size = new System.Drawing.Size(202, 26);
            this.CamionComboBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(642, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(2, 460);
            this.label7.TabIndex = 17;
            // 
            // BuscarClienteButton
            // 
            this.BuscarClienteButton.AutoSize = true;
            this.BuscarClienteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BuscarClienteButton.Location = new System.Drawing.Point(650, 12);
            this.BuscarClienteButton.Name = "BuscarClienteButton";
            this.BuscarClienteButton.Size = new System.Drawing.Size(104, 28);
            this.BuscarClienteButton.TabIndex = 18;
            this.BuscarClienteButton.Text = "Buscar cliente";
            this.BuscarClienteButton.UseVisualStyleBackColor = true;
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(650, 64);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.ReadOnly = true;
            this.IdTextBox.Size = new System.Drawing.Size(112, 26);
            this.IdTextBox.TabIndex = 19;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(650, 114);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(239, 26);
            this.NombreTextBox.TabIndex = 20;
            // 
            // IdentificadorTextBox
            // 
            this.IdentificadorTextBox.Location = new System.Drawing.Point(768, 64);
            this.IdentificadorTextBox.Name = "IdentificadorTextBox";
            this.IdentificadorTextBox.Size = new System.Drawing.Size(121, 26);
            this.IdentificadorTextBox.TabIndex = 21;
            // 
            // PersonaFisicaRadioButton
            // 
            this.PersonaFisicaRadioButton.AutoSize = true;
            this.PersonaFisicaRadioButton.Location = new System.Drawing.Point(653, 191);
            this.PersonaFisicaRadioButton.Name = "PersonaFisicaRadioButton";
            this.PersonaFisicaRadioButton.Size = new System.Drawing.Size(110, 22);
            this.PersonaFisicaRadioButton.TabIndex = 22;
            this.PersonaFisicaRadioButton.TabStop = true;
            this.PersonaFisicaRadioButton.Text = "Persona física";
            this.PersonaFisicaRadioButton.UseVisualStyleBackColor = true;
            // 
            // PersonaJuridicaRadioButton
            // 
            this.PersonaJuridicaRadioButton.AutoSize = true;
            this.PersonaJuridicaRadioButton.Location = new System.Drawing.Point(768, 191);
            this.PersonaJuridicaRadioButton.Name = "PersonaJuridicaRadioButton";
            this.PersonaJuridicaRadioButton.Size = new System.Drawing.Size(124, 22);
            this.PersonaJuridicaRadioButton.TabIndex = 23;
            this.PersonaJuridicaRadioButton.TabStop = true;
            this.PersonaJuridicaRadioButton.Text = "Persona jurídica";
            this.PersonaJuridicaRadioButton.UseVisualStyleBackColor = true;
            // 
            // NivelTarifarioComboBox
            // 
            this.NivelTarifarioComboBox.FormattingEnabled = true;
            this.NivelTarifarioComboBox.Location = new System.Drawing.Point(768, 219);
            this.NivelTarifarioComboBox.Name = "NivelTarifarioComboBox";
            this.NivelTarifarioComboBox.Size = new System.Drawing.Size(121, 26);
            this.NivelTarifarioComboBox.TabIndex = 24;
            // 
            // DireccionTextBox
            // 
            this.DireccionTextBox.Location = new System.Drawing.Point(650, 292);
            this.DireccionTextBox.Name = "DireccionTextBox";
            this.DireccionTextBox.Size = new System.Drawing.Size(239, 26);
            this.DireccionTextBox.TabIndex = 25;
            // 
            // TelefonoTextBox
            // 
            this.TelefonoTextBox.Location = new System.Drawing.Point(768, 324);
            this.TelefonoTextBox.Name = "TelefonoTextBox";
            this.TelefonoTextBox.Size = new System.Drawing.Size(121, 26);
            this.TelefonoTextBox.TabIndex = 26;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(698, 356);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(191, 26);
            this.EmailTextBox.TabIndex = 27;
            // 
            // GuardarClienteButton
            // 
            this.GuardarClienteButton.AutoSize = true;
            this.GuardarClienteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GuardarClienteButton.Location = new System.Drawing.Point(776, 400);
            this.GuardarClienteButton.Name = "GuardarClienteButton";
            this.GuardarClienteButton.Size = new System.Drawing.Size(113, 28);
            this.GuardarClienteButton.TabIndex = 28;
            this.GuardarClienteButton.Text = "Guardar cliente";
            this.GuardarClienteButton.UseVisualStyleBackColor = true;
            // 
            // CrearClienteButton
            // 
            this.CrearClienteButton.AutoSize = true;
            this.CrearClienteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CrearClienteButton.Location = new System.Drawing.Point(792, 12);
            this.CrearClienteButton.Name = "CrearClienteButton";
            this.CrearClienteButton.Size = new System.Drawing.Size(97, 28);
            this.CrearClienteButton.TabIndex = 29;
            this.CrearClienteButton.Text = "Crear cliente";
            this.CrearClienteButton.UseVisualStyleBackColor = true;
            // 
            // CotizacionTextBox
            // 
            this.CotizacionTextBox.Enabled = false;
            this.CotizacionTextBox.Location = new System.Drawing.Point(768, 443);
            this.CotizacionTextBox.Name = "CotizacionTextBox";
            this.CotizacionTextBox.Size = new System.Drawing.Size(121, 26);
            this.CotizacionTextBox.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(647, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 18);
            this.label8.TabIndex = 32;
            this.label8.Text = "Condición fiscal";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(650, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 18);
            this.label9.TabIndex = 33;
            this.label9.Text = "Id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(765, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 18);
            this.label10.TabIndex = 34;
            this.label10.Text = "DNI/CUIT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(650, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(210, 18);
            this.label11.TabIndex = 35;
            this.label11.Text = "Nombre y apellido / Razón social";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(650, 222);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 18);
            this.label12.TabIndex = 36;
            this.label12.Text = "Nivel tarifario";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(650, 271);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 18);
            this.label13.TabIndex = 37;
            this.label13.Text = "Dirección";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(650, 327);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 18);
            this.label14.TabIndex = 38;
            this.label14.Text = "Teléfono";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(650, 359);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 18);
            this.label15.TabIndex = 39;
            this.label15.Text = "Email";
            // 
            // CondicionFiscalComboBox
            // 
            this.CondicionFiscalComboBox.FormattingEnabled = true;
            this.CondicionFiscalComboBox.Location = new System.Drawing.Point(768, 159);
            this.CondicionFiscalComboBox.Name = "CondicionFiscalComboBox";
            this.CondicionFiscalComboBox.Size = new System.Drawing.Size(121, 26);
            this.CondicionFiscalComboBox.TabIndex = 40;
            // 
            // CotizarButton
            // 
            this.CotizarButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CotizarButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CotizarButton.Depth = 0;
            this.CotizarButton.HighEmphasis = true;
            this.CotizarButton.Icon = null;
            this.CotizarButton.Location = new System.Drawing.Point(653, 437);
            this.CotizarButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CotizarButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.CotizarButton.Name = "CotizarButton";
            this.CotizarButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CotizarButton.Size = new System.Drawing.Size(82, 36);
            this.CotizarButton.TabIndex = 41;
            this.CotizarButton.Text = "Cotizar";
            this.CotizarButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CotizarButton.UseAccentColor = false;
            this.CotizarButton.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(903, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 18);
            this.label16.TabIndex = 42;
            this.label16.Text = "Dirección de descarga";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(903, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 18);
            this.label17.TabIndex = 43;
            this.label17.Text = "Dirección de carga";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(903, 122);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(221, 18);
            this.label18.TabIndex = 44;
            this.label18.Text = "Observaciones (horario/embalaje)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(903, 211);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 18);
            this.label19.TabIndex = 45;
            this.label19.Text = "Ítem";
            // 
            // LugarCargaTextBox
            // 
            this.LugarCargaTextBox.Location = new System.Drawing.Point(906, 30);
            this.LugarCargaTextBox.Name = "LugarCargaTextBox";
            this.LugarCargaTextBox.Size = new System.Drawing.Size(239, 26);
            this.LugarCargaTextBox.TabIndex = 46;
            // 
            // LugarDescargaTextBox
            // 
            this.LugarDescargaTextBox.Location = new System.Drawing.Point(906, 85);
            this.LugarDescargaTextBox.Name = "LugarDescargaTextBox";
            this.LugarDescargaTextBox.Size = new System.Drawing.Size(239, 26);
            this.LugarDescargaTextBox.TabIndex = 47;
            // 
            // ObservacionesTextBox
            // 
            this.ObservacionesTextBox.Location = new System.Drawing.Point(906, 143);
            this.ObservacionesTextBox.Multiline = true;
            this.ObservacionesTextBox.Name = "ObservacionesTextBox";
            this.ObservacionesTextBox.Size = new System.Drawing.Size(239, 65);
            this.ObservacionesTextBox.TabIndex = 48;
            // 
            // ItemTextBox
            // 
            this.ItemTextBox.Location = new System.Drawing.Point(906, 232);
            this.ItemTextBox.Name = "ItemTextBox";
            this.ItemTextBox.Size = new System.Drawing.Size(239, 26);
            this.ItemTextBox.TabIndex = 49;
            // 
            // AgregarItemButton
            // 
            this.AgregarItemButton.AutoSize = true;
            this.AgregarItemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AgregarItemButton.Location = new System.Drawing.Point(1026, 264);
            this.AgregarItemButton.Name = "AgregarItemButton";
            this.AgregarItemButton.Size = new System.Drawing.Size(97, 28);
            this.AgregarItemButton.TabIndex = 50;
            this.AgregarItemButton.Text = "Agregar ítem";
            this.AgregarItemButton.UseVisualStyleBackColor = true;
            // 
            // CancelarOperacionButton
            // 
            this.CancelarOperacionButton.AutoSize = true;
            this.CancelarOperacionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelarOperacionButton.Location = new System.Drawing.Point(928, 441);
            this.CancelarOperacionButton.Name = "CancelarOperacionButton";
            this.CancelarOperacionButton.Size = new System.Drawing.Size(71, 28);
            this.CancelarOperacionButton.TabIndex = 52;
            this.CancelarOperacionButton.Text = "Cancelar";
            this.CancelarOperacionButton.UseVisualStyleBackColor = true;
            // 
            // GenerarOrdenButton
            // 
            this.GenerarOrdenButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GenerarOrdenButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GenerarOrdenButton.Depth = 0;
            this.GenerarOrdenButton.HighEmphasis = true;
            this.GenerarOrdenButton.Icon = null;
            this.GenerarOrdenButton.Location = new System.Drawing.Point(1006, 437);
            this.GenerarOrdenButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GenerarOrdenButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.GenerarOrdenButton.Name = "GenerarOrdenButton";
            this.GenerarOrdenButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GenerarOrdenButton.Size = new System.Drawing.Size(139, 36);
            this.GenerarOrdenButton.TabIndex = 53;
            this.GenerarOrdenButton.Text = "Generar orden";
            this.GenerarOrdenButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GenerarOrdenButton.UseAccentColor = true;
            this.GenerarOrdenButton.UseVisualStyleBackColor = true;
            // 
            // QuitarItemButton
            // 
            this.QuitarItemButton.AutoSize = true;
            this.QuitarItemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.QuitarItemButton.Location = new System.Drawing.Point(906, 264);
            this.QuitarItemButton.Name = "QuitarItemButton";
            this.QuitarItemButton.Size = new System.Drawing.Size(88, 28);
            this.QuitarItemButton.TabIndex = 54;
            this.QuitarItemButton.Text = "Quitar ítem";
            this.QuitarItemButton.UseVisualStyleBackColor = true;
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.HorizontalScrollbar = true;
            this.ItemsListBox.ItemHeight = 18;
            this.ItemsListBox.Location = new System.Drawing.Point(906, 298);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(239, 130);
            this.ItemsListBox.TabIndex = 311;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 18);
            this.label4.TabIndex = 313;
            this.label4.Text = "Descarga-Central";
            // 
            // DescargaCentralTextBox
            // 
            this.DescargaCentralTextBox.Location = new System.Drawing.Point(131, 227);
            this.DescargaCentralTextBox.Name = "DescargaCentralTextBox";
            this.DescargaCentralTextBox.ReadOnly = true;
            this.DescargaCentralTextBox.Size = new System.Drawing.Size(83, 26);
            this.DescargaCentralTextBox.TabIndex = 312;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(12, 198);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(102, 18);
            this.label20.TabIndex = 315;
            this.label20.Text = "Carga-Descarga";
            // 
            // CargaDescargaTextBox
            // 
            this.CargaDescargaTextBox.Location = new System.Drawing.Point(131, 195);
            this.CargaDescargaTextBox.Name = "CargaDescargaTextBox";
            this.CargaDescargaTextBox.ReadOnly = true;
            this.CargaDescargaTextBox.Size = new System.Drawing.Size(83, 26);
            this.CargaDescargaTextBox.TabIndex = 314;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(12, 167);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 18);
            this.label21.TabIndex = 317;
            this.label21.Text = "Central-Carga";
            // 
            // CentralCargaTextBox
            // 
            this.CentralCargaTextBox.Location = new System.Drawing.Point(131, 163);
            this.CentralCargaTextBox.Name = "CentralCargaTextBox";
            this.CentralCargaTextBox.ReadOnly = true;
            this.CentralCargaTextBox.Size = new System.Drawing.Size(83, 26);
            this.CentralCargaTextBox.TabIndex = 316;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(12, 129);
            this.materialLabel1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(91, 19);
            this.materialLabel1.TabIndex = 318;
            this.materialLabel1.Text = "DISTANCIAS";
            // 
            // MonitorLabel
            // 
            this.MonitorLabel.AutoSize = true;
            this.MonitorLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonitorLabel.Location = new System.Drawing.Point(8, 448);
            this.MonitorLabel.Name = "MonitorLabel";
            this.MonitorLabel.Size = new System.Drawing.Size(83, 21);
            this.MonitorLabel.TabIndex = 320;
            this.MonitorLabel.Text = "Monitor...";
            // 
            // CapturadorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 484);
            this.Controls.Add(this.MonitorLabel);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.CentralCargaTextBox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.CargaDescargaTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DescargaCentralTextBox);
            this.Controls.Add(this.ItemsListBox);
            this.Controls.Add(this.QuitarItemButton);
            this.Controls.Add(this.GenerarOrdenButton);
            this.Controls.Add(this.CancelarOperacionButton);
            this.Controls.Add(this.AgregarItemButton);
            this.Controls.Add(this.ItemTextBox);
            this.Controls.Add(this.ObservacionesTextBox);
            this.Controls.Add(this.LugarDescargaTextBox);
            this.Controls.Add(this.LugarCargaTextBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.CotizarButton);
            this.Controls.Add(this.CondicionFiscalComboBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CotizacionTextBox);
            this.Controls.Add(this.CrearClienteButton);
            this.Controls.Add(this.GuardarClienteButton);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.TelefonoTextBox);
            this.Controls.Add(this.DireccionTextBox);
            this.Controls.Add(this.NivelTarifarioComboBox);
            this.Controls.Add(this.PersonaJuridicaRadioButton);
            this.Controls.Add(this.PersonaFisicaRadioButton);
            this.Controls.Add(this.IdentificadorTextBox);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.BuscarClienteButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CamionComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FechaMudanzaDateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MapaPictureBox);
            this.Controls.Add(this.DestinoComboBox);
            this.Controls.Add(this.OrigenComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DistanciaTotalTextBox);
            this.Controls.Add(this.VerticalDivider);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CapturadorForm";
            this.Text = "CAPTURA";
            ((System.ComponentModel.ISupportInitialize)(this.MapaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label VerticalDivider;
        private System.Windows.Forms.TextBox DistanciaTotalTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox OrigenComboBox;
        private System.Windows.Forms.ComboBox DestinoComboBox;
        private System.Windows.Forms.PictureBox MapaPictureBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker FechaMudanzaDateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CamionComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BuscarClienteButton;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.TextBox IdentificadorTextBox;
        private System.Windows.Forms.RadioButton PersonaFisicaRadioButton;
        private System.Windows.Forms.RadioButton PersonaJuridicaRadioButton;
        private System.Windows.Forms.ComboBox NivelTarifarioComboBox;
        private System.Windows.Forms.TextBox DireccionTextBox;
        private System.Windows.Forms.TextBox TelefonoTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Button GuardarClienteButton;
        private System.Windows.Forms.Button CrearClienteButton;
        private System.Windows.Forms.TextBox CotizacionTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CondicionFiscalComboBox;
        private MaterialSkin2Framework.Controls.MaterialButton CotizarButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox LugarCargaTextBox;
        private System.Windows.Forms.TextBox LugarDescargaTextBox;
        private System.Windows.Forms.TextBox ObservacionesTextBox;
        private System.Windows.Forms.TextBox ItemTextBox;
        private System.Windows.Forms.Button AgregarItemButton;
        private System.Windows.Forms.Button CancelarOperacionButton;
        private MaterialSkin2Framework.Controls.MaterialButton GenerarOrdenButton;
        private System.Windows.Forms.Button QuitarItemButton;
        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DescargaCentralTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox CargaDescargaTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox CentralCargaTextBox;
        private MaterialSkin2Framework.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Label MonitorLabel;
    }
}