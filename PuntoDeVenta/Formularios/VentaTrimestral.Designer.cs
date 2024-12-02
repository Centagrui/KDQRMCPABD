namespace PuntoDeVenta.Formularios
{
    partial class VentaTrimestralForm
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
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trimestre_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trimestre_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trimestre_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trimestre_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnregreso = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Trimestre_1,
            this.Trimestre_2,
            this.Trimestre_3,
            this.Trimestre_4});
            this.dgvReporte.Location = new System.Drawing.Point(82, 226);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.RowTemplate.Height = 24;
            this.dgvReporte.Size = new System.Drawing.Size(657, 212);
            this.dgvReporte.TabIndex = 0;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.Width = 125;
            // 
            // Trimestre_1
            // 
            this.Trimestre_1.HeaderText = "Trimestre_1";
            this.Trimestre_1.MinimumWidth = 6;
            this.Trimestre_1.Name = "Trimestre_1";
            this.Trimestre_1.Width = 125;
            // 
            // Trimestre_2
            // 
            this.Trimestre_2.HeaderText = "Trimestre_2";
            this.Trimestre_2.MinimumWidth = 6;
            this.Trimestre_2.Name = "Trimestre_2";
            this.Trimestre_2.Width = 125;
            // 
            // Trimestre_3
            // 
            this.Trimestre_3.HeaderText = "Trimestre_3";
            this.Trimestre_3.MinimumWidth = 6;
            this.Trimestre_3.Name = "Trimestre_3";
            this.Trimestre_3.Width = 125;
            // 
            // Trimestre_4
            // 
            this.Trimestre_4.HeaderText = "Trimestre_4";
            this.Trimestre_4.MinimumWidth = 6;
            this.Trimestre_4.Name = "Trimestre_4";
            this.Trimestre_4.Width = 125;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.BackColor = System.Drawing.Color.BurlyWood;
            this.btnGenerarReporte.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReporte.Location = new System.Drawing.Point(344, 114);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(222, 39);
            this.btnGenerarReporte.TabIndex = 1;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // btnregreso
            // 
            this.btnregreso.BackgroundImage = global::PuntoDeVenta.Properties.Resources.volverMenu;
            this.btnregreso.Location = new System.Drawing.Point(3, 2);
            this.btnregreso.Name = "btnregreso";
            this.btnregreso.Size = new System.Drawing.Size(38, 30);
            this.btnregreso.TabIndex = 3;
            this.btnregreso.UseVisualStyleBackColor = true;
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // VentaTrimestralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PuntoDeVenta.Properties.Resources.trimestre;
            this.ClientSize = new System.Drawing.Size(794, 450);
            this.Controls.Add(this.btnregreso);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.dgvReporte);
            this.Name = "VentaTrimestralForm";
            this.Text = "VentaTrimestral";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnregreso;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trimestre_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trimestre_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trimestre_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trimestre_4;
    }
}