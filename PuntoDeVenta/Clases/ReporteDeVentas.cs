using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta
{
    public class ReporteDeVentas
    {
        // Cadena de conexión a la base de datos (ajusta los valores según tu configuración)
        private string connectionString = "server=localhost;database=puntoventa;user=root;password=tu_contraseña";

        /// <summary>
        /// Obtiene las ventas realizadas en un mes y año específicos.
        /// </summary>
        /// <param name="mes">El mes (1 a 12) para filtrar las ventas.</param>
        /// <param name="anio">El año para filtrar las ventas.</param>
        /// <returns>Un DataTable con las ventas correspondientes.</returns>
        public DataTable ObtenerVentasPorMes(int mes, int anio)
        {
            // Crear una tabla para almacenar los resultados
            DataTable dtVentas = new DataTable();

            try
            {
                // Establecer la conexión con la base de datos
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener las ventas
                    string query = @"
                        SELECT 
                            v.Fecha AS 'Fecha de Venta',
                            p.Nombre AS 'Producto',
                            dv.Cantidad AS 'Cantidad',
                            p.Precio AS 'Precio Unitario',
                            (dv.Cantidad * p.Precio) AS 'Total'
                        FROM Ventas v
                        INNER JOIN DetalleVentas dv ON v.ID_Venta = dv.ID_Venta
                        INNER JOIN Productos p ON dv.ID_Producto = p.ID_Producto
                        WHERE MONTH(v.Fecha) = @mes AND YEAR(v.Fecha) = @anio
                        ORDER BY v.Fecha ASC";

                    // Crear el comando con los parámetros
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mes", mes);
                        command.Parameters.AddWithValue("@anio", anio);

                        // Adaptador para llenar el DataTable
                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dtVentas);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores de conexión o consulta
                throw new Exception($"Error al obtener las ventas: {ex.Message}");
            }

            return dtVentas;
        }
    }
}
