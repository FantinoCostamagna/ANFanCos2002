using Calculus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANFanCos
{
    public partial class PantallaUnidad4 : Form
    {
        public PantallaUnidad4()
        {
            InitializeComponent();
            ConfigurarMetodos();
            this.Load += InicializarWebView; // Carga de GeoGebra al iniciar
        }

        private void ConfigurarMetodos()
        {
            comboBoxMETODO.Items.Clear();
            comboBoxMETODO.Items.Add("Trapecios Simple");
            comboBoxMETODO.Items.Add("Trapecios Múltiple");
            comboBoxMETODO.Items.Add("Simpson 1/3 Simple");
            comboBoxMETODO.Items.Add("Simpson 1/3 Múltiple");
            comboBoxMETODO.Items.Add("Simpson 3/8");
            comboBoxMETODO.Items.Add("Simpson 1/3 M. y 3/8 Combinados");
            comboBoxMETODO.SelectedIndex = 0;
        }

        private async void InicializarWebView(object sender, EventArgs e)
        {
            await webView22.EnsureCoreWebView2Async(null);
            // Reemplaza con la ruta local de tu archivo HTML actual o tu servidor local
            webView22.CoreWebView2.Navigate("https://www.geogebra.org/classic#classic.c");
        }

        private void btnCALCULAR_Click(object sender, EventArgs e)
        {
            // 1. Validaciones de consistencia de la interfaz
            if (string.IsNullOrWhiteSpace(txtFuncion.Text) ||
                string.IsNullOrWhiteSpace(txtXi.Text) ||
                string.IsNullOrWhiteSpace(txtXd.Text))
            {
                MessageBox.Show("Tenés que completar la función y los límites obligatoriamente.");
                return;
            }

            string funcion = txtFuncion.Text;
            double xi = double.Parse(txtXi.Text);
            double xd = double.Parse(txtXd.Text);
            int n = 0;

            Calculo Funcion = new Calculo();

            if (!Funcion.Sintaxis(funcion, 'x'))
            {
                txtMotivoDeSalida.Text = "Función mal ingresada. Revisar sintaxis.";
                txtArea.Text = "0";
                return;
            }

            txtFunIngresada.Text = funcion;
            txtLimInferior.Text = xi.ToString();
            txtLimSuperior.Text = xd.ToString();
            txtMotivoDeSalida.Text = "Cálculo realizado con éxito.";

            double areaFinal = 0;
            string metodoSeleccionado = comboBoxMETODO.SelectedItem.ToString();

            // 2. Selección y ejecución según las estructuras del PDF de la cátedra
            if (metodoSeleccionado == "Trapecios Simple")
            {
                // Pág 1: ((Funcion.EvaluaFx(xi) + Funcion.EvaluaFx(xd)) * (xd - xi)) / 2
                areaFinal = ((Funcion.EvaluaFx(xi) + Funcion.EvaluaFx(xd)) * (xd - xi)) / 2.0;
            }
            else if (metodoSeleccionado == "Trapecios Múltiple")
            {
                if (!ValidarSubintervalos(out n)) return;
                double h = (xd - xi) / n;
                double sum = 0;

                for (int i = 1; i < n; i++)
                {
                    sum += Funcion.EvaluaFx(xi + h * i);
                }

              
                areaFinal = (h / 2.0) * (Funcion.EvaluaFx(xi) + 2.0 * sum + Funcion.EvaluaFx(xd));
            }
            else if (metodoSeleccionado == "Simpson 1/3 Simple")
            {
                // Pág 2: h = (xd - xi) / 2
                double h = (xd - xi) / 2.0;
                areaFinal = (h / 3.0) * (Funcion.EvaluaFx(xi) + 4.0 * Funcion.EvaluaFx(xi + h) + Funcion.EvaluaFx(xd));
            }
            else if (metodoSeleccionado == "Simpson 1/3 Múltiple")
            {
                if (!ValidarSubintervalos(out n)) return;
                if (n % 2 != 0)
                {
                    txtMotivoDeSalida.Text = "Error: Simpson 1/3 Múltiple requiere n par.";
                    txtArea.Text = "0";
                    return;
                }

                double h = (xd - xi) / n;
                double sumPares = 0, sumImpares = 0;

                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0)
                        sumPares += Funcion.EvaluaFx(xi + h * i);
                    else
                        sumImpares += Funcion.EvaluaFx(xi + h * i);
                }
                areaFinal = (h / 3.0) * (Funcion.EvaluaFx(xi) + 4.0 * sumImpares + 2.0 * sumPares + Funcion.EvaluaFx(xd));
            }
            else if (metodoSeleccionado == "Simpson 3/8")
            {
                // Pág 2: h = (xd - xi) / 3
                double h = (xd - xi) / 3.0;
                areaFinal = (3.0 * h / 8.0) * (Funcion.EvaluaFx(xi) + 3.0 * Funcion.EvaluaFx(xi + h) + 3.0 * Funcion.EvaluaFx(xi + 2.0 * h) + Funcion.EvaluaFx(xd));
            }
            else if (metodoSeleccionado == "Simpson 1/3 M. y 3/8 Combinados")
            {
                if (!ValidarSubintervalos(out n)) return;
                areaFinal = CalcularCombinado(Funcion, funcion, xi, xd, n);
            }

            // 3. Imprimir resultado y refrescar el lienzo gráfico
            txtArea.Text = Math.Round(areaFinal, 4).ToString();
            GraficarIntegracionConHTML(funcion, xi, xd, n, metodoSeleccionado);
        }

        private double CalcularSimpson13Multiple(Calculo Funcion, double xi, double xd, int n)
        {
            double h = (xd - xi) / n;
            double sumPares = 0;
            double sumImpares = 0;

            for (int i = 1; i < n; i++)
            {
                double x = xi + h * i;
                if (i % 2 == 0)
                    sumPares += Funcion.EvaluaFx(x);
                else
                    sumImpares += Funcion.EvaluaFx(x);
            }

            return (h / 3.0) * (Funcion.EvaluaFx(xi) + 4.0 * sumImpares + 2.0 * sumPares + Funcion.EvaluaFx(xd));
        }

        private double CalcularCombinado(Calculo Funcion, string funcion, double xi, double xd, int n)
        {
            double h = (xd - xi) / n;
            double resultado = 0;

            // Si es impar, separamos los últimos 3 intervalos para Simpson 3/8
            if (n % 2 != 0)
            {
                double nuevoXd = xd - (3.0 * h);

                // Calculamos la parte de Simpson 1/3 Múltiple con los intervalos pares restantes
                if (n - 3 > 0)
                {
                    resultado += CalcularSimpson13Multiple(Funcion, xi, nuevoXd, n - 3);
                }

                // Calculamos los últimos 3 intervalos usando Simpson 3/8
                double h38 = h;
                resultado += (3.0 * h38 / 8.0) * (Funcion.EvaluaFx(nuevoXd) + 3.0 * Funcion.EvaluaFx(nuevoXd + h38) + 3.0 * Funcion.EvaluaFx(nuevoXd + 2.0 * h38) + Funcion.EvaluaFx(xd));
            }
            else
            {
                // Si es par de entrada, es simplemente un Simpson 1/3 Múltiple puro
                resultado = CalcularSimpson13Multiple(Funcion, xi, xd, n);
            }

            return resultado;
        }

        private bool ValidarSubintervalos(out int n)
        {
            if (string.IsNullOrWhiteSpace(txtCantSubInt.Text) || !int.TryParse(txtCantSubInt.Text, out n) || n <= 0)
            {
                MessageBox.Show("Ingresá una cantidad válida y mayor a 0 de subintervalos (n).");
                n = 0;
                return false;
            }
            return true;
        }


        private void GraficarIntegracionConHTML(string funcion, double xi, double xd, int n, string metodo)
        {
            var culture = System.Globalization.CultureInfo.InvariantCulture;
            string sXi = xi.ToString(culture);
            string sXd = xd.ToString(culture);

            string funcionParaGeoGebra = funcion.ToUpper()
                                         .Replace("LOG", "ln")
                                         .Replace("LN", "ln")
                                         .Replace("EXP", "exp")
                                         .Replace("X", "x") 
                                         .Replace(" ", "");

            // Limpiamos el lienzo de GeoGebra
            _ = webView22.CoreWebView2.ExecuteScriptAsync("ggbApplet.reset();");

            string comandoArea;
            if (metodo == "Trapecios Múltiple" && n > 0)
            {
                comandoArea = $"ggbApplet.evalCommand(\"AreaPintada = TrapezoidalSum(f, {sXi}, {sXd}, {n})\");";
            }
            else
            {
                comandoArea = $"ggbApplet.evalCommand(\"AreaPintada = Integral(f, {sXi}, {sXd})\");";
            }

            // Enviamos la función ya traducida de forma limpia
            string comandosDibujo =
                $"ggbApplet.evalCommand(\"f(x) = {funcionParaGeoGebra}\");\n" +
                comandoArea + "\n" +
                "ggbApplet.setColor('f', 30, 100, 200);\n" +
                "ggbApplet.setLineThickness('f', 4);\n" +
                "ggbApplet.setColor('AreaPintada', 0, 180, 50);";

            string scriptFinal = $"表达 = setTimeout(function() {{ {comandosDibujo} }}, 100);";
            _ = webView22.CoreWebView2.ExecuteScriptAsync(scriptFinal);
        }



        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaMenú menu = new PantallaMenú();
            menu.ShowDialog();
            this.Close();
        }
    }
}
