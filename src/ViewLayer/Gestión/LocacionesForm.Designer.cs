namespace ViewLayer
{
    partial class LocacionesForm
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
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NuevaLocacionButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LugarTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EliminadoCheckBox = new System.Windows.Forms.CheckBox();
            this.BloqueadoCheckBox = new System.Windows.Forms.CheckBox();
            this.XNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.YNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GuardarModificacionesButton = new System.Windows.Forms.Button();
            this.LocacionesDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocacionesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Enabled = false;
            this.IdTextBox.Location = new System.Drawing.Point(610, 40);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(163, 26);
            this.IdTextBox.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 18);
            this.label5.TabIndex = 28;
            this.label5.Text = "Id";
            // 
            // NuevaLocacionButton
            // 
            this.NuevaLocacionButton.AutoSize = true;
            this.NuevaLocacionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NuevaLocacionButton.Location = new System.Drawing.Point(492, 234);
            this.NuevaLocacionButton.Name = "NuevaLocacionButton";
            this.NuevaLocacionButton.Size = new System.Drawing.Size(112, 28);
            this.NuevaLocacionButton.TabIndex = 26;
            this.NuevaLocacionButton.Text = "Nueva locación";
            this.NuevaLocacionButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "X";
            // 
            // LugarTextBox
            // 
            this.LugarTextBox.Location = new System.Drawing.Point(498, 104);
            this.LugarTextBox.Name = "LugarTextBox";
            this.LugarTextBox.Size = new System.Drawing.Size(276, 26);
            this.LugarTextBox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Lugar";
            // 
            // EliminadoCheckBox
            // 
            this.EliminadoCheckBox.AutoSize = true;
            this.EliminadoCheckBox.Location = new System.Drawing.Point(611, 12);
            this.EliminadoCheckBox.Name = "EliminadoCheckBox";
            this.EliminadoCheckBox.Size = new System.Drawing.Size(89, 22);
            this.EliminadoCheckBox.TabIndex = 17;
            this.EliminadoCheckBox.Text = "Eliminado";
            this.EliminadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // BloqueadoCheckBox
            // 
            this.BloqueadoCheckBox.AutoSize = true;
            this.BloqueadoCheckBox.Location = new System.Drawing.Point(498, 12);
            this.BloqueadoCheckBox.Name = "BloqueadoCheckBox";
            this.BloqueadoCheckBox.Size = new System.Drawing.Size(94, 22);
            this.BloqueadoCheckBox.TabIndex = 16;
            this.BloqueadoCheckBox.Text = "Bloqueado";
            this.BloqueadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // XNumericUpDown
            // 
            this.XNumericUpDown.Location = new System.Drawing.Point(610, 136);
            this.XNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.XNumericUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.XNumericUpDown.Name = "XNumericUpDown";
            this.XNumericUpDown.Size = new System.Drawing.Size(163, 26);
            this.XNumericUpDown.TabIndex = 30;
            // 
            // YNumericUpDown
            // 
            this.YNumericUpDown.Location = new System.Drawing.Point(611, 168);
            this.YNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.YNumericUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.YNumericUpDown.Name = "YNumericUpDown";
            this.YNumericUpDown.Size = new System.Drawing.Size(163, 26);
            this.YNumericUpDown.TabIndex = 31;
            // 
            // GuardarModificacionesButton
            // 
            this.GuardarModificacionesButton.AutoSize = true;
            this.GuardarModificacionesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GuardarModificacionesButton.Enabled = false;
            this.GuardarModificacionesButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarModificacionesButton.ForeColor = System.Drawing.Color.DarkRed;
            this.GuardarModificacionesButton.Location = new System.Drawing.Point(610, 234);
            this.GuardarModificacionesButton.Name = "GuardarModificacionesButton";
            this.GuardarModificacionesButton.Size = new System.Drawing.Size(164, 28);
            this.GuardarModificacionesButton.TabIndex = 56;
            this.GuardarModificacionesButton.Text = "Guardar modificaciones";
            this.GuardarModificacionesButton.UseVisualStyleBackColor = true;
            // 
            // LocacionesDataGridView
            // 
            this.LocacionesDataGridView.AllowUserToAddRows = false;
            this.LocacionesDataGridView.AllowUserToDeleteRows = false;
            this.LocacionesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.LocacionesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LocacionesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.LocacionesDataGridView.MultiSelect = false;
            this.LocacionesDataGridView.Name = "LocacionesDataGridView";
            this.LocacionesDataGridView.ReadOnly = true;
            this.LocacionesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LocacionesDataGridView.Size = new System.Drawing.Size(480, 182);
            this.LocacionesDataGridView.TabIndex = 55;
            // 
            // LocacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 277);
            this.Controls.Add(this.GuardarModificacionesButton);
            this.Controls.Add(this.LocacionesDataGridView);
            this.Controls.Add(this.YNumericUpDown);
            this.Controls.Add(this.XNumericUpDown);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NuevaLocacionButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LugarTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EliminadoCheckBox);
            this.Controls.Add(this.BloqueadoCheckBox);
            this.Name = "LocacionesForm";
            this.Text = "Locaciones";
            ((System.ComponentModel.ISupportInitialize)(this.XNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocacionesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button NuevaLocacionButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LugarTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox EliminadoCheckBox;
        private System.Windows.Forms.CheckBox BloqueadoCheckBox;
        private System.Windows.Forms.NumericUpDown XNumericUpDown;
        private System.Windows.Forms.NumericUpDown YNumericUpDown;
        private System.Windows.Forms.Button GuardarModificacionesButton;
        private System.Windows.Forms.DataGridView LocacionesDataGridView;
    }
}