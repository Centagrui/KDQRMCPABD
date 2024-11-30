using PuntoDeVenta.Clases;
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
    public partial class VentaPorEmpleado : Form
    {
        private VentaEmpleado ventaEmpleado = new VentaEmpleado();
        public VentaPorEmpleado()
        {
            InitializeComponent();
            for (int i = 1; i <= 12; i++)
                comboBoxMes.Items.Add(new DateTime(1, i, 1).ToString("MMMM"));

            for (int i = 2020; i <= DateTime.Now.Year; i++)
                comboBoxAnio.Items.Add(i);

            comboBoxMes.SelectedIndex = 0; // Selecciona enero por defecto
            comboBoxAnio.SelectedIndex = comboBoxAnio.Items.Count - 1;

        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMostrarVentas_Click(object sender, EventArgs e)
        {
            if (comboBoxMes.SelectedIndex == -1 || comboBoxAnio.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un mes y un año.");
                return;
            }

            int mes = comboBoxMes.SelectedIndex + 1;
            int anio = int.Parse(comboBoxAnio.SelectedItem.ToString());

            DataTable ventas = ventaEmpleado.ObtenerVentasPorMes(mes, anio);
            dataGridViewVentas.DataSource = ventas;
        }
    }

}

