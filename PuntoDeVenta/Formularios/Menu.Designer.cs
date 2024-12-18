﻿namespace PuntoDeVenta
{
    partial class Menu
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
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVenta
            // 
            this.btnVenta.BackgroundImage = global::PuntoDeVenta.Properties.Resources.venta;
            this.btnVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.Location = new System.Drawing.Point(104, 213);
            this.btnVenta.Margin = new System.Windows.Forms.Padding(4);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(97, 87);
            this.btnVenta.TabIndex = 0;
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackgroundImage = global::PuntoDeVenta.Properties.Resources.empleado;
            this.btnEmpleados.Location = new System.Drawing.Point(274, 308);
            this.btnEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(86, 95);
            this.btnEmpleados.TabIndex = 1;
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackgroundImage = global::PuntoDeVenta.Properties.Resources.productos;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.Location = new System.Drawing.Point(228, 213);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(86, 87);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackgroundImage = global::PuntoDeVenta.Properties.Resources.cliente;
            this.btnClientes.Location = new System.Drawing.Point(183, 308);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(83, 95);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Peru;
            this.button1.BackgroundImage = global::PuntoDeVenta.Properties.Resources.atras;
            this.button1.Location = new System.Drawing.Point(243, 425);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 49);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.BackgroundImage = global::PuntoDeVenta.Properties.Resources.ReporteVen__1_;
            this.btnGenerarReporte.Location = new System.Drawing.Point(334, 218);
            this.btnGenerarReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(89, 82);
            this.btnGenerarReporte.TabIndex = 5;
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PuntoDeVenta.Properties.Resources.imagen3;
            this.ClientSize = new System.Drawing.Size(506, 486);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnVenta);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGenerarReporte;
    }
}