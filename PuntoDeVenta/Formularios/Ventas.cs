using MySql.Data.MySqlClient;
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
using PuntoDeVenta.Clases;
using static PuntoDeVenta.Clases.DetallesDeVenta;

namespace PuntoDeVenta
{
    public partial class Ventas : Form
    {
        public Ventas(String username)
        {
            InitializeComponent();
            // Asocia el evento KeyDown del TextBox al método TxtCodigo_KeyDown
            TxtCodigo.KeyDown += new KeyEventHandler(TxtCodigo_KeyDown);

            // Asignamos el valor de nombreUsuario al TextBox txtUsuario
            txtUsuario.Text = username;

        }
        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar_Click(sender, e);
            }
        }

        private ConexionBD conexionBD;

        public Ventas()
        {
            conexionBD = new ConexionBD();
        }
        // Contador para el número del producto en el DataGridView
        private int contadorProducto = 1;

        // Lista para almacenar los productos (opcional, si deseas manipular los datos de forma interna)
        private List<Producto> listaProductos = new List<Producto>();


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem.ToString() == "Cliente Mayorista")
            {
                // Mostrar mensaje para que ingrese la clave
                MessageBox.Show("Por favor, ingresa la clave del cliente mayorista.");

                // Habilitar la caja de texto txtClave y el botón btnValidar
                txtClave.Enabled = true;
                btnValidar.Enabled = true;

                // Limpiar el campo de nombre del cliente
                txtNombreCliente.Text = "";

            }
            else if (cmbCliente.SelectedItem.ToString() == "Cliente Mostrador")
            {
                // Deshabilitar la caja de texto txtClave y el botón btnValidar
                txtClave.Enabled = false;
                btnValidar.Enabled = false;

                // Colocar "Cliente Mostrador" en el campo de nombre
                txtNombreCliente.Text = "Cliente Mostrador";

                // Limpiar la caja de clave
                txtClave.Clear();
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación antes de cancelar
            var resultado = MessageBox.Show(
                "¿Estás seguro de que deseas cancelar la venta? Todos los datos se perderán.",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Si el usuario hace clic en "Sí", cancelar la venta
            if (resultado == DialogResult.Yes)
            {
                // Limpiar todas las filas del DataGridView
                dataGridView1.Rows.Clear();

                // Limpiar el TextBox de total
                txtTotal.Clear();

                // Limpiar el campo de código del producto
                TxtCodigo.Clear();

                // Restablecer contador de productos (si lo tienes)
                contadorProducto = 1;

                // Limpiar cualquier otro campo de entrada, como nombre de cliente (si lo tienes)
                txtNombreCliente.Clear();
            }
            // Si el usuario hace clic en "No", no hacer nada

        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string codigoProducto = TxtCodigo.Text; 
            if (string.IsNullOrEmpty(codigoProducto))
            {
                MessageBox.Show("Por favor, ingrese el código del producto.");
                return;
            }
            // Crear una instancia del repositorio de productos y buscar el producto en la base de datos
            ProductoRepository repo = new ProductoRepository();
            Producto producto = repo.ObtenerProductoPorCodigo(codigoProducto);

            // Si el producto no se encuentra
            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            // Obtener la cantidad desde el TextBox, si no se ingresa nada, usar 1 por defecto
            int cantidad = 1;
            if (int.TryParse(txtCantidad.Text, out int cantidadIngresada))
            {
                cantidad = cantidadIngresada;
            }
            decimal importe = cantidad * producto.Precio;
            DataGridViewRow nuevaFila = new DataGridViewRow();

            // Colocar los datos en las celdas correspondientes
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = contadorProducto }); // No.producto
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = producto.Nombre });  // Codigo
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = producto.Codigo }); // Nombre
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = producto.Descripcion }); // Descripcion
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = cantidad }); // Cantidad (del TextBox o 1 por defecto)
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = producto.Precio }); // PrecioUnitario
            nuevaFila.Cells.Add(new DataGridViewTextBoxCell { Value = importe }); // Importe (cantidad * precio)                                                                             
            dataGridView1.Rows.Add(nuevaFila);

            // Incrementar el contador para el siguiente producto
            contadorProducto++;

            ActualizarTotal();
      
            txtCantidad.Clear();
            TxtCodigo.Clear();
            TxtCodigo.Focus(); 


        }
        private void ActualizarTotal()
        {
            decimal totalVenta = 0m;

            // Iterar sobre todas las filas del DataGridView para calcular el total original
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Importe"].Value != null)
                {
                    decimal importe = Convert.ToDecimal(row.Cells["Importe"].Value);
                    totalVenta += importe;
                }
            }

            // Mostrar el total en txtTotal (sin descuento)
            txtTotal.Text = totalVenta.ToString("C2");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres terminar la venta?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Calcular el total de la venta
                decimal totalVenta = 0;
                List<ProductVenta> productosVendidos = new List<ProductVenta>(); // Lista para almacenar los productos vendidos
                int cantidadTotalProductos = 0;
                // Recorrer las filas del DataGridView para obtener los productos y calcular el total
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.IsNewRow) continue; // Ignorar la fila nueva vacía

                    string codigoProducto = fila.Cells["Codigo"].Value.ToString();
                    string nombreProducto = fila.Cells["Nombre"].Value.ToString();
                    decimal cantidad = Convert.ToDecimal(fila.Cells["Cantidad"].Value);
                    decimal precio = Convert.ToDecimal(fila.Cells["Precio"].Value);
                    decimal importe = Convert.ToDecimal(fila.Cells["Importe"].Value);
                    totalVenta += importe;
                    cantidadTotalProductos += (int)cantidad;

                    // Crear un objeto para almacenar los datos del producto
                    productosVendidos.Add(new ProductVenta
                    {
                        CodigoProducto = codigoProducto,
                        NombreProducto = nombreProducto,
                        Cantidad = cantidad,
                        Precio = precio,
                        Importe = importe
                    });
                }
                txtTotal.Text = totalVenta.ToString("C");
                ActualizarExistencias(productosVendidos);
                GuardarDetallesVenta(txtUsuario.Text, txtNombreCliente.Text, cantidadTotalProductos, totalVenta);
                ImprimirTicket(productosVendidos, totalVenta);
                LimpiarVenta();
            }
        }

        // Método para limpiar los controles después de terminar la venta
        private void LimpiarVenta()
        {
            // Limpiar el DataGridView
            dataGridView1.Rows.Clear();

            // Limpiar los TextBox
            txtTotal.Clear();
            txtNombreCliente.Clear();
            txtUsuario.Clear();
            txtClave.Clear();

            // Limpiar el ComboBox y restablecer a "Cliente Mostrador" como opción por defecto
            cmbCliente.SelectedIndex = 0;

            // Si usas el DateTimePicker, restablecer la fecha al valor actual
            fecha.Value = DateTime.Now;

            // Si tienes otros controles, también deberías limpiarlos, como los ComboBoxes, etc.

        }

      private void  ActualizarExistencias(List<ProductVenta> productosVendidos)
        {
            string connectionString = "server=localhost;database=tarea;user=root;password=root;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var transaction = conn.BeginTransaction();

                try
                {
                    foreach (var producto in productosVendidos)
                    {

                        // Consulta para reducir la existencia del producto en la base de datos
                        string query = "UPDATE Productos SET existencia = existencia - @cantidad WHERE codigo = @codigo";
                        MySqlCommand cmd = new MySqlCommand(query, conn, transaction);

                        // Parámetro de código del producto
                        cmd.Parameters.AddWithValue("@codigo", producto.CodigoProducto);
                        cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);


                        // Ejecutar la consulta para descontar cantidad de la existencia
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // Verificar que la consulta haya afectado al menos una fila
                        if (filasAfectadas == 0)
                        {
                            // Esto significa que no se encontró el producto con el código proporcionado
                            throw new Exception($"No se encontró el producto con código {producto.CodigoProducto}.");
                        }
                    }

                    // Si todo va bien, confirmar la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Si hay un error, revertir la transacción
                    transaction.Rollback();
                    MessageBox.Show("Error al procesar la venta: " + ex.Message);
                }
            }
        }
            private void ImprimirTicket(List<ProductVenta> productosVendidos, decimal totalVenta)
        {
            StringBuilder ticket = new StringBuilder();

            // Obtener los valores desde los controles de la interfaz de usuario
            //DateTime fecha = fecha.Value; // 'fecha' es el DateTimePicker, no el tipo DateTime
            string nombreEmpleado = txtUsuario.Text; // Nombre del empleado en txtUsuario
            string nombreCliente = txtNombreCliente.Text; // Nombre del cliente en txtNombreCliente
            decimal descuento = 0; // Inicializamos el descuento en 0
            decimal totalConDescuento = totalVenta; // Inicializamos con el valor del total

            // Si es cliente mayorista, aplicar descuento del 10%
            if (cmbCliente.SelectedItem.ToString() == "Cliente Mayorista")
            {
                descuento = totalVenta * 0.10m; // 10% de descuento
                totalConDescuento = totalVenta - descuento; // Total con descuento
            }

            // Calcular el IVA (16%)
            decimal iva = totalConDescuento * 0.16m; // 16% de IVA
            decimal totalConIva = totalConDescuento + iva; // Total con IVA incluido

            // Título del ticket
            ticket.AppendLine("******************* TICKET DE VENTA **********************************");
            //ticket.AppendLine($"Fecha: {fecha.ToString("dd/MM/yyyy")}");
            ticket.AppendLine($"Empleado: {nombreEmpleado}");
            ticket.AppendLine($"Cliente: {nombreCliente}");
            ticket.AppendLine("---------------------------------------------------------------------------");
            ticket.AppendLine("Producto\t           Cantidad\t      Precio\t            Importe");
            ticket.AppendLine("---------------------------------------------------------------------------");

            // Agregar los productos vendidos al ticket
            foreach (var producto in productosVendidos)
            {
                // Calcular el importe como Cantidad * Precio
                decimal importe = producto.Cantidad * producto.Precio;

                ticket.AppendLine($"{producto.NombreProducto}\t        {producto.Cantidad}\t        {producto.Precio:C}\t       {importe:C}");
            }

            ticket.AppendLine("---------------------------------------------------------------------------");

            // Mostrar el subtotal
            ticket.AppendLine($"Subtotal: {totalVenta:C}");

            // Mostrar el descuento (si aplica)
            if (descuento > 0)
            {
                ticket.AppendLine($"Descuento(10%):{descuento:C}");
            }
            else
            {
                ticket.AppendLine("Descuento(0%):");
            }

            // Mostrar el IVA
            ticket.AppendLine($"IVA (16%): {iva:C}");

            // Mostrar el total con IVA
            ticket.AppendLine($"Total con IVA: {totalConIva:C}");

            ticket.AppendLine("--------------------------------------------------------");
            ticket.AppendLine("Gracias por su compra!");
            ticket.AppendLine("*******************************************************");

            // Mostrar el ticket en un MessageBox
            MessageBox.Show(ticket.ToString(), "Resumen de la Venta");
        }

        private void GuardarDetallesVenta(string nombreEmpleado, string nombreCliente, int cantidadProductos, decimal totalVenta)
        {
            // Crear una instancia de la clase DetallesDeVenta
            DetallesDeVenta detallesDeVenta = new DetallesDeVenta();

            // Llamar al método GuardarDetallesVenta de la clase DetallesDeVenta
            detallesDeVenta.GuardarDetallesVenta(nombreEmpleado, nombreCliente, cantidadProductos, totalVenta);

            // Aquí puedes agregar más lógica si es necesario, como mostrar un mensaje de éxito
            MessageBox.Show("Detalles de la venta guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void txtEliminarProducto_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Confirmar con el usuario si realmente desea eliminar el producto
                var resultado = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este producto de la venta?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    // Eliminar la fila seleccionada
                    foreach (DataGridViewRow fila in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.Remove(fila);  // Eliminar la fila
                    }

                    // Recalcular el total de la venta después de la eliminación
                    RecalcularTotal();
                }
            }
            else
            {
                // Si no hay fila seleccionada, mostrar un mensaje
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
            }
        }
        private void RecalcularTotal()
        {
            decimal totalVenta = 0m;

            // Sumar los precios de todos los productos en el DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Importe"].Value != null)
                {
                    decimal importe = Convert.ToDecimal(row.Cells["Importe"].Value);
                    totalVenta += importe;  // Sumar el precio del producto
                }
            }

            // Mostrar el total actualizado en el TextBox o Label
            txtTotal.Text = totalVenta.ToString("C2");  // Formato de moneda
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            // Validar si se ingresó la clave
            string clave = txtClave.Text;

            if (string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, ingresa la clave del cliente mayorista.");
                return;
            }

            // Consultar la base de datos para obtener el nombre y apellido
            string nombreCliente = ObtenerNombreClienteMayorista(clave);

            if (!string.IsNullOrEmpty(nombreCliente))
            {
                // Si la clave es válida, colocar el nombre del cliente en txtNombreCliente
                txtNombreCliente.Text = nombreCliente;
            }
            else
            {
                // Si no se encuentra el cliente, mostrar un mensaje de error
                MessageBox.Show("La clave del cliente mayorista no es válida.");
            }
        }

        private string ObtenerNombreClienteMayorista(string clave)
        {
            // Crea una instancia de la clase DetallesDeVenta
            DetallesDeVenta detallesVenta = new DetallesDeVenta();

            // Llama al método ObtenerNombreClientePorClave a través de la instancia
            return detallesVenta.ObtenerNombreClientePorClave(clave);  // Llamada al método desde DetallesDeVenta
        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void fecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
   
    
}

                                                                           
public class ProductVenta
{
    public string CodigoProducto { get; set; }
    public string NombreProducto { get; set; }
    public decimal Importe{ get; set; }
    public decimal Precio { get; set; }
    public decimal Cantidad { get; set; }

}

