using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta
{
    public class ReporteDeVentas
    {
        public class Venta
        {
            public int Id { get; set; }
            public string Cliente { get; set; }
            public string Empleado { get; set; }
            public int CantidadProductos { get; set; }
            public decimal MontoTotal { get; set; }
            public DateTime FechaVenta { get; set; }
        }

        private string connectionString = "server=localhost;database=tarea;user=root;password=root;";

        public List<Venta> ObtenerVentas(DateTime fecha)
        {
            var ventas = new List<Venta>();
            using (var connection = new MySqlConnection(connectionString))
            {
                // Filtra las ventas por una fecha específica (sin considerar hora)
                string query = @"SELECT noVenta, NombreEmpleado, NombreCliente, cantidadProductos, totalVenta, fechaVenta
                         FROM detallesVenta
                         WHERE DATE(fechaVenta) = @Fecha";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fecha", fecha.Date); // Solo la parte de la fecha

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta
                            {
                                Id = reader.GetInt32("noVenta"),
                                Empleado = reader.GetString("NombreEmpleado"),
                                Cliente = reader.GetString("NombreCliente"),
                                CantidadProductos = reader.GetInt32("cantidadProductos"),
                                MontoTotal = reader.GetDecimal("totalVenta"),
                                FechaVenta = reader.GetDateTime("fechaVenta")
                            });
                        }
                    }
                }
            }
            return ventas;
        }

    }
}
