using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PuntoDeVenta
{
    public partial class Form1 : Form
    {
        private Login login;

        public Form1()
        {
            InitializeComponent();
            login = new Login(); // Instanciamos el servicio de login
        }

        // Acción del botón "Aceptar" (Login)
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string username = txtNombre.Text;
            string password = txtPassword.Text;
            
            // Llamamos al método de LoginService para procesar el login
            login.ProcesarLogin(username, password, this);
        }

        // Otras acciones del formulario (si es necesario)
        private void Form1_Load(object sender, EventArgs e)
        {
            // Lógica cuando se carga el formulario (si es necesario)
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Llamamos al método LimpiarCampos
            login.LimpiarCampos(txtNombre, txtPassword);
        }
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            // Llamamos al método AbrirFormulario
            login.AbrirFormularioRegistro(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
