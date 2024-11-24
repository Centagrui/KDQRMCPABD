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
    public partial class ReporteVentas : Form
    {
      

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDownAño_ValueChanged(object sender, EventArgs e)
        {

            numericUpDownAño.Minimum = 1;  // El valor mínimo es 1 (enero)
            numericUpDownAño.Maximum = 12; // El valor máximo es 12 (diciembre)
            numericUpDownAño.Value = 1;    // Inicialmente, el valor puede ser 1 (enero)

            // También puedes personalizar el incremento
            numericUpDownAño.Increment = 1; // Incrementar de uno en uno

        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {

        }
    }
}
