using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta.Clases
{



    public class VentaEmpleadoDAO
    {
        private string connectionString = "server=localhost;database=tarea;user=root;password=root;";

        public DataTable ObtenerVentasPorMes(int mes, int anio)
        {
            DataTable dtVentas = new DataTable();

            string query = @"
        SELECT 
            u.Nombre AS Empleado, 
            COUNT(dv.noVenta) AS CantidadVentas, 
            SUM(dv.totalVenta) AS TotalVentas
        FROM detallesVenta dv
        JOIN USUARIOS u ON u.id_usuario = dv.idEmpleado
        WHERE MONTH(dv.fechaVenta) = @Mes AND YEAR(dv.fechaVenta) = @Anio
        GROUP BY u.id_usuario";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Mes", MySqlDbType.Int32).Value = mes;
                        cmd.Parameters.Add("@Anio", MySqlDbType.Int32).Value = anio;

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dtVentas);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new ApplicationException("Ocurrió un error al obtener las ventas por mes.", ex);
            }

            return dtVentas;
        }
    }

}





