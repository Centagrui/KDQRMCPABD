using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// holi 
namespace PuntoDeVenta
{
    internal class AgregarProduc
    {
        private ConexionBD conexionBD;

        public AgregarProduc()
        {
            conexionBD = new ConexionBD();
        }

        public void AgregarProducto(string nombre, string codigo, string descripcion, string precioText, string existenciaText, DataGridView dataGridView)
        {
            // Verificar si los campos están llenos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(descripcion) ||
                string.IsNullOrEmpty(precioText) || string.IsNullOrEmpty(existenciaText))
            {
                MessageBox.Show("Todos los campos deben ser llenados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convertir precio y existencia a sus tipos correspondientes
            decimal precio;
            int existencia;

            if (!decimal.TryParse(precioText, out precio))
            {
                MessageBox.Show("El precio debe ser un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(existenciaText, out existencia))
            {
                MessageBox.Show("La existencia debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insertar el producto en la base de datos
            string query = "INSERT INTO productos (Nombre, Codigo, Descripcion, Precio, Existencia) VALUES (@nombre, @codigo, @descripcion, @precio, @existencia)";

            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Agregar parámetros a la consulta
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@existencia", existencia);

                    // Ejecutar la consulta de inserción
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Verificar si se insertó correctamente
                    if (filasAfectadas > 0)
                    {
                        // Si la inserción fue exitosa, mostrar mensaje
                        MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Agregar el producto al DataGridView
                        dataGridView.Rows.Add(nombre, codigo, descripcion, precio.ToString("C"), existencia);

                        // Limpiar los campos de texto
                        //LimpiarCampos();
                    }
                    else
                    {
                        // Si no se insertó correctamente, mostrar mensaje de error
                        MessageBox.Show("Ocurrió un error al intentar agregar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones, si ocurre algún error de conexión
                    MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public bool BuscarProductoPorCodigo(string codigo, TextBox txtNombre, TextBox txtCodigo, TextBox txtDescripcion, TextBox txtPrecio, TextBox txtExistencia)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM productos WHERE Codigo = @codigo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Si se encuentra el producto, asignar los valores a los TextBoxes
                        txtCodigo.Text = reader["Codigo"].ToString();
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                        txtPrecio.Text = reader["Precio"].ToString();
                        txtExistencia.Text = reader["Existencia"].ToString();
                        return true; // Producto encontrado
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado.");
                        return false; // Producto no encontrado
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al buscar el producto: {ex.Message}");
                    return false;
                }
            }
        }

        // Método para modificar un producto
        public bool ModificarProducto(string codigo, string nombre, string descripcion, decimal precio, int existencia)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE productos SET Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Existencia = @existencia WHERE Codigo = @codigo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Parámetros para la consulta
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@existencia", existencia);
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Si se modificó alguna fila, se devuelve true
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al modificar el producto: {ex.Message}");
                    return false;
                }
            }
        }

        // Método para agregar un producto al DataGridView
        public void AgregarProductoAlGrid(DataGridView grid, string codigo, string nombre, string descripcion, decimal precio, int existencia)
        {
            // Crear una nueva fila para el DataGridView
            DataGridViewRow nuevaFila = new DataGridViewRow();
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = nombre });
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = codigo });
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = descripcion });
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = precio });
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = existencia });

            // Agregar la fila al DataGridView
            grid.Rows.Add(nuevaFila);
        }

        // Método para limpiar los campos de texto después de modificar o agregar un producto
        public void LimpiarCampos(TextBox txtNombre, TextBox txtCodigo, TextBox txtDescripcion, TextBox txtPrecio, TextBox txtExistencia, TextBox txtBuscar)
        {
            txtNombre.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtExistencia.Clear();
            txtBuscar.Clear();
        }

        public bool EliminarProducto(string codigo, DataGridView grid)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    // Mostrar el mensaje de confirmación
                    DialogResult resultado = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este producto?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Si el usuario selecciona "Sí"
                    if (resultado == DialogResult.Yes)
                    {
                        conn.Open();

                        // Eliminar producto de la base de datos
                        string query = "DELETE FROM productos WHERE Codigo = @codigo";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@codigo", codigo);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Si se eliminó correctamente de la base de datos, eliminar también del DataGridView
                            foreach (DataGridViewRow row in grid.Rows)
                            {
                                if (row.Cells["Codigo"].Value != null && row.Cells["Codigo"].Value.ToString() == codigo)
                                {
                                    grid.Rows.Remove(row);
                                    break;
                                }
                            }

                            // Mensaje de eliminación exitosa
                            MessageBox.Show("Producto eliminado exitosamente.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto para eliminar.");
                            return false;
                        }
                    }

                    return false; // El usuario canceló la eliminación
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al eliminar el producto: {ex.Message}");
                    return false;
                }
            }
        }
    }
}




