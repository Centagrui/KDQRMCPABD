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
        private VentaEmpleadoDAO ventaEmpleadoDAO = new VentaEmpleadoDAO();

        public VentaPorEmpleado()
        {
            InitializeComponent();

            // Configurar ComboBox de Meses y Años
            for (int i = 1; i <= 12; i++)
                comboBoxMes.Items.Add(new DateTime(1, i, 1).ToString("MMMM"));

            for (int i = 2020; i <= DateTime.Now.Year; i++)
                comboBoxAnio.Items.Add(i);

            comboBoxMes.SelectedIndex = 0; // Enero por defecto
            comboBoxAnio.SelectedIndex = comboBoxAnio.Items.Count - 1; // Año actual por defecto
        }

        private void btnMostrarVentas_Click(object sender, EventArgs e)
        {
            if (comboBoxMes.SelectedIndex == -1 || comboBoxAnio.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un mes y un año.");
                return;
            }

            int mes = comboBoxMes.SelectedIndex + 1; // Meses de 1 a 12
            int anio = int.Parse(comboBoxAnio.SelectedItem.ToString());

            try
            {
                // Obtener ventas desde la base de datos
                var ventas = ventaEmpleadoDAO.ObtenerVentasPorMes(anio, mes);

                if (ventas == null || ventas.Count == 0)
                {
                    MessageBox.Show("No hay datos para el mes y año seleccionados.");
                    dataGridViewVentas.DataSource = null;
                    return;
                }

                // Mostrar los datos en el DataGridView
                dataGridViewVentas.AutoGenerateColumns = true;
                dataGridViewVentas.DataSource = ventas;
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }




        private void comboBoxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    
    }
}

