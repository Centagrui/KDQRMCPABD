namespace PuntoDeVenta.Formularios
{
    partial class VentaTrimestral
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
            this.dataGridViewReporte = new System.Windows.Forms.DataGridView();
            this.btnGraReporte = new System.Windows.Forms.Button();
            this.btnregreso = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.comboBoxAnio = new System.Windows.Forms.ComboBox();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReporte
            // 
            this.dataGridViewReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Venta});
            this.dataGridViewReporte.Location = new System.Drawing.Point(23, 226);
            this.dataGridViewReporte.Name = "dataGridViewReporte";
            this.dataGridViewReporte.RowHeadersWidth = 51;
            this.dataGridViewReporte.RowTemplate.Height = 24;
            this.dataGridViewReporte.Size = new System.Drawing.Size(847, 212);
            this.dataGridViewReporte.TabIndex = 0;
            this.dataGridViewReporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVieWReporte_CellContentClick);
            // 
            // btnGraReporte
            // 
            this.btnGraReporte.Location = new System.Drawing.Point(620, 35);
            this.btnGraReporte.Name = "btnGraReporte";
            this.btnGraReporte.Size = new System.Drawing.Size(111, 49);
            this.btnGraReporte.TabIndex = 1;
            this.btnGraReporte.Text = "Generar Reporte";
            this.btnGraReporte.UseVisualStyleBackColor = true;
            this.btnGraReporte.Click += new System.EventHandler(this.btnGraReporte_Click);
            // 
            // btnregreso
            // 
            this.btnregreso.Location = new System.Drawing.Point(620, 136);
            this.btnregreso.Name = "btnregreso";
            this.btnregreso.Size = new System.Drawing.Size(118, 51);
            this.btnregreso.TabIndex = 3;
            this.btnregreso.Text = "Regresar";
            this.btnregreso.UseVisualStyleBackColor = true;
            this.btnregreso.Click += new System.EventHandler(this.btnregreso_Click);
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // comboBoxAnio
            // 
            this.comboBoxAnio.FormattingEnabled = true;
            this.comboBoxAnio.Location = new System.Drawing.Point(102, 48);
            this.comboBoxAnio.Name = "comboBoxAnio";
            this.comboBoxAnio.Size = new System.Drawing.Size(218, 24);
            this.comboBoxAnio.TabIndex = 4;
            this.comboBoxAnio.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.Width = 125;
            // 
            // Venta
            // 
            this.Venta.HeaderText = "Venta";
            this.Venta.MinimumWidth = 6;
            this.Venta.Name = "Venta";
            this.Venta.Width = 125;
            // 
            // VentaTrimestral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 450);
            this.Controls.Add(this.comboBoxAnio);
            this.Controls.Add(this.btnregreso);
            this.Controls.Add(this.btnGraReporte);
            this.Controls.Add(this.dataGridViewReporte);
            this.Name = "VentaTrimestral";
            this.Text = "VentaTrimestral";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReporte;
        private System.Windows.Forms.Button btnGraReporte;
        private System.Windows.Forms.Button btnregreso;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.ComboBox comboBoxAnio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venta;
    }
}