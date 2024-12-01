using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using static PuntoDeVenta.ReporteDeVentas;

namespace PuntoDeVenta.Clases
{
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
    }

    // Clase modelo
    public class VentaEmpleado
    {
        public string Empleado { get; set; }
        public int CantidadProductos { get; set; }
        public decimal MontoTotal { get; set; }
    }



}



