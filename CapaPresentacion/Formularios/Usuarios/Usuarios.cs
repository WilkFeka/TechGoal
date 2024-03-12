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
        private formInicio formInicioC;

        public formUsuarios(formInicio formInicio)
        {
            InitializeComponent();
            formInicioC = formInicio;
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet.rol' Puede moverla o quitarla según sea necesario.
            this.rolTableAdapter.Fill(dB_TECHGOALDataSet.rol);



            // ---------------------------- CARGA DE COMBOBOX ESTADO ----------------------------
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Activo", valor = 1 });
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Inactivo", valor = 0 });
            cmbEstadoFilter.DisplayMember = "texto";
            cmbEstadoFilter.ValueMember = "valor";

            LlenarTabla();

            limpiarFiltros();

            

        }

        public void LlenarTabla()
        {
            string estadoSeleccionado = "";

            if (cmbEstadoFilter.SelectedItem != null)
            {
                opcionCombo estado = (opcionCombo)cmbEstadoFilter.SelectedItem;
                int valorSeleccionado = estado.valor;

                estadoSeleccionado = valorSeleccionado.ToString();

            }

            if (dgvUsuarios.DataSource == null)
            {
                DataTable tablaUsuarios = new DataTable();
                UsuarioControladora.CargarTablaUsuarios(tablaUsuarios, txtCorreoFilter.Text, txtNombreFilter.Text, txtDNIFilter.Text, cmbRolFilter.SelectedValue, estadoSeleccionado);
                dgvUsuarios.DataSource = tablaUsuarios;

                // / ---------------------------- CARGA DE TABLA SUUARIOS ----------------------------

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

                // ---------------------------- COLUMNA NUEVA CLAVE ----------------------------

                DataGridViewImageColumn nuevaClave = new DataGridViewImageColumn();
                nuevaClave.HeaderText = "";
                nuevaClave.Name = "nuevaClave";
                nuevaClave.ImageLayout = DataGridViewImageCellLayout.Zoom;
                nuevaClave.Image = Properties.Resources.GenNuevaClave;
                nuevaClave.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvUsuarios.Columns.Add(nuevaClave);

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

                

            } else
            {
                DataTable tablaUsuarios = new DataTable();
                UsuarioControladora.CargarTablaUsuarios(tablaUsuarios, txtCorreoFilter.Text, txtNombreFilter.Text, txtDNIFilter.Text, cmbRolFilter.SelectedValue, estadoSeleccionado);
                dgvUsuarios.DataSource = tablaUsuarios;
            }



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
            LlenarTabla();
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
            Form agregar = new formUsuarioAgregar(this);
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

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvUsuarios.Columns[e.ColumnIndex].Name == "editar" && e.RowIndex != -1)
                {
                    // ------------- Obtiene el valor de la celda ID ---------------------
                    DataGridViewRow filaSeleccionada = dgvUsuarios.CurrentRow;

                    DataGridViewCell celda = filaSeleccionada.Cells["id_usuario"];

                    int id = Convert.ToInt32(celda.Value);

                    Usuario usuarioSeleccionado = UsuarioControladora.EncontrarUsuarioID(id);

                    formUsuarioModificar formUsuarioModificar = new formUsuarioModificar(this, usuarioSeleccionado);
                    formUsuarioModificar.ShowDialog();

                }

                if (dgvUsuarios.Columns[e.ColumnIndex].Name == "borrar" && e.RowIndex != -1)
                {
                    // ------------- Obtiene el valor de la celda ID ---------------------
                    DataGridViewRow filaSeleccionada = dgvUsuarios.CurrentRow;

                    DataGridViewCell celda = filaSeleccionada.Cells["id_usuario"];

                    int id = Convert.ToInt32(celda.Value);

                    Usuario usuarioSeleccionado = UsuarioControladora.EncontrarUsuarioID(id);

                    var mensaje = MessageBox.Show("¿Esta seguro de que desea borrar el usuario " + usuarioSeleccionado.email + "?", "Borrando usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (mensaje == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (usuarioSeleccionado.id_usuario == 12)
                        {
                            MessageBox.Show("No es posible borrar el usuario administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;


                        }

                        bool eliminarUsuario = UsuarioControladora.EliminarUsuario(usuarioSeleccionado.id_usuario);

                        if (eliminarUsuario)
                        {
                            MessageBox.Show("Usuario eliminado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LlenarTabla();

                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al eliminar usuario. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }

                if (dgvUsuarios.Columns[e.ColumnIndex].Name == "nuevaClave" && e.RowIndex != -1)
                {
                    // ------------- Obtiene el valor de la celda ID ---------------------
                    DataGridViewRow filaSeleccionada = dgvUsuarios.CurrentRow;

                    DataGridViewCell celda = filaSeleccionada.Cells["id_usuario"];

                    int id = Convert.ToInt32(celda.Value);

                    Usuario usuarioSeleccionado = UsuarioControladora.EncontrarUsuarioID(id);

                    formUsuarioNuevaClave formUsuarioNuevaClave = new formUsuarioNuevaClave(this, usuarioSeleccionado);
                    formUsuarioNuevaClave.ShowDialog();

                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            
        }

        private void dgvUsuarios_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "nuevaClave" && e.RowIndex != -1 || dgvUsuarios.Columns[e.ColumnIndex].Name == "editar" && e.RowIndex != -1 || dgvUsuarios.Columns[e.ColumnIndex].Name == "borrar" && e.RowIndex != -1)
            {
                Cursor = Cursors.Hand;
            }

        }

        private void dgvUsuarios_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            formInicioC.AbrirFormulario(new formRoles(formInicioC)); // Sirve para que se pueda mostrar el formulario de roles y ocultar el de usuarios
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        { // Seleccionar la ubicación para guardar el archivo Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;

                // Exportar el DataGridView actualmente filtrado a Excel
                funcionalidades.ExportarDataGridViewAExcel(dgvUsuarios, rutaArchivo);
            }
        }
    }
}
