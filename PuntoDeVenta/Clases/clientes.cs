using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    internal class clientes
    {
        private ConexionBD conexionBD;

        public clientes()
        {
            conexionBD = new ConexionBD();
        }

        public void AgregarCliente(string nombre, string apellido, string clave, DataGridView dataGridView)
        {
            // Verificar si los campos están llenos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(clave))
                
            {
                MessageBox.Show("Todos los campos deben ser llenados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insertar el cliente en la base de datos
            string query = "INSERT INTO clientesMayoristas (Nombre, Apellido, Clave) VALUES (@nombre, @apellido, @clave)";

            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Agregar parámetros a la consulta
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@clave", clave);

                    // Ejecutar la consulta de inserción
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Verificar si se insertó correctamente
                    if (filasAfectadas > 0)
                    {
                        // Si la inserción fue exitosa, mostrar mensaje
                        MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Agregar el cliente al DataGridView
                        dataGridView.Rows.Add(nombre, apellido,clave);
                    }
                    else
                    {
                        // Si no se insertó correctamente, mostrar mensaje de error
                        MessageBox.Show("Ocurrió un error al intentar agregar el Cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones, si ocurre algún error de conexión
                    MessageBox.Show($"Error al agregar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public bool BuscarClientePorCodigo(string codigo, TextBox txtNombre, TextBox txtApellido, TextBox txtClave)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM clientesMayoristas WHERE clave = @codigo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Si se encuentra el cliente, asignar los valores a los TextBoxes
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtApellido.Text = reader["Apellido"].ToString();
                        txtClave.Text = reader["Clave"].ToString();
                        return true; // Cliente encontrado
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado.");
                        return false; // Cliente no encontrado
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al buscar el Cliente: {ex.Message}");
                    return false;
                }
            }
        }

        // Método para modificar un cliente
        public bool ModificarCliente(string Nombre, string Apellido, string Clave)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE clientesMayoristas SET Nombre = @nombre, Apellido = @apellido, Clave = @clave";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Parámetros para la consulta
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@apellido", Apellido);
                    cmd.Parameters.AddWithValue("@clave", Clave);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Si se modificó alguna fila, se devuelve true
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al modificar el cliente: {ex.Message}");
                    return false;
                }
            }
        }

        // Método para agregar un cliente al DataGridView
        public void AgregarClienteAlGrid(DataGridView grid, string Nombre, string Apellido, string Clave)
        {
            // Crear una nueva fila para el DataGridView
            DataGridViewRow nuevaFila = new DataGridViewRow();
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = Nombre });
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = Apellido });
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = Clave });

            // Agregar la fila al DataGridView
            grid.Rows.Add(nuevaFila);
        }

        // Método para limpiar los campos de texto después de modificar o agregar un cliente
        public void LimpiarCampos(TextBox txtNombre, TextBox txtApellido, TextBox txtClave)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtClave.Clear();
        }

        public bool EliminarCliente(string codigo, DataGridView grid)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    // Mostrar el mensaje de confirmación
                    DialogResult resultado = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este Cliente?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Si el usuario selecciona "Sí"
                    if (resultado == DialogResult.Yes)
                    {
                        conn.Open();

                        // Eliminar cliente de la base de datos
                        string query = "DELETE FROM clientesMayoristas WHERE Clave = @codigo";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@codigo", codigo);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Si se eliminó correctamente de la base de datos, eliminar también del DataGridView
                            foreach (DataGridViewRow row in grid.Rows)
                            {
                                if (row.Cells["Clave"].Value != null && row.Cells["Clave"].Value.ToString() == codigo)
                                {
                                    grid.Rows.Remove(row);
                                    break;
                                }
                            }

                            // Mensaje de eliminación exitosa
                            MessageBox.Show("Cliente eliminado exitosamente.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el cliente para eliminar.");
                            return false;
                        }
                    }

                    return false; // El usuario canceló la eliminación
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al eliminar el cliente: {ex.Message}");
                    return false;
                }
            }
        }
    }
}

