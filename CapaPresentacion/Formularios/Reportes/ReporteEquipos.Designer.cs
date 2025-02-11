namespace CapaPresentacion.Formularios.Reportes
{
    partial class formReporteEquipos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.fpnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVolver = new CapaPresentacion.Personalizacion.MSButton();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbEquipos = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chEstadisticaEquipos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chHorarios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chClientesReservas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAplicar = new CapaPresentacion.Personalizacion.MSButton();
            this.msButton3 = new CapaPresentacion.Personalizacion.MSButton();
            this.fpnlBotones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chEstadisticaEquipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chHorarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chClientesReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // fpnlBotones
            // 
            this.fpnlBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlBotones.Controls.Add(this.btnVolver);
            this.fpnlBotones.Location = new System.Drawing.Point(1386, 12);
            this.fpnlBotones.Name = "fpnlBotones";
            this.fpnlBotones.Size = new System.Drawing.Size(90, 77);
            this.fpnlBotones.TabIndex = 83;
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnVolver.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnVolver.BackgroundImage = global::CapaPresentacion.Properties.Resources.back;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnVolver.BorderRadius = 25;
            this.btnVolver.BorderSize = 0;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(10, 3);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(64, 64);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.TextColor = System.Drawing.Color.White;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNombre.Location = new System.Drawing.Point(27, 112);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(0, 20, 0, 5);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(169, 29);
            this.lblNombre.TabIndex = 107;
            this.lblNombre.Text = "Buscar Equipo";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtNombre.Location = new System.Drawing.Point(31, 158);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(0);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(442, 29);
            this.txtNombre.TabIndex = 105;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // cmbEquipos
            // 
            this.cmbEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipos.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEquipos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbEquipos.FormattingEnabled = true;
            this.cmbEquipos.Location = new System.Drawing.Point(21, 215);
            this.cmbEquipos.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cmbEquipos.MaxDropDownItems = 12;
            this.cmbEquipos.Name = "cmbEquipos";
            this.cmbEquipos.Size = new System.Drawing.Size(468, 37);
            this.cmbEquipos.TabIndex = 117;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.chEstadisticaEquipos);
            this.panel1.Controls.Add(this.chHorarios);
            this.panel1.Controls.Add(this.chClientesReservas);
            this.panel1.Location = new System.Drawing.Point(603, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 636);
            this.panel1.TabIndex = 118;
            // 
            // chEstadisticaEquipos
            // 
            chartArea1.Name = "ChartArea1";
            this.chEstadisticaEquipos.ChartAreas.Add(chartArea1);
            this.chEstadisticaEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chEstadisticaEquipos.Legends.Add(legend1);
            this.chEstadisticaEquipos.Location = new System.Drawing.Point(0, 0);
            this.chEstadisticaEquipos.Name = "chEstadisticaEquipos";
            this.chEstadisticaEquipos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chEstadisticaEquipos.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))))};
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Reservas x Cancha";
            this.chEstadisticaEquipos.Series.Add(series1);
            this.chEstadisticaEquipos.Size = new System.Drawing.Size(857, 636);
            this.chEstadisticaEquipos.TabIndex = 79;
            this.chEstadisticaEquipos.Visible = false;
            // 
            // chHorarios
            // 
            chartArea2.Name = "ChartArea1";
            this.chHorarios.ChartAreas.Add(chartArea2);
            this.chHorarios.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chHorarios.Legends.Add(legend2);
            this.chHorarios.Location = new System.Drawing.Point(0, 0);
            this.chHorarios.Name = "chHorarios";
            this.chHorarios.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chHorarios.Series.Add(series2);
            this.chHorarios.Size = new System.Drawing.Size(857, 636);
            this.chHorarios.TabIndex = 81;
            this.chHorarios.Text = "chart2";
            // 
            // chClientesReservas
            // 
            chartArea3.Name = "ChartArea1";
            this.chClientesReservas.ChartAreas.Add(chartArea3);
            this.chClientesReservas.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chClientesReservas.Legends.Add(legend3);
            this.chClientesReservas.Location = new System.Drawing.Point(0, 0);
            this.chClientesReservas.Name = "chClientesReservas";
            this.chClientesReservas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chClientesReservas.Series.Add(series3);
            this.chClientesReservas.Size = new System.Drawing.Size(857, 636);
            this.chClientesReservas.TabIndex = 80;
            this.chClientesReservas.Text = "chart1";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnAplicar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnAplicar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnAplicar.BorderRadius = 20;
            this.btnAplicar.BorderSize = 0;
            this.btnAplicar.FlatAppearance.BorderSize = 0;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(187, 285);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(120, 46);
            this.btnAplicar.TabIndex = 119;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.TextColor = System.Drawing.Color.White;
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // msButton3
            // 
            this.msButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.msButton3.BorderRadius = 20;
            this.msButton3.BorderSize = 0;
            this.msButton3.Enabled = false;
            this.msButton3.FlatAppearance.BorderSize = 0;
            this.msButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.msButton3.ForeColor = System.Drawing.Color.White;
            this.msButton3.Location = new System.Drawing.Point(20, 146);
            this.msButton3.Margin = new System.Windows.Forms.Padding(15, 0, 3, 30);
            this.msButton3.Name = "msButton3";
            this.msButton3.Size = new System.Drawing.Size(469, 50);
            this.msButton3.TabIndex = 106;
            this.msButton3.TextColor = System.Drawing.Color.White;
            this.msButton3.UseVisualStyleBackColor = false;
            // 
            // formReporteEquipos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1488, 814);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbEquipos);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.msButton3);
            this.Controls.Add(this.fpnlBotones);
            this.Name = "formReporteEquipos";
            this.Text = "ReporteEquipos";
            this.fpnlBotones.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chEstadisticaEquipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chHorarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chClientesReservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fpnlBotones;
        private Personalizacion.MSButton btnVolver;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private Personalizacion.MSButton msButton3;
        public System.Windows.Forms.ComboBox cmbEquipos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chEstadisticaEquipos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chHorarios;
        private System.Windows.Forms.DataVisualization.Charting.Chart chClientesReservas;
        private Personalizacion.MSButton btnAplicar;
    }
}