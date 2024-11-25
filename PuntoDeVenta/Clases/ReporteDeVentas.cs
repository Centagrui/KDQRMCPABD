using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using PuntoDeVenta.Clases;

namespace PuntoDeVenta
{
    public class ReporteDeVentas

    {
        private string connectionString = "server=localhost;database=tarea;user=root;password=root;";

        // Método para obtener las ventas por mes y año seleccionados
        public List<Venta> ObtenerVentasPorMes(int mes, int anio)
        {
            List<Venta> ventas = new List<Venta>();

            // Consulta SQL para obtener las ventas del mes y año seleccionados
            string query = @"
                SELECT v.idVenta, v.fechaVenta, v.totalVenta, 
                       e.Nombre AS Empleado, c.Nombre AS Cliente
                FROM Ventas v
                JOIN USUARIOS e ON v.idEmpleado = e.id_usuario
                JOIN clientesMayoristas c ON v.idCliente = c.idCliente
                WHERE MONTH(v.fechaVenta) = @Mes AND YEAR(v.fechaVenta) = @Anio
            ";

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
                            Venta venta = new Venta
                            {
                                Id = reader.GetInt32("idVenta"),
                                FechaVenta = reader.GetDateTime("fechaVenta"),
                                MontoTotal = reader.GetDecimal("totalVenta"),
                                Empleado = reader.GetString("Empleado"),
                                Cliente = reader.GetString("Cliente")
                            };
                            ventas.Add(venta);
                        }
                    }
                }
            }

            return ventas;
        }

    
        public class Venta
        {
            public int Id { get; set; }
            public string Empleado { get; set; }
            public string Cliente { get; set; }
            public DateTime FechaVenta { get; set; }
            public decimal MontoTotal { get; set; }
        }
    }

}


