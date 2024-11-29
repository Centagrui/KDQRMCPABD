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
    public partial class VentaTrimestral : Form
    {
        public VentaTrimestral()
        {
            InitializeComponent();
        }

        private void dataGridVieWReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Este evento puede quedar vacío si no necesitas manejar acciones específicas aquí
        }

        private void btnGraReporte_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas para el trimestre
            DateTime fechaInicio = dateTimePicker1.Value.Date;
            DateTime fechaFin = fechaInicio.AddMonths(3).AddDays(-1);

            // Obtener datos de ventas por empleado
            var tabla = ObtenerVentasPorEmpleado(fechaInicio, fechaFin);

            // Mostrar los datos en el DataGridView
            dataGridVieWReporte.DataSource = tabla;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Evento para manejar cambios en el DateTimePicker (puede quedar vacío si no es necesario)
        }

        private void btnregreso_Click(object sender, EventArgs e)
        {
            // Volver al menú principal (descomentar si tienes el formulario Menu)
            // Menu menu = new Menu();
            // menu.Show();
            this.Close();
        }

        // Método para obtener ventas por empleado
        private DataTable ObtenerVentasPorEmpleado(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tablaVentas = new DataTable();
            string connectionString ="server=localhost;database=tarea;user=root;password=root; ";
            string query = @"SELECT NombreEmpleado, COUNT(noVenta) AS TotalVentas, 
                             SUM(totalVenta) AS MontoTotal
                             FROM detallesVenta
                             WHERE fechaVenta BETWEEN @FechaInicio AND @FechaFin
                             GROUP BY NombreEmpleado";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        comando.Parameters.AddWithValue("@FechaFin", fechaFin);

                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                        {
                            adaptador.Fill(tablaVentas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return tablaVentas;
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}