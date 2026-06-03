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
    public partial class PantallaUnidad3 : Form
    {
        public PantallaUnidad3()
        {
            InitializeComponent();
            this.Load += InicializarWebView;
            // Cargar GeoGebra al presionar el boton calcular
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
    }
}
