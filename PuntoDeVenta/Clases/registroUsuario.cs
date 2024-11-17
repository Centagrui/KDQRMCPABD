using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public class registroUsuario
    {
        private ConexionBD conexionBD;

        public registroUsuario()
        {
            conexionBD = new ConexionBD(); // Instanciamos ConexionBD
        }

        // Método para validar los campos y registrar un nuevo usuario
        public bool Registrar(string nombre, string apellido, string direccion, string usuario, string contrasena, string repetir)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena) || string.IsNullOrWhiteSpace(repetir))
            {
                MessageBox.Show("Todos los campos deben ser llenados.");
                return false; // Retorna false si algún campo está vacío
            }

            // Verificar que las contraseñas coincidan
            if (contrasena != repetir)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return false; // Retorna false si las contraseñas no coinciden
            }

            // Realizar el registro en la base de datos
            using (MySqlConnection conn = conexionBD.ObtenerConexion()) // Usar la conexión de la clase ConexionBD
            {
                try
                {
                    conn.Open(); // Conectar a la base de datos

                    string query = "INSERT INTO Usuarios (Nombre, Apellido, Direccion, Usuario, Contrasenia) " +
                                   "VALUES (@nombre, @apellido, @direccion, @usuario, SHA2(@contrasena, 256))";

                    // Crear el comando SQL
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    // Ejecutar el comando y verificar si se realizó correctamente el registro
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Si se insertaron filas, el registro fue exitoso
                    if (rowsAffected > 0)
                    {
                        // Si el registro es exitoso, manejar la post-acción
                        ManejarPostRegistro();
                        return true; // Registro exitoso
                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar el usuario en la base de datos.");
                        return false; // Si no se insertó ninguna fila
                    }
                }
                catch (MySqlException ex)
                {
                    // Mostrar el error en caso de excepción
                    MessageBox.Show($"Error al registrar: {ex.Message}");
                    return false; // Retorna false en caso de error
                }
            }
        }

        // Método para manejar la acción posterior al registro exitoso
        private void ManejarPostRegistro()
        {
            // Mostrar mensaje de éxito
            MessageBox.Show("¡Registro exitoso! Ahora puedes iniciar sesión.");

            // Abrir el formulario de login (Form1)
            Form1 form1 = new Form1();
            form1.Show();
            
            // Si deseas cerrar el formulario actual (Registrar), puedes usar this.Close() en el formulario correspondiente
        }
    }
}
