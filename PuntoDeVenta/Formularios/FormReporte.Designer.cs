namespace PuntoDeVenta.Formularios
{
    partial class FormReporte
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
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.dgvReporteTrimestral = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrimestre1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrimestre2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrimestre3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrimestre4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteTrimestral)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(327, 83);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(155, 48);
            this.btnGenerarReporte.TabIndex = 0;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // dgvReporteTrimestral
            // 
            this.dgvReporteTrimestral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteTrimestral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colTrimestre1,
            this.colTrimestre2,
            this.colTrimestre3,
            this.colTrimestre4});
            this.dgvReporteTrimestral.Location = new System.Drawing.Point(12, 231);
            this.dgvReporteTrimestral.Name = "dgvReporteTrimestral";
            this.dgvReporteTrimestral.RowHeadersWidth = 51;
            this.dgvReporteTrimestral.RowTemplate.Height = 24;
            this.dgvReporteTrimestral.Size = new System.Drawing.Size(764, 207);
            this.dgvReporteTrimestral.TabIndex = 1;
            this.dgvReporteTrimestral.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReporteTrimestral_CellContentClick);
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.MinimumWidth = 6;
            this.colProducto.Name = "colProducto";
            this.colProducto.Width = 125;
            // 
            // colTrimestre1
            // 
            this.colTrimestre1.HeaderText = "Trimestre 1";
            this.colTrimestre1.MinimumWidth = 6;
            this.colTrimestre1.Name = "colTrimestre1";
            this.colTrimestre1.Width = 125;
            // 
            // colTrimestre2
            // 
            this.colTrimestre2.HeaderText = "Trimestre 2";
            this.colTrimestre2.MinimumWidth = 6;
            this.colTrimestre2.Name = "colTrimestre2";
            this.colTrimestre2.Width = 125;
            // 
            // colTrimestre3
            // 
            this.colTrimestre3.HeaderText = "Trimestre 3";
            this.colTrimestre3.MinimumWidth = 6;
            this.colTrimestre3.Name = "colTrimestre3";
            this.colTrimestre3.Width = 125;
            // 
            // colTrimestre4
            // 
            this.colTrimestre4.HeaderText = "Trimestre 4";
            this.colTrimestre4.MinimumWidth = 6;
            this.colTrimestre4.Name = "colTrimestre4";
            this.colTrimestre4.Width = 125;
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvReporteTrimestral);
            this.Controls.Add(this.btnGenerarReporte);
            this.Name = "FormReporte";
            this.Text = "FormReporte";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteTrimestral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.DataGridView dgvReporteTrimestral;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrimestre1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrimestre2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrimestre3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrimestre4;
    }
}