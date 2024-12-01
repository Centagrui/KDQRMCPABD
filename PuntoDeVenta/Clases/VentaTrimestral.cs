using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuntoDeVenta.Formularios;

namespace PuntoDeVenta.Clases
{
    public class VentaTrimestral
    {
        private string connectionString = "server=localhost;database=tarea;user=root;password=root;";

        public List<Dictionary<string, object>> ObtenerVentasTrimestrales(int anio)
        {
            var ventasTrimestrales = new List<Dictionary<string, object>>();

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    p.NombreProducto,
                    SUM(CASE WHEN QUARTER(v.FechaVenta) = 1 THEN v.Cantidad ELSE 0 END) AS 'Trim1',
                    SUM(CASE WHEN QUARTER(v.FechaVenta) = 2 THEN v.Cantidad ELSE 0 END) AS 'Trim2',
                    SUM(CASE WHEN QUARTER(v.FechaVenta) = 3 THEN v.Cantidad ELSE 0 END) AS 'Trim3',
                    SUM(CASE WHEN QUARTER(v.FechaVenta) = 4 THEN v.Cantidad ELSE 0 END) AS 'Trim4'
                FROM Ventas v
                INNER JOIN Productos p ON v.IdProducto = p.IdProducto
                WHERE YEAR(v.FechaVenta) = @anio
                GROUP BY p.NombreProducto;
            ";

                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@anio", anio);

                conexion.Open();
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new Dictionary<string, object>
                    {
                        { "NombreProducto", reader["NombreProducto"].ToString() },
                        { "Trim1", Convert.ToInt32(reader["Trim1"]) },
                        { "Trim2", Convert.ToInt32(reader["Trim2"]) },
                        { "Trim3", Convert.ToInt32(reader["Trim3"]) },
                        { "Trim4", Convert.ToInt32(reader["Trim4"]) }
                    };
                        ventasTrimestrales.Add(producto);
                    }
                }
            }

            return ventasTrimestrales;
        }
    }
}
