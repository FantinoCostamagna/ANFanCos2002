using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANFanCos
{
    public partial class PantallaUnidad2 : Form
    {
        public PantallaUnidad2()
        {
            InitializeComponent();
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMETODO.SelectedItem.ToString() == "Método: Gauss-Jordan")
            {
                txtIngresarIterac.Visible = false; // Oculta el TextBox
                lblIterac.Visible = false; // Oculta el Label
            }
            else
            {
                txtIngresarIterac.Visible = true; // Lo muestra
                lblIterac.Visible = true;// Lo muestra
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaMenú pantallaMenú = new PantallaMenú();
            pantallaMenú.ShowDialog();
            this.Close();
        }
    }
}
