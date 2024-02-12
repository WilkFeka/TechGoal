using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Personalizacion;
using CapaControladora;
using CapaEntidad;
using System.Windows.Controls;
using CapaPresentacion.Formularios;
using System.Data.Common;

namespace CapaPresentacion
{
    public partial class formUsuarios : Form
    {
        private CC_Usuario UsuarioControladora = CC_Usuario.getInstance;
        private Funcionalidades funcionalidades = Funcionalidades.getInstance;
        public formUsuarios()
        {
            InitializeComponent();
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet.rol' Puede moverla o quitarla según sea necesario.
            this.rolTableAdapter.Fill(dB_TECHGOALDataSet.rol);


            // / ---------------------------- CARGA DE TABLA SUUARIOS ----------------------------
            DataTable tablaUsuarios = new DataTable();
            UsuarioControladora.CargarTablaUsuarios(tablaUsuarios);
            dgvUsuarios.DataSource = tablaUsuarios;

            dgvUsuarios.Columns["id_usuario"].Visible = false;
            dgvUsuarios.Columns["id_rol"].Visible = false;
            dgvUsuarios.Columns["clave"].Visible = false;


            dgvUsuarios.Columns["email"].HeaderText = "Correo";
            dgvUsuarios.Columns["nombre"].HeaderText = "Nombre";
            dgvUsuarios.Columns["apellido"].HeaderText = "Apellido";
            dgvUsuarios.Columns["dni"].HeaderText = "Documento";
            dgvUsuarios.Columns["telefono"].HeaderText = "Telefono";
            dgvUsuarios.Columns["estado"].HeaderText = "Estado";
            dgvUsuarios.Columns["fechaRegistro"].HeaderText = "Fecha Registro";
            dgvUsuarios.Columns["descripcion"].HeaderText = "Rol";

            dgvUsuarios.Columns["estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;





            // ---------------------------- COLUMNA EDITAR ----------------------------

            DataGridViewImageColumn editarColumn = new DataGridViewImageColumn();
            editarColumn.HeaderText = "";
            editarColumn.Name = "editar"; 
            editarColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; 
            editarColumn.Image = Properties.Resources.New_Project; 
            editarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns.Add(editarColumn);

            // ---------------------------- COLUMNA BORRAR ----------------------------

            DataGridViewImageColumn borrarColumn = new DataGridViewImageColumn();
            borrarColumn.HeaderText = "";
            borrarColumn.Name = "borrar"; 
            borrarColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            borrarColumn.Image = Properties.Resources.trash_561125; 
            borrarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns.Add(borrarColumn);


            // ---------------------------- CARGA DE COMBOBOX ESTADO ----------------------------
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Activo", valor = 1 });
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Inactivo", valor = 0 });
            cmbEstadoFilter.DisplayMember = "texto";
            cmbEstadoFilter.ValueMember = "valor";



            limpiarFiltros();
        }

        private void txtCorreoFilter_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtNombreFilter_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtDNIFilter_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
            
        }

        private void cmbRolFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            Filtrar();

        }

        private void cmbEstadoFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();

        }

        private void Filtrar()
        {
            string rolQuery = "";
            string estadoQuery = "";


            if (cmbRolFilter.SelectedValue != null)
            {
                string rolID = cmbRolFilter.SelectedValue.ToString();
                rolQuery = " AND id_rol = " + rolID;

            }

            if (cmbEstadoFilter.SelectedItem != null)
            {
                foreach (opcionCombo item in cmbEstadoFilter.Items)
                {
                    if (item.texto == cmbEstadoFilter.Text)
                    {
                        estadoQuery = " AND estado = " + item.valor;
                    }
                }   

            }


            //usuariosBindingSource.Filter = "email LIKE '%" + txtCorreoFilter.Text + "%' AND nombre LIKE '%" + txtNombreFilter.Text + "%' AND dni LIKE '%" + txtDNIFilter.Text + "%'" + rolQuery + estadoQuery;

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFiltros();
        }

        private void limpiarFiltros()
        {
            txtCorreoFilter.Text = "";
            txtNombreFilter.Text = "";
            txtDNIFilter.Text = "";
            cmbRolFilter.SelectedIndex = -1;
            cmbEstadoFilter.SelectedIndex = -1;
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Form agregar = new formUsuarioAgregar();
            agregar.ShowDialog();

        }

        private void txtNombreFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);

        }

        private void txtDNIFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);

        }

        public void RecargarTabla()
        {
            dgvUsuarios.Refresh();
        }
    }
}
