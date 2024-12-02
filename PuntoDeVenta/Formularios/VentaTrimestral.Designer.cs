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
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trimestre_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trimestre_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trimestre_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trimestre_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReporte
            // 
            this.dataGridViewReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Trimestre_1,
            this.Trimestre_2,
            this.Trimestre_3,
            this.Trimestre_4});
            this.dataGridViewReporte.Location = new System.Drawing.Point(82, 226);
            this.dataGridViewReporte.Name = "dataGridViewReporte";
            this.dataGridViewReporte.RowHeadersWidth = 51;
            this.dataGridViewReporte.RowTemplate.Height = 24;
            this.dataGridViewReporte.Size = new System.Drawing.Size(657, 212);
            this.dataGridViewReporte.TabIndex = 0;
            this.dataGridViewReporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVieWReporte_CellContentClick);
            // 
            // btnGraReporte
            // 
            this.btnGraReporte.BackColor = System.Drawing.Color.BurlyWood;
            this.btnGraReporte.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraReporte.Location = new System.Drawing.Point(339, 113);
            this.btnGraReporte.Name = "btnGraReporte";
            this.btnGraReporte.Size = new System.Drawing.Size(222, 39);
            this.btnGraReporte.TabIndex = 1;
            this.btnGraReporte.Text = "Generar Reporte";
            this.btnGraReporte.UseVisualStyleBackColor = false;
            this.btnGraReporte.Click += new System.EventHandler(this.btnGraReporte_Click);
            // 
            // btnregreso
            // 
            this.btnregreso.BackgroundImage = global::PuntoDeVenta.Properties.Resources.volverMenu;
            this.btnregreso.Location = new System.Drawing.Point(3, 2);
            this.btnregreso.Name = "btnregreso";
            this.btnregreso.Size = new System.Drawing.Size(38, 30);
            this.btnregreso.TabIndex = 3;
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
            // VentaTrimestral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PuntoDeVenta.Properties.Resources.trimestre;
            this.ClientSize = new System.Drawing.Size(794, 450);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trimestre_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trimestre_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trimestre_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trimestre_4;
    }
}