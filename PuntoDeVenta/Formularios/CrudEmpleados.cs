using MySqlX.XDevAPI;
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
  
    public partial class CrudEmpleados : Form
    {
        private empleados Empleados;
        public CrudEmpleados()
        {
            InitializeComponent();
            Empleados = new empleados();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigoBuscar = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(codigoBuscar))
            {
                MessageBox.Show("Por favor ingresa una contraseña para buscar.");
                return;
            }

            bool encontrado = Empleados.BuscarEmpleadoPorCodigo(codigoBuscar, txtNombre, txtApellido, txtDireccion, txtUsuario);

            // Si el empleado fue encontrado, los campos se llenan con los datos.
            if (!encontrado)
            {
                // Si no se encuentra el producto, limpiar los campos de texto
                txtNombre.Clear();
                txtApellido.Clear();
                txtDireccion.Clear();
                txtUsuario.Clear();
            }
        }

        private void CrudEmpleados_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string usuario = txtUsuario.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, Primero ingresa el password y da clic en (BUSCAR).");
                return;
            }

            // Realizar la modificación en la base de datos
            bool exito = Empleados.ModificarEmpleado(nombre, apellido, direccion, usuario);

            if (exito)
            {
                MessageBox.Show("Empleado modificado exitosamente.");

                // Limpiar los campos de texto
                LimpiarCampos();

                // Mostrar el empleadoActualizado en el DataGridView
                Empleados.AgregarEmpleadoAlGrid(dataGridView1, nombre, apellido, direccion, usuario);
            }
            else
            {
                MessageBox.Show("Ocurrió un error al modificar el empleado.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscar.Text.Trim();

            // Verificar si hay algo escrito en txtBuscar o si hay una fila seleccionada en el DataGridView (pero no ambos)
            if (string.IsNullOrEmpty(codigo) && dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, ingresa un password del empleado o selecciona un empleado de la tabla.");
                return;
            }

            // Si hay un código en txtBuscar, usarlo para eliminar el empleado
            if (!string.IsNullOrEmpty(codigo))
            {
                // Llamar a la función para eliminar el empleado pasando el código y el DataGridView
                bool exito = Empleados.EliminarEmpleado(codigo, dataGridView1);

                if (exito)
                {
                    // Limpiar los campos después de la eliminación
                    LimpiarCampos();
                }
            }
        }
            private void LimpiarCampos()
            {
                txtNombre.Clear();
                txtApellido.Clear();
                txtDireccion.Clear();
                txtUsuario.Clear();
                txtBuscar.Clear();
            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            Registrar registrar = new Registrar();
            registrar.Show();
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
