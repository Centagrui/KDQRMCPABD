using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos de texto
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasenia.Text;
            string repetir = txtRepetir.Text;

            // Crear una instancia de la clase RegistroUsuario
            registroUsuario registro = new registroUsuario();

            // Llamar al método Registrar de la clase RegistroUsuario
            bool registroExitoso = registro.Registrar(nombre, apellido, direccion, usuario, contrasena, repetir);

            // Si el registro fue exitoso, el método ya maneja la acción de abrir el login y mostrar el mensaje
            if (registroExitoso)
            {
                // El código que se encuentra en la clase RegistroUsuario maneja el flujo posterior al registro
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje con las opciones de "Aceptar" y "Cancelar"
            DialogResult resultado = MessageBox.Show(
                "Selecciona (Si),si quieres salir de la ventana Registrar y cancelar el registro.\n" +
                "Selecciona (No), si solo quieres comenzar de nuevo el registro.",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Verificar el resultado del cuadro de mensaje
            if (resultado == DialogResult.Yes)
            {
                // Si el usuario selecciona "Aceptar", cerrar el formulario de registro
                this.Close();  // Cierra la ventana actual (Formulario de registro)
                               // Abrir el formulario de login
                Form1 formLogin = new Form1();  // Crear una nueva instancia de Form1 (Login)
                formLogin.Show();  // Mostrar el formulario de login
            }
            else
            {
                // Si el usuario selecciona "Cancelar", limpiar los campos de texto
                LimpiarCampos();  // Llamar a un método para limpiar los campos
            }
        }

        // Método para limpiar los campos
        private void LimpiarCampos()
        {
            // Limpiar los cuadros de texto en el formulario de registro
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtUsuario.Clear();
            txtContrasenia.Clear();
            txtRepetir.Clear();
        }

        private void Registrar_Load(object sender, EventArgs e)
        {

        }
    }
    
}
