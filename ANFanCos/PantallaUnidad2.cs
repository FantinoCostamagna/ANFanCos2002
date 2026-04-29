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

        void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxMETODO.SelectedItem.ToString() == "Método: Gauss-Jordan")
            {
                int dimension = int.Parse(txtIngresarDim.Text);

                int columnaSeparadora = dimension; // última columna (resultados)

                int espacioExtra = 40; // separación entre matriz y resultados

                pnlMatriz.Controls.Clear(); // limpiar matriz anterior

                int tamaño = 100; // tamaño de cada celda
                int espacio = 10;

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < (dimension + 1); j++) // DIMENSION + 1 , Para agregar la columna de resultados
                    {
                        TextBox txt = new TextBox();

                        txt.Width = tamaño;
                        txt.Height = tamaño;
                        txt.TextAlign = HorizontalAlignment.Center;


                        int x = j * (tamaño + espacio);

                        // si es la columna de resultados, agrego espacio extra
                        if (j == columnaSeparadora)
                        {
                            x += espacioExtra;
                        }

                        // Posición
                        txt.Left = x;
                        txt.Top = i * (tamaño + espacio);

                        // Color
                        txt.BackColor = (i == j) ? Color.LightBlue : Color.Beige;
                        txt.BackColor = (j == columnaSeparadora) ? Color.LightYellow : txt.BackColor; // Columna de resultados en amarillo

                        pnlMatriz.Controls.Add(txt);
                    }


                }
            }
        }

        void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaMenú pantallaMenú = new PantallaMenú();
            pantallaMenú.ShowDialog();
            this.Close();
        }

        void btnCALCULAR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIngresarDim.Text) ||
            (comboBoxMETODO.SelectedIndex == -1) ||
            string.IsNullOrWhiteSpace(txtIngresartoler.Text))
            //string.IsNullOrWhiteSpace(txtIngresarIterac.Text) || Para cuando hagamos el Gauss seidel, lo ponemos dentro del if (comboboxmetodo = "gauss seidel")
            {
                MessageBox.Show("Tenés que completar todos los datos y elegir el método");
                return;
            }

            if (comboBoxMETODO.SelectedItem.ToString() == "Método: Gauss-Jordan")
            {
                GaussJordan();
            }
            else if (comboBoxMETODO.SelectedItem.ToString() == "Método: GaussSeidel")
            {
                GaussSeidel();
            }



        }

        void GaussJordan()
        {
            int n = int.Parse(txtIngresarDim.Text);
            double[,] matriz = new double[n, n + 1];

            var controles = pnlMatriz.Controls.OfType<TextBox>().ToList();

            // 1. LEER DATOS
            int contador = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (!double.TryParse(controles[contador].Text, out matriz[i, j]))
                        matriz[i, j] = 0;
                    contador++;
                }
            }


            for (int rowDiag = 0; rowDiag < n; rowDiag++)
            {
                double coefDiag = matriz[rowDiag, rowDiag];


                if (Math.Abs(coefDiag) < 1e-10) continue;

                for (int j = 0; j < n + 1; j++)
                    matriz[rowDiag, j] /= coefDiag;

                for (int row = 0; row < n; row++)
                {
                    if (row != rowDiag)
                    {
                        double coefCero = matriz[row, rowDiag];
                        for (int j = 0; j < n + 1; j++)
                        {
                            matriz[row, j] -= coefCero * matriz[rowDiag, j];
                        }
                    }
                }
            }

            // 3. ACTUALIZAR INTERFAZ Y CAMBIAR COLOR A ROJO
            contador = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {

                    controles[contador].Text = Math.Round(matriz[i, j], 4).ToString();


                    if (j == n)
                    {
                        controles[contador].BackColor = Color.IndianRed;
                        controles[contador].ForeColor = Color.White;
                    }

                    contador++;
                }
            }
        }
        void GaussSeidel()
        {
            // Implementación del método 
        }
    }

}

