using CapaControladora;
using CapaEntidad;
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
        CC_Cliente ClienteControladora = CC_Cliente.getInstance;
        public formClientes(formInicio formInicio)
        {
            InitializeComponent();
            formInicioC = formInicio;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            // ---------------------------- CARGA DE COMBOBOX ESTADO ----------------------------

            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Activo", valor = 1 });
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Inactivo", valor = 0 });
            cmbEstadoFilter.DisplayMember = "texto";
            cmbEstadoFilter.ValueMember = "valor";

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



        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }

        private void filtrar()
        {
            string filtro = $"nombre LIKE '%{txtNombreFilter.Text}%' AND apellido LIKE '%{txtApellidoFilter.Text}%' AND dni LIKE '%{txtDocumentoFilter.Text}%'";

            if (cmbEstadoFilter.SelectedIndex >= 0)
            {

                opcionCombo a = cmbEstadoFilter.Items[cmbEstadoFilter.SelectedIndex] as opcionCombo;

                if (a != null)
                {
                    filtro += " AND estado = " + a.valor;
                    
                }
            }

            clientesBindingSource.Filter = filtro;
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

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvClientes.Columns[e.ColumnIndex].Name == "editar" && e.RowIndex != -1)
                {
                    // ------------- Obtiene el valor de la celda ID ---------------------
                    DataGridViewRow filaSeleccionada = dgvClientes.CurrentRow;

                    DataGridViewCell celda = filaSeleccionada.Cells["id_cliente"];

                    int id = Convert.ToInt32(celda.Value);

                    Cliente clienteSeleccionado = ClienteControladora.EncontrarClienteID(id);

                    formClientesModificar formClientesModificar = new formClientesModificar(this, clienteSeleccionado);
                    formClientesModificar.ShowDialog();

                }

                if (dgvClientes.Columns[e.ColumnIndex].Name == "borrar" && e.RowIndex != -1)
                {
                    // ------------- Obtiene el valor de la celda ID ---------------------
                    DataGridViewRow filaSeleccionada = dgvClientes.CurrentRow;

                    DataGridViewCell celda = filaSeleccionada.Cells["id_cliente"];

                    int id = Convert.ToInt32(celda.Value);

                    Cliente clienteSeleccionado = ClienteControladora.EncontrarClienteID(id);

                    var mensaje = MessageBox.Show("¿Esta seguro de que desea borrar el cliente " + clienteSeleccionado.dni + "?", "Borrando cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (mensaje == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {

                        bool eliminarCliente = ClienteControladora.EliminarCliente(clienteSeleccionado.id_cliente);

                        if (eliminarCliente)
                        {
                            MessageBox.Show("Cliente eliminado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            llenarTabla();

                        }
                        else
                        {
                            MessageBox.Show("El cliente tiene reservas ya hechas, por lo que solo se deshabilitara.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            bool modificado = ClienteControladora.ModificarEstadoCliente(clienteSeleccionado.id_cliente, false);

                            if (modificado == false)
                            {
                                MessageBox.Show("Hubo un error al eliminar usuario. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                            MessageBox.Show("Cliente deshabilitado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            llenarTabla();
                        }

                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void dgvClientes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].Name == "editar" && e.RowIndex != -1 || dgvClientes.Columns[e.ColumnIndex].Name == "borrar" && e.RowIndex != -1)
            {
                Cursor = Cursors.Hand;
            }

        }

        private void dgvClientes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.Default;

        }
    }
}
