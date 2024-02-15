namespace CapaPresentacion
{
    partial class formLogin
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
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.picLogoTechGoal = new System.Windows.Forms.PictureBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.iconKey = new FontAwesome.Sharp.IconPictureBox();
            this.iconMail = new FontAwesome.Sharp.IconPictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCorreo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVerClave = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new CapaPresentacion.Personalizacion.MSButton();
            this.btnIniciarSesion = new CapaPresentacion.Personalizacion.MSButton();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTechGoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconKey)).BeginInit();
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
            this.pnlLogo.TabIndex = 0;
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
            // lblCorreo
            // 
            this.lblCorreo.AccessibleName = "Correo Electronico";
            this.lblCorreo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.lblCorreo.Location = new System.Drawing.Point(534, 142);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(213, 29);
            this.lblCorreo.TabIndex = 0;
            this.lblCorreo.Text = "Correo electronico";
            // 
            // lblClave
            // 
            this.lblClave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblClave.AutoSize = true;
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.lblClave.Location = new System.Drawing.Point(534, 279);
            this.lblClave.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(136, 29);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Contraseña";
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClave.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.DimGray;
            this.txtClave.Location = new System.Drawing.Point(522, 321);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(473, 39);
            this.txtClave.TabIndex = 1;
            this.txtClave.Text = "KKtIAoKU";
            this.txtClave.Enter += new System.EventHandler(this.txtClave_Enter);
            // 
            // iconKey
            // 
            this.iconKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconKey.BackColor = System.Drawing.Color.Transparent;
            this.iconKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.iconKey.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconKey.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.iconKey.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconKey.Location = new System.Drawing.Point(502, 279);
            this.iconKey.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.iconKey.Name = "iconKey";
            this.iconKey.Size = new System.Drawing.Size(32, 32);
            this.iconKey.TabIndex = 3;
            this.iconKey.TabStop = false;
            // 
            // iconMail
            // 
            this.iconMail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconMail.BackColor = System.Drawing.Color.Transparent;
            this.iconMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.iconMail.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            this.iconMail.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.iconMail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMail.Location = new System.Drawing.Point(502, 142);
            this.iconMail.Margin = new System.Windows.Forms.Padding(0);
            this.iconMail.Name = "iconMail";
            this.iconMail.Size = new System.Drawing.Size(32, 32);
            this.iconMail.TabIndex = 1;
            this.iconMail.TabStop = false;
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
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCorreo.Location = new System.Drawing.Point(522, 181);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(0);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(506, 39);
            this.txtCorreo.TabIndex = 0;
            this.txtCorreo.Text = "Administrador@gmail.com";
            this.txtCorreo.Enter += new System.EventHandler(this.txtCorreo_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(600, 384);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "¿Olvidaste tu clave? Restablecela haciendo click aqui.";
            // 
            // panelCorreo
            // 
            this.panelCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.panelCorreo.Location = new System.Drawing.Point(502, 228);
            this.panelCorreo.Name = "panelCorreo";
            this.panelCorreo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panelCorreo.Size = new System.Drawing.Size(541, 3);
            this.panelCorreo.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.panel2.Location = new System.Drawing.Point(502, 368);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 3);
            this.panel2.TabIndex = 13;
            // 
            // btnVerClave
            // 
            this.btnVerClave.FlatAppearance.BorderSize = 0;
            this.btnVerClave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnVerClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerClave.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btnVerClave.IconColor = System.Drawing.Color.White;
            this.btnVerClave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerClave.Location = new System.Drawing.Point(1001, 321);
            this.btnVerClave.Name = "btnVerClave";
            this.btnVerClave.Size = new System.Drawing.Size(39, 39);
            this.btnVerClave.TabIndex = 14;
            this.btnVerClave.UseVisualStyleBackColor = true;
            this.btnVerClave.Click += new System.EventHandler(this.btnVerClave_Click);
            this.btnVerClave.MouseEnter += new System.EventHandler(this.btnVerClave_MouseEnter);
            this.btnVerClave.MouseLeave += new System.EventHandler(this.btnVerClave_MouseLeave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnCancelar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnCancelar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnCancelar.BorderRadius = 60;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.btnCancelar.Location = new System.Drawing.Point(840, 431);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(200, 60);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnIniciarSesion.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnIniciarSesion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnIniciarSesion.BorderRadius = 60;
            this.btnIniciarSesion.BorderSize = 2;
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnIniciarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnIniciarSesion.Location = new System.Drawing.Point(502, 431);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(200, 60);
            this.btnIniciarSesion.TabIndex = 9;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            this.btnIniciarSesion.MouseEnter += new System.EventHandler(this.btnIniciarSesion_MouseEnter);
            this.btnIniciarSesion.MouseLeave += new System.EventHandler(this.btnIniciarSesion_MouseLeave);
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1100, 550);
            this.Controls.Add(this.btnVerClave);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelCorreo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.iconKey);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.iconMail);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlLogo);
            this.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MinimumSize = new System.Drawing.Size(1100, 550);
            this.Name = "formLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.LoginV2_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTechGoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblClave;
        private FontAwesome.Sharp.IconPictureBox iconMail;
        private FontAwesome.Sharp.IconPictureBox iconKey;
        private System.Windows.Forms.PictureBox picLogoTechGoal;
        private Personalizacion.MSButton btnIniciarSesion;
        private Personalizacion.MSButton btnCancelar;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCorreo;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnVerClave;
    }
}