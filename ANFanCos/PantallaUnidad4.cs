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

        private void btnCALCULAR_Click(object sender, EventArgs e)
        {
            // Validaciones iniciales de campos vacíos
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

            // Ejecución utilizando IF y ELSE IF según el método seleccionado
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
                double hSimpSimple = (xd - xi) / 2.0;
                areaFinal = (hSimpSimple / 3.0) * (Funcion.EvaluaFx(xi) + 4.0 * Funcion.EvaluaFx(xi + hSimpSimple) + Funcion.EvaluaFx(xd));
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
                areaFinal = CalcularSimpson13Multiple(Funcion, funcion, xi, xd, n);
            }
            else if (metodoSeleccionado == "Simpson 3/8")
            {
                double h38 = (xd - xi) / 3.0;
                areaFinal = (3.0 * h38 / 8.0) * (Funcion.EvaluaFx(xi) + 3.0 * Funcion.EvaluaFx(xi + h38) + 3.0 * Funcion.EvaluaFx(xi + 2.0 * h38) + Funcion.EvaluaFx(xd));
            }
            else if (metodoSeleccionado == "Simpson 1/3 M. y 3/8 Combinados")
            {
                if (!ValidarSubintervalos(out n)) return;
                areaFinal = CalcularCombinado(Funcion, funcion, xi, xd, n);
            }

            // Mostrar el resultado redondeado a 4 decimales
            txtArea.Text = Math.Round(areaFinal, 4).ToString();
        }

        private double CalcularSimpson13Multiple(Calculo Funcion, string funcion, double xi, double xd, int n)
        {
            double h = (xd - xi) / n;
            double sumPares = 0, sumImpares = 0;

            for (int i = 1; i < n; i++)
            {
                if (i % 2 == 0)
                    sumPares += Funcion.EvaluaFx(xi + h * i);
                else
                    sumImpares += Funcion.EvaluaFx(xi + h * i);
            }

            return (h / 3.0) * (Funcion.EvaluaFx(xi) + 4.0 * sumImpares + 2.0 * sumPares + Funcion.EvaluaFx(xd));
        }

        // Algoritmo combinado adaptado perfectamente de tu documento
        private double CalcularCombinado(Calculo Funcion, string funcion, double xi, double xd, int n)
        {
            double h = (xd - xi) / n;
            double resultado = 0;
            bool simpson38Hecho = false;

            if (n % 2 != 0) // Cantidad de intervalos impar
            {
                // Se calcula Simpson 3/8 en los últimos 3 subintervalos
                double nuevoXi = xi + h * (n - 3);

                double h38 = (xd - nuevoXi) / 3.0;
                resultado = (3.0 * h38 / 8.0) * (Funcion.EvaluaFx(nuevoXi) + 3.0 * Funcion.EvaluaFx(nuevoXi + h38) + 3.0 * Funcion.EvaluaFx(nuevoXi + 2.0 * h38) + Funcion.EvaluaFx(xd));

                // Ajustamos el límite superior y subintervalos para el tramo restante
                n = n - 3;
                xd = nuevoXi;
                simpson38Hecho = true;
            }

            // Si n quedó en 0 porque originalmente era 3, no hace falta procesar Simpson 1/3
            if (n > 0)
            {
                resultado += CalcularSimpson13Multiple(Funcion, funcion, xi, xd, n);
            }

            return resultado;
        }

        // Validador de cantidad de subintervalos
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
    }
}
