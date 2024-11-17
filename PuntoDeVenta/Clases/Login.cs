using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public class Login
    {
        private ConexionBD conexionBD;

        public Login()
        {
            conexionBD = new ConexionBD(); // Instanciamos ConexionBD
        }

        // Método para validar usuario y contraseña
        public bool ValidarUsuario(string username, string password)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Asegúrate de que los campos contengan datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Retornamos false si alguno de los campos está vacío
            }

            // Si los campos están completos, procedemos con la validación
            using (MySqlConnection conn = conexionBD.ObtenerConexion())
            {
                try
                {
                    conn.Open(); // Abrir la conexión a la base de datos
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE usuario = @username AND contrasenia = SHA2(@password,256)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0; // Si count > 0, las credenciales son correctas
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }

        // Método para manejar el login
        public void ProcesarLogin(string username, string password, Form currentForm)
        {
            try
            {
                bool isAuthenticated = ValidarUsuario(username, password);

                if (isAuthenticated)
                {
                    // Si el login es exitoso, mostrar Form2
                    Menu menu = new Menu(username);
                    menu.Show();
                    currentForm.Hide(); // Ocultar Form1
                }
                else
                {
                    // Si las credenciales son incorrectas, mostrar un mensaje
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Método para limpiar los campos de usuario y contraseña
        public void LimpiarCampos(TextBox txtUsuario, TextBox txtPassword)
        {
            txtUsuario.Clear();
            txtPassword.Clear();
        }

        // Método para abrir el formulario de registro
        public void AbrirFormularioRegistro(Form currentForm)
        {

            Registrar registrar = new Registrar();
            registrar.Show();
            currentForm.Hide(); // Ocultar Form1
        }
    }
}
