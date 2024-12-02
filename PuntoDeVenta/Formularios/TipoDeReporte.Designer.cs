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
            this.btnMes.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMes.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMes.Location = new System.Drawing.Point(372, 177);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(144, 43);
            this.btnMes.TabIndex = 0;
            this.btnMes.Text = "Venta por Mes";
            this.btnMes.UseVisualStyleBackColor = false;
            this.btnMes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVentaE
            // 
            this.btnVentaE.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnVentaE.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentaE.Location = new System.Drawing.Point(449, 104);
            this.btnVentaE.Name = "btnVentaE";
            this.btnVentaE.Size = new System.Drawing.Size(243, 45);
            this.btnVentaE.TabIndex = 1;
            this.btnVentaE.Text = "Venta por Empleado";
            this.btnVentaE.UseVisualStyleBackColor = false;
            this.btnVentaE.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTrimestral
            // 
            this.btnTrimestral.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTrimestral.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrimestral.Location = new System.Drawing.Point(250, 104);
            this.btnTrimestral.Name = "btnTrimestral";
            this.btnTrimestral.Size = new System.Drawing.Size(183, 41);
            this.btnTrimestral.TabIndex = 2;
            this.btnTrimestral.Text = "Venta Trimestral";
            this.btnTrimestral.UseVisualStyleBackColor = false;
            this.btnTrimestral.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnRegreso
            // 
            this.btnRegreso.BackgroundImage = global::PuntoDeVenta.Properties.Resources.volverMenu;
            this.btnRegreso.Location = new System.Drawing.Point(12, 3);
            this.btnRegreso.Name = "btnRegreso";
            this.btnRegreso.Size = new System.Drawing.Size(40, 32);
            this.btnRegreso.TabIndex = 3;
            this.btnRegreso.UseVisualStyleBackColor = true;
            this.btnRegreso.Click += new System.EventHandler(this.btnRegreso_Click);
            // 
            // TipoDeReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PuntoDeVenta.Properties.Resources.menuReportes;
            this.ClientSize = new System.Drawing.Size(704, 232);
            this.Controls.Add(this.btnRegreso);
            this.Controls.Add(this.btnTrimestral);
            this.Controls.Add(this.btnVentaE);
            this.Controls.Add(this.btnMes);
            this.Name = "TipoDeReporte";
            this.Text = "TipoDeReporte";
            this.Load += new System.EventHandler(this.TipoDeReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btnVentaE;
        private System.Windows.Forms.Button btnTrimestral;
        private System.Windows.Forms.Button btnRegreso;
    }
}