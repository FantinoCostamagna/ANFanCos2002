using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ANFanCos
{
    public partial class PantallaMenú : Form
    {
        public PantallaMenú()
        {
            InitializeComponent();
        }

        private void PantallaMenú_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void lblUNIDAD1_Click(object sender, EventArgs e)
        {
            this.Hide();
            APPANALISISNUMERICO APPANALISISNUMERICO = new APPANALISISNUMERICO();
            APPANALISISNUMERICO.Show();

        }

        private void lblUNIDAD2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaUnidad2 APP = new PantallaUnidad2();
            APP.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            PantallaUnidad3 APP = new PantallaUnidad3();
            APP.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaUnidad4 APP = new PantallaUnidad4();
            APP.Show();
        }
    }
}
