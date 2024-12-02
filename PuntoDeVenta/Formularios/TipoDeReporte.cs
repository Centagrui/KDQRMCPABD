using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.Clases;

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
            FormReporte formReporte = new FormReporte();
            formReporte.Show();
            this.Close();

        }

        private void btnRegreso_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void TipoDeReporte_Load(object sender, EventArgs e)
        {

        }
    }
}
