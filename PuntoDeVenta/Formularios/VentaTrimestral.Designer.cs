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
            this.dataGridVieWReporte = new System.Windows.Forms.DataGridView();
            this.Empledo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGraReporte = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnregreso = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVieWReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridVieWReporte
            // 
            this.dataGridVieWReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVieWReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empledo,
            this.Total,
            this.CantVentas});
            this.dataGridVieWReporte.Location = new System.Drawing.Point(23, 226);
            this.dataGridVieWReporte.Name = "dataGridVieWReporte";
            this.dataGridVieWReporte.RowHeadersWidth = 51;
            this.dataGridVieWReporte.RowTemplate.Height = 24;
            this.dataGridVieWReporte.Size = new System.Drawing.Size(753, 212);
            this.dataGridVieWReporte.TabIndex = 0;
            this.dataGridVieWReporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVieWReporte_CellContentClick);
            // 
            // Empledo
            // 
            this.Empledo.HeaderText = "Empleaddo";
            this.Empledo.MinimumWidth = 6;
            this.Empledo.Name = "Empledo";
            this.Empledo.Width = 125;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.Width = 125;
            // 
            // CantVentas
            // 
            this.CantVentas.HeaderText = "Caantidad de Ventas";
            this.CantVentas.MinimumWidth = 6;
            this.CantVentas.Name = "CantVentas";
            this.CantVentas.Width = 125;
            // 
            // btnGraReporte
            // 
            this.btnGraReporte.Location = new System.Drawing.Point(556, 48);
            this.btnGraReporte.Name = "btnGraReporte";
            this.btnGraReporte.Size = new System.Drawing.Size(111, 49);
            this.btnGraReporte.TabIndex = 1;
            this.btnGraReporte.Text = "Generar Reporte";
            this.btnGraReporte.UseVisualStyleBackColor = true;
            this.btnGraReporte.Click += new System.EventHandler(this.btnGraReporte_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(127, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(300, 22);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnregreso
            // 
            this.btnregreso.Location = new System.Drawing.Point(556, 126);
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
            // VentaTrimestral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnregreso);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnGraReporte);
            this.Controls.Add(this.dataGridVieWReporte);
            this.Name = "VentaTrimestral";
            this.Text = "VentaTrimestral";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVieWReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridVieWReporte;
        private System.Windows.Forms.Button btnGraReporte;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnregreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empledo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantVentas;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
    }
}