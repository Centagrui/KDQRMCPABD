using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PuntoDeVenta;
using PuntoDeVenta.Clases;
using static PuntoDeVenta.ReporteDeVentas;

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
            int mes = monthCalendar1.SelectionStart.Month;
            int anio = monthCalendar1.SelectionStart.Year;

            // Obtener las ventas del mes seleccionado
            var ventasDelMes = reporteDeVenta.ObtenerVentasPorMes(mes, anio);

            // Mostrar las ventas en el DataGridView
            MostrarVentasEnDataGridView(ventasDelMes);
        }

        private void MostrarVentasEnDataGridView(List<Venta> ventas)
        {
            dataGridView1.Rows.Clear();

            // Agregar cada venta al DataGridView
            foreach (var venta in ventas)
            {
                dataGridView1.Rows.Add(venta.Id, venta.Empleado, venta.Cliente, venta.FechaVenta.ToShortDateString(), venta.MontoTotal);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


