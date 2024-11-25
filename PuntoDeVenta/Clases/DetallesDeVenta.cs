using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta.Clases
{
    internal class DetallesDeVenta
    {
        private ConexionBD conexionBD;

        public DetallesDeVenta()
        {
            conexionBD = new ConexionBD();
        }

        public string ObtenerNombreClientePorClave(string clave)
        {
            string nombreCompleto = null;

            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();

                    // Consulta para verificar si la clave existe
                    string query = "SELECT CONCAT(nombre, ' ', apellido) FROM clientesMayoristas WHERE clave = @clave";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@clave", clave);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        nombreCompleto = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar con la base de datos: " + ex.Message);
                }
            }

            return nombreCompleto;
        }

        // Nuevo método para guardar detalles de venta
        public void GuardarDetallesVenta(string nombreEmpleado, string nombreCliente, int cantidadProductos, decimal totalVenta, DateTime? fechaVenta = null)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                conn.Open();
                var transaction = conn.BeginTransaction();

                try
                {
                    // Crear la consulta SQL para insertar en la tabla detallesVenta
                    string query = @"
                INSERT INTO detallesVenta (NombreEmpleado, NombreCliente, cantidadProductos, totalVenta, fechaVenta)
                VALUES (@nombreEmpleado, @nombreCliente, @cantidadProductos, @totalVenta, @fechaVenta)";

                    MySqlCommand cmd = new MySqlCommand(query, conn, transaction);

                    // Agregar los parámetros necesarios para la inserción
                    cmd.Parameters.AddWithValue("@nombreEmpleado", nombreEmpleado);
                    cmd.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                    cmd.Parameters.AddWithValue("@cantidadProductos", cantidadProductos);
                    cmd.Parameters.AddWithValue("@totalVenta", totalVenta);

                    // Si se proporciona una fecha, úsala; de lo contrario, utiliza la fecha actual
                    cmd.Parameters.AddWithValue("@fechaVenta", fechaVenta ?? DateTime.Now);

                    // Ejecutar la consulta
                    cmd.ExecuteNonQuery();

                    // Confirmar la transacción si todo va bien
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Deshacer la transacción si ocurre un error
                    transaction.Rollback();
                    Console.WriteLine($"Error al guardar los detalles de la venta: {ex.Message}");
                }
            }
        }

        public class ProductoService
        {
            internal class DetallesDeVenta
            {
                private ConexionBD conexionBD;

                public DetallesDeVenta()
                {
                    conexionBD = new ConexionBD();
                }

                public void ActualizarExistenciasConDescuento(List<ProductVenta> productosVendidos, decimal descuento)
                {
                    using (MySqlConnection conn = conexionBD.ObtenerConexion())
                    {
                        conn.Open();
                        var transaction = conn.BeginTransaction();

                        try
                        {
                            foreach (var producto in productosVendidos)
                            {
                                // Aquí aplicamos el descuento sobre la cantidad del producto
                                decimal cantidadConDescuento = producto.Cantidad - (producto.Cantidad * descuento);

                                string query = "UPDATE Productos SET existencia = existencia - @cantidad WHERE codigo = @codigo";
                                MySqlCommand cmd = new MySqlCommand(query, conn, transaction);

                                cmd.Parameters.AddWithValue("@codigo", producto.CodigoProducto);
                                cmd.Parameters.AddWithValue("@cantidad", cantidadConDescuento);

                                int filasAfectadas = cmd.ExecuteNonQuery();

                                if (filasAfectadas == 0)
                                {
                                    throw new Exception($"No se encontró el producto con código {producto.CodigoProducto}.");
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error al procesar la venta con descuento: " + ex.Message);
                        }
                    }
                }
            }

        }
        public class StockManager
        {
            private readonly ConexionBD conexionBD;

            public StockManager()
            {
                conexionBD = new ConexionBD(); // Asegúrate de que ConexionBD esté implementada correctamente
            }

            public void ActualizarExistencias(List<ProductVenta> productosVendidos)
            {
                using (MySqlConnection conn = conexionBD.ObtenerConexion())
                {
                    conn.Open();
                    var transaction = conn.BeginTransaction();

                    try
                    {
                        foreach (var producto in productosVendidos)
                        {
                            string query = "UPDATE Productos SET existencia = existencia - @cantidad WHERE codigo = @codigo";
                            MySqlCommand cmd = new MySqlCommand(query, conn, transaction);

                            cmd.Parameters.AddWithValue("@codigo", producto.CodigoProducto);
                            cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);

                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas == 0)
                            {
                                throw new Exception($"No se encontró el producto con código {producto.CodigoProducto}.");
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al procesar la venta", ex);
                    }
                }
            }
        }



    }
}
