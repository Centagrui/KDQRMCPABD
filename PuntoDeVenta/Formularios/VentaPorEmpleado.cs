using MySql.Data.MySqlClient;
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
                    LlenarDataGridView(null); // Limpiar datos
                    return;
                }

                // Mostrar los datos en el DataGridView
                LlenarDataGridView(ventas);
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

        private void LlenarDataGridView(List<VentaEmpleado> ventas)
        {
            if (dataGridViewVentas.Columns.Count == 0)
            {
                dataGridViewVentas.Columns.Add("Empleado", "Empleado");
                dataGridViewVentas.Columns.Add("Cantidad", "Cantidad de Productos");
                dataGridViewVentas.Columns.Add("Total", "Monto Total");
            }

            dataGridViewVentas.Rows.Clear();

            if (ventas != null)
            {
                foreach (var venta in ventas)
                {
                    dataGridViewVentas.Rows.Add(
                        venta.Empleado,
                        venta.CantidadProductos,
                        venta.MontoTotal
                    );
                }
            }
        }

        private void comboBoxAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoDeReporte tipoDeReporte = new TipoDeReporte();
            tipoDeReporte.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    // Clase para acceso a datos
    public class VentaEmpleadoDAO
    {
        private string connectionString = "server=localhost;database=tarea;user=root;password=root;";

        public List<VentaEmpleado> ObtenerVentasPorMes(int anio, int mes)
        {
            var ventas = new List<VentaEmpleado>();

            string query = @"
           SELECT 
    dv.nombreempleado AS Empleado, 
    SUM(dv.totalVenta) AS MontoTotal,
    SUM(dv.cantidadProductos) AS CantidadProductos
FROM detallesVenta dv
WHERE MONTH(dv.fechaVenta) = @Mes AND YEAR(dv.fechaVenta) = @Anio
GROUP BY dv.nombreempleado";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", anio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ventas.Add(new VentaEmpleado
                                {
                                    Empleado = reader.GetString("Empleado"),
                                    CantidadProductos = reader.GetInt32("CantidadProductos"),
                                    MontoTotal = reader.GetDecimal("MontoTotal")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener ventas: {ex.Message}", ex);
            }

            return ventas;
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

