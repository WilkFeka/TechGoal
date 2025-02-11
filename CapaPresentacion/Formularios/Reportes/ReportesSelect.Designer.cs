namespace CapaPresentacion.Formularios.Reportes
{
    partial class formReportesSelect
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
            this.btnReservas = new CapaPresentacion.Personalizacion.MSButton();
            this.btnReporteEquipos = new CapaPresentacion.Personalizacion.MSButton();
            this.SuspendLayout();
            // 
            // btnReservas
            // 
            this.btnReservas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReservas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnReservas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnReservas.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnReservas.BorderRadius = 40;
            this.btnReservas.BorderSize = 0;
            this.btnReservas.FlatAppearance.BorderSize = 0;
            this.btnReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservas.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservas.ForeColor = System.Drawing.Color.White;
            this.btnReservas.Location = new System.Drawing.Point(36, 38);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Size = new System.Drawing.Size(243, 107);
            this.btnReservas.TabIndex = 84;
            this.btnReservas.Text = "Reservas por Cancha";
            this.btnReservas.TextColor = System.Drawing.Color.White;
            this.btnReservas.UseVisualStyleBackColor = false;
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            // 
            // btnReporteEquipos
            // 
            this.btnReporteEquipos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReporteEquipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnReporteEquipos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnReporteEquipos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnReporteEquipos.BorderRadius = 40;
            this.btnReporteEquipos.BorderSize = 0;
            this.btnReporteEquipos.FlatAppearance.BorderSize = 0;
            this.btnReporteEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteEquipos.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEquipos.ForeColor = System.Drawing.Color.White;
            this.btnReporteEquipos.Location = new System.Drawing.Point(322, 38);
            this.btnReporteEquipos.Name = "btnReporteEquipos";
            this.btnReporteEquipos.Size = new System.Drawing.Size(243, 107);
            this.btnReporteEquipos.TabIndex = 85;
            this.btnReporteEquipos.Text = "Reporte de Equipos";
            this.btnReporteEquipos.TextColor = System.Drawing.Color.White;
            this.btnReporteEquipos.UseVisualStyleBackColor = false;
            this.btnReporteEquipos.Click += new System.EventHandler(this.btnReporteEquipos_Click);
            // 
            // formReportesSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(618, 183);
            this.Controls.Add(this.btnReporteEquipos);
            this.Controls.Add(this.btnReservas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formReportesSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Reporte";
            this.ResumeLayout(false);

        }

        #endregion

        private Personalizacion.MSButton btnReservas;
        private Personalizacion.MSButton btnReporteEquipos;
    }
}