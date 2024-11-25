using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PuntoDeVenta;

namespace PuntoDeVenta.Formularios
{
    public partial class ReporteVentas : Form
    {
        private ReporteDeVentas reporteDeVenta;

        public ReporteVentas()
        {
            InitializeComponent();
            reporteDeVenta = new ReporteDeVentas(); // Instancia de ReporteDeVentas
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada
            DateTime fecha = dateTimePicker1.Value.Date;

            try
            {
                // Obtener las ventas para esa fecha
                var ventas = reporteDeVenta.ObtenerVentas(fecha);

                // Llenar el DataGridView
                LlenarDataGridView(ventas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las ventas: {ex.Message}");
            }
        }

        private void LlenarDataGridView(List<ReporteDeVentas.Venta> ventas)
        {
            // Configurar columnas si es necesario
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Id", "ID Venta");
                dataGridView1.Columns.Add("Empleado", "Empleado");
                dataGridView1.Columns.Add("Cliente", "Cliente");
                dataGridView1.Columns.Add("Cantidad", "Cantidad de Productos");
                dataGridView1.Columns.Add("Total", "Monto Total");
                dataGridView1.Columns.Add("Fecha", "Fecha de Venta");
            }

            // Limpiar filas anteriores
            dataGridView1.Rows.Clear();

            // Agregar filas con datos
            foreach (var venta in ventas)
            {
                dataGridView1.Rows.Add(
                    venta.Id,
                    venta.Empleado,
                    venta.Cliente,
                    venta.CantidadProductos,
                    venta.MontoTotal,
                    venta.FechaVenta
                );
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnRegreso_Click(object sender, EventArgs e)
        {
          
            this.Close();    
                
        }
    }
}
