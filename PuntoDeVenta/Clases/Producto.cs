using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public class Producto
    {
        public string Nombre { get; set; }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; } 
    }

    public class ProductoRepository
    {
        private ConexionBD conexionBD;

        public ProductoRepository()
        {
            conexionBD = new ConexionBD(); // Instanciamos ConexionBD
        }
        // Método para obtener los datos del producto
        public Producto ObtenerProductoPorCodigo(string codigo)
        {
            Producto producto = null;

            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Nombre, Codigo, Descripcion, Precio FROM productos WHERE Codigo = @codigo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        producto = new Producto
                        {
                            Nombre = reader.GetString("Nombre"),
                            Codigo = reader.GetString("Codigo"),
                            Descripcion = reader.GetString("Descripcion"),
                            Precio = reader.GetDecimal("Precio")
                        };
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones (puedes personalizar este mensaje)
                    MessageBox.Show("Error al obtener el producto: " + ex.Message);
                }
            }
            return producto;
        }
    }
}
