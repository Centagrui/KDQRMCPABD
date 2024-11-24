using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.Formularios;

namespace PuntoDeVenta
{
    public partial class Menu : Form
    {

        // Variable para almacenar el nombre de usuario
        private string username;

        // Constructor del formulario de menú que recibe el nombre de usuario
        public Menu(string username)
        {
            InitializeComponent();
            this.username = username;  // Guardamos el nombre de usuario
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            
            // Crear una nueva instancia de FormVenta y pasar el nombre de usuario
            Ventas ventas = new Ventas(username);
            ventas.Show();
            this.Hide();
            this.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Show();
            // Crear una nueva instancia de la ventana AgregarProducto
            CRUDProducto agregarProducto = new CRUDProducto();

            // Mostrar la ventana AgregarProducto
            agregarProducto.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            CrudEmpleados empleados = new CrudEmpleados();
            empleados.Show();
            this.Hide();
            this.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            CrudClientes clientes = new CrudClientes();
            clientes.Show();
            this.Hide();
            this.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            ReporteVentas reporte = new ReporteVentas();
            reporte.Show();
              this.Close();
            
            
        }

    }
}
