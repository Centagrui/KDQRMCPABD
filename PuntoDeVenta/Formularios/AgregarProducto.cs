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
    public partial class CRUDProducto : Form
    {
       
        private AgregarProduc agregarProduc;

        public CRUDProducto()
        {
            InitializeComponent();
            agregarProduc = new AgregarProduc(); // Pasa tu cadena de conexión
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los cuadros de texto
            string nombre = txtNombre.Text.Trim();
            string codigo = txtCodigo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            string precio = txtPrecio.Text.Trim();
            string existencia = txtExistencia.Text.Trim();

            // Llamar al método de la clase ProductoController para agregar el producto
            agregarProduc.AgregarProducto(nombre, codigo, descripcion, precio, existencia, dataGridView1);

            txtNombre.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtExistencia.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigoBuscar = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(codigoBuscar))
            {
                MessageBox.Show("Por favor ingresa un código para buscar.");
                return;
            }

            bool encontrado = agregarProduc.BuscarProductoPorCodigo(codigoBuscar, txtNombre, txtCodigo, txtDescripcion, txtPrecio, txtExistencia);

            // Si el producto fue encontrado, los campos se llenan con los datos.
            if (!encontrado)
            {
                // Si no se encuentra el producto, limpiar los campos de texto
                txtNombre.Clear();
                txtCodigo.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
                txtExistencia.Clear();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            decimal precio;
            int existencia;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion) || !decimal.TryParse(txtPrecio.Text, out precio) || !int.TryParse(txtExistencia.Text, out existencia))
            {
                MessageBox.Show("Por favor, Primero ingresa el código y da lic en (BUSCAR).");
                return;
            }

            // Realizar la modificación en la base de datos
            bool exito = agregarProduc.ModificarProducto(codigo, nombre, descripcion, precio, existencia);

            if (exito)
            {
                MessageBox.Show("Producto modificado exitosamente.");

                // Limpiar los campos de texto
                LimpiarCampos();

                // Mostrar el producto actualizado en el DataGridView
                agregarProduc.AgregarProductoAlGrid(dataGridView1, codigo, nombre, descripcion, precio, existencia);
            }
            else
            {
                MessageBox.Show("Ocurrió un error al modificar el producto.");
            }
        }

        // Método para limpiar los campos de texto después de modificar o agregar un producto
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtExistencia.Clear();
            txtBuscar.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();

            // Verificar si hay algo escrito en txtCodigo o si hay una fila seleccionada en el DataGridView (pero no ambos)
            if (string.IsNullOrEmpty(codigo) && dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, ingresa un código de producto o selecciona un producto de la tabla.");
                return;
            }

            // Si hay un código en txtCodigo, usarlo para eliminar el producto
            if (!string.IsNullOrEmpty(codigo))
            {
                // Llamar a la función para eliminar el producto pasando el código y el DataGridView
                bool exito = agregarProduc.EliminarProducto(codigo, dataGridView1);

                if (exito)
                {
                    // Limpiar los campos después de la eliminación
                    LimpiarCampos();
                }
            }
            // Si no hay código, pero se seleccionó una fila en el grid
            else if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el código del producto seleccionado en el DataGridView
                string codigoSeleccionado = dataGridView1.SelectedRows[0].Cells["Codigo"].Value.ToString();

                // Llamar a la función para eliminar el producto pasando el código y el DataGridView
                bool exito = agregarProduc.EliminarProducto(codigoSeleccionado, dataGridView1);

                if (exito)
                {
                    // Limpiar los campos después de la eliminación
                    LimpiarCampos();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

