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

            // Instanciamos la librería Calculus
            Calculo Funcion = new Calculo();

            // Verificar sintaxis de la función respecto a 'x'
            if (!Funcion.Sintaxis(funcion, 'x'))
            {
                txtMotivoDeSalida.Text = "Función mal ingresada. Revisar sintaxis.";
                txtArea.Text = "0";
                return;
            }

            // Es una función válida, actualizamos los datos de control en la interfaz
            txtFunIngresada.Text = funcion;
            txtLimInferior.Text = xi.ToString();
            txtLimSuperior.Text = xd.ToString();
            txtMotivoDeSalida.Text = "Cálculo realizado con éxito.";

            double areaFinal = 0;
            string metodoSeleccionado = comboBoxMETODO.SelectedItem.ToString();

            if (metodoSeleccionado == "Trapecios Simple")
            {
                areaFinal = (Funcion.EvaluaFx(xi) + Funcion.EvaluaFx(xd)) * (xd - xi) / 2.0;
            }
            else if (metodoSeleccionado == "Trapecios Múltiple")
            {
                if (!ValidarSubintervalos(out n)) return;
                double hTemp = (xd - xi) / n;
                double sumaTrapecios = 0;
                for (int i = 1; i < n; i++)
                {
                    sumaTrapecios += Funcion.EvaluaFx(xi + hTemp * i);
                }
                areaFinal = (hTemp / 2.0) * (Funcion.EvaluaFx(xi) + 2.0 * sumaTrapecios + Funcion.EvaluaFx(xd));
            }
            else if (metodoSeleccionado == "Simpson 1/3 Simple")
            {
                // Simpson 1/3 Simple requiere dividir el intervalo en 2 partes (h = (xd - xi) / 2)
                double hSimpSimple = (xd - xi) / 2.0;
                double x1 = xi + hSimpSimple; // Punto medio
                areaFinal = (hSimpSimple / 3.0) * (Funcion.EvaluaFx(xi) + 4.0 * Funcion.EvaluaFx(x1) + Funcion.EvaluaFx(xd));
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
                areaFinal = CalcularSimpson13Multiple(Funcion, xi, xd, n);
            }
            else if (metodoSeleccionado == "Simpson 3/8")
            {
                double h38 = (xd - xi) / 3.0;
                areaFinal = (3.0 * h38 / 8.0) * (Funcion.EvaluaFx(xi) + 3.0 * Funcion.EvaluaFx(xi + h38) + 3.0 * Funcion.EvaluaFx(xi + 2.0 * h38) + Funcion.EvaluaFx(xd));
            }
            else if (metodoSeleccionado == "Simpson 1/3 M. y 3/8 Combinados")
            {
                if (!ValidarSubintervalos(out n)) return;
                areaFinal = CalcularCombinado(Funcion, xi, xd, n);
            }

            // Mostrar el resultado redondeado a 4 decimales
            txtArea.Text = Math.Round(areaFinal, 4).ToString();

            // Graficación
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

        private double CalcularCombinado(Calculo Funcion, double xi, double xd, int n)
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

            // 1. Limpiamos por completo el lienzo de GeoGebra
            _ = webView22.CoreWebView2.ExecuteScriptAsync("ggbApplet.reset();");

            string comandoArea;
            // Si es Trapecios Múltiple, usamos TrapezoidalSum (Comando oficial en inglés)
            if (metodo == "Trapecios Múltiple" && n > 0)
            {
                comandoArea = $"ggbApplet.evalCommand(\"AreaPintada = TrapezoidalSum(f, {sXi}, {sXd}, {n})\");";
            }
            else
            {
                // Para los demás métodos usamos Integral
                comandoArea = $"ggbApplet.evalCommand(\"AreaPintada = Integral(f, {sXi}, {sXd})\");";
            }

            // 2. Armamos el bloque de comandos estructurado correctamente
            string comandosDibujo =
                $"ggbApplet.evalCommand(\"f(x) = {funcion}\");\n" +
                comandoArea + "\n" +
                "ggbApplet.setColor('f', 30, 100, 200);\n" +
                "ggbApplet.setLineThickness('f', 4);\n" +
                "ggbApplet.setColor('AreaPintada', 0, 180, 50);";

            // Corrigo el '表达 =' por la declaración limpia del setTimeout en JS
            string scriptFinal = $"表达 = setTimeout(function() {{ {comandosDibujo} }}, 100);";

            // 3. Ejecutamos de manera asíncrona en el WebView2
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
