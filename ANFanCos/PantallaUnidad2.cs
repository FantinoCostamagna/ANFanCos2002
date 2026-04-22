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
            int dimension = int.Parse(txtIngresarDim.Text);

            pnlMatriz.Controls.Clear(); // limpiar matriz anterior

            int tamaño = 80; // tamaño de cada celda
            int espacio = 10;

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < (dimension + 1); j++) // DIMENSION + 1 , Para agregar la columna de resultados
                {
                    TextBox txt = new TextBox();

                    txt.Width = tamaño;
                    txt.Height = tamaño;
                    txt.TextAlign = HorizontalAlignment.Center;

                    // Posición
                    txt.Left = j * (tamaño + espacio);
                    txt.Top = i * (tamaño + espacio);

                   
                    // Color
                    txt.BackColor = (i == j) ? Color.LightBlue : Color.Beige;

                    pnlMatriz.Controls.Add(txt);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaMenú pantallaMenú = new PantallaMenú();
            pantallaMenú.ShowDialog();
            this.Close();
        }

        private void btnCALCULAR_Click(object sender, EventArgs e)
        {
            int dimension = int.Parse(txtIngresarDim.Text);

            pnlMatriz.Controls.Clear(); // limpiar matriz anterior

            int tamaño = 80; // tamaño de cada celda
            int espacio = 10;

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    TextBox txt = new TextBox();

                    txt.Width = tamaño;
                    txt.Height = tamaño;
                    txt.TextAlign = HorizontalAlignment.Center;

                    // Posición
                    txt.Left = j * (tamaño + espacio);
                    txt.Top = i * (tamaño + espacio);

                    // Valores iniciales (como tu imagen)
                    txt.Text = (i == j) ? "1" : "0";

                    // Color
                    txt.BackColor = (i == j) ? Color.LightBlue : Color.Beige;

                    pnlMatriz.Controls.Add(txt);
                }
            }
        }
    }
}
