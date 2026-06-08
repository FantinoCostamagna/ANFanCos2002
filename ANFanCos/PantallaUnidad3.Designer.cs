namespace ANFanCos
{
    partial class PantallaUnidad3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaUnidad3));
            btnVolverMenu = new Button();
            label11 = new Label();
            lblCorrelación = new Label();
            lblFuncObt = new Label();
            txtEfectividadAjuste = new TextBox();
            txtCorrelacion = new TextBox();
            txtFuncionObtenida = new TextBox();
            label6 = new Label();
            label3 = new Label();
            btnCALCULAR = new Button();
            txtIngresarint2 = new TextBox();
            txtIngresarint1 = new TextBox();
            txtPuntosIngresados = new TextBox();
            label2 = new Label();
            TITULOPRINCIPAL = new Label();
            panel7 = new Panel();
            webView22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            comboBoxTIPO = new ComboBox();
            txtGrado = new TextBox();
            lblGrado = new Label();
            txtTolerancia = new TextBox();
            lblTolerancia = new Label();
            btnEditar = new Button();
            btnBorrarTodos = new Button();
            btnBorrarUltimo = new Button();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView22).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnVolverMenu
            // 
            btnVolverMenu.BackColor = Color.Beige;
            btnVolverMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolverMenu.Location = new Point(87, 40);
            btnVolverMenu.Name = "btnVolverMenu";
            btnVolverMenu.Size = new Size(111, 35);
            btnVolverMenu.TabIndex = 77;
            btnVolverMenu.Text = "VOLVER";
            btnVolverMenu.UseVisualStyleBackColor = false;
            btnVolverMenu.Click += btnVolverMenu_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
            label11.Location = new Point(47, 169);
            label11.Name = "label11";
            label11.Size = new Size(174, 21);
            label11.TabIndex = 70;
            label11.Text = "Efectividad del ajuste";
            // 
            // lblCorrelación
            // 
            lblCorrelación.AutoSize = true;
            lblCorrelación.BackColor = Color.Transparent;
            lblCorrelación.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
            lblCorrelación.Location = new Point(47, 124);
            lblCorrelación.Name = "lblCorrelación";
            lblCorrelación.Size = new Size(120, 21);
            lblCorrelación.TabIndex = 69;
            lblCorrelación.Text = "Correlación (r)";
            // 
            // lblFuncObt
            // 
            lblFuncObt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblFuncObt.AutoSize = true;
            lblFuncObt.BackColor = Color.Transparent;
            lblFuncObt.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
            lblFuncObt.Location = new Point(47, 79);
            lblFuncObt.Name = "lblFuncObt";
            lblFuncObt.Size = new Size(146, 21);
            lblFuncObt.TabIndex = 68;
            lblFuncObt.Text = "Función Obtenida";
            // 
            // txtEfectividadAjuste
            // 
            txtEfectividadAjuste.BackColor = Color.White;
            txtEfectividadAjuste.BorderStyle = BorderStyle.FixedSingle;
            txtEfectividadAjuste.Enabled = false;
            txtEfectividadAjuste.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold);
            txtEfectividadAjuste.Location = new Point(239, 165);
            txtEfectividadAjuste.Name = "txtEfectividadAjuste";
            txtEfectividadAjuste.ReadOnly = true;
            txtEfectividadAjuste.Size = new Size(442, 27);
            txtEfectividadAjuste.TabIndex = 63;
            txtEfectividadAjuste.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCorrelacion
            // 
            txtCorrelacion.BackColor = Color.White;
            txtCorrelacion.BorderStyle = BorderStyle.FixedSingle;
            txtCorrelacion.Enabled = false;
            txtCorrelacion.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold);
            txtCorrelacion.Location = new Point(239, 119);
            txtCorrelacion.Name = "txtCorrelacion";
            txtCorrelacion.ReadOnly = true;
            txtCorrelacion.Size = new Size(442, 27);
            txtCorrelacion.TabIndex = 62;
            txtCorrelacion.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFuncionObtenida
            // 
            txtFuncionObtenida.BackColor = Color.White;
            txtFuncionObtenida.BorderStyle = BorderStyle.FixedSingle;
            txtFuncionObtenida.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold);
            txtFuncionObtenida.Location = new Point(239, 75);
            txtFuncionObtenida.Name = "txtFuncionObtenida";
            txtFuncionObtenida.ReadOnly = true;
            txtFuncionObtenida.Size = new Size(442, 27);
            txtFuncionObtenida.TabIndex = 61;
            txtFuncionObtenida.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label6.Location = new Point(15, 23);
            label6.Name = "label6";
            label6.Size = new Size(75, 25);
            label6.TabIndex = 57;
            label6.Text = "Puntos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.Location = new Point(286, 244);
            label3.Name = "label3";
            label3.Size = new Size(150, 21);
            label3.TabIndex = 54;
            label3.Text = "Puntos Ingresados";
            label3.Click += label3_Click;
            // 
            // btnCALCULAR
            // 
            btnCALCULAR.BackColor = Color.Beige;
            btnCALCULAR.FlatAppearance.BorderColor = Color.Black;
            btnCALCULAR.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnCALCULAR.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnCALCULAR.FlatStyle = FlatStyle.Flat;
            btnCALCULAR.Font = new Font("Century", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCALCULAR.Location = new Point(474, 129);
            btnCALCULAR.Name = "btnCALCULAR";
            btnCALCULAR.Size = new Size(188, 52);
            btnCALCULAR.TabIndex = 53;
            btnCALCULAR.Text = "CALCULAR";
            btnCALCULAR.UseVisualStyleBackColor = false;
            btnCALCULAR.Click += btnCALCULAR_Click;
            // 
            // txtIngresarint2
            // 
            txtIngresarint2.Font = new Font("Segoe UI", 12F);
            txtIngresarint2.Location = new Point(207, 23);
            txtIngresarint2.Name = "txtIngresarint2";
            txtIngresarint2.Size = new Size(74, 29);
            txtIngresarint2.TabIndex = 52;
            txtIngresarint2.Text = "Y";
            txtIngresarint2.TextAlign = HorizontalAlignment.Center;
            // 
            // txtIngresarint1
            // 
            txtIngresarint1.Font = new Font("Segoe UI", 12F);
            txtIngresarint1.Location = new Point(123, 23);
            txtIngresarint1.Name = "txtIngresarint1";
            txtIngresarint1.Size = new Size(78, 29);
            txtIngresarint1.TabIndex = 51;
            txtIngresarint1.Text = "X";
            txtIngresarint1.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPuntosIngresados
            // 
            txtPuntosIngresados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPuntosIngresados.Font = new Font("Segoe UI", 12F);
            txtPuntosIngresados.Location = new Point(123, 278);
            txtPuntosIngresados.MaximumSize = new Size(500, 500);
            txtPuntosIngresados.Multiline = true;
            txtPuntosIngresados.Name = "txtPuntosIngresados";
            txtPuntosIngresados.Size = new Size(500, 248);
            txtPuntosIngresados.TabIndex = 48;
            txtPuntosIngresados.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(265, 23);
            label2.Name = "label2";
            label2.Size = new Size(150, 27);
            label2.TabIndex = 45;
            label2.Text = "Datos de Salida";
            // 
            // TITULOPRINCIPAL
            // 
            TITULOPRINCIPAL.AutoSize = true;
            TITULOPRINCIPAL.BackColor = Color.Transparent;
            TITULOPRINCIPAL.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TITULOPRINCIPAL.Location = new Point(489, 33);
            TITULOPRINCIPAL.Name = "TITULOPRINCIPAL";
            TITULOPRINCIPAL.Size = new Size(414, 37);
            TITULOPRINCIPAL.TabIndex = 42;
            TITULOPRINCIPAL.Text = "UNIDAD 3: AJUSTE DE CURVAS";
            TITULOPRINCIPAL.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.GradientInactiveCaption;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(lblFuncObt);
            panel7.Controls.Add(txtFuncionObtenida);
            panel7.Controls.Add(txtCorrelacion);
            panel7.Controls.Add(txtEfectividadAjuste);
            panel7.Controls.Add(label11);
            panel7.Controls.Add(lblCorrelación);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(webView22);
            panel7.Location = new Point(744, 104);
            panel7.Name = "panel7";
            panel7.Size = new Size(699, 608);
            panel7.TabIndex = 78;
            // 
            // webView22
            // 
            webView22.AllowExternalDrop = true;
            webView22.BackColor = SystemColors.ButtonHighlight;
            webView22.CreationProperties = null;
            webView22.DefaultBackgroundColor = Color.White;
            webView22.Location = new Point(15, 241);
            webView22.Name = "webView22";
            webView22.Size = new Size(666, 362);
            webView22.TabIndex = 60;
            webView22.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(txtGrado);
            panel1.Controls.Add(lblGrado);
            panel1.Controls.Add(txtTolerancia);
            panel1.Controls.Add(txtPuntosIngresados);
            panel1.Controls.Add(lblTolerancia);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnBorrarTodos);
            panel1.Controls.Add(btnCALCULAR);
            panel1.Controls.Add(btnBorrarUltimo);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtIngresarint1);
            panel1.Controls.Add(txtIngresarint2);
            panel1.Location = new Point(12, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(669, 608);
            panel1.TabIndex = 79;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(comboBoxTIPO);
            panel2.Location = new Point(412, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(252, 117);
            panel2.TabIndex = 84;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold | FontStyle.Underline);
            label1.Location = new Point(26, 10);
            label1.Name = "label1";
            label1.Size = new Size(196, 31);
            label1.TabIndex = 81;
            label1.Text = "TIPO REGRESIÓN";
            // 
            // comboBoxTIPO
            // 
            comboBoxTIPO.AllowDrop = true;
            comboBoxTIPO.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTIPO.Font = new Font("Segoe UI", 14F);
            comboBoxTIPO.FormattingEnabled = true;
            comboBoxTIPO.ImeMode = ImeMode.Disable;
            comboBoxTIPO.Items.AddRange(new object[] { "REGRESIÓN LINEAL", "REGRESIÓN POLINOMIAL" });
            comboBoxTIPO.Location = new Point(19, 45);
            comboBoxTIPO.Name = "comboBoxTIPO";
            comboBoxTIPO.Size = new Size(210, 33);
            comboBoxTIPO.TabIndex = 80;
            comboBoxTIPO.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtGrado
            // 
            txtGrado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtGrado.Font = new Font("Segoe UI", 12F);
            txtGrado.Location = new Point(123, 180);
            txtGrado.MaximumSize = new Size(500, 500);
            txtGrado.Name = "txtGrado";
            txtGrado.Size = new Size(158, 29);
            txtGrado.TabIndex = 83;
            txtGrado.TextAlign = HorizontalAlignment.Center;
            // 
            // lblGrado
            // 
            lblGrado.AutoSize = true;
            lblGrado.BackColor = Color.Transparent;
            lblGrado.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblGrado.Location = new Point(15, 180);
            lblGrado.Name = "lblGrado";
            lblGrado.Size = new Size(68, 25);
            lblGrado.TabIndex = 82;
            lblGrado.Text = "Grado";
            // 
            // txtTolerancia
            // 
            txtTolerancia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTolerancia.Font = new Font("Segoe UI", 12F);
            txtTolerancia.Location = new Point(123, 102);
            txtTolerancia.MaximumSize = new Size(500, 500);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(158, 29);
            txtTolerancia.TabIndex = 64;
            txtTolerancia.Text = "80";
            txtTolerancia.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTolerancia
            // 
            lblTolerancia.AutoSize = true;
            lblTolerancia.BackColor = Color.Transparent;
            lblTolerancia.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTolerancia.Location = new Point(15, 102);
            lblTolerancia.Name = "lblTolerancia";
            lblTolerancia.Size = new Size(102, 25);
            lblTolerancia.TabIndex = 63;
            lblTolerancia.Text = "Tolerancia";
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.DarkGray;
            btnEditar.FlatAppearance.BorderColor = Color.Black;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Century", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(476, 532);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(162, 40);
            btnEditar.TabIndex = 62;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnBorrarTodos
            // 
            btnBorrarTodos.BackColor = Color.Red;
            btnBorrarTodos.FlatAppearance.BorderColor = Color.Black;
            btnBorrarTodos.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnBorrarTodos.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnBorrarTodos.FlatStyle = FlatStyle.Flat;
            btnBorrarTodos.Font = new Font("Century", 10F, FontStyle.Bold);
            btnBorrarTodos.Location = new Point(288, 532);
            btnBorrarTodos.Name = "btnBorrarTodos";
            btnBorrarTodos.Size = new Size(162, 40);
            btnBorrarTodos.TabIndex = 61;
            btnBorrarTodos.Text = "BORRAR TODOS";
            btnBorrarTodos.UseVisualStyleBackColor = false;
            btnBorrarTodos.Click += btnBorrarTodos_Click;
            // 
            // btnBorrarUltimo
            // 
            btnBorrarUltimo.BackColor = Color.White;
            btnBorrarUltimo.FlatAppearance.BorderColor = Color.Black;
            btnBorrarUltimo.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnBorrarUltimo.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnBorrarUltimo.FlatStyle = FlatStyle.Flat;
            btnBorrarUltimo.Font = new Font("Century", 10F, FontStyle.Bold);
            btnBorrarUltimo.Location = new Point(99, 532);
            btnBorrarUltimo.Name = "btnBorrarUltimo";
            btnBorrarUltimo.Size = new Size(162, 40);
            btnBorrarUltimo.TabIndex = 60;
            btnBorrarUltimo.Text = "BORRAR ULTIMO";
            btnBorrarUltimo.UseVisualStyleBackColor = false;
            btnBorrarUltimo.Click += btnBorrarUltimo_Click;
            // 
            // PantallaUnidad3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1455, 724);
            Controls.Add(panel1);
            Controls.Add(btnVolverMenu);
            Controls.Add(TITULOPRINCIPAL);
            Controls.Add(panel7);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PantallaUnidad3";
            Text = "AppAnalisisNumérico";
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView22).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolverMenu;
        private Label label11;
        private Label lblCorrelación;
        private Label lblFuncObt;
        private TextBox txtEfectividadAjuste;
        private TextBox txtCorrelacion;
        private TextBox txtFuncionObtenida;
        private Label label6;
        private Label label3;
        private Button btnCALCULAR;
        private TextBox txtIngresarint2;
        private TextBox txtIngresarint1;
        private TextBox txtPuntosIngresados;
        private Label label2;
        private Label TITULOPRINCIPAL;
        private Panel panel7;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView22;
        private Panel panel1;
        private Button btnEditar;
        private Button btnBorrarTodos;
        private Button btnBorrarUltimo;
        private TextBox txtTolerancia;
        private Label lblTolerancia;
        private Label label1;
        private ComboBox comboBoxTIPO;
        private Panel panel2;
        private TextBox txtGrado;
        private Label lblGrado;
        //private EventHandler PantallaUnidad3_Load;
    }
}