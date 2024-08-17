namespace CapaPresentacion.Formularios.Equipos
{
    partial class formEquipos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fpnlBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVolver = new CapaPresentacion.Personalizacion.MSButton();
            this.btnAgregarEquipo = new CapaPresentacion.Personalizacion.MSButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.equiposBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dB_TECHGOALDataSet2 = new CapaPresentacion.DB_TECHGOALDataSet2();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNombreFilter = new System.Windows.Forms.TextBox();
            this.msButton1 = new CapaPresentacion.Personalizacion.MSButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTorneoFilter = new System.Windows.Forms.TextBox();
            this.msButton2 = new CapaPresentacion.Personalizacion.MSButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEstadoFilter = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLimpiar = new CapaPresentacion.Personalizacion.MSButton();
            this.dB_TECHGOALDataSet = new CapaPresentacion.DB_TECHGOALDataSet();
            this.permisosTableAdapter = new CapaPresentacion.DB_TECHGOALDataSetTableAdapters.permisosTableAdapter();
            this.dBTECHGOALDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equiposTableAdapter = new CapaPresentacion.DB_TECHGOALDataSet2TableAdapters.equiposTableAdapter();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Paginator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fpnlBotones.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equiposBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_TECHGOALDataSet2)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_TECHGOALDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTECHGOALDataSetBindingSource)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Paginator)).BeginInit();
            this.Paginator.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpnlBotones
            // 
            this.fpnlBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fpnlBotones.Controls.Add(this.btnVolver);
            this.fpnlBotones.Controls.Add(this.btnAgregarEquipo);
            this.fpnlBotones.Location = new System.Drawing.Point(1284, 23);
            this.fpnlBotones.Name = "fpnlBotones";
            this.fpnlBotones.Size = new System.Drawing.Size(161, 77);
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
            // btnAgregarEquipo
            // 
            this.btnAgregarEquipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAgregarEquipo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAgregarEquipo.BackgroundImage = global::CapaPresentacion.Properties.Resources.agregarBlanco;
            this.btnAgregarEquipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarEquipo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(201)))), ((int)(((byte)(236)))));
            this.btnAgregarEquipo.BorderRadius = 25;
            this.btnAgregarEquipo.BorderSize = 0;
            this.btnAgregarEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEquipo.FlatAppearance.BorderSize = 0;
            this.btnAgregarEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEquipo.ForeColor = System.Drawing.Color.White;
            this.btnAgregarEquipo.Location = new System.Drawing.Point(87, 3);
            this.btnAgregarEquipo.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnAgregarEquipo.Name = "btnAgregarEquipo";
            this.btnAgregarEquipo.Size = new System.Drawing.Size(64, 64);
            this.btnAgregarEquipo.TabIndex = 3;
            this.btnAgregarEquipo.TextColor = System.Drawing.Color.White;
            this.btnAgregarEquipo.UseVisualStyleBackColor = false;
            this.btnAgregarEquipo.Click += new System.EventHandler(this.btnAgregarEquipo_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.dgvEquipos);
            this.panel5.Location = new System.Drawing.Point(12, 218);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1453, 480);
            this.panel5.TabIndex = 19;
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AllowUserToResizeColumns = false;
            this.dgvEquipos.AllowUserToResizeRows = false;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle31.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.Color.White;
            this.dgvEquipos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquipos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvEquipos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle32.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipos.DefaultCellStyle = dataGridViewCellStyle33;
            this.dgvEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvEquipos.Location = new System.Drawing.Point(0, 0);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle34.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.RowHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle35.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.Color.White;
            this.dgvEquipos.RowsDefaultCellStyle = dataGridViewCellStyle35;
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(1453, 480);
            this.dgvEquipos.TabIndex = 11;
            this.dgvEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellClick);
            // 
            // equiposBindingSource
            // 
            this.equiposBindingSource.DataMember = "equipos";
            this.equiposBindingSource.DataSource = this.dB_TECHGOALDataSet2;
            // 
            // dB_TECHGOALDataSet2
            // 
            this.dB_TECHGOALDataSet2.DataSetName = "DB_TECHGOALDataSet2";
            this.dB_TECHGOALDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
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
            this.panel4.Size = new System.Drawing.Size(1477, 762);
            this.panel4.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(90, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipos";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbEstadoFilter, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1375, 98);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.txtNombreFilter);
            this.panel3.Controls.Add(this.msButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 49);
            this.panel3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(438, 49);
            this.panel3.TabIndex = 18;
            // 
            // txtNombreFilter
            // 
            this.txtNombreFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtNombreFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreFilter.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtNombreFilter.Location = new System.Drawing.Point(13, 11);
            this.txtNombreFilter.Name = "txtNombreFilter";
            this.txtNombreFilter.Size = new System.Drawing.Size(410, 29);
            this.txtNombreFilter.TabIndex = 5;
            this.txtNombreFilter.TextChanged += new System.EventHandler(this.txtNombreFilter_TextChanged);
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
            this.msButton1.Size = new System.Drawing.Size(438, 49);
            this.msButton1.TabIndex = 22;
            this.msButton1.TextColor = System.Drawing.Color.White;
            this.msButton1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtTorneoFilter);
            this.panel1.Controls.Add(this.msButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(468, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 49);
            this.panel1.TabIndex = 11;
            // 
            // txtTorneoFilter
            // 
            this.txtTorneoFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtTorneoFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTorneoFilter.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTorneoFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtTorneoFilter.Location = new System.Drawing.Point(13, 10);
            this.txtTorneoFilter.Name = "txtTorneoFilter";
            this.txtTorneoFilter.Size = new System.Drawing.Size(407, 29);
            this.txtTorneoFilter.TabIndex = 6;
            this.txtTorneoFilter.TextChanged += new System.EventHandler(this.txtTorneoFilter_TextChanged);
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
            this.msButton2.ForeColor = System.Drawing.Color.Transparent;
            this.msButton2.Location = new System.Drawing.Point(0, 0);
            this.msButton2.Name = "msButton2";
            this.msButton2.Size = new System.Drawing.Size(438, 49);
            this.msButton2.TabIndex = 23;
            this.msButton2.TextColor = System.Drawing.Color.Transparent;
            this.msButton2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(468, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(445, 49);
            this.label2.TabIndex = 6;
            this.label2.Text = "Torneo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label6.Size = new System.Drawing.Size(445, 49);
            this.label6.TabIndex = 17;
            this.label6.Text = "Nombre";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(926, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(446, 49);
            this.label5.TabIndex = 14;
            this.label5.Text = "Estado";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEstadoFilter
            // 
            this.cmbEstadoFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEstadoFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFilter.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstadoFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbEstadoFilter.FormattingEnabled = true;
            this.cmbEstadoFilter.Location = new System.Drawing.Point(926, 49);
            this.cmbEstadoFilter.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cmbEstadoFilter.Name = "cmbEstadoFilter";
            this.cmbEstadoFilter.Size = new System.Drawing.Size(439, 37);
            this.cmbEstadoFilter.TabIndex = 9;
            this.cmbEstadoFilter.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFilter_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.camisetaNegra;
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
            this.btnLimpiar.Location = new System.Drawing.Point(1405, 156);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(40, 40);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.TextColor = System.Drawing.Color.White;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dB_TECHGOALDataSet
            // 
            this.dB_TECHGOALDataSet.DataSetName = "DB_TECHGOALDataSet";
            this.dB_TECHGOALDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // permisosTableAdapter
            // 
            this.permisosTableAdapter.ClearBeforeFill = true;
            // 
            // dBTECHGOALDataSetBindingSource
            // 
            this.dBTECHGOALDataSetBindingSource.DataSource = this.dB_TECHGOALDataSet;
            this.dBTECHGOALDataSetBindingSource.Position = 0;
            // 
            // equiposTableAdapter
            // 
            this.equiposTableAdapter.ClearBeforeFill = true;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel6.Controls.Add(this.Paginator);
            this.panel6.Location = new System.Drawing.Point(12, 704);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(617, 35);
            this.panel6.TabIndex = 133;
            // 
            // Paginator
            // 
            this.Paginator.AddNewItem = null;
            this.Paginator.BackColor = System.Drawing.Color.White;
            this.Paginator.BindingSource = this.equiposBindingSource;
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
            this.Paginator.Size = new System.Drawing.Size(617, 35);
            this.Paginator.TabIndex = 130;
            this.Paginator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::CapaPresentacion.Properties.Resources.previusG;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 32);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 35);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(39, 32);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::CapaPresentacion.Properties.Resources.nextG;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 32);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // formEquipos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1477, 762);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "formEquipos";
            this.Text = "Equipos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formEquipos_FormClosed);
            this.Load += new System.EventHandler(this.formEquipos_Load);
            this.fpnlBotones.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equiposBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_TECHGOALDataSet2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_TECHGOALDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTECHGOALDataSetBindingSource)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Paginator)).EndInit();
            this.Paginator.ResumeLayout(false);
            this.Paginator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.FlowLayoutPanel fpnlBotones;
        public Personalizacion.MSButton btnVolver;
        public Personalizacion.MSButton btnAgregarEquipo;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.DataGridView dgvEquipos;
        public System.Windows.Forms.PictureBox pictureBox1;
        public Personalizacion.MSButton btnLimpiar;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox txtNombreFilter;
        public Personalizacion.MSButton msButton1;
        public System.Windows.Forms.ComboBox cmbEstadoFilter;
        public DB_TECHGOALDataSet dB_TECHGOALDataSet;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtTorneoFilter;
        public Personalizacion.MSButton msButton2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label6;
        public DB_TECHGOALDataSetTableAdapters.permisosTableAdapter permisosTableAdapter;
        public System.Windows.Forms.BindingSource dBTECHGOALDataSetBindingSource;
        public DB_TECHGOALDataSet2 dB_TECHGOALDataSet2;
        public System.Windows.Forms.BindingSource equiposBindingSource;
        public DB_TECHGOALDataSet2TableAdapters.equiposTableAdapter equiposTableAdapter;
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