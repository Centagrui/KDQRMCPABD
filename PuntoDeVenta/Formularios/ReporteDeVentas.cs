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
          
        }

        private void MostrarVentasEnDataGridView(List<Venta> ventas)
        {
           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}


