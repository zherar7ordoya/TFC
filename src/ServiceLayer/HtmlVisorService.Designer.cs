namespace ServiceLayer
{
    partial class HtmlVisorService
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
            this.VisorWebBrowser = new System.Windows.Forms.WebBrowser();
            this.ImprimirButton = new System.Windows.Forms.Button();
            this.EmailearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VisorWebBrowser
            // 
            this.VisorWebBrowser.Dock = System.Windows.Forms.DockStyle.Top;
            this.VisorWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.VisorWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.VisorWebBrowser.Name = "VisorWebBrowser";
            this.VisorWebBrowser.Size = new System.Drawing.Size(1160, 465);
            this.VisorWebBrowser.TabIndex = 0;
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.AutoSize = true;
            this.ImprimirButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ImprimirButton.Location = new System.Drawing.Point(1044, 471);
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(104, 23);
            this.ImprimirButton.TabIndex = 1;
            this.ImprimirButton.Text = "Enviar a impresora";
            this.ImprimirButton.UseVisualStyleBackColor = true;
            // 
            // EmailearButton
            // 
            this.EmailearButton.AutoSize = true;
            this.EmailearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EmailearButton.Location = new System.Drawing.Point(952, 471);
            this.EmailearButton.Name = "EmailearButton";
            this.EmailearButton.Size = new System.Drawing.Size(86, 23);
            this.EmailearButton.TabIndex = 2;
            this.EmailearButton.Text = "Enviar a e-mail";
            this.EmailearButton.UseVisualStyleBackColor = true;
            // 
            // HtmlVisorService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 506);
            this.Controls.Add(this.EmailearButton);
            this.Controls.Add(this.ImprimirButton);
            this.Controls.Add(this.VisorWebBrowser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HtmlVisorService";
            this.Text = "Documento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser VisorWebBrowser;
        private System.Windows.Forms.Button ImprimirButton;
        private System.Windows.Forms.Button EmailearButton;
    }
}