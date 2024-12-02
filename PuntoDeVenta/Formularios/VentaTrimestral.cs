using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PuntoDeVenta.Clases; // Asegúrate de incluir este espacio de nombres

namespace PuntoDeVenta.Formularios
{
    public partial class VentaTrimestral : Form
    {
        private string connectionString = "server=localhost;database=tarea;user=root;password=root;";
        VentaTrimestral ventaTrimestral = new VentaTrimestral();

        public VentaTrimestral()
        {
            InitializeComponent();
            CargarOpcionesComboBox(); // Método para llenar las opciones del ComboBox
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                comboBoxAnio.Items.Add(i);
            }
            comboBoxAnio.SelectedIndex = 0;
        }

        private void CargarOpcionesComboBox()
        {
            
        }

        private void btnGraReporte_Click(object sender, EventArgs e)
        {


            VentaTrimestral ventaTrimestral = new VentaTrimestral();
            var ventas = ventaTrimestral.ObtenerVentasTrimestrales(anioSeleccionado);

            // Limpiar el DataGridView
            dataGridViewReporte.Rows.Clear();
            dataGridViewReporte.Columns.Clear();

            // Configurar columnas
            dataGridViewReporte.Columns.Add("NombreProducto", "Producto");
            dataGridViewReporte.Columns.Add("Trim1", "Trim. 1");
            dataGridViewReporte.Columns.Add("Trim2", "Trim. 2");
            dataGridViewReporte.Columns.Add("Trim3", "Trim. 3");
            dataGridViewReporte.Columns.Add("Trim4", "Trim. 4");

            // Agregar filas
            foreach (var producto in ventas)
            {
                dataGridViewReporte.Rows.Add(
                    producto["NombreProducto"],
                    producto["Trim1"],
                    producto["Trim2"],
                    producto["Trim3"],
                    producto["Trim4"]
                );
            }
        }

        public List<Dictionary<string, object>> ObtenerVentasTrimestrales(int anio)
        {
            var ventasTrimestrales = new List<Dictionary<string, object>>();

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                string query = @"
             
            SELECT p.Nombre AS Producto,
    SUM(dv.cantidadProductos) AS TotalVendidos
FROM detallesventa dv, productos p
WHERE p.Nombre = p.Nombre
GROUP BY  p.Codigo, p.Nombre;";

                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@anio", anio);

                conexion.Open();
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new Dictionary<string, object>
                    {
                        { "NombreProducto", reader["NombreProducto"].ToString() },
                        { "Trim1", Convert.ToInt32(reader["Trim1"]) },
                        { "Trim2", Convert.ToInt32(reader["Trim2"]) },
                        { "Trim3", Convert.ToInt32(reader["Trim3"]) },
                        { "Trim4", Convert.ToInt32(reader["Trim4"]) }
                    };
                        ventasTrimestrales.Add(producto);
                    }
                }
            }

            return ventasTrimestrales;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void btnregreso_Click(object sender, EventArgs e)
        {
            TipoDeReporte tipoDeReporte = new TipoDeReporte();
            tipoDeReporte.Show();
            this.Close();
        }

        private void dataGridVieWReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}


