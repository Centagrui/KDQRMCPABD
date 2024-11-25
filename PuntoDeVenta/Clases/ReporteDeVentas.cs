using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using PuntoDeVenta.Formularios;

namespace PuntoDeVenta
{
    public class ReporteDeVentas
    {
        public class Venta
        {

            private string connectionString = "server=localhost;database=tarea;user=root;password=root;";

            // Método para obtener las ventas del mes y año seleccionados
            public List<Venta> ObtenerVentasPorMes(int mes, int anio)
            {
                List<Venta> ventas = new List<Venta>();

                // Consulta SQL para obtener las ventas del mes y año seleccionados
                string query = "SELECT * FROM Ventas WHERE MONTH(fechaVenta) = @Mes AND YEAR(fechaVenta) = @Anio";

                // Conexión a la base de datos y ejecución de la consulta
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
                                // Crear un objeto Venta para cada registro
                                Venta venta = new Venta
                                {
                                    Id = reader.GetInt32("idVenta"),
                                    Cliente = reader.GetString("cliente"),
                                    FechaVenta = reader.GetDateTime("fechaVenta"),
                                    MontoTotal = reader.GetDecimal("montoTotal")
                                };
                                ventas.Add(venta);
                            }
                        }
                    }
                }

                return ventas;
            }

            public int Id { get; set; }
            public string Cliente { get; set; }
            public DateTime FechaVenta { get; set; }
            public decimal MontoTotal { get; set; }
        }

    }
}
