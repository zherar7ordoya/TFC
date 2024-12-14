namespace ViewLayer
{
    partial class AyudaForm
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
            this.Navegador = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // Navegador
            // 
            this.Navegador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Navegador.Location = new System.Drawing.Point(3, 64);
            this.Navegador.Margin = new System.Windows.Forms.Padding(2);
            this.Navegador.MinimumSize = new System.Drawing.Size(15, 14);
            this.Navegador.Name = "Navegador";
            this.Navegador.Size = new System.Drawing.Size(843, 479);
            this.Navegador.TabIndex = 0;
            // 
            // AyudaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 545);
            this.Controls.Add(this.Navegador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AyudaForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ayuda";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser Navegador;
    }
}