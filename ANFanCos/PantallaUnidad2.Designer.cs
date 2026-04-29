namespace ANFanCos
{
    partial class PantallaUnidad2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaUnidad2));
            panelMenuPrincipal = new Panel();
            panel1 = new Panel();
            PanelFondo = new Panel();
            pnlMatriz = new Panel();
            lblSelMetodo = new Label();
            btnGenMat = new Button();
            button1 = new Button();
            lblToler = new Label();
            lblIterac = new Label();
            lblDim = new Label();
            btnCALCULAR = new Button();
            txtIngresartoler = new TextBox();
            txtIngresarIterac = new TextBox();
            txtIngresarDim = new TextBox();
            comboBoxMETODO = new ComboBox();
            lblIngresarDatos = new Label();
            TITULOPRINCIPAL = new Label();
            lblUNIDAD2 = new Label();
            btnVolverMenu = new Button();
            panelMenuPrincipal.SuspendLayout();
            panel1.SuspendLayout();
            PanelFondo.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuPrincipal
            // 
            panelMenuPrincipal.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelMenuPrincipal.BackColor = SystemColors.ActiveCaption;
            panelMenuPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelMenuPrincipal.Controls.Add(panel1);
            panelMenuPrincipal.Controls.Add(lblUNIDAD2);
            panelMenuPrincipal.Controls.Add(btnVolverMenu);
            panelMenuPrincipal.Dock = DockStyle.Fill;
            panelMenuPrincipal.Location = new Point(0, 0);
            panelMenuPrincipal.Name = "panelMenuPrincipal";
            panelMenuPrincipal.Size = new Size(1329, 665);
            panelMenuPrincipal.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(PanelFondo);
            panel1.Controls.Add(lblSelMetodo);
            panel1.Controls.Add(btnGenMat);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(lblToler);
            panel1.Controls.Add(lblIterac);
            panel1.Controls.Add(lblDim);
            panel1.Controls.Add(btnCALCULAR);
            panel1.Controls.Add(txtIngresartoler);
            panel1.Controls.Add(txtIngresarIterac);
            panel1.Controls.Add(txtIngresarDim);
            panel1.Controls.Add(comboBoxMETODO);
            panel1.Controls.Add(lblIngresarDatos);
            panel1.Controls.Add(TITULOPRINCIPAL);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1327, 663);
            panel1.TabIndex = 40;
            // 
            // PanelFondo
            // 
            PanelFondo.BackColor = SystemColors.Desktop;
            PanelFondo.Controls.Add(pnlMatriz);
            PanelFondo.Location = new Point(20, 226);
            PanelFondo.Name = "PanelFondo";
            PanelFondo.Size = new Size(816, 409);
            PanelFondo.TabIndex = 41;
            // 
            // pnlMatriz
            // 
            pnlMatriz.BackColor = SystemColors.Desktop;
            pnlMatriz.Location = new Point(181, 98);
            pnlMatriz.Name = "pnlMatriz";
            pnlMatriz.Size = new Size(584, 308);
            pnlMatriz.TabIndex = 40;
            // 
            // lblSelMetodo
            // 
            lblSelMetodo.AutoSize = true;
            lblSelMetodo.BackColor = Color.Transparent;
            lblSelMetodo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelMetodo.Location = new Point(75, 134);
            lblSelMetodo.Name = "lblSelMetodo";
            lblSelMetodo.Size = new Size(162, 21);
            lblSelMetodo.TabIndex = 39;
            lblSelMetodo.Text = "Seleccionar método";
            // 
            // btnGenMat
            // 
            btnGenMat.BackColor = Color.Beige;
            btnGenMat.FlatAppearance.BorderColor = Color.Black;
            btnGenMat.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnGenMat.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnGenMat.FlatStyle = FlatStyle.Flat;
            btnGenMat.Font = new Font("Century", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenMat.Location = new Point(902, 146);
            btnGenMat.Name = "btnGenMat";
            btnGenMat.Size = new Size(190, 70);
            btnGenMat.TabIndex = 5;
            btnGenMat.Text = "GENERAR MATRIZ";
            btnGenMat.UseVisualStyleBackColor = false;
            btnGenMat.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Beige;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(20, 11);
            button1.Name = "button1";
            button1.Size = new Size(111, 35);
            button1.TabIndex = 7;
            button1.Text = "VOLVER";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lblToler
            // 
            lblToler.AutoSize = true;
            lblToler.BackColor = Color.Transparent;
            lblToler.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblToler.Location = new Point(506, 137);
            lblToler.Name = "lblToler";
            lblToler.Size = new Size(155, 21);
            lblToler.TabIndex = 14;
            lblToler.Text = "Ingresar Tolerancia";
            // 
            // lblIterac
            // 
            lblIterac.AutoSize = true;
            lblIterac.BackColor = Color.Transparent;
            lblIterac.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIterac.Location = new Point(704, 137);
            lblIterac.Name = "lblIterac";
            lblIterac.Size = new Size(160, 21);
            lblIterac.TabIndex = 13;
            lblIterac.Text = "Ingresar Iteraciones";
            // 
            // lblDim
            // 
            lblDim.AutoSize = true;
            lblDim.BackColor = Color.Transparent;
            lblDim.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDim.Location = new Point(307, 137);
            lblDim.Name = "lblDim";
            lblDim.Size = new Size(159, 21);
            lblDim.TabIndex = 12;
            lblDim.Text = "Ingresar Dimensión";
            // 
            // btnCALCULAR
            // 
            btnCALCULAR.BackColor = Color.Beige;
            btnCALCULAR.FlatAppearance.BorderColor = Color.Black;
            btnCALCULAR.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnCALCULAR.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnCALCULAR.FlatStyle = FlatStyle.Flat;
            btnCALCULAR.Font = new Font("Century", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCALCULAR.Location = new Point(1107, 146);
            btnCALCULAR.Name = "btnCALCULAR";
            btnCALCULAR.Size = new Size(190, 70);
            btnCALCULAR.TabIndex = 6;
            btnCALCULAR.Text = "CALCULAR";
            btnCALCULAR.UseVisualStyleBackColor = false;
            btnCALCULAR.Click += btnCALCULAR_Click;
            // 
            // txtIngresartoler
            // 
            txtIngresartoler.Font = new Font("Segoe UI", 12F);
            txtIngresartoler.Location = new Point(499, 158);
            txtIngresartoler.Name = "txtIngresartoler";
            txtIngresartoler.Size = new Size(162, 29);
            txtIngresartoler.TabIndex = 3;
            txtIngresartoler.Text = "0,0001";
            txtIngresartoler.TextAlign = HorizontalAlignment.Center;
            // 
            // txtIngresarIterac
            // 
            txtIngresarIterac.Font = new Font("Segoe UI", 12F);
            txtIngresarIterac.Location = new Point(702, 161);
            txtIngresarIterac.Name = "txtIngresarIterac";
            txtIngresarIterac.Size = new Size(162, 29);
            txtIngresarIterac.TabIndex = 4;
            txtIngresarIterac.Text = "100";
            txtIngresarIterac.TextAlign = HorizontalAlignment.Center;
            // 
            // txtIngresarDim
            // 
            txtIngresarDim.Font = new Font("Segoe UI", 12F);
            txtIngresarDim.Location = new Point(307, 161);
            txtIngresarDim.Name = "txtIngresarDim";
            txtIngresarDim.Size = new Size(162, 29);
            txtIngresarDim.TabIndex = 2;
            txtIngresarDim.TextAlign = HorizontalAlignment.Center;
            // 
            // comboBoxMETODO
            // 
            comboBoxMETODO.AllowDrop = true;
            comboBoxMETODO.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMETODO.Font = new Font("Segoe UI", 14F);
            comboBoxMETODO.FormattingEnabled = true;
            comboBoxMETODO.ImeMode = ImeMode.Disable;
            comboBoxMETODO.Items.AddRange(new object[] { "Método: Gauss-Jordan", "Método: Gauss-Seidel" });
            comboBoxMETODO.Location = new Point(18, 158);
            comboBoxMETODO.Name = "comboBoxMETODO";
            comboBoxMETODO.Size = new Size(261, 33);
            comboBoxMETODO.TabIndex = 1;
            comboBoxMETODO.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblIngresarDatos
            // 
            lblIngresarDatos.AutoSize = true;
            lblIngresarDatos.BackColor = Color.Transparent;
            lblIngresarDatos.BorderStyle = BorderStyle.FixedSingle;
            lblIngresarDatos.CausesValidation = false;
            lblIngresarDatos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblIngresarDatos.ForeColor = SystemColors.ActiveCaptionText;
            lblIngresarDatos.Location = new Point(584, 82);
            lblIngresarDatos.Name = "lblIngresarDatos";
            lblIngresarDatos.Size = new Size(173, 27);
            lblIngresarDatos.TabIndex = 100;
            lblIngresarDatos.Text = "INGRESAR DATOS";
            // 
            // TITULOPRINCIPAL
            // 
            TITULOPRINCIPAL.AutoSize = true;
            TITULOPRINCIPAL.BackColor = Color.Transparent;
            TITULOPRINCIPAL.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TITULOPRINCIPAL.Location = new Point(422, 9);
            TITULOPRINCIPAL.Name = "TITULOPRINCIPAL";
            TITULOPRINCIPAL.Size = new Size(505, 37);
            TITULOPRINCIPAL.TabIndex = 0;
            TITULOPRINCIPAL.Text = "UNIDAD 2: SISTEMAS DE ECUACIONES";
            TITULOPRINCIPAL.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblUNIDAD2
            // 
            lblUNIDAD2.AutoSize = true;
            lblUNIDAD2.BackColor = Color.Beige;
            lblUNIDAD2.BorderStyle = BorderStyle.FixedSingle;
            lblUNIDAD2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblUNIDAD2.Location = new Point(383, 44);
            lblUNIDAD2.Name = "lblUNIDAD2";
            lblUNIDAD2.Size = new Size(507, 39);
            lblUNIDAD2.TabIndex = 39;
            lblUNIDAD2.Text = "UNIDAD 2: SISTEMAS DE ECUACIONES";
            lblUNIDAD2.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnVolverMenu
            // 
            btnVolverMenu.BackColor = Color.Beige;
            btnVolverMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolverMenu.Location = new Point(20, 11);
            btnVolverMenu.Name = "btnVolverMenu";
            btnVolverMenu.Size = new Size(0, 0);
            btnVolverMenu.TabIndex = 36;
            btnVolverMenu.Text = "VOLVER";
            btnVolverMenu.UseVisualStyleBackColor = false;
            // 
            // PantallaUnidad2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 665);
            Controls.Add(panelMenuPrincipal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PantallaUnidad2";
            Text = "PantallaUnidad2";
            panelMenuPrincipal.ResumeLayout(false);
            panelMenuPrincipal.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            PanelFondo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuPrincipal;
        private Label lblUNIDAD2;
        private Button btnVolverMenu;
        private Panel panel1;
        private Button btnGenMat;
        private Button button1;
        private Label lblToler;
        private Label lblIterac;
        private Label lblDim;
        private Button btnCALCULAR;
        private TextBox txtIngresartoler;
        private TextBox txtIngresarIterac;
        private TextBox txtIngresarDim;
        private ComboBox comboBoxMETODO;
        private Label lblIngresarDatos;
        private Label TITULOPRINCIPAL;
        private Label lblSelMetodo;
        private Panel pnlMatriz;
        private Panel PanelFondo;
    }
}