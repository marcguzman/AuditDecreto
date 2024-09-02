namespace AuditDecreto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            BtnCargar = new Button();
            FlPanel = new FlowLayoutPanel();
            BtnMonitorear = new Button();
            BtnReporte = new Button();
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            iniciarSesiónToolStripMenuItem = new ToolStripMenuItem();
            cerrarToolStripMenuItem = new ToolStripMenuItem();
            evaluadorToolStripMenuItem = new ToolStripMenuItem();
            cargarDecretoToolStripMenuItem = new ToolStripMenuItem();
            supervisorToolStripMenuItem = new ToolStripMenuItem();
            evaluaciónToolStripMenuItem1 = new ToolStripMenuItem();
            reporteToolStripMenuItem1 = new ToolStripMenuItem();
            evaluadoToolStripMenuItem = new ToolStripMenuItem();
            resultadoEvaluaciónToolStripMenuItem = new ToolStripMenuItem();
            PnlFondo = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtPreview = new TextBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            txtContrasena = new TextBox();
            txtUsuario = new TextBox();
            PnlInicio = new Panel();
            btnInicio = new Button();
            dgvDecreto = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            BtnPreview = new Button();
            pblogo = new PictureBox();
            menuStrip1.SuspendLayout();
            PnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PnlInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDecreto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pblogo).BeginInit();
            SuspendLayout();
            // 
            // BtnCargar
            // 
            BtnCargar.Location = new Point(1107, 31);
            BtnCargar.Name = "BtnCargar";
            BtnCargar.Size = new Size(94, 29);
            BtnCargar.TabIndex = 0;
            BtnCargar.Text = "Cargar Decreto";
            BtnCargar.UseVisualStyleBackColor = true;
            BtnCargar.Click += BtnCargar_Click;
            // 
            // FlPanel
            // 
            FlPanel.AutoScroll = true;
            FlPanel.Location = new Point(1489, 666);
            FlPanel.Name = "FlPanel";
            FlPanel.Size = new Size(63, 107);
            FlPanel.TabIndex = 1;
            // 
            // BtnMonitorear
            // 
            BtnMonitorear.Location = new Point(1207, 31);
            BtnMonitorear.Name = "BtnMonitorear";
            BtnMonitorear.Size = new Size(94, 29);
            BtnMonitorear.TabIndex = 2;
            BtnMonitorear.Text = "Evaluar";
            BtnMonitorear.UseVisualStyleBackColor = true;
            BtnMonitorear.Click += BtnMonitorear_Click;
            // 
            // BtnReporte
            // 
            BtnReporte.Location = new Point(1307, 31);
            BtnReporte.Name = "BtnReporte";
            BtnReporte.Size = new Size(94, 29);
            BtnReporte.TabIndex = 3;
            BtnReporte.Text = "Reporte";
            BtnReporte.UseVisualStyleBackColor = true;
            BtnReporte.Click += BtnReporte_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, evaluadorToolStripMenuItem, supervisorToolStripMenuItem, evaluadoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1562, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iniciarSesiónToolStripMenuItem, cerrarToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(59, 24);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // iniciarSesiónToolStripMenuItem
            // 
            iniciarSesiónToolStripMenuItem.Name = "iniciarSesiónToolStripMenuItem";
            iniciarSesiónToolStripMenuItem.Size = new Size(179, 26);
            iniciarSesiónToolStripMenuItem.Text = "Iniciar Sesión";
            iniciarSesiónToolStripMenuItem.Click += iniciarSesiónToolStripMenuItem_Click;
            // 
            // cerrarToolStripMenuItem
            // 
            cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            cerrarToolStripMenuItem.Size = new Size(179, 26);
            cerrarToolStripMenuItem.Text = "Cerrar sesión";
            cerrarToolStripMenuItem.Click += cerrarToolStripMenuItem_Click;
            // 
            // evaluadorToolStripMenuItem
            // 
            evaluadorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cargarDecretoToolStripMenuItem });
            evaluadorToolStripMenuItem.Name = "evaluadorToolStripMenuItem";
            evaluadorToolStripMenuItem.Size = new Size(92, 24);
            evaluadorToolStripMenuItem.Text = "Operación";
            evaluadorToolStripMenuItem.Click += evaluadorToolStripMenuItem_Click;
            // 
            // cargarDecretoToolStripMenuItem
            // 
            cargarDecretoToolStripMenuItem.Name = "cargarDecretoToolStripMenuItem";
            cargarDecretoToolStripMenuItem.Size = new Size(193, 26);
            cargarDecretoToolStripMenuItem.Text = "Cargar Decreto";
            cargarDecretoToolStripMenuItem.Click += cargarDecretoToolStripMenuItem_Click;
            // 
            // supervisorToolStripMenuItem
            // 
            supervisorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { evaluaciónToolStripMenuItem1, reporteToolStripMenuItem1 });
            supervisorToolStripMenuItem.Name = "supervisorToolStripMenuItem";
            supervisorToolStripMenuItem.Size = new Size(99, 24);
            supervisorToolStripMenuItem.Text = "Supervisión";
            // 
            // evaluaciónToolStripMenuItem1
            // 
            evaluaciónToolStripMenuItem1.Name = "evaluaciónToolStripMenuItem1";
            evaluaciónToolStripMenuItem1.Size = new Size(163, 26);
            evaluaciónToolStripMenuItem1.Text = "Evaluación";
            // 
            // reporteToolStripMenuItem1
            // 
            reporteToolStripMenuItem1.Name = "reporteToolStripMenuItem1";
            reporteToolStripMenuItem1.Size = new Size(163, 26);
            reporteToolStripMenuItem1.Text = "Reporte";
            // 
            // evaluadoToolStripMenuItem
            // 
            evaluadoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resultadoEvaluaciónToolStripMenuItem });
            evaluadoToolStripMenuItem.Name = "evaluadoToolStripMenuItem";
            evaluadoToolStripMenuItem.Size = new Size(89, 24);
            evaluadoToolStripMenuItem.Text = "Resultado";
            // 
            // resultadoEvaluaciónToolStripMenuItem
            // 
            resultadoEvaluaciónToolStripMenuItem.Name = "resultadoEvaluaciónToolStripMenuItem";
            resultadoEvaluaciónToolStripMenuItem.Size = new Size(233, 26);
            resultadoEvaluaciónToolStripMenuItem.Text = "Resultado Evaluación";
            resultadoEvaluaciónToolStripMenuItem.Click += resultadoEvaluaciónToolStripMenuItem_Click;
            // 
            // PnlFondo
            // 
            PnlFondo.BackColor = Color.FromArgb(25, 113, 176);
            PnlFondo.Controls.Add(label5);
            PnlFondo.Controls.Add(label4);
            PnlFondo.Controls.Add(label3);
            PnlFondo.Controls.Add(label2);
            PnlFondo.Location = new Point(12, 43);
            PnlFondo.Name = "PnlFondo";
            PnlFondo.Size = new Size(241, 730);
            PnlFondo.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(176, 443);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 3;
            label5.Text = "Grupo 5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(116, 423);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 2;
            label4.Text = "Desarrollado por";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(135, 163);
            label3.Name = "label3";
            label3.Size = new Size(90, 38);
            label3.TabIndex = 1;
            label3.Text = "Audit";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(138, 143);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 0;
            label2.Text = "Bievenido a";
            // 
            // txtPreview
            // 
            txtPreview.Location = new Point(122, 69);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = ScrollBars.Vertical;
            txtPreview.Size = new Size(864, 701);
            txtPreview.TabIndex = 11;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(22, 197);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 28);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 28);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(52, 197);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(254, 27);
            txtContrasena.TabIndex = 1;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(52, 143);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(254, 27);
            txtUsuario.TabIndex = 0;
            // 
            // PnlInicio
            // 
            PnlInicio.Controls.Add(btnInicio);
            PnlInicio.Controls.Add(pictureBox2);
            PnlInicio.Controls.Add(txtUsuario);
            PnlInicio.Controls.Add(pictureBox1);
            PnlInicio.Controls.Add(txtContrasena);
            PnlInicio.Location = new Point(256, 43);
            PnlInicio.Name = "PnlInicio";
            PnlInicio.Size = new Size(313, 730);
            PnlInicio.TabIndex = 7;
            // 
            // btnInicio
            // 
            btnInicio.Location = new Point(52, 240);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(139, 29);
            btnInicio.TabIndex = 10;
            btnInicio.Text = "Inicio de sesión";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // dgvDecreto
            // 
            dgvDecreto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDecreto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDecreto.Location = new Point(25, 69);
            dgvDecreto.Name = "dgvDecreto";
            dgvDecreto.RowHeadersWidth = 51;
            dgvDecreto.Size = new Size(1488, 453);
            dgvDecreto.TabIndex = 8;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(25, 528);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(1488, 245);
            chart1.TabIndex = 9;
            chart1.Text = "chart1";
            // 
            // BtnPreview
            // 
            BtnPreview.Location = new Point(1407, 31);
            BtnPreview.Name = "BtnPreview";
            BtnPreview.Size = new Size(106, 29);
            BtnPreview.TabIndex = 10;
            BtnPreview.Text = "Previsualizar";
            BtnPreview.UseVisualStyleBackColor = true;
            BtnPreview.Click += BtnPreview_Click;
            // 
            // pblogo
            // 
            pblogo.Image = (Image)resources.GetObject("pblogo.Image");
            pblogo.Location = new Point(329, 80);
            pblogo.Name = "pblogo";
            pblogo.Size = new Size(872, 679);
            pblogo.SizeMode = PictureBoxSizeMode.CenterImage;
            pblogo.TabIndex = 12;
            pblogo.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1562, 819);
            Controls.Add(pblogo);
            Controls.Add(txtPreview);
            Controls.Add(dgvDecreto);
            Controls.Add(BtnPreview);
            Controls.Add(chart1);
            Controls.Add(FlPanel);
            Controls.Add(PnlInicio);
            Controls.Add(PnlFondo);
            Controls.Add(BtnReporte);
            Controls.Add(BtnMonitorear);
            Controls.Add(BtnCargar);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Audit Decreto";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            PnlFondo.ResumeLayout(false);
            PnlFondo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PnlInicio.ResumeLayout(false);
            PnlInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDecreto).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pblogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCargar;
        private FlowLayoutPanel FlPanel;
        private Button BtnMonitorear;
        private Button BtnReporte;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem iniciarSesiónToolStripMenuItem;
        private ToolStripMenuItem cerrarToolStripMenuItem;
        private ToolStripMenuItem evaluadorToolStripMenuItem;
        private ToolStripMenuItem cargarDecretoToolStripMenuItem;
        private ToolStripMenuItem supervisorToolStripMenuItem;
        private ToolStripMenuItem evaluaciónToolStripMenuItem1;
        private ToolStripMenuItem reporteToolStripMenuItem1;
        private ToolStripMenuItem evaluadoToolStripMenuItem;
        private ToolStripMenuItem resultadoEvaluaciónToolStripMenuItem;
        private Panel PnlFondo;
        private TextBox txtContrasena;
        private TextBox txtUsuario;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel PnlInicio;
        private Button btnInicio;
        private DataGridView dgvDecreto;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button BtnPreview;
        private TextBox txtPreview;
        private PictureBox pblogo;
    }
}
