namespace CapaPresentacion
{
    partial class formUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstadoFilter = new System.Windows.Forms.ComboBox();
            this.cmbRolFilter = new System.Windows.Forms.ComboBox();
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dB_TECHGOALDataSet = new CapaPresentacion.DB_TECHGOALDataSet();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDNIFilter = new System.Windows.Forms.TextBox();
            this.msButton3 = new CapaPresentacion.Personalizacion.MSButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNombreFilter = new System.Windows.Forms.TextBox();
            this.msButton2 = new CapaPresentacion.Personalizacion.MSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCorreoFilter = new System.Windows.Forms.TextBox();
            this.msButton1 = new CapaPresentacion.Personalizacion.MSButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.fpnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVolver = new CapaPresentacion.Personalizacion.MSButton();
            this.btnRoles = new CapaPresentacion.Personalizacion.MSButton();
            this.btnAgregarUsuario = new CapaPresentacion.Personalizacion.MSButton();
            this.btnExportar = new CapaPresentacion.Personalizacion.MSButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLimpiar = new CapaPresentacion.Personalizacion.MSButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.permisosTableAdapter = new CapaPresentacion.DB_TECHGOALDataSetTableAdapters.permisosTableAdapter();
            this.rolTableAdapter = new CapaPresentacion.DB_TECHGOALDataSetTableAdapters.rolTableAdapter();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Paginator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_TECHGOALDataSet)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.fpnlBotones.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Paginator)).BeginInit();
            this.Paginator.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(299, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 49);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEstadoFilter
            // 
            this.cmbEstadoFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEstadoFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFilter.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstadoFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbEstadoFilter.FormattingEnabled = true;
            this.cmbEstadoFilter.Location = new System.Drawing.Point(1166, 49);
            this.cmbEstadoFilter.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cmbEstadoFilter.Name = "cmbEstadoFilter";
            this.cmbEstadoFilter.Size = new System.Drawing.Size(270, 37);
            this.cmbEstadoFilter.TabIndex = 9;
            this.cmbEstadoFilter.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFilter_SelectedIndexChanged);
            // 
            // cmbRolFilter
            // 
            this.cmbRolFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.cmbRolFilter.DataSource = this.rolBindingSource;
            this.cmbRolFilter.DisplayMember = "descripcion";
            this.cmbRolFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRolFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRolFilter.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRolFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbRolFilter.FormattingEnabled = true;
            this.cmbRolFilter.ItemHeight = 29;
            this.cmbRolFilter.Location = new System.Drawing.Point(877, 49);
            this.cmbRolFilter.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cmbRolFilter.Name = "cmbRolFilter";
            this.cmbRolFilter.Size = new System.Drawing.Size(269, 37);
            this.cmbRolFilter.TabIndex = 8;
            this.cmbRolFilter.ValueMember = "id_rol";
            this.cmbRolFilter.SelectedValueChanged += new System.EventHandler(this.cmbRolFilter_SelectedValueChanged);
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataMember = "rol";
            this.rolBindingSource.DataSource = this.dB_TECHGOALDataSet;
            // 
            // dB_TECHGOALDataSet
            // 
            this.dB_TECHGOALDataSet.DataSetName = "DB_TECHGOALDataSet";
            this.dB_TECHGOALDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtDNIFilter);
            this.panel2.Controls.Add(this.msButton3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(588, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 49);
            this.panel2.TabIndex = 15;
            // 
            // txtDNIFilter
            // 
            this.txtDNIFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtDNIFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDNIFilter.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNIFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtDNIFilter.Location = new System.Drawing.Point(13, 11);
            this.txtDNIFilter.Name = "txtDNIFilter";
            this.txtDNIFilter.Size = new System.Drawing.Size(246, 29);
            this.txtDNIFilter.TabIndex = 7;
            this.txtDNIFilter.TextChanged += new System.EventHandler(this.txtDNIFilter_TextChanged);
            this.txtDNIFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNIFilter_KeyPress);
            // 
            // msButton3
            // 
            this.msButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.msButton3.BorderRadius = 20;
            this.msButton3.BorderSize = 0;
            this.msButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msButton3.Enabled = false;
            this.msButton3.FlatAppearance.BorderSize = 0;
            this.msButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.msButton3.ForeColor = System.Drawing.Color.White;
            this.msButton3.Location = new System.Drawing.Point(0, 0);
            this.msButton3.Name = "msButton3";
            this.msButton3.Size = new System.Drawing.Size(269, 49);
            this.msButton3.TabIndex = 23;
            this.msButton3.TextColor = System.Drawing.Color.White;
            this.msButton3.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(1166, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 49);
            this.label5.TabIndex = 14;
            this.label5.Text = "Estado";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(877, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 49);
            this.label4.TabIndex = 13;
            this.label4.Text = "Rol";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(588, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 49);
            this.label3.TabIndex = 12;
            this.label3.Text = "Documento";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtNombreFilter);
            this.panel1.Controls.Add(this.msButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(299, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 49);
            this.panel1.TabIndex = 11;
            // 
            // txtNombreFilter
            // 
            this.txtNombreFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtNombreFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreFilter.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtNombreFilter.Location = new System.Drawing.Point(13, 10);
            this.txtNombreFilter.Name = "txtNombreFilter";
            this.txtNombreFilter.Size = new System.Drawing.Size(246, 29);
            this.txtNombreFilter.TabIndex = 6;
            this.txtNombreFilter.TextChanged += new System.EventHandler(this.txtNombreFilter_TextChanged);
            this.txtNombreFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreFilter_KeyPress);
            // 
            // msButton2
            // 
            this.msButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.msButton2.BorderRadius = 20;
            this.msButton2.BorderSize = 0;
            this.msButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msButton2.Enabled = false;
            this.msButton2.FlatAppearance.BorderSize = 0;
            this.msButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.msButton2.ForeColor = System.Drawing.Color.White;
            this.msButton2.Location = new System.Drawing.Point(0, 0);
            this.msButton2.Name = "msButton2";
            this.msButton2.Size = new System.Drawing.Size(269, 49);
            this.msButton2.TabIndex = 23;
            this.msButton2.TextColor = System.Drawing.Color.White;
            this.msButton2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(90, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuarios";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbEstadoFilter, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbRolFilter, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1446, 98);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtCorreoFilter);
            this.panel3.Controls.Add(this.msButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 49);
            this.panel3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 49);
            this.panel3.TabIndex = 18;
            // 
            // txtCorreoFilter
            // 
            this.txtCorreoFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtCorreoFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreoFilter.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtCorreoFilter.Location = new System.Drawing.Point(13, 11);
            this.txtCorreoFilter.Name = "txtCorreoFilter";
            this.txtCorreoFilter.Size = new System.Drawing.Size(246, 29);
            this.txtCorreoFilter.TabIndex = 5;
            this.txtCorreoFilter.TextChanged += new System.EventHandler(this.txtCorreoFilter_TextChanged);
            // 
            // msButton1
            // 
            this.msButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.msButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.msButton1.BorderRadius = 20;
            this.msButton1.BorderSize = 0;
            this.msButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msButton1.Enabled = false;
            this.msButton1.FlatAppearance.BorderSize = 0;
            this.msButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.msButton1.ForeColor = System.Drawing.Color.White;
            this.msButton1.Location = new System.Drawing.Point(0, 0);
            this.msButton1.Name = "msButton1";
            this.msButton1.Size = new System.Drawing.Size(269, 49);
            this.msButton1.TabIndex = 22;
            this.msButton1.TextColor = System.Drawing.Color.White;
            this.msButton1.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Location = new System.Drawing.Point(10, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(276, 49);
            this.label6.TabIndex = 17;
            this.label6.Text = "E - mail";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.fpnlBotones);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.btnLimpiar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1548, 712);
            this.panel4.TabIndex = 18;
            // 
            // fpnlBotones
            // 
            this.fpnlBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlBotones.Controls.Add(this.btnVolver);
            this.fpnlBotones.Controls.Add(this.btnRoles);
            this.fpnlBotones.Controls.Add(this.btnAgregarUsuario);
            this.fpnlBotones.Controls.Add(this.btnExportar);
            this.fpnlBotones.Location = new System.Drawing.Point(1196, 23);
            this.fpnlBotones.Name = "fpnlBotones";
            this.fpnlBotones.Size = new System.Drawing.Size(320, 77);
            this.fpnlBotones.TabIndex = 71;
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
            // btnRoles
            // 
            this.btnRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRoles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRoles.BackgroundImage = global::CapaPresentacion.Properties.Resources.RolesWhite1;
            this.btnRoles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRoles.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnRoles.BorderRadius = 25;
            this.btnRoles.BorderSize = 0;
            this.btnRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoles.FlatAppearance.BorderSize = 0;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.ForeColor = System.Drawing.Color.White;
            this.btnRoles.Location = new System.Drawing.Point(87, 3);
            this.btnRoles.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(64, 64);
            this.btnRoles.TabIndex = 2;
            this.btnRoles.TextColor = System.Drawing.Color.White;
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAgregarUsuario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAgregarUsuario.BackgroundImage = global::CapaPresentacion.Properties.Resources.agregarBlanco;
            this.btnAgregarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarUsuario.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnAgregarUsuario.BorderRadius = 25;
            this.btnAgregarUsuario.BorderSize = 0;
            this.btnAgregarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarUsuario.FlatAppearance.BorderSize = 0;
            this.btnAgregarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnAgregarUsuario.Location = new System.Drawing.Point(164, 3);
            this.btnAgregarUsuario.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(64, 64);
            this.btnAgregarUsuario.TabIndex = 3;
            this.btnAgregarUsuario.TextColor = System.Drawing.Color.White;
            this.btnAgregarUsuario.UseVisualStyleBackColor = false;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            this.btnExportar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            this.btnExportar.BackgroundImage = global::CapaPresentacion.Properties.Resources.excelBlanco;
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnExportar.BorderRadius = 25;
            this.btnExportar.BorderSize = 0;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(241, 3);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(64, 64);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.TextColor = System.Drawing.Color.White;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.dgvUsuarios);
            this.panel5.Location = new System.Drawing.Point(12, 218);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1524, 430);
            this.panel5.TabIndex = 19;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeColumns = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvUsuarios.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 0);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(1524, 430);
            this.dgvUsuarios.TabIndex = 11;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            this.dgvUsuarios.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellMouseEnter);
            this.dgvUsuarios.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellMouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.userBlack__1_;
            this.pictureBox1.Location = new System.Drawing.Point(20, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLimpiar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLimpiar.BackgroundImage = global::CapaPresentacion.Properties.Resources.clear__2_;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpiar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(20)))));
            this.btnLimpiar.BorderRadius = 20;
            this.btnLimpiar.BorderSize = 0;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(1476, 156);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(40, 40);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.TextColor = System.Drawing.Color.White;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewImageColumn1.FillWeight = 126.9036F;
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewImageColumn2.FillWeight = 97.0107F;
            this.dataGridViewImageColumn2.HeaderText = "Eliminar";
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // permisosTableAdapter
            // 
            this.permisosTableAdapter.ClearBeforeFill = true;
            // 
            // rolTableAdapter
            // 
            this.rolTableAdapter.ClearBeforeFill = true;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel6.Controls.Add(this.Paginator);
            this.panel6.Location = new System.Drawing.Point(12, 654);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1113, 46);
            this.panel6.TabIndex = 72;
            // 
            // Paginator
            // 
            this.Paginator.AddNewItem = null;
            this.Paginator.BackColor = System.Drawing.Color.White;
            this.Paginator.CanOverflow = false;
            this.Paginator.CountItem = null;
            this.Paginator.CountItemFormat = "";
            this.Paginator.DeleteItem = null;
            this.Paginator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Paginator.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paginator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Paginator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorSeparator2});
            this.Paginator.Location = new System.Drawing.Point(0, 0);
            this.Paginator.MoveFirstItem = null;
            this.Paginator.MoveLastItem = null;
            this.Paginator.MoveNextItem = null;
            this.Paginator.MovePreviousItem = null;
            this.Paginator.Name = "Paginator";
            this.Paginator.PositionItem = null;
            this.Paginator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Paginator.Size = new System.Drawing.Size(1113, 46);
            this.Paginator.TabIndex = 131;
            this.Paginator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::CapaPresentacion.Properties.Resources.previusG;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 43);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 46);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(39, 43);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::CapaPresentacion.Properties.Resources.nextG;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 43);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // formUsuarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1548, 712);
            this.Controls.Add(this.panel4);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "formUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.formUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_TECHGOALDataSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.fpnlBotones.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Paginator)).EndInit();
            this.Paginator.ResumeLayout(false);
            this.Paginator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNombreFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRolFilter;
        private System.Windows.Forms.TextBox txtDNIFilter;
        private System.Windows.Forms.ComboBox cmbEstadoFilter;
        private Personalizacion.MSButton btnLimpiar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCorreoFilter;
        private System.Windows.Forms.Label label6;
        private Personalizacion.MSButton btnAgregarUsuario;
        private Personalizacion.MSButton btnExportar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private DB_TECHGOALDataSetTableAdapters.permisosTableAdapter permisosTableAdapter;
        private DB_TECHGOALDataSet dB_TECHGOALDataSet;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private DB_TECHGOALDataSetTableAdapters.rolTableAdapter rolTableAdapter;
        private Personalizacion.MSButton msButton1;
        private Personalizacion.MSButton msButton3;
        private Personalizacion.MSButton msButton2;
        private Personalizacion.MSButton btnRoles;
        private Personalizacion.MSButton btnVolver;
        private System.Windows.Forms.FlowLayoutPanel fpnlBotones;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.BindingNavigator Paginator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    }
}