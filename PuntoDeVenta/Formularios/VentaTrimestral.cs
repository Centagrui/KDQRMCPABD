using System;
using System.Windows.Forms;
using PuntoDeVenta.Clases; // Asegúrate de incluir este espacio de nombres

namespace PuntoDeVenta.Formularios
{
    public partial class VentaTrimestral : Form
    {
        public VentaTrimestral()
        {
            InitializeComponent();
            CargarOpcionesComboBox(); // Método para llenar las opciones del ComboBox
        }

        private void CargarOpcionesComboBox()
        {
            // Agregar opciones al ComboBox
            comboBox1.Items.Add("1 trimestre");
            comboBox1.Items.Add("2 trimestre");
            comboBox1.Items.Add("3 trimestre");
            comboBox1.Items.Add("4 trimestre");
        }

        private void btnGraReporte_Click(object sender, EventArgs e)
        {
            // Lógica del botón "Generar Reporte"
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar la opción seleccionada en un mensaje (puedes agregar tu lógica aquí)
            string opcionSeleccionada = comboBox1.SelectedItem?.ToString();
            if (opcionSeleccionada != null)
            {
                MessageBox.Show("Seleccionaste: " + opcionSeleccionada);
            }
        }

        private void btnregreso_Click(object sender, EventArgs e)
        {
            // Lógica del botón "Regresar"
        }

        private void dataGridVieWReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica del evento CellContentClick del DataGridView
        }
    }
}


