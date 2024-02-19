namespace CapaPresentacion.Formularios
{
    partial class formLoginRecuperar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLoginRecuperar));
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.picLogoTechGoal = new System.Windows.Forms.PictureBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.panelCorreo = new System.Windows.Forms.Panel();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.iconMail = new FontAwesome.Sharp.IconPictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnVolver = new CapaPresentacion.Personalizacion.MSButton();
            this.btnEnviar = new CapaPresentacion.Personalizacion.MSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTechGoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.Controls.Add(this.picLogoTechGoal);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(444, 550);
            this.pnlLogo.TabIndex = 1;
            this.pnlLogo.TabStop = true;
            // 
            // picLogoTechGoal
            // 
            this.picLogoTechGoal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogoTechGoal.Image = global::CapaPresentacion.Properties.Resources.LogoGradient;
            this.picLogoTechGoal.Location = new System.Drawing.Point(0, 0);
            this.picLogoTechGoal.Name = "picLogoTechGoal";
            this.picLogoTechGoal.Size = new System.Drawing.Size(444, 550);
            this.picLogoTechGoal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoTechGoal.TabIndex = 0;
            this.picLogoTechGoal.TabStop = false;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCorreo.Location = new System.Drawing.Point(528, 284);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(0);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(506, 39);
            this.txtCorreo.TabIndex = 13;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // panelCorreo
            // 
            this.panelCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.panelCorreo.Location = new System.Drawing.Point(508, 331);
            this.panelCorreo.Name = "panelCorreo";
            this.panelCorreo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panelCorreo.Size = new System.Drawing.Size(541, 3);
            this.panelCorreo.TabIndex = 17;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AccessibleName = "Correo Electronico";
            this.lblCorreo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreo.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.lblCorreo.Location = new System.Drawing.Point(540, 245);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(213, 29);
            this.lblCorreo.TabIndex = 14;
            this.lblCorreo.Text = "Correo electronico";
            this.lblCorreo.Click += new System.EventHandler(this.lblCorreo_Click);
            // 
            // iconMail
            // 
            this.iconMail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconMail.BackColor = System.Drawing.Color.Transparent;
            this.iconMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.iconMail.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            this.iconMail.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.iconMail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMail.Location = new System.Drawing.Point(508, 245);
            this.iconMail.Margin = new System.Windows.Forms.Padding(0);
            this.iconMail.Name = "iconMail";
            this.iconMail.Size = new System.Drawing.Size(32, 32);
            this.iconMail.TabIndex = 15;
            this.iconMail.TabStop = false;
            this.iconMail.Click += new System.EventHandler(this.iconMail_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.TextWhite;
            this.pictureBox2.Location = new System.Drawing.Point(603, 52);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(378, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnVolver.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnVolver.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnVolver.BorderRadius = 60;
            this.btnVolver.BorderSize = 0;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.btnVolver.Location = new System.Drawing.Point(842, 451);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(200, 60);
            this.btnVolver.TabIndex = 19;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.btnVolver.UseVisualStyleBackColor = false;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.Transparent;
            this.btnEnviar.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnEnviar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnEnviar.BorderRadius = 60;
            this.btnEnviar.BorderSize = 2;
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnEnviar.Location = new System.Drawing.Point(504, 451);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(200, 60);
            this.btnEnviar.TabIndex = 18;
            this.btnEnviar.Text = "Restablecer";
            this.btnEnviar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnEnviar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AccessibleName = "";
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(532, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 54);
            this.label1.TabIndex = 20;
            this.label1.Text = "Bienvenido a la seccion de restablecimiento de clave. Para hacerlo debes \r\npropor" +
    "cionar tu correo electronico y te enviaremos una nueva clave para \r\nque accedas " +
    "y la cambies.\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formLoginRecuperar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1100, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.panelCorreo);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.iconMail);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formLoginRecuperar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recuperar Clave";
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTechGoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox picLogoTechGoal;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Panel panelCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private FontAwesome.Sharp.IconPictureBox iconMail;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Personalizacion.MSButton btnVolver;
        private Personalizacion.MSButton btnEnviar;
        private System.Windows.Forms.Label label1;
    }
}