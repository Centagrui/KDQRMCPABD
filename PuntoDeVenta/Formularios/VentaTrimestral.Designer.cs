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
            this.btnGraReporte = new System.Windows.Forms.Button();
            this.btnregreso = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVieWReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridVieWReporte
            // 
            this.dataGridVieWReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVieWReporte.Location = new System.Drawing.Point(23, 226);
            this.dataGridVieWReporte.Name = "dataGridVieWReporte";
            this.dataGridVieWReporte.RowHeadersWidth = 51;
            this.dataGridVieWReporte.RowTemplate.Height = 24;
            this.dataGridVieWReporte.Size = new System.Drawing.Size(847, 212);
            this.dataGridVieWReporte.TabIndex = 0;
            this.dataGridVieWReporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVieWReporte_CellContentClick);
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(117, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(271, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // VentaTrimestral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnregreso);
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
        private System.Windows.Forms.Button btnregreso;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}