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
            if ((comboBoxMETODO.SelectedItem.ToString() == "Método: Gauss-Jordan" ||
                comboBoxMETODO.SelectedItem.ToString() == "Método: Gauss-Seidel") &&
                !string.IsNullOrWhiteSpace(txtIngresarDim.Text))
            {
                int dimension = int.Parse(txtIngresarDim.Text);

                int tamaño = 80;
                int espacio = 10;
                int espacioExtra = 40;

                int columnaSeparadora = dimension; // última columna (resultados)

                pnlMatriz.Controls.Clear();

                // Calcular ancho total (incluye columna extra y separación)
                int anchoTotal = (dimension + 1) * (tamaño + espacio) + espacioExtra;

                // Calcular alto total
                int altoTotal = dimension * (tamaño + espacio);

                // Offsets para centrar
                int offsetX = (pnlMatriz.Width - anchoTotal) / 2;
                int offsetY = (pnlMatriz.Height - altoTotal) / 2;

                // Por si no entra en el panel
                pnlMatriz.AutoScroll = true;

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < (dimension + 1); j++) // +1 por resultados
                    {
                        TextBox txt = new TextBox();

                        txt.Width = tamaño;
                        txt.Height = tamaño;
                        txt.TextAlign = HorizontalAlignment.Center;

                        // Posición X (centrada)
                        int x = offsetX + j * (tamaño + espacio);

                        // Separación extra antes de la columna de resultados
                        if (j == columnaSeparadora)
                        {
                            x += espacioExtra;
                        }

                        // Posición Y (centrada)
                        int y = offsetY + i * (tamaño + espacio);

                        txt.Left = x;
                        txt.Top = y;

                        // Colores
                        if (j == columnaSeparadora)
                            txt.BackColor = Color.LightYellow; // resultados
                        else if (i == j)
                            txt.BackColor = Color.LightBlue;   // diagonal
                        else
                            txt.BackColor = Color.Beige;

                        pnlMatriz.Controls.Add(txt);
                    }
                }
            }
            else
            {
                MessageBox.Show("Tenés que elegir un método e ingresar dimensión para generar la matriz");
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
                    coeficienteIncognita = resultado / coeficienteIncognita; // dividir por el coeficiente para obtener nuevo valor
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
                    matriz[i, n] = vectorResultado[i]; // actualizar columna de resultados con solución encontrada
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

