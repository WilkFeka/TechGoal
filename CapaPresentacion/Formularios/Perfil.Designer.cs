namespace CapaPresentacion.Formularios
{
    partial class formPerfil
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
            this.components = new System.ComponentModel.Container();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rolTableAdapter = new CapaPresentacion.DB_TECHGOALDataSetTableAdapters.rolTableAdapter();
            this.dB_TECHGOALDataSet = new CapaPresentacion.DB_TECHGOALDataSet();
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar = new CapaPresentacion.Personalizacion.MSButton();
            this.btnFondoCorreo = new CapaPresentacion.Personalizacion.MSButton();
            this.btnFondoNombre = new CapaPresentacion.Personalizacion.MSButton();
            this.btnFondoApellido = new CapaPresentacion.Personalizacion.MSButton();
            this.btnFondoDocumento = new CapaPresentacion.Personalizacion.MSButton();
            this.btnFondoClave = new CapaPresentacion.Personalizacion.MSButton();
            this.msButton5 = new CapaPresentacion.Personalizacion.MSButton();
            this.btnCancelar = new CapaPresentacion.Personalizacion.MSButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnVerClave = new CapaPresentacion.Personalizacion.MSButton();
            this.btnVolver = new CapaPresentacion.Personalizacion.MSButton();
            this.btnEditar = new CapaPresentacion.Personalizacion.MSButton();
            this.btnNuevaClave = new CapaPresentacion.Personalizacion.MSButton();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dB_TECHGOALDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlContainer.Controls.Add(this.btnVerClave);
            this.pnlContainer.Controls.Add(this.lblClave);
            this.pnlContainer.Controls.Add(this.txtTelefono);
            this.pnlContainer.Controls.Add(this.txtClave);
            this.pnlContainer.Controls.Add(this.btnAceptar);
            this.pnlContainer.Controls.Add(this.label4);
            this.pnlContainer.Controls.Add(this.label3);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Controls.Add(this.txtApellido);
            this.pnlContainer.Controls.Add(this.lblNombre);
            this.pnlContainer.Controls.Add(this.txtNombre);
            this.pnlContainer.Controls.Add(this.lblCorreo);
            this.pnlContainer.Controls.Add(this.txtDocumento);
            this.pnlContainer.Controls.Add(this.txtCorreo);
            this.pnlContainer.Controls.Add(this.btnFondoCorreo);
            this.pnlContainer.Controls.Add(this.btnFondoNombre);
            this.pnlContainer.Controls.Add(this.btnFondoApellido);
            this.pnlContainer.Controls.Add(this.btnFondoDocumento);
            this.pnlContainer.Controls.Add(this.btnFondoClave);
            this.pnlContainer.Controls.Add(this.msButton5);
            this.pnlContainer.Controls.Add(this.btnCancelar);
            this.pnlContainer.Controls.Add(this.btnVolver);
            this.pnlContainer.Controls.Add(this.btnEditar);
            this.pnlContainer.Controls.Add(this.btnNuevaClave);
            this.pnlContainer.Location = new System.Drawing.Point(138, 203);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1030, 464);
            this.pnlContainer.TabIndex = 81;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblClave.Location = new System.Drawing.Point(558, 202);
            this.lblClave.Margin = new System.Windows.Forms.Padding(0, 20, 0, 5);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(223, 29);
            this.lblClave.TabIndex = 88;
            this.lblClave.Text = "Clave confirmacion";
            this.lblClave.Visible = false;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtTelefono.Location = new System.Drawing.Point(568, 153);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(0);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(429, 29);
            this.txtTelefono.TabIndex = 75;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClave.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtClave.Location = new System.Drawing.Point(568, 248);
            this.txtClave.Margin = new System.Windows.Forms.Padding(0);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(350, 29);
            this.txtClave.TabIndex = 76;
            this.txtClave.TabStop = false;
            this.txtClave.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(558, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 20, 0, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 29);
            this.label4.TabIndex = 87;
            this.label4.Text = "Telefono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(558, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 20, 0, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 29);
            this.label3.TabIndex = 86;
            this.label3.Text = "Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(30, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 20, 0, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 29);
            this.label2.TabIndex = 85;
            this.label2.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellido.Enabled = false;
            this.txtApellido.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtApellido.Location = new System.Drawing.Point(34, 247);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(0);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(429, 29);
            this.txtApellido.TabIndex = 73;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNombre.Location = new System.Drawing.Point(30, 107);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(0, 20, 0, 5);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(101, 29);
            this.lblNombre.TabIndex = 84;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtNombre.Location = new System.Drawing.Point(34, 153);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(0);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(429, 29);
            this.txtNombre.TabIndex = 72;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCorreo.Location = new System.Drawing.Point(30, 8);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(88, 29);
            this.lblCorreo.TabIndex = 83;
            this.lblCorreo.Text = "Correo";
            // 
            // txtDocumento
            // 
            this.txtDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDocumento.Enabled = false;
            this.txtDocumento.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtDocumento.Location = new System.Drawing.Point(567, 53);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(0);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(429, 29);
            this.txtDocumento.TabIndex = 74;
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Enabled = false;
            this.txtCorreo.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtCorreo.Location = new System.Drawing.Point(34, 53);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(0);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(429, 29);
            this.txtCorreo.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(566, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 77);
            this.label1.TabIndex = 80;
            this.label1.Text = "Mi Perfil";
            // 
            // rolTableAdapter
            // 
            this.rolTableAdapter.ClearBeforeFill = true;
            // 
            // dB_TECHGOALDataSet
            // 
            this.dB_TECHGOALDataSet.DataSetName = "DB_TECHGOALDataSet";
            this.dB_TECHGOALDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataMember = "rol";
            this.rolBindingSource.DataSource = this.dB_TECHGOALDataSet;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnAceptar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnAceptar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnAceptar.BorderRadius = 30;
            this.btnAceptar.BorderSize = 0;
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(787, 375);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(220, 71);
            this.btnAceptar.TabIndex = 66;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextColor = System.Drawing.Color.White;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Visible = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnFondoCorreo
            // 
            this.btnFondoCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoCorreo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoCorreo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnFondoCorreo.BorderRadius = 20;
            this.btnFondoCorreo.BorderSize = 0;
            this.btnFondoCorreo.Enabled = false;
            this.btnFondoCorreo.FlatAppearance.BorderSize = 0;
            this.btnFondoCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFondoCorreo.ForeColor = System.Drawing.Color.White;
            this.btnFondoCorreo.Location = new System.Drawing.Point(23, 42);
            this.btnFondoCorreo.Margin = new System.Windows.Forms.Padding(15, 0, 3, 30);
            this.btnFondoCorreo.Name = "btnFondoCorreo";
            this.btnFondoCorreo.Size = new System.Drawing.Size(456, 50);
            this.btnFondoCorreo.TabIndex = 82;
            this.btnFondoCorreo.TextColor = System.Drawing.Color.White;
            this.btnFondoCorreo.UseVisualStyleBackColor = false;
            // 
            // btnFondoNombre
            // 
            this.btnFondoNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoNombre.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoNombre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnFondoNombre.BorderRadius = 20;
            this.btnFondoNombre.BorderSize = 0;
            this.btnFondoNombre.Enabled = false;
            this.btnFondoNombre.FlatAppearance.BorderSize = 0;
            this.btnFondoNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFondoNombre.ForeColor = System.Drawing.Color.White;
            this.btnFondoNombre.Location = new System.Drawing.Point(23, 141);
            this.btnFondoNombre.Margin = new System.Windows.Forms.Padding(15, 0, 3, 30);
            this.btnFondoNombre.Name = "btnFondoNombre";
            this.btnFondoNombre.Size = new System.Drawing.Size(456, 50);
            this.btnFondoNombre.TabIndex = 81;
            this.btnFondoNombre.TextColor = System.Drawing.Color.White;
            this.btnFondoNombre.UseVisualStyleBackColor = false;
            // 
            // btnFondoApellido
            // 
            this.btnFondoApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoApellido.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoApellido.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnFondoApellido.BorderRadius = 20;
            this.btnFondoApellido.BorderSize = 0;
            this.btnFondoApellido.Enabled = false;
            this.btnFondoApellido.FlatAppearance.BorderSize = 0;
            this.btnFondoApellido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFondoApellido.ForeColor = System.Drawing.Color.White;
            this.btnFondoApellido.Location = new System.Drawing.Point(23, 236);
            this.btnFondoApellido.Margin = new System.Windows.Forms.Padding(15, 0, 3, 30);
            this.btnFondoApellido.Name = "btnFondoApellido";
            this.btnFondoApellido.Size = new System.Drawing.Size(456, 50);
            this.btnFondoApellido.TabIndex = 80;
            this.btnFondoApellido.TextColor = System.Drawing.Color.White;
            this.btnFondoApellido.UseVisualStyleBackColor = false;
            // 
            // btnFondoDocumento
            // 
            this.btnFondoDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoDocumento.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoDocumento.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnFondoDocumento.BorderRadius = 20;
            this.btnFondoDocumento.BorderSize = 0;
            this.btnFondoDocumento.Enabled = false;
            this.btnFondoDocumento.FlatAppearance.BorderSize = 0;
            this.btnFondoDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFondoDocumento.ForeColor = System.Drawing.Color.White;
            this.btnFondoDocumento.Location = new System.Drawing.Point(551, 42);
            this.btnFondoDocumento.Margin = new System.Windows.Forms.Padding(15, 0, 3, 30);
            this.btnFondoDocumento.Name = "btnFondoDocumento";
            this.btnFondoDocumento.Size = new System.Drawing.Size(456, 50);
            this.btnFondoDocumento.TabIndex = 79;
            this.btnFondoDocumento.TextColor = System.Drawing.Color.White;
            this.btnFondoDocumento.UseVisualStyleBackColor = false;
            // 
            // btnFondoClave
            // 
            this.btnFondoClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoClave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnFondoClave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnFondoClave.BorderRadius = 20;
            this.btnFondoClave.BorderSize = 0;
            this.btnFondoClave.Enabled = false;
            this.btnFondoClave.FlatAppearance.BorderSize = 0;
            this.btnFondoClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFondoClave.ForeColor = System.Drawing.Color.White;
            this.btnFondoClave.Location = new System.Drawing.Point(552, 236);
            this.btnFondoClave.Margin = new System.Windows.Forms.Padding(15, 0, 3, 30);
            this.btnFondoClave.Name = "btnFondoClave";
            this.btnFondoClave.Size = new System.Drawing.Size(384, 50);
            this.btnFondoClave.TabIndex = 78;
            this.btnFondoClave.TextColor = System.Drawing.Color.White;
            this.btnFondoClave.UseVisualStyleBackColor = false;
            this.btnFondoClave.Visible = false;
            // 
            // msButton5
            // 
            this.msButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.msButton5.BorderRadius = 20;
            this.msButton5.BorderSize = 0;
            this.msButton5.Enabled = false;
            this.msButton5.FlatAppearance.BorderSize = 0;
            this.msButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.msButton5.ForeColor = System.Drawing.Color.White;
            this.msButton5.Location = new System.Drawing.Point(552, 142);
            this.msButton5.Margin = new System.Windows.Forms.Padding(15, 0, 3, 30);
            this.msButton5.Name = "msButton5";
            this.msButton5.Size = new System.Drawing.Size(456, 50);
            this.msButton5.TabIndex = 77;
            this.msButton5.TextColor = System.Drawing.Color.White;
            this.msButton5.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancelar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancelar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancelar.BorderRadius = 30;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(551, 375);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(220, 71);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.userBlack;
            this.pictureBox1.Location = new System.Drawing.Point(342, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 82;
            this.pictureBox1.TabStop = false;
            // 
            // btnVerClave
            // 
            this.btnVerClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnVerClave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnVerClave.BackgroundImage = global::CapaPresentacion.Properties.Resources.eyeW__1_;
            this.btnVerClave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVerClave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnVerClave.BorderRadius = 20;
            this.btnVerClave.BorderSize = 0;
            this.btnVerClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerClave.FlatAppearance.BorderSize = 0;
            this.btnVerClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerClave.ForeColor = System.Drawing.Color.White;
            this.btnVerClave.Location = new System.Drawing.Point(956, 236);
            this.btnVerClave.Margin = new System.Windows.Forms.Padding(10, 0, 3, 30);
            this.btnVerClave.Name = "btnVerClave";
            this.btnVerClave.Size = new System.Drawing.Size(51, 50);
            this.btnVerClave.TabIndex = 83;
            this.btnVerClave.TextColor = System.Drawing.Color.White;
            this.btnVerClave.UseVisualStyleBackColor = false;
            this.btnVerClave.Click += new System.EventHandler(this.btnVerClave_Click);
            // 
            // btnVolver
            // 
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
            this.btnVolver.Location = new System.Drawing.Point(23, 359);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 100);
            this.btnVolver.TabIndex = 70;
            this.btnVolver.TextColor = System.Drawing.Color.White;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEditar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEditar.BackgroundImage = global::CapaPresentacion.Properties.Resources.lapizBlanco;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnEditar.BorderRadius = 25;
            this.btnEditar.BorderSize = 0;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(204, 359);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 100);
            this.btnEditar.TabIndex = 22;
            this.btnEditar.TextColor = System.Drawing.Color.White;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevaClave
            // 
            this.btnNuevaClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnNuevaClave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnNuevaClave.BackgroundImage = global::CapaPresentacion.Properties.Resources.generadorContrasenia;
            this.btnNuevaClave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNuevaClave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnNuevaClave.BorderRadius = 25;
            this.btnNuevaClave.BorderSize = 0;
            this.btnNuevaClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaClave.FlatAppearance.BorderSize = 0;
            this.btnNuevaClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaClave.ForeColor = System.Drawing.Color.White;
            this.btnNuevaClave.Location = new System.Drawing.Point(379, 359);
            this.btnNuevaClave.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnNuevaClave.Name = "btnNuevaClave";
            this.btnNuevaClave.Size = new System.Drawing.Size(100, 100);
            this.btnNuevaClave.TabIndex = 20;
            this.btnNuevaClave.TextColor = System.Drawing.Color.White;
            this.btnNuevaClave.UseVisualStyleBackColor = false;
            this.btnNuevaClave.Click += new System.EventHandler(this.btnNuevaClave_Click);
            // 
            // formPerfil
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 791);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.label1);
            this.Name = "formPerfil";
            this.Text = "Perfil";
            this.Load += new System.EventHandler(this.formPerfil_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dB_TECHGOALDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Personalizacion.MSButton btnNuevaClave;
        private Personalizacion.MSButton btnEditar;
        private Personalizacion.MSButton btnVolver;
        private Personalizacion.MSButton btnAceptar;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtCorreo;
        private Personalizacion.MSButton btnFondoCorreo;
        private Personalizacion.MSButton btnFondoNombre;
        private Personalizacion.MSButton btnFondoApellido;
        private Personalizacion.MSButton btnFondoDocumento;
        private Personalizacion.MSButton btnFondoClave;
        private Personalizacion.MSButton msButton5;
        private DB_TECHGOALDataSetTableAdapters.rolTableAdapter rolTableAdapter;
        private DB_TECHGOALDataSet dB_TECHGOALDataSet;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private Personalizacion.MSButton btnCancelar;
        private Personalizacion.MSButton btnVerClave;
    }
}