using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace PuntoDeVenta.Clases
{
    internal class ReporteVentas
    {
        private string connectionString = "server=localhost;database=tarea;user=root;password=root;";

        public DataTable ObtenerVentasPorEmpleado(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tablaVentas = new DataTable();
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
                    // Manejar errores de conexión o consulta
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return tablaVentas;
        }
    }
}
