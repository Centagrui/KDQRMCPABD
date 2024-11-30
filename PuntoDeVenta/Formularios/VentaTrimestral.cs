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

        // Evento del botón para generar el reporte
        private void btnGraReporte_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas para el trimestre
            DateTime fechaInicio = dateTimePicker1.Value.Date;
            DateTime fechaFin = fechaInicio.AddMonths(3).AddDays(-1);

            // Llamar al método para obtener las ventas por empleado
            DataTable tabla = ObtenerVentasPorEmpleado(fechaInicio, fechaFin);

            // Mostrar los datos en el DataGridView
            dataGridVieWReporte.DataSource = tabla;

            // Configurar encabezados de las columnas
            dataGridVieWReporte.Columns["Empleado"].HeaderText = "Empleado";
            dataGridVieWReporte.Columns["CantidadVentas"].HeaderText = "Cantidad de Ventas";
            dataGridVieWReporte.Columns["TotalVentas"].HeaderText = "Total de Ventas";
        }

        // Evento del botón para cerrar el formulario
        private void btnregreso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método para obtener las ventas por empleado desde la base de datos
        private DataTable ObtenerVentasPorEmpleado(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tablaVentas = new DataTable();
            string connectionString = "server=localhost;database=tarea;user=root;password=root;";
            string query = @"SELECT 
                                NombreEmpleado AS Empleado, 
                                COUNT(noVenta) AS CantidadVentas, 
                                SUM(totalVenta) AS TotalVentas
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

        // Eventos vacíos (puedes eliminarlos si no los necesitas)
        private void dataGridVieWReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
    }


}
