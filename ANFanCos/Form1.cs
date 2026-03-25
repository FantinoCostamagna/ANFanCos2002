using Calculus;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ANFanCos
{
    public partial class APPANALISISNUMERICO : Form
    {
        Calculo AnalizadorDeFunciones = new Calculo();
        public APPANALISISNUMERICO()
        {
            InitializeComponent();

        }


        void Form1_Load(object sender, EventArgs e)
        {

        }

        public void btnCALCULAR_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrWhiteSpace(txtIngresarFunc.Text) ||
                string.IsNullOrWhiteSpace(txtIngresarIterac.Text) ||
                string.IsNullOrWhiteSpace(txtIngresartoler.Text) ||
                string.IsNullOrWhiteSpace(txtIngresarint1.Text) ||
                string.IsNullOrWhiteSpace(txtIngresarint2.Text) ||
                (comboBoxMETODO.SelectedIndex == -1))
            {
                MessageBox.Show("Tenés que completar todos los datos y elegir el método");
                return;
            }


            //  Leer datos desde los TextBox
            string funcion = txtIngresarFunc.Text;

            double xi, xd, tolerancia;
            int iteraciones;

            if (!double.TryParse(txtIngresarint1.Text, out xi) ||
                !double.TryParse(txtIngresarint2.Text, out xd) ||
                !double.TryParse(txtIngresartoler.Text, out tolerancia) ||
                !int.TryParse(txtIngresarIterac.Text, out iteraciones))
            {
                MessageBox.Show("Datos numéricos inválidos");
                return;
            }

            if (!AnalizadorDeFunciones.Sintaxis(funcion, 'x'))
            {
                MessageBox.Show("Función no válida");
                return;
            }

            string metodo = comboBoxMETODO.SelectedItem.ToString();

            if (metodo == "Método cerrado: Bisección")
            {
                Biseccion(funcion, xi, xd, tolerancia, iteraciones);
            }
            else if (metodo == "Método abierto: Newton - Raphson / Tangente")
            {
                MessageBox.Show("Método en desarrollo, próximamente disponible.");
                //MetodoNewton();
            }
            else if (metodo == "Método abierto: Secante")
            {
                MessageBox.Show("Método en desarrollo, próximamente disponible.");
                //MetodoSecante();
            }
            else if (metodo == "Método cerrado: Regla Falsa")
            {
                MessageBox.Show("Método en desarrollo, próximamente disponible.");
                //MetodoReglaFalsa();
            }

            
            // Biseccion
            void Biseccion(string funcion, double xi, double xd, double tolerancia, int iteraciones)
            {
                txtFuncionUtilizada.Clear();
                txtConverge.Clear();
                txtError.Clear();
                txtIntervaloUtilizado.Clear();
                txtMetodoutilizado.Clear();
                txtIteracionesRealizadas.Clear();
                txtRaiz.Clear();
                txtToleranciaUtilizada.Clear();

                double xr = 0;
                double xrAnterior = 0;
                double error = double.MaxValue;

                double fxi, fxd;

                try
                {
                    fxi = AnalizadorDeFunciones.EvaluaFx(xi);
                    fxd = AnalizadorDeFunciones.EvaluaFx(xd);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Error interno al evaluar la función: inicialice la función correctamente.");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al evaluar la función: {ex.Message}");
                    return;
                }

                if (double.IsNaN(fxi) || double.IsNaN(fxd))
                {
                    MessageBox.Show("La evaluación de la función devolvió NaN.");
                    return;
                }

                if (fxi == 0)
                {
                    MessageBox.Show($"La raíz es: {xi}");
                    return;
                }

                if (fxd == 0)
                {
                    MessageBox.Show($"La raíz es: {xd}");
                    return;
                }

                if (fxi * fxd > 0)
                {
                    MessageBox.Show($"El intervalo {xi},{xd} no contiene a la raíz. Vuelva a ingresar xi y xd.");
                    return;
                }
                else
                {
                    // Algoritmo de bisección
                    for (int i = 1; i <= iteraciones;)
                    {
                        xr = (xi + xd) / 2;
                        double fxr;
                        try { fxr = AnalizadorDeFunciones.EvaluaFx(xr); }
                        catch (Exception ex) { MessageBox.Show($"Error al evaluar xr: {ex.Message}"); return; }

                        if (i > 1)
                        {
                            error = xr != 0 ? Math.Abs((xr - xrAnterior) / xr) : Math.Abs(xr - xrAnterior);
                        }


                        //txtError.AppendText($"Iteración {i}: xr = {xr}, error = {error}");


                        if (Math.Abs(fxr) < tolerancia || error < tolerancia) //Si el valor absoluto de fxr es menor que la tolerancia o el error es menor que la tolerancia, se acepta la raíz y se devuelven los valores
                        {
                            txtFuncionUtilizada.Text = funcion;
                            txtRaiz.AppendText($" {xr.ToString("F5")}");
                            txtIteracionesRealizadas.Text = ($"{i}" + " / " + txtIngresarIterac.Text);
                            txtIntervaloUtilizado.Text = txtIngresarint1.Text + " , " + txtIngresarint2.Text;
                            txtMetodoutilizado.AppendText("Bisección");
                            txtToleranciaUtilizada.AppendText($"{tolerancia}");
                            txtError.AppendText($" {error.ToString("F5")}" + " < " + "Tolerancia aceptada");
                            txtConverge.AppendText("Sí");
                            return;
                        }

                        else if (fxi * fxr < 0)
                        {
                            xd = xr;
                            fxd = fxr;
                        }
                        else
                        {
                            xi = xr;
                            fxi = fxr;
                        }

                        xrAnterior = xr;
                        i++;
                        
                    }
                }
                // Si se alcanza el número máximo de iteraciones sin converger, se muestran los resultados finales obtenidos
                MessageBox.Show("Se alcanzó el número máximo de iteraciones sin converger a la raíz dentro de la tolerancia especificada, se devuelve ultimo valor de xr");
                txtFuncionUtilizada.Text = funcion;
                txtIteracionesRealizadas.Text = txtIngresarIterac.Text;
                txtIntervaloUtilizado.Text = txtIngresarint1.Text + ", " + txtIngresarint2.Text;
                txtMetodoutilizado.AppendText("Bisección");
                txtToleranciaUtilizada.AppendText($"{tolerancia}");
                //txtError.AppendText($" {error.ToString("F6")}");
                txtRaiz.AppendText($"{xr.ToString("F5")}");
                txtConverge.AppendText("");
            }


        }

    }
}

