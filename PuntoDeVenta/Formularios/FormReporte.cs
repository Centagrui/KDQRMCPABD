using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.Formularios
{
    public partial class FormReporte : Form
    {
        private ConexionBD conexionBD;

        public FormReporte()
        {
            InitializeComponent();
            conexionBD = new ConexionBD();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            Nombre_producto,
            SUM(CASE WHEN MONTH(fecha) BETWEEN 1 AND 3 THEN cant_producto ELSE 0 END) AS Trimestre1,
            SUM(CASE WHEN MONTH(fecha) BETWEEN 4 AND 6 THEN cant_producto ELSE 0 END) AS Trimestre2,
            SUM(CASE WHEN MONTH(fecha) BETWEEN 7 AND 9 THEN cant_producto ELSE 0 END) AS Trimestre3,
            SUM(CASE WHEN MONTH(fecha) BETWEEN 10 AND 12 THEN cant_producto ELSE 0 END) AS Trimestre4
        FROM detalleproducto
        JOIN productos ON detalleproducto.Nombre_producto = productos.Nombre
        WHERE YEAR(fecha) = @Anio
        GROUP BY Nombre_producto
        ORDER BY Nombre_producto;";

            try
            {
                using (MySqlConnection conn = conexionBD.ObtenerConexion())
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        // Agregar parámetro de año
                        command.Parameters.AddWithValue("@Anio", DateTime.Now.Year);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Llenar el DataGridView con los datos obtenidos
                            LlenarDataGridView(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }
        }

        private void LlenarDataGridView(MySqlDataReader reader)
        {
            // Limpiar datos anteriores
            dgvReporteTrimestral.Rows.Clear();

            // Leer los datos y agregarlos al DataGridView
            while (reader.Read())
            {
                dgvReporteTrimestral.Rows.Add(
                    reader.GetString("Nombre_producto"),
                    reader.GetInt32("Trimestre1"),
                    reader.GetInt32("Trimestre2"),
                    reader.GetInt32("Trimestre3"),
                    reader.GetInt32("Trimestre4")
                );
            }
        }

        private void dgvReporteTrimestral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica adicional para manejar clics en celdas, si es necesario
        }
    }

}
