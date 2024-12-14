namespace ViewLayer
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.TitularLabel = new System.Windows.Forms.Label();
            this.ContenedorPanel = new System.Windows.Forms.Panel();
            this.ProgresoPanel = new System.Windows.Forms.Panel();
            this.Temporizador = new System.Windows.Forms.Timer(this.components);
            this.ImagenPictureBox = new System.Windows.Forms.PictureBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ContenedorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitularLabel
            // 
            this.TitularLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitularLabel.ForeColor = System.Drawing.Color.White;
            this.TitularLabel.Location = new System.Drawing.Point(0, 180);
            this.TitularLabel.Name = "TitularLabel";
            this.TitularLabel.Size = new System.Drawing.Size(575, 25);
            this.TitularLabel.TabIndex = 0;
            this.TitularLabel.Text = "La Mudadora";
            this.TitularLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContenedorPanel
            // 
            this.ContenedorPanel.Controls.Add(this.ProgresoPanel);
            this.ContenedorPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ContenedorPanel.Location = new System.Drawing.Point(0, 330);
            this.ContenedorPanel.Name = "ContenedorPanel";
            this.ContenedorPanel.Size = new System.Drawing.Size(575, 20);
            this.ContenedorPanel.TabIndex = 1;
            // 
            // ProgresoPanel
            // 
            this.ProgresoPanel.BackColor = System.Drawing.Color.White;
            this.ProgresoPanel.Location = new System.Drawing.Point(0, 0);
            this.ProgresoPanel.Name = "ProgresoPanel";
            this.ProgresoPanel.Size = new System.Drawing.Size(35, 20);
            this.ProgresoPanel.TabIndex = 2;
            // 
            // Temporizador
            // 
            this.Temporizador.Enabled = true;
            this.Temporizador.Interval = 20;
            // 
            // ImagenPictureBox
            // 
            this.ImagenPictureBox.Image = global::ViewLayer.Properties.Resources.icons8_in_transit_100;
            this.ImagenPictureBox.Location = new System.Drawing.Point(246, 70);
            this.ImagenPictureBox.Name = "ImagenPictureBox";
            this.ImagenPictureBox.Size = new System.Drawing.Size(100, 100);
            this.ImagenPictureBox.TabIndex = 2;
            this.ImagenPictureBox.TabStop = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(0, 222);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(575, 50);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Poniendo en funcionamientos los servicios del sistema...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(575, 350);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ImagenPictureBox);
            this.Controls.Add(this.ContenedorPanel);
            this.Controls.Add(this.TitularLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splash screen";
            this.ContenedorPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitularLabel;
        private System.Windows.Forms.Panel ContenedorPanel;
        private System.Windows.Forms.Panel ProgresoPanel;
        private System.Windows.Forms.PictureBox ImagenPictureBox;
        private System.Windows.Forms.Timer Temporizador;
        private System.Windows.Forms.Label StatusLabel;
    }
}
