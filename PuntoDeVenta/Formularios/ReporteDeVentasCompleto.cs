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
            reporteDeVenta = new ReporteDeVentas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada
            DateTime fecha = dateTimePicker1.Value.Date;

            // Obtener las ventas para esa fecha
            var ventas = reporteDeVenta.ObtenerVentas(fecha);

            // Llenar el DataGridView
            LlenarDataGridView(ventas);
        }


        private void LlenarDataGridView(List<ReporteDeVentas.Venta> ventas)
        {
            // Asegúrate de que las columnas estén creadas si no usas el diseñador
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "ID Venta");
            dataGridView1.Columns.Add("Empleado", "Empleado");
            dataGridView1.Columns.Add("Cliente", "Cliente");
            dataGridView1.Columns.Add("Cantidad", "Cantidad de Productos");
            dataGridView1.Columns.Add("Total", "Monto Total");
            dataGridView1.Columns.Add("Fecha", "Fecha de Venta");

            dataGridView1.Rows.Clear();

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


        private void MonthCalendar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


