namespace PuntoDeVenta.Formularios
{
    partial class TipoDeReporte
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
            this.btnMes = new System.Windows.Forms.Button();
            this.btnVentaE = new System.Windows.Forms.Button();
            this.btnTrimestral = new System.Windows.Forms.Button();
            this.btnRegreso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMes
            // 
            this.btnMes.Location = new System.Drawing.Point(114, 125);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(144, 92);
            this.btnMes.TabIndex = 0;
            this.btnMes.Text = "Venta por Mes";
            this.btnMes.UseVisualStyleBackColor = true;
            this.btnMes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVentaE
            // 
            this.btnVentaE.Location = new System.Drawing.Point(526, 125);
            this.btnVentaE.Name = "btnVentaE";
            this.btnVentaE.Size = new System.Drawing.Size(138, 95);
            this.btnVentaE.TabIndex = 1;
            this.btnVentaE.Text = "Venta por Empleado";
            this.btnVentaE.UseVisualStyleBackColor = true;
            this.btnVentaE.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTrimestral
            // 
            this.btnTrimestral.Location = new System.Drawing.Point(323, 248);
            this.btnTrimestral.Name = "btnTrimestral";
            this.btnTrimestral.Size = new System.Drawing.Size(134, 91);
            this.btnTrimestral.TabIndex = 2;
            this.btnTrimestral.Text = "Venta Trimestral";
            this.btnTrimestral.UseVisualStyleBackColor = true;
            this.btnTrimestral.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnRegreso
            // 
            this.btnRegreso.Location = new System.Drawing.Point(114, 370);
            this.btnRegreso.Name = "btnRegreso";
            this.btnRegreso.Size = new System.Drawing.Size(94, 36);
            this.btnRegreso.TabIndex = 3;
            this.btnRegreso.Text = "Regresar";
            this.btnRegreso.UseVisualStyleBackColor = true;
            this.btnRegreso.Click += new System.EventHandler(this.btnRegreso_Click);
            // 
            // TipoDeReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegreso);
            this.Controls.Add(this.btnTrimestral);
            this.Controls.Add(this.btnVentaE);
            this.Controls.Add(this.btnMes);
            this.Name = "TipoDeReporte";
            this.Text = "TipoDeReporte";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btnVentaE;
        private System.Windows.Forms.Button btnTrimestral;
        private System.Windows.Forms.Button btnRegreso;
    }
}