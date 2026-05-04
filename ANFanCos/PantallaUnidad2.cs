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
            if (comboBoxMETODO.SelectedItem.ToString() == "Método: Gauss-Jordan" || comboBoxMETODO.SelectedItem.ToString() == "Método: Gauss-Seidel")
            {
                double dimension = double.Parse(txtIngresarDim.Text);

                double columnaSeparadora = dimension; // última columna (resultados)

                int espacioExtra = 10; // separación entre matriz y resultados

                pnlMatriz.Controls.Clear(); // limpiar matriz anterior

                int tamaño = 75; // tamaño de cada celda
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

            {
                MessageBox.Show("Tenés que completar todos los datos y elegir el método");
                return;
            }

            if (comboBoxMETODO.SelectedItem.ToString() == "Método: Gauss-Jordan")
            {
                GaussJordan();
            }
            else if (comboBoxMETODO.SelectedItem.ToString() == "Método: Gauss-Seidel" && !string.IsNullOrWhiteSpace(txtIngresarIterac.Text))
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
            bool esSolucion = false;

            double resultado = 0;
            double tolerancia = double.Parse(txtIngresartoler.Text);
            int n = int.Parse(txtIngresarDim.Text);
            double[,] matriz = new double[n, n + 1];
            double[] vectorResultado = new double[n];
            vectorResultado.Initialize();
            double[] vectorAnterior = new double[n];

            
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

            while (contador <= 100 && !esSolucion)
            {
                contador++;
                if (contador > 1)
                {
                    vectorResultado.CopyTo(vectorAnterior, 0); // guardar resultado anterior para comparar
                }

                for (int row = 0; row < n; row++)
                {
                    resultado = matriz[row, n]; // resultado actual
                    double coeficienteIncognita = matriz[row, row]; // coeficiente de la incógnita actual
                    for (int col = 0; col < n; col++)
                    {
                        if (row != col)
                        {
                            resultado = resultado - matriz[row, col] * vectorResultado[col]; // restar contribución de otras incógnitas
                        }   
                    }
                    coeficienteIncognita = resultado / coeficienteIncognita; // dividir por el coeficiente para obtener nuevo valor}
                    vectorResultado[row] = coeficienteIncognita; // actualizar valor de la incógnita
                }
                double contadorMismoResultado = 0;
                double errorRelativo = 0;

                for (int i = 0; i < n; i++)
                {
                    errorRelativo = Math.Abs((vectorResultado[i] - vectorAnterior[i]) / vectorResultado[i]);

                    if (errorRelativo < tolerancia)
                        contadorMismoResultado++;
                }

                esSolucion = contadorMismoResultado == n; // si todas las incógnitas cumplen la condición, tenemos solución

            }
            
            if (contador <= 100)
            {
                for (int i = 0; i < n; i++)
                {
                    matriz[i, n]= vectorResultado[i]; // actualizar columna de resultados con solución encontrada
                }
            }       
            else
            {
                MessageBox.Show("Superó iteraciones");// no se encontró solución en el límite de iteraciones
            }
                

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
    }

}

