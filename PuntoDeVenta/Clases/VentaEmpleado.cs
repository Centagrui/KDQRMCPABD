using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Clases
{
    internal class VentaEmpleado
    {

            private string connectionString = "server = localhost; database=tarea;user=root;password=root;";

        public DataTable ObtenerVentasPorMes(int mes, int anio)
        {
            DataTable dtVentas = new DataTable();

            string query = @"
            SELECT 
                e.Nombre AS Empleado, 
                SUM(v.Total) AS TotalVentas, 
                COUNT(v.VentaID) AS CantidadVentas
            FROM Ventas v
            INNER JOIN Empleados e ON v.EmpleadoID = e.EmpleadoID
            WHERE MONTH(v.FechaVenta) = @Mes AND YEAR(v.FechaVenta) = @Anio
            GROUP BY e.Nombre
            ORDER BY TotalVentas DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    cmd.Parameters.AddWithValue("@Anio", anio);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtVentas);
                }
            }

            return dtVentas;
        }
    }
    }




