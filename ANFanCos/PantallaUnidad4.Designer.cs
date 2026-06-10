namespace ANFanCos
{
    partial class PantallaUnidad4
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
            btnVolverMenu = new Button();
            TITULOPRINCIPAL = new Label();
            panel7 = new Panel();
            lblFuncObt = new Label();
            txtArea = new TextBox();
            txtMotivoDeSalida = new TextBox();
            lblCorrelación = new Label();
            label2 = new Label();
            webView22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            txtXd = new TextBox();
            txtXi = new TextBox();
            label7 = new Label();
            btnCALCULAR = new Button();
            label8 = new Label();
            txtFuncion = new TextBox();
            label1 = new Label();
            txtCantSubInt = new TextBox();
            label4 = new Label();
            comboBoxMETODO = new ComboBox();
            lblSelMetodo = new Label();
            panel1 = new Panel();
            label5 = new Label();
            txtFunIngresada = new TextBox();
            txtLimInferior = new TextBox();
            txtLimSuperior = new TextBox();
            label6 = new Label();
            label9 = new Label();
            label10 = new Label();
            label3 = new Label();
            label11 = new Label();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView22).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnVolverMenu
            // 
            btnVolverMenu.BackColor = Color.Beige;
            btnVolverMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolverMenu.Location = new Point(45, 30);
            btnVolverMenu.Name = "btnVolverMenu";
            btnVolverMenu.Size = new Size(111, 35);
            btnVolverMenu.TabIndex = 81;
            btnVolverMenu.Text = "VOLVER";
            btnVolverMenu.UseVisualStyleBackColor = false;
            // 
            // TITULOPRINCIPAL
            // 
            TITULOPRINCIPAL.AutoSize = true;
            TITULOPRINCIPAL.BackColor = Color.Transparent;
            TITULOPRINCIPAL.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TITULOPRINCIPAL.Location = new Point(447, 23);
            TITULOPRINCIPAL.Name = "TITULOPRINCIPAL";
            TITULOPRINCIPAL.Size = new Size(497, 37);
            TITULOPRINCIPAL.TabIndex = 80;
            TITULOPRINCIPAL.Text = "UNIDAD 4: INTEGRACION NUMERICA";
            TITULOPRINCIPAL.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.InactiveCaption;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(label11);
            panel7.Controls.Add(lblFuncObt);
            panel7.Controls.Add(txtArea);
            panel7.Controls.Add(txtMotivoDeSalida);
            panel7.Controls.Add(lblCorrelación);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(webView22);
            panel7.Location = new Point(702, 94);
            panel7.Name = "panel7";
            panel7.Size = new Size(699, 608);
            panel7.TabIndex = 82;
            // 
            // lblFuncObt
            // 
            lblFuncObt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblFuncObt.AutoSize = true;
            lblFuncObt.BackColor = Color.Transparent;
            lblFuncObt.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFuncObt.Location = new Point(73, 60);
            lblFuncObt.Name = "lblFuncObt";
            lblFuncObt.Size = new Size(49, 21);
            lblFuncObt.TabIndex = 68;
            lblFuncObt.Text = "Area:";
            // 
            // txtArea
            // 
            txtArea.BackColor = Color.White;
            txtArea.BorderStyle = BorderStyle.FixedSingle;
            txtArea.Enabled = false;
            txtArea.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold);
            txtArea.Location = new Point(73, 94);
            txtArea.Name = "txtArea";
            txtArea.ReadOnly = true;
            txtArea.Size = new Size(148, 27);
            txtArea.TabIndex = 61;
            txtArea.TextAlign = HorizontalAlignment.Center;
            // 
            // txtMotivoDeSalida
            // 
            txtMotivoDeSalida.BackColor = Color.White;
            txtMotivoDeSalida.BorderStyle = BorderStyle.FixedSingle;
            txtMotivoDeSalida.Enabled = false;
            txtMotivoDeSalida.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold);
            txtMotivoDeSalida.Location = new Point(283, 94);
            txtMotivoDeSalida.Name = "txtMotivoDeSalida";
            txtMotivoDeSalida.ReadOnly = true;
            txtMotivoDeSalida.Size = new Size(355, 27);
            txtMotivoDeSalida.TabIndex = 62;
            txtMotivoDeSalida.TextAlign = HorizontalAlignment.Center;
            // 
            // lblCorrelación
            // 
            lblCorrelación.AutoSize = true;
            lblCorrelación.BackColor = Color.Transparent;
            lblCorrelación.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCorrelación.Location = new Point(283, 60);
            lblCorrelación.Name = "lblCorrelación";
            lblCorrelación.Size = new Size(141, 21);
            lblCorrelación.TabIndex = 69;
            lblCorrelación.Text = "Motivo de salida:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(73, 15);
            label2.Name = "label2";
            label2.Size = new Size(110, 27);
            label2.TabIndex = 45;
            label2.Text = "Resultados";
            // 
            // webView22
            // 
            webView22.AllowExternalDrop = true;
            webView22.BackColor = SystemColors.ButtonHighlight;
            webView22.CreationProperties = null;
            webView22.DefaultBackgroundColor = Color.White;
            webView22.Location = new Point(15, 167);
            webView22.Name = "webView22";
            webView22.Size = new Size(640, 426);
            webView22.TabIndex = 60;
            webView22.ZoomFactor = 1D;
            // 
            // txtXd
            // 
            txtXd.Font = new Font("Segoe UI", 12F);
            txtXd.Location = new Point(438, 106);
            txtXd.Name = "txtXd";
            txtXd.Size = new Size(81, 29);
            txtXd.TabIndex = 52;
            txtXd.TextAlign = HorizontalAlignment.Center;
            // 
            // txtXi
            // 
            txtXi.Font = new Font("Segoe UI", 12F);
            txtXi.Location = new Point(357, 106);
            txtXi.Name = "txtXi";
            txtXi.Size = new Size(75, 29);
            txtXi.TabIndex = 51;
            txtXi.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(465, 135);
            label7.Name = "label7";
            label7.Size = new Size(26, 21);
            label7.TabIndex = 58;
            label7.Text = "xd";
            // 
            // btnCALCULAR
            // 
            btnCALCULAR.BackColor = Color.Beige;
            btnCALCULAR.FlatAppearance.BorderColor = Color.Black;
            btnCALCULAR.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnCALCULAR.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnCALCULAR.FlatStyle = FlatStyle.Flat;
            btnCALCULAR.Font = new Font("Century", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCALCULAR.Location = new Point(252, 282);
            btnCALCULAR.Name = "btnCALCULAR";
            btnCALCULAR.Size = new Size(162, 40);
            btnCALCULAR.TabIndex = 53;
            btnCALCULAR.Text = "CALCULAR";
            btnCALCULAR.UseVisualStyleBackColor = false;
            btnCALCULAR.Click += btnCALCULAR_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(383, 135);
            label8.Name = "label8";
            label8.Size = new Size(20, 21);
            label8.TabIndex = 59;
            label8.Text = "xi";
            // 
            // txtFuncion
            // 
            txtFuncion.Font = new Font("Segoe UI", 12F);
            txtFuncion.Location = new Point(97, 107);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(222, 29);
            txtFuncion.TabIndex = 63;
            txtFuncion.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(97, 74);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 64;
            label1.Text = "Funcion:";
            // 
            // txtCantSubInt
            // 
            txtCantSubInt.Font = new Font("Segoe UI", 12F);
            txtCantSubInt.Location = new Point(97, 220);
            txtCantSubInt.Name = "txtCantSubInt";
            txtCantSubInt.Size = new Size(222, 29);
            txtCantSubInt.TabIndex = 65;
            txtCantSubInt.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(97, 177);
            label4.Name = "label4";
            label4.Size = new Size(240, 21);
            label4.TabIndex = 66;
            label4.Text = "Cantidad de subintervalos (n):";
            // 
            // comboBoxMETODO
            // 
            comboBoxMETODO.AllowDrop = true;
            comboBoxMETODO.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMETODO.Font = new Font("Segoe UI", 14F);
            comboBoxMETODO.FormattingEnabled = true;
            comboBoxMETODO.ImeMode = ImeMode.Disable;
            comboBoxMETODO.Location = new Point(357, 217);
            comboBoxMETODO.Name = "comboBoxMETODO";
            comboBoxMETODO.Size = new Size(222, 33);
            comboBoxMETODO.TabIndex = 67;
            // 
            // lblSelMetodo
            // 
            lblSelMetodo.AutoSize = true;
            lblSelMetodo.BackColor = Color.Transparent;
            lblSelMetodo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelMetodo.Location = new Point(357, 177);
            lblSelMetodo.Name = "lblSelMetodo";
            lblSelMetodo.Size = new Size(70, 21);
            lblSelMetodo.TabIndex = 68;
            lblSelMetodo.Text = "Metodo";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtFunIngresada);
            panel1.Controls.Add(txtLimInferior);
            panel1.Controls.Add(txtLimSuperior);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblSelMetodo);
            panel1.Controls.Add(comboBoxMETODO);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtCantSubInt);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtFuncion);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnCALCULAR);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtXi);
            panel1.Controls.Add(txtXd);
            panel1.Location = new Point(-30, 94);
            panel1.Name = "panel1";
            panel1.Size = new Size(669, 608);
            panel1.TabIndex = 83;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(140, 442);
            label5.Name = "label5";
            label5.Size = new Size(150, 21);
            label5.TabIndex = 75;
            label5.Text = "Función Ingresada";
            // 
            // txtFunIngresada
            // 
            txtFunIngresada.BackColor = Color.White;
            txtFunIngresada.BorderStyle = BorderStyle.FixedSingle;
            txtFunIngresada.Enabled = false;
            txtFunIngresada.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold);
            txtFunIngresada.Location = new Point(329, 436);
            txtFunIngresada.Name = "txtFunIngresada";
            txtFunIngresada.ReadOnly = true;
            txtFunIngresada.Size = new Size(186, 27);
            txtFunIngresada.TabIndex = 72;
            txtFunIngresada.TextAlign = HorizontalAlignment.Center;
            // 
            // txtLimInferior
            // 
            txtLimInferior.BackColor = Color.White;
            txtLimInferior.BorderStyle = BorderStyle.FixedSingle;
            txtLimInferior.Enabled = false;
            txtLimInferior.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold);
            txtLimInferior.Location = new Point(329, 479);
            txtLimInferior.Name = "txtLimInferior";
            txtLimInferior.ReadOnly = true;
            txtLimInferior.Size = new Size(186, 27);
            txtLimInferior.TabIndex = 73;
            txtLimInferior.TextAlign = HorizontalAlignment.Center;
            // 
            // txtLimSuperior
            // 
            txtLimSuperior.BackColor = Color.White;
            txtLimSuperior.BorderStyle = BorderStyle.FixedSingle;
            txtLimSuperior.Enabled = false;
            txtLimSuperior.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold);
            txtLimSuperior.Location = new Point(329, 525);
            txtLimSuperior.Name = "txtLimSuperior";
            txtLimSuperior.ReadOnly = true;
            txtLimSuperior.Size = new Size(186, 27);
            txtLimSuperior.TabIndex = 74;
            txtLimSuperior.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(140, 527);
            label6.Name = "label6";
            label6.Size = new Size(127, 21);
            label6.TabIndex = 77;
            label6.Text = "Limite Superior";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(140, 480);
            label9.Name = "label9";
            label9.Size = new Size(124, 21);
            label9.TabIndex = 76;
            label9.Text = "Limite Inferior:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(199, 390);
            label10.Name = "label10";
            label10.Size = new Size(186, 27);
            label10.TabIndex = 71;
            label10.Text = "Datos de la funcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(357, 73);
            label3.Name = "label3";
            label3.Size = new Size(81, 21);
            label3.TabIndex = 69;
            label3.Text = "Extremos";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.BorderStyle = BorderStyle.FixedSingle;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ActiveCaptionText;
            label11.Location = new Point(15, 135);
            label11.Name = "label11";
            label11.Size = new Size(174, 27);
            label11.TabIndex = 70;
            label11.Text = "Valor real del area";
            // 
            // PantallaUnidad4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 724);
            Controls.Add(panel1);
            Controls.Add(btnVolverMenu);
            Controls.Add(TITULOPRINCIPAL);
            Controls.Add(panel7);
            Name = "PantallaUnidad4";
            Text = "PantallaUnidad4";
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView22).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnVolverMenu;
        private Label TITULOPRINCIPAL;
        private Panel panel7;
        private Label lblFuncObt;
        private TextBox txtArea;
        private TextBox txtMotivoDeSalida;
        private Label lblCorrelación;
        private Label label2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView22;
        private TextBox txtXd;
        private TextBox txtXi;
        private Label label7;
        private Button btnCALCULAR;
        private Label label8;
        private TextBox txtFuncion;
        private Label label1;
        private TextBox txtCantSubInt;
        private Label label4;
        private ComboBox comboBoxMETODO;
        private Label lblSelMetodo;
        private Panel panel1;
        private Label label3;
        private Label label5;
        private TextBox txtFunIngresada;
        private TextBox txtLimInferior;
        private TextBox txtLimSuperior;
        private Label label6;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}