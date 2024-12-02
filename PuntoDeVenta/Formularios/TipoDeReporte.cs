using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.Formularios
{
    public partial class TipoDeReporte : Form
    {
        public TipoDeReporte()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteVentas reporte = new ReporteVentas();
            reporte.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VentaPorEmpleado ventaPorEmpleado = new VentaPorEmpleado();
            ventaPorEmpleado.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VentaTrimestral ventaTrimestral = new VentaTrimestral();
            ventaTrimestral.Show();
         
        }

        private void btnRegreso_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
