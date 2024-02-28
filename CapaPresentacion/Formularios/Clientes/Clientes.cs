using CapaPresentacion.Personalizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Clientes
{
    public partial class formClientes : Form
    {
        formInicio formInicioC;
        Funcionalidades funcionalidades = Funcionalidades.getInstance;
        public formClientes(formInicio formInicio)
        {
            InitializeComponent();
            formInicioC = formInicio;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            // ---------------------------- COLUMNA EDITAR ----------------------------

            DataGridViewImageColumn editarColumn = new DataGridViewImageColumn();
            editarColumn.HeaderText = "";
            editarColumn.Name = "editar";
            editarColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            editarColumn.Image = Properties.Resources.New_Project;
            editarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns.Add(editarColumn);

            // ---------------------------- COLUMNA BORRAR ----------------------------

            DataGridViewImageColumn borrarColumn = new DataGridViewImageColumn();
            borrarColumn.HeaderText = "";
            borrarColumn.Name = "borrar";
            borrarColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            borrarColumn.Image = Properties.Resources.trash_561125;
            borrarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns.Add(borrarColumn);

            llenarTabla();
            limpiarFiltros();


        }

        public void llenarTabla()
        {

            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet.clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.dB_TECHGOALDataSet.clientes);

            // ---------------------------- CARGA DE COMBOBOX ESTADO ----------------------------
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Activo", valor = 1 });
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Inactivo", valor = 0 });
            cmbEstadoFilter.DisplayMember = "texto";
            cmbEstadoFilter.ValueMember = "valor";

            

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }

        private void filtrar()
        {
            bool valorSeleccionado = true;
            if (cmbEstadoFilter.SelectedValue != null)
            {
                valorSeleccionado = (bool)cmbEstadoFilter.SelectedValue;

            }

            clientesBindingSource.Filter = $"nombre LIKE '%{txtNombreFilter.Text}%' AND apellido LIKE '%{txtApellidoFilter.Text}%' AND dni LIKE '%{txtDocumentoFilter.Text}%' AND estado = '{valorSeleccionado}'";
        }

        private void txtNombreFilter_TextChanged(object sender, EventArgs e)
        {
            filtrar();  
        }

        private void txtApellidoFilter_TextChanged(object sender, EventArgs e)
        {
            filtrar();

        }

        private void txtDocumentoFilter_TextChanged(object sender, EventArgs e)
        {
            filtrar();

        }

        private void cmbEstadoFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar ();
        }

        private void limpiarFiltros()
        {
            txtApellidoFilter.Text = "";
            txtNombreFilter.Text = "";
            txtDocumentoFilter.Text = "";
            cmbEstadoFilter.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFiltros();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            formClientesAgregar formClientesAgregar = new formClientesAgregar(this);
            formClientesAgregar.ShowDialog();
        }

        private void txtDocumentoFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);
        }

        private void txtApellidoFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);

        }

        private void txtNombreFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);

        }
    }
}
