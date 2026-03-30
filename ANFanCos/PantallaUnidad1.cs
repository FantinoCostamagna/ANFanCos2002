using Calculus;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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
            InicializarWebView();
            // Cargar GeoGebra al presionar el boton calcular
        }

        private async void InicializarWebView()
        {
            await webView22.EnsureCoreWebView2Async(null);

            string rutaHtml = System.IO.Path.Combine(Application.StartupPath, "HTML", "htmlGeoGebra.html");
            string url = $"file:///{rutaHtml.Replace("\\", "/")}";
            
            webView22.CoreWebView2.Navigate(url);
        }

        public void btbVolverMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaMenú pantallaMenú = new PantallaMenú();
            pantallaMenú.ShowDialog();
            this.Close();
        }

        void Form1_Load(object sender, EventArgs e)
        {

        }

       
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMETODO.SelectedItem.ToString() == "Método abierto: Newton-Raphson/Tangente")
            {
                txtIngresarint2.Visible = false; // Oculta el TextBox
                label7.Visible = false; // Oculta el Label
                txtIngresarint2.Text = "1"; // completa el TextBox para que me valide la función, aunque no se use en el método abierto, para evitar errores al evaluar la función en el método abierto, ya que el método abierto solo necesita un intervalo inicial (xi) y no un intervalo completo (xi, xd) como el método cerrado. Al ocultar el TextBox y el Label, se evita que el usuario ingrese un valor para xd, lo cual podría causar confusión o errores al evaluar la función. Al completar el TextBox con un valor predeterminado (en este caso, "1"), se asegura que la función se evalúe correctamente sin necesidad de que el usuario ingrese un valor para xd.
            }
            else
            {
                txtIngresarint2.Visible = true; // Lo muestra
                label7.Visible = true; // Lo muestra
                txtIngresarint2.Text = ""; // Limpia el TextBox
            }
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

            

            if (!string.IsNullOrEmpty(funcion))
            {
                webView22.CoreWebView2.ExecuteScriptAsync($"dibujarFuncion('{funcion}')");
                
                
            }

            

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
            else if (metodo == "Método abierto: Newton-Raphson/Tangente")
            {
                EncontrarRaiz(funcion, xi, tolerancia, iteraciones, metodo);
            }
            else if (metodo == "Método abierto: Secante")
            {
                EncontrarRaiz(funcion, xi, tolerancia, iteraciones, metodo);
            }
            else if (metodo == "Método cerrado: Regla Falsa")
            {
                ReglaFalsa(funcion, xi, xd, tolerancia, iteraciones);
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

                        error = Math.Abs((xr - xrAnterior) / xr);

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
                txtError.AppendText($" {error.ToString("F6")}");
                txtRaiz.AppendText($"{xr.ToString("F5")}");
                txtConverge.AppendText("");
            }


            //Regla Falsa
            void ReglaFalsa(string funcion, double xi, double xd, double tolerancia, int iteraciones)
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
                    // Algoritmo de Regla Falsa
                    for (int i = 1; i <= iteraciones;)
                    {
                        xr = (fxd * xi - fxi * xd) / (fxd - fxi);
                        double fxr;
                        try { fxr = AnalizadorDeFunciones.EvaluaFx(xr); }
                        catch (Exception ex) { MessageBox.Show($"Error al evaluar xr: {ex.Message}"); return; }

                        error = Math.Abs((xr - xrAnterior) / xr);


                        if (Math.Abs(fxr) < tolerancia || error < tolerancia) //Si el valor absoluto de fxr es menor que la tolerancia o el error es menor que la tolerancia, se acepta la raíz y se devuelven los valores
                        {
                            txtFuncionUtilizada.Text = funcion;
                            txtRaiz.AppendText($" {xr.ToString("F5")}");
                            txtIteracionesRealizadas.Text = ($"{i}" + " / " + txtIngresarIterac.Text);
                            txtIntervaloUtilizado.Text = txtIngresarint1.Text + " , " + txtIngresarint2.Text;
                            txtMetodoutilizado.AppendText("Regla Falsa");
                            txtToleranciaUtilizada.AppendText($"{tolerancia}");
                            txtError.AppendText($" {error.ToString("F5")}" + " < " + "Tolerancia aceptada");
                            txtConverge.AppendText("Si");
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

                    // Si se alcanza el número máximo de iteraciones sin converger, se muestran los resultados finales obtenidos
                    MessageBox.Show("Se alcanzó el número máximo de iteraciones sin converger a la raíz dentro de la tolerancia especificada, se devuelve ultimo valor de xr");
                    txtFuncionUtilizada.Text = funcion;
                    txtIteracionesRealizadas.Text = txtIngresarIterac.Text;
                    txtIntervaloUtilizado.Text = txtIngresarint1.Text + ", " + txtIngresarint2.Text;
                    txtMetodoutilizado.AppendText("Regla Falsa");
                    txtToleranciaUtilizada.AppendText($"{tolerancia}");
                    txtError.AppendText($" {error.ToString("F6")}");
                    txtRaiz.AppendText($"{xr.ToString("F5")}");
                    txtConverge.AppendText("No");

                }
            }


                // EncontrarRaiz
                void EncontrarRaiz(string funcion, double xi, double tolerancia, int iteraciones, string metodo)
                {
                    txtFuncionUtilizada.Clear();
                    txtConverge.Clear();
                    txtError.Clear();
                    txtIntervaloUtilizado.Clear();
                    txtMetodoutilizado.Clear();
                    txtIteracionesRealizadas.Clear();
                    txtRaiz.Clear();
                    txtToleranciaUtilizada.Clear();

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

                    if (Math.Abs(fxi) < tolerancia)
                    {
                        MessageBox.Show($"La raíz es: {xi}");
                        return;
                    }

                    else if (metodo == "Método abierto: Secante" && Math.Abs(fxd) < tolerancia)
                    {
                        MessageBox.Show($"La raíz es: {xd}");
                        return;
                    }

                    else
                    {

                        double xr = 0;
                        double xrAnterior = 0;
                        double error = 0;
                        double derivada = 0;

                        for (int i = 1; i < iteraciones;)
                        {
                            xr = CalcularXR(metodo, funcion, xi, xd, tolerancia, derivada);
                            Console.WriteLine(xr);

                            double fxr;
                            fxr = AnalizadorDeFunciones.EvaluaFx(xr);

                            if (double.IsNaN(fxr))
                            {
                                MessageBox.Show("El método diverge. No encuentra raíz");
                                return;
                            }


                            error = Math.Abs((xr - xrAnterior) / xr);

                            if (metodo == "Método abierto: Secante" && Math.Abs(fxr) < tolerancia || error < tolerancia) //es solo para que muestre correctamente el intervalo utilizado
                            {
                                txtFuncionUtilizada.Text = funcion;
                                txtRaiz.AppendText($" {xr.ToString("F5")}");
                                txtIteracionesRealizadas.Text = ($"{i}" + " / " + txtIngresarIterac.Text);
                                txtIntervaloUtilizado.Text = txtIngresarint1.Text + " , " + txtIngresarint2.Text;
                                txtMetodoutilizado.AppendText(metodo.ToString());
                                txtToleranciaUtilizada.AppendText($"{tolerancia}");
                                txtError.AppendText($" {error.ToString("F5")}" + " < " + "Tolerancia aceptada");
                                txtConverge.AppendText("Si");
                                return;
                            }

                            if (metodo == "Método abierto: Newton-Raphson/Tangente" && Math.Abs(fxr) < tolerancia || error < tolerancia)
                            {
                                txtFuncionUtilizada.Text = funcion;
                                txtRaiz.AppendText($" {xr.ToString("F5")}");
                                txtIteracionesRealizadas.Text = ($"{i}" + " / " + txtIngresarIterac.Text);
                                txtIntervaloUtilizado.Text = txtIngresarint1.Text + " , " + " - ";//aca no se muestra el xd, que yo declare igual para que no me rompa la validación
                                txtMetodoutilizado.AppendText(metodo.ToString());
                                txtToleranciaUtilizada.AppendText($"{tolerancia}");
                                txtError.AppendText($" {error.ToString("F5")}" + " < " + "Tolerancia aceptada");
                                txtConverge.AppendText("Si");
                                return;
                            }

                            else if (metodo == "Método abierto: Secante")
                            {
                                xi = xr;
                            }
                            else
                            {
                                xi = xd;
                                xd = xr;
                            }


                            xrAnterior = xr;
                            i++;
                        }

                        // Si se alcanza el número máximo de iteraciones sin converger, se muestran los resultados finales obtenidos
                        MessageBox.Show("Se alcanzó el número máximo de iteraciones sin converger a la raíz dentro de la tolerancia especificada, se devuelve ultimo valor de xr");
                        txtFuncionUtilizada.Text = funcion;
                        txtIteracionesRealizadas.Text = txtIngresarIterac.Text;
                        txtIntervaloUtilizado.Text = txtIngresarint1.Text + " , " + " - ";
                        txtMetodoutilizado.AppendText(metodo.ToString());
                        txtToleranciaUtilizada.AppendText($"{tolerancia}");
                        txtError.AppendText($" {error.ToString("F6")}");
                        txtRaiz.AppendText($"{xr.ToString("F5")}");
                        txtConverge.AppendText("No");
                        return;

                    }


                    double CalcularXR(string metodo, string funcion, double xi, double xd, double tolerancia, double derivada)
                    {
                        double fxi = AnalizadorDeFunciones.EvaluaFx(xi);
                        double fxd = AnalizadorDeFunciones.EvaluaFx(xd);
                        derivada = AnalizadorDeFunciones.Dx(xi);

                        if (metodo == "Método abierto: Secante")
                        {

                            double xr = (fxd * xi - fxi * xd) / (fxd - fxi);
                            return xr;
                        }


                        if (metodo == "Método abierto: Newton-Raphson/Tangente" && derivada < tolerancia || double.IsNaN(derivada))
                        {
                            MessageBox.Show("El método diverge, no encuentra raíz");
                            double xr = xi - fxi / derivada;
                            return xr; // Devuelve el valor actual de xr, aunque no se ha encontrado una raíz válida

                        }
                        else
                        {
                            double xr = xi - fxi / derivada;
                            return xr;

                        }
                    }

                }

            }

        }
    }







