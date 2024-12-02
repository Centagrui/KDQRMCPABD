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
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion) ||
                string.IsNullOrWhiteSpace(precioText) || string.IsNullOrWhiteSpace(existenciaText))
            {
                MessageBox.Show("Todos los campos deben ser llenados correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el nombre no contenga solo espacios
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre del producto no puede estar vacío o contener solo espacios en blanco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar precio
            if (!decimal.TryParse(precioText, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio debe ser un número válido mayor o igual a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar existencia
            if (!int.TryParse(existenciaText, out int existencia) || existencia < 0)
            {
                MessageBox.Show("La existencia debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar longitud del código de barras (si no está vacío)
            if (!string.IsNullOrEmpty(codigo) && (codigo.Length < 8 || codigo.Length > 20))
            {
                MessageBox.Show("El código de barras debe tener entre 8 y 20 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Consulta SQL para insertar producto
            string query = "INSERT INTO productos (Nombre, Codigo, Descripcion, Precio, Existencia) VALUES (@nombre, @codigo, @descripcion, @precio, @existencia)";

            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@existencia", existencia);

                    // Ejecutar la consulta
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView.Rows.Add(nombre, codigo, descripcion, precio.ToString("C"), existencia);
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar agregar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
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




