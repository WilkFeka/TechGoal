namespace CapaPresentacion.Formularios.Canchas
{
    partial class formCanchaIndividual
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
            this.flowHorarios = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCancha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.fpnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTomorrow = new CapaPresentacion.Personalizacion.MSButton();
            this.btnYesterday = new CapaPresentacion.Personalizacion.MSButton();
            this.btnVolver = new CapaPresentacion.Personalizacion.MSButton();
            this.fpnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowHorarios
            // 
            this.flowHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowHorarios.Location = new System.Drawing.Point(100, 238);
            this.flowHorarios.Name = "flowHorarios";
            this.flowHorarios.Size = new System.Drawing.Size(1261, 496);
            this.flowHorarios.TabIndex = 0;
            // 
            // lblCancha
            // 
            this.lblCancha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCancha.AutoSize = true;
            this.lblCancha.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCancha.Location = new System.Drawing.Point(87, 115);
            this.lblCancha.Name = "lblCancha";
            this.lblCancha.Size = new System.Drawing.Size(282, 77);
            this.lblCancha.TabIndex = 1;
            this.lblCancha.Text = "Cancha: ";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.CalendarForeColor = System.Drawing.Color.Lime;
            this.dtpFecha.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption;
            this.dtpFecha.CalendarTitleBackColor = System.Drawing.Color.IndianRed;
            this.dtpFecha.CalendarTitleForeColor = System.Drawing.Color.DarkOrange;
            this.dtpFecha.CalendarTrailingForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dtpFecha.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(1123, 140);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(238, 46);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.TabStop = false;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(92, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 44);
            this.label2.TabIndex = 25;
            this.label2.Text = "Reservar Cancha";
            // 
            // fpnlBotones
            // 
            this.fpnlBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlBotones.Controls.Add(this.btnVolver);
            this.fpnlBotones.Location = new System.Drawing.Point(1370, 21);
            this.fpnlBotones.Name = "fpnlBotones";
            this.fpnlBotones.Size = new System.Drawing.Size(85, 77);
            this.fpnlBotones.TabIndex = 73;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.football_field_6162391;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btnTomorrow
            // 
            this.btnTomorrow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTomorrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            this.btnTomorrow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            this.btnTomorrow.BackgroundImage = global::CapaPresentacion.Properties.Resources.forwardW;
            this.btnTomorrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTomorrow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnTomorrow.BorderRadius = 25;
            this.btnTomorrow.BorderSize = 0;
            this.btnTomorrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTomorrow.FlatAppearance.BorderSize = 0;
            this.btnTomorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTomorrow.ForeColor = System.Drawing.Color.White;
            this.btnTomorrow.Location = new System.Drawing.Point(1048, 136);
            this.btnTomorrow.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnTomorrow.Name = "btnTomorrow";
            this.btnTomorrow.Size = new System.Drawing.Size(50, 50);
            this.btnTomorrow.TabIndex = 75;
            this.btnTomorrow.TextColor = System.Drawing.Color.White;
            this.btnTomorrow.UseVisualStyleBackColor = false;
            this.btnTomorrow.Click += new System.EventHandler(this.btnTomorrow_Click);
            // 
            // btnYesterday
            // 
            this.btnYesterday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnYesterday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnYesterday.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnYesterday.BackgroundImage = global::CapaPresentacion.Properties.Resources.backW;
            this.btnYesterday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnYesterday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnYesterday.BorderRadius = 25;
            this.btnYesterday.BorderSize = 0;
            this.btnYesterday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYesterday.FlatAppearance.BorderSize = 0;
            this.btnYesterday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYesterday.ForeColor = System.Drawing.Color.White;
            this.btnYesterday.Location = new System.Drawing.Point(985, 136);
            this.btnYesterday.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.Size = new System.Drawing.Size(50, 50);
            this.btnYesterday.TabIndex = 74;
            this.btnYesterday.TextColor = System.Drawing.Color.White;
            this.btnYesterday.UseVisualStyleBackColor = false;
            this.btnYesterday.Click += new System.EventHandler(this.btnYesterday_Click);
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
            // formCanchaIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1467, 796);
            this.Controls.Add(this.btnTomorrow);
            this.Controls.Add(this.btnYesterday);
            this.Controls.Add(this.fpnlBotones);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblCancha);
            this.Controls.Add(this.flowHorarios);
            this.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "formCanchaIndividual";
            this.Text = "Cancha___Individual";
            this.Load += new System.EventHandler(this.formCanchaIndividual_Load);
            this.fpnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowHorarios;
        private System.Windows.Forms.Label lblCancha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel fpnlBotones;
        private Personalizacion.MSButton btnVolver;
        private Personalizacion.MSButton btnYesterday;
        private Personalizacion.MSButton btnTomorrow;
    }
}