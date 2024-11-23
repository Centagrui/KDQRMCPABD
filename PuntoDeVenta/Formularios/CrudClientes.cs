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

namespace PuntoDeVenta
{
 
    public partial class CrudClientes : Form
    {
        private clientes Clientes;
        public CrudClientes()
        {
            InitializeComponent();
            Clientes = new clientes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigoBuscar = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(codigoBuscar))
            {
                MessageBox.Show("Por favor ingresa una clave para buscar.");
                return;
            }

            bool encontrado = Clientes.BuscarClientePorCodigo(codigoBuscar, txtNombre, txtApellido, txtClave);
          
            // Si el producto fue encontrado, los campos se llenan con los datos.
            if (!encontrado)
            {
                // Si no se encuentra el producto, limpiar los campos de texto
                txtNombre.Clear();
                txtApellido.Clear();
                txtClave.Clear();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string clave = txtClave.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, Primero ingresa la clave y da clic en (BUSCAR).");
                return;
            }

            // Realizar la modificación en la base de datos
            bool exito = Clientes.ModificarCliente( nombre, apellido, clave);

            if (exito)
            {
                MessageBox.Show("Cliente modificado exitosamente.");

                // Limpiar los campos de texto
                LimpiarCampos();

                // Mostrar el clienteActualizado en el DataGridView
                Clientes.AgregarClienteAlGrid(dataGridView1,nombre, apellido, clave);
            }
            else
            {
                MessageBox.Show("Ocurrió un error al modificar el cliente.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigo = txtBuscar.Text.Trim();

            // Verificar si hay algo escrito en txtBuscar o si hay una fila seleccionada en el DataGridView (pero no ambos)
            if (string.IsNullOrEmpty(codigo) && dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, ingresa una Clave del cliente o selecciona un Cliente de la tabla.");
                return;
            }

            // Si hay un código en txtBuscar, usarlo para eliminar el cliente
            if (!string.IsNullOrEmpty(codigo))
            {
                // Llamar a la función para eliminar el cliente pasando el código y el DataGridView
                bool exito = Clientes.EliminarCliente(codigo, dataGridView1);

                if (exito)
                {
                    // Limpiar los campos después de la eliminación
                    LimpiarCampos();
                }
            }
            // Si no hay clave, pero se seleccionó una fila en el grid
            else if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la clave del producto seleccionado en el DataGridView
                string codigoSeleccionado = dataGridView1.SelectedRows[0].Cells["Clave"].Value.ToString();

                // Llamar a la función para eliminar el producto pasando el código y el DataGridView
                bool exito = Clientes.EliminarCliente(codigoSeleccionado, dataGridView1);

                if (exito)
                {
                    // Limpiar los campos después de la eliminación
                    LimpiarCampos();
                }
            }
        }

        private void CrudClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los cuadros de texto
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string clave = txtClave.Text.Trim();

            // Llamar al método de la clase ProductoController para agregar el producto
            Clientes.AgregarCliente(nombre, apellido, clave, dataGridView1);

            txtNombre.Clear();
            txtApellido.Clear();
            txtClave.Clear();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtClave.Clear();
            txtApellido.Clear();
            txtBuscar.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
