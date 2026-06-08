using Calculus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ANFanCos
{
    public partial class PantallaUnidad3 : Form
    {
        private List<double[]> PuntosCargados = new List<double[]>();
        

        public PantallaUnidad3()
        {
            InitializeComponent();
            this.Load += InicializarWebView;
            // Cargar GeoGebra al presionar el boton calcular
            txtGrado.Visible = false;
            lblGrado.Visible = false;
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTIPO.SelectedItem.ToString() == "REGRESIÓN POLINOMIAL")
            {
                txtGrado.Visible = true;
                txtGrado.Enabled = true;
                lblGrado.Visible = true;
            }
            else
            {
                txtGrado.Enabled = false;
                lblGrado.Visible = false;
                txtGrado.Visible = false;
            }

        }

        private async void InicializarWebView(object sender, EventArgs e)
        {
            await webView22.EnsureCoreWebView2Async(null);
            webView22.CoreWebView2.Navigate("https://www.geogebra.org/classic#classic.c");
        }

        
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaMenú pantallaMenú = new PantallaMenú();
            pantallaMenú.ShowDialog();
            this.Close();
        }


        private void btnCALCULAR_Click(object sender, EventArgs e)
        {
            if (comboBoxTIPO.SelectedItem.ToString() == "REGRESIÓN LINEAL")
            {
                RegresíonLineal();
            }
            if (comboBoxTIPO.SelectedItem.ToString() == "REGRESIÓN POLINOMIAL")
            {
                RegresionPolinomial();
            }

        }

        void RegresíonLineal()
        {

            PuntosCargados.Clear();
            string input = txtPuntosIngresados.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Ingrese al menos un punto en el formato x,y (uno por línea).");
                return;
            }

            // Usamos InvariantCulture para aceptar punto como decimal siempre
            var culture = System.Globalization.CultureInfo.InvariantCulture;

            string[] lineas = input.Split(new char[] { '\n', '\r' },
                                          StringSplitOptions.RemoveEmptyEntries);

            foreach (string linea in lineas)
            {
                string[] partes = linea.Trim().Split(',');
                if (partes.Length == 2 &&
                    double.TryParse(partes[0].Trim(), System.Globalization.NumberStyles.Any, culture, out double x) &&
                    double.TryParse(partes[1].Trim(), System.Globalization.NumberStyles.Any, culture, out double y))
                {
                    PuntosCargados.Add(new double[] { x, y });
                }
                else
                {
                    MessageBox.Show($"Formato inválido en la línea: \"{linea}\"\n" +
                                    "Use el formato: x,y  (con punto como decimal, ej: 1.5,3.75)");
                    PuntosCargados.Clear();
                    return;
                }
            }

            double TOLERANCIA = double.Parse(txtTolerancia.Text);

            if (
                !string.IsNullOrWhiteSpace(txtIngresarint1.Text) ||
                !string.IsNullOrWhiteSpace(txtIngresarint2.Text) ||
                !string.IsNullOrWhiteSpace(txtPuntosIngresados.Text))
            {

                // Validar que haya puntos
                if (PuntosCargados.Count < 2)
                {
                    MessageBox.Show("Se necesitan al menos 2 puntos para calcular la regresión.\n" +
                                    "Cargue los puntos primero.");
                    return;
                }

                // ── Paso 1: n
                int n = PuntosCargados.Count;

                // ── Pasos 2-5: Sumatoria de X, Y, XY, X²
                double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;

                // foreach 1: sumatorias
                foreach (double[] punto in PuntosCargados)
                {
                    sumX += punto[0];
                    sumY += punto[1];
                    sumXY += punto[0] * punto[1];
                    sumX2 += punto[0] * punto[0];
                }

                // a1 y a0 VAN ACÁ, antes del segundo foreach
                double denominador = (n * sumX2) - (sumX * sumX);
                double a1 = ((n * sumXY) - (sumX * sumY)) / denominador;
                double a0 = (sumY / n) - a1 * (sumX / n);

                // foreach 2: st y sr
                double yPromedio = sumY / n;
                double st = 0, sr = 0;
                foreach (double[] punto in PuntosCargados)
                {
                    st += Math.Pow((yPromedio - punto[1]), 2);
                    sr += Math.Pow(((a1 * punto[0] + a0) - punto[1]), 2);
                }

                // r
                double r = 0;
                if (st > 0)
                {
                    r = Math.Sqrt((st - sr) / st) * 100;
                }


                // ── Paso 10: Resultados
                string funcion = $"y = {a1:F4}x + ({a0:F4})";
                string correlacion = $"r = {r:F4}%";
                string efectividad = r >= TOLERANCIA
                                       ? $"Buen ajuste ({r:F2}% ≥ {TOLERANCIA}%)"
                                       : $"Ajuste deficiente ({r:F2}% < {TOLERANCIA}%)";

                txtFuncionObtenida.Text = funcion;
                txtCorrelacion.Text = correlacion;
                txtEfectividadAjuste.Text = efectividad;
                txtPuntosIngresados.ReadOnly = true;
                txtPuntosIngresados.BackColor = Color.FromArgb(220, 220, 225);

                // Crear arreglo de coeficientes para la función lineal: coef[0] = a0 (constante), coef[1] = a1 (x)
                double[] funcionlineal = new double[] { a0, a1 };

                // Graficar en GeoGebra
                GraficarEnGeoGebraLineal(funcionlineal);
            }


        }



            void RegresionPolinomial()
            {
                PuntosCargados.Clear();
                string input = txtPuntosIngresados.Text.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Ingrese al menos un punto en el formato x,y (uno por línea).");
                    return;
                }

                // Usamos InvariantCulture para aceptar punto como decimal siempre
                var culture = System.Globalization.CultureInfo.InvariantCulture;

                string[] lineas = input.Split(new char[] { '\n', '\r' },
                                              StringSplitOptions.RemoveEmptyEntries);

                foreach (string linea in lineas)
                {
                    string[] partes = linea.Trim().Split(',');
                    if (partes.Length == 2 &&
                        double.TryParse(partes[0].Trim(), System.Globalization.NumberStyles.Any, culture, out double x) &&
                        double.TryParse(partes[1].Trim(), System.Globalization.NumberStyles.Any, culture, out double y))
                    {
                        PuntosCargados.Add(new double[] { x, y });
                    }
                    else
                    {
                        MessageBox.Show($"Formato inválido en la línea: \"{linea}\"\n" +
                                        "Use el formato: x,y  (con punto como decimal, ej: 1.5,3.75)");
                        PuntosCargados.Clear();
                        return;
                    }
                }

                GenerarMatrizPolinomial();
            }

            void GenerarMatrizPolinomial()
            {
                double[] vectorResultado = Array.Empty<double>();
                double TOLERANCIA = double.Parse(txtTolerancia.Text);
                int n = PuntosCargados.Count;
                int grado = int.Parse(txtGrado.Text);
                int dimension = grado + 1;

                double[,] matriz = new double[dimension, dimension + 1];

                // ── Bug 1 CORREGIDO: llenar la matriz con las sumatorias reales
                for (int row = 0; row < dimension; row++)
                {
                    for (int col = 0; col < dimension; col++)
                    {
                        double suma = 0;
                        foreach (double[] punto in PuntosCargados)
                            suma += Math.Pow(punto[0], row + col);
                        matriz[row, col] = suma;
                    }
                    // Columna independiente: Σ(y · x^i)
                    double sumaY = 0;
                    foreach (double[] punto in PuntosCargados)
                        sumaY += punto[1] * Math.Pow(punto[0], row);
                    matriz[row, dimension] = sumaY;
                }

                // ── Gauss-Jordan (sin cambios)
                for (int rowDiag = 0; rowDiag < dimension; rowDiag++)
                {
                    double coefDiag = matriz[rowDiag, rowDiag];
                    if (Math.Abs(coefDiag) < 1e-10) continue;

                    for (int j = 0; j < dimension + 1; j++)
                        matriz[rowDiag, j] /= coefDiag;

                    for (int row = 0; row < dimension; row++)
                    {
                        if (row != rowDiag)
                        {
                            double coefCero = matriz[row, rowDiag];
                            for (int j = 0; j < dimension + 1; j++)
                                matriz[row, j] -= coefCero * matriz[rowDiag, j];
                        }
                    }
                }

                //Obtener coeficientes
                vectorResultado = new double[dimension];
                for (int i = 0; i < dimension; i++)
                    vectorResultado[i] = matriz[i, dimension];

                //armar la función polinomial correctamente
                string funcion = "y = ";
                bool primero = true;
                for (int i = dimension - 1; i >= 0; i--)
                {
                    double ai = Math.Round(vectorResultado[i], 4);
                    if (ai == 0) continue;

                    if (!primero && ai > 0) funcion += " + ";
                    else if (!primero && ai < 0) funcion += " - ";

                    double absAi = Math.Abs(ai);
                    if (i == 0) funcion += $"{(primero ? ai : absAi):F4}";
                    else if (i == 1) funcion += $"{(primero ? ai : absAi):F4}x";
                    else funcion += $"{(primero ? ai : absAi):F4}x^{i}";

                    primero = false;
                }


                double sumYTotal = 0, mediaY = 0;
                foreach (double[] punto in PuntosCargados)
                    sumYTotal += punto[1];
                mediaY = sumYTotal / n;

                double sr = 0, st = 0;
                foreach (double[] punto in PuntosCargados)
                {
                    double yEval = 0;
                    for (int i = 0; i < dimension; i++)
                        yEval += vectorResultado[i] * Math.Pow(punto[0], i);

                    sr += Math.Pow(punto[1] - yEval, 2);
                    st += Math.Pow(punto[1] - mediaY, 2);
                }

                double r = st > 0 ? Math.Sqrt(Math.Max(0, (st - sr) / st)) * 100 : 0;

                string correlacion = $"r = {r:F4}%";
                string efectividad = r >= TOLERANCIA
                    ? $"Buen ajuste ({r:F2}% ≥ {TOLERANCIA}%)"
                    : $"Ajuste deficiente ({r:F2}% < {TOLERANCIA}%)";

                txtFuncionObtenida.Text = funcion;
                txtCorrelacion.Text = correlacion;
                txtEfectividadAjuste.Text = efectividad;
                txtPuntosIngresados.ReadOnly = true;
                txtPuntosIngresados.BackColor = Color.FromArgb(220, 220, 225);

                // Graficar en GeoGebra
                GraficarEnGeoGebraPolinomial(vectorResultado);
        }



        private void btnBorrarTodos_Click(object sender, EventArgs e)
        {
            txtPuntosIngresados.Clear();

        }

        private void btnBorrarUltimo_Click(object sender, EventArgs e)
        {
            string texto = txtPuntosIngresados.Text.TrimEnd('\r', '\n');

            int ultimoSalto = texto.LastIndexOfAny(new char[] { '\n', '\r' });

            if (ultimoSalto >= 0)
                txtPuntosIngresados.Text = texto.Substring(0, ultimoSalto).TrimEnd('\r', '\n') + Environment.NewLine;
            else
                txtPuntosIngresados.Clear(); // era el único punto
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtPuntosIngresados.ReadOnly = false;
            txtPuntosIngresados.BackColor = Color.White;

            // Limpiar resultados para que no queden anteriores
            txtFuncionObtenida.Clear();
            txtCorrelacion.Clear();
            txtEfectividadAjuste.Clear();
            PuntosCargados.Clear();

            txtPuntosIngresados.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        void GraficarEnGeoGebraPolinomial(double[] vectorResultado)
        {
            var culture = System.Globalization.CultureInfo.InvariantCulture;

            // Limpiar gráfico anterior
            _ = webView22.CoreWebView2.ExecuteScriptAsync("ggbApplet.reset();");

            // Graficar cada punto
            for (int i = 0; i < PuntosCargados.Count; i++)
            {
                string x = PuntosCargados[i][0].ToString(culture);
                string y = PuntosCargados[i][1].ToString(culture);

                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.evalCommand('P{i} = ({x}, {y})');");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setPointStyle('P{i}', 2);");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setColor('P{i}', 220, 50, 50);");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setPointSize('P{i}', 5);");
            }

            // Graficar la función polinomial
            string funcionGGB = ConstruirFuncionGeoGebra(vectorResultado);
            if (!string.IsNullOrEmpty(funcionGGB))
            {
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.evalCommand('f(x) = {funcionGGB}');");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setColor('f', 30, 100, 200);");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setLineThickness('f', 3);");
            }
        }

        private string ConstruirFuncionGeoGebra(double[] vectorResultado)
        {
            if (vectorResultado == null || vectorResultado.Length == 0)
                return "";

            var partes = new System.Collections.Generic.List<string>();
            var culture = System.Globalization.CultureInfo.InvariantCulture;

            for (int i = 0; i < vectorResultado.Length; i++)
            {
                double ai = Math.Round(vectorResultado[i], 6);
                if (Math.Abs(ai) < 1e-10) continue;

                string coef = ai.ToString(culture);
                if (i == 0) partes.Add(coef);
                else if (i == 1) partes.Add($"({coef})*x");
                else partes.Add($"({coef})*x^{i}");
            }

            return partes.Count > 0 ? string.Join(" + ", partes) : "";
        }

        void GraficarEnGeoGebraLineal(double[] funcionlineal)
        {
            var culture = System.Globalization.CultureInfo.InvariantCulture;

            // Limpiar gráfico anterior
            _ = webView22.CoreWebView2.ExecuteScriptAsync("ggbApplet.reset();");

            // Graficar cada punto
            for (int i = 0; i < PuntosCargados.Count; i++)
            {
                string x = PuntosCargados[i][0].ToString(culture);
                string y = PuntosCargados[i][1].ToString(culture);

                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.evalCommand('P{i} = ({x}, {y})');");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setPointStyle('P{i}', 2);");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setColor('P{i}', 220, 50, 50);");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setPointSize('P{i}', 5);");
            }

            // Graficar la función lineal
            string funcionGGB = ConstruirFuncionlinealGeoGebra(funcionlineal);
            if (!string.IsNullOrEmpty(funcionGGB))
            {
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.evalCommand('f(x) = {funcionGGB}');");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setColor('f', 30, 100, 200);");
                _ = webView22.CoreWebView2.ExecuteScriptAsync($"ggbApplet.setLineThickness('f', 3);");
            }
        }


        private string ConstruirFuncionlinealGeoGebra(double[] funcionlineal)
        {
            if (funcionlineal == null || funcionlineal.Length == 0)
                return "";

            var partes = new System.Collections.Generic.List<string>();
            var culture = System.Globalization.CultureInfo.InvariantCulture;

            for (int i = 0; i < funcionlineal.Length; i++)
            {
                double ai = Math.Round(funcionlineal[i], 6);
                if (Math.Abs(ai) < 1e-10) continue;

                string coef = ai.ToString(culture);
                if (i == 0) partes.Add(coef);
                else if (i == 1) partes.Add($"({coef})*x");
                else partes.Add($"({coef})*x^{i}");
            }

            return partes.Count > 0 ? string.Join(" + ", partes) : "";
        }
    }
}

