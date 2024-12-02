    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;
    using PuntoDeVenta.Clases;


    namespace PuntoDeVenta.Formularios
    {

    public partial class VentaTrimestralForm : Form
    {
        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            string connectionString = "server=localhost;database=tarea;user=root;password=root;";
            string query = @"
                SELECT 
                    Nombre_producto,
                    SUM(CASE WHEN MONTH(fecha) BETWEEN 1 AND 3 THEN cant_producto ELSE 0 END) AS Trimestre1,
                    SUM(CASE WHEN MONTH(fecha) BETWEEN 4 AND 6 THEN cant_producto ELSE 0 END) AS Trimestre2,
                    SUM(CASE WHEN MONTH(fecha) BETWEEN 7 AND 9 THEN cant_producto ELSE 0 END) AS Trimestre3,
                    SUM(CASE WHEN MONTH(fecha) BETWEEN 10 AND 12 THEN cant_producto ELSE 0 END) AS Trimestre4
                FROM detalleproducto
                JOIN productos ON detalleproducto.Nombre_producto = productos.Nombre
                WHERE YEAR(fecha) = @anio
                GROUP BY Nombre_producto
                ORDER BY Nombre_producto;";

            // Obtén el año desde el control (o usa un valor fijo si no hay control).
            int anio = 2024; // Cambiar por el valor dinámico si se agrega un NumericUpDown.

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@anio", anio);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // Llena la tabla con los resultados.
                    adapter.Fill(dataTable);

                    // Asigna los datos al DataGridView.
                    dgvReporte.DataSource = dataTable;

                    // Ajusta los nombres de las columnas para que sean más amigables.
                    dgvReporte.Columns[0].HeaderText = "Producto";
                    dgvReporte.Columns[1].HeaderText = "Trimestre 1";
                    dgvReporte.Columns[2].HeaderText = "Trimestre 2";
                    dgvReporte.Columns[3].HeaderText = "Trimestre 3";
                    dgvReporte.Columns[4].HeaderText = "Trimestre 4";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}


