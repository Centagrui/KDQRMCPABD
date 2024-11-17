using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    internal class empleados
    {
        private ConexionBD conexionBD;

        public empleados()
        {
            conexionBD = new ConexionBD();
        }

        
        public bool BuscarEmpleadoPorCodigo(string codigo, TextBox txtNombre, TextBox txtApellido, TextBox txtDireccion, TextBox txtUsuario)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM usuarios WHERE contrasenia = SHA2(@codigo,256)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Si se encuentra el empleado, asignar los valores a los TextBoxes
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtApellido.Text = reader["Apellido"].ToString();
                        txtDireccion.Text = reader["Direccion"].ToString();
                        txtUsuario.Text = reader["Usuario"].ToString();
                        return true; // Empleado encontrado
                    }
                    else
                    {
                        MessageBox.Show("Empleado no encontrado.");
                        return false; // Empleado no encontrado
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al buscar el Empleado: {ex.Message}");
                    return false;
                }
            }
        }

        // Método para modificar un empleado
        public bool ModificarEmpleado(string Nombre, string Apellido, string Direccion, string Usuario)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE usuarios SET Nombre = @nombre, Apellido = @apellido, Direccion = @direccion, Usuario=@usuario";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Parámetros para la consulta
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@apellido", Apellido);
                    cmd.Parameters.AddWithValue("@direccion", Direccion);
                    cmd.Parameters.AddWithValue("@usuario", Usuario);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Si se modificó alguna fila, se devuelve true
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al modificar el empleado: {ex.Message}");
                    return false;
                }
            }
        }

        // Método para agregar un empleado al DataGridView
        public void AgregarEmpleadoAlGrid(DataGridView grid, string Nombre, string Apellido, string Direccion, string Usuario)
        {
            // Crear una nueva fila para el DataGridView
            DataGridViewRow nuevaFila = new DataGridViewRow();
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = Nombre });
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = Apellido });
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = Direccion });
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = Usuario });

            // Agregar la fila al DataGridView
            grid.Rows.Add(nuevaFila);
        }

        // Método para limpiar los campos de texto después de modificar  un empleado
        public void LimpiarCampos(TextBox txtNombre, TextBox txtApellido, TextBox txtDireccion, TextBox txtUsuario)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtUsuario.Clear();
        }

        public bool EliminarEmpleado(string codigo, DataGridView grid)
        {
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    // Mostrar el mensaje de confirmación
                    DialogResult resultado = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este Empleado?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Si el usuario selecciona "Sí"
                    if (resultado == DialogResult.Yes)
                    {
                        conn.Open();

                        // Eliminar cliente de la base de datos
                        string query = "DELETE FROM usuarios WHERE contrasenia = @codigo";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@codigo", codigo);

                        // Mensaje de eliminación exitosa
                        MessageBox.Show("Cliente eliminado exitosamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el empleado para eliminar.");
                        return false;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al eliminar el empleado: {ex.Message}");
                    return false;
                }
            }
        }
    }
}

