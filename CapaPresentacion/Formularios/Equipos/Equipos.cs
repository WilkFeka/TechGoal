using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaControladora;
using CapaPresentacion.Personalizacion;

namespace CapaPresentacion.Formularios.Equipos
{
    public partial class formEquipos : Form
    {
        private formInicio formInicioC;
        private CC_Equipos EquiposControladora = CC_Equipos.getInstance;


        public formEquipos(formInicio formInicio)
        {
            InitializeComponent();
            formInicioC = formInicio;

        }

        private void formEquipos_Load(object sender, EventArgs e)
        {
            // ---------------------------- CARGA DE COMBOBOX ESTADO ----------------------------
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Activo", valor = 1 });
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Inactivo", valor = 0 });
            cmbEstadoFilter.DisplayMember = "texto";
            cmbEstadoFilter.ValueMember = "valor";

            llenarTabla();
            


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }

        private void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            formAgregarEquipos formAgregarEquipos = new formAgregarEquipos();
            formAgregarEquipos.ShowDialog();

           

        }

        private void llenarTabla()
        {
            string estadoSeleccionado = "";

            dgvEquipos.DataSource = null;
            if (dgvEquipos.Columns.Contains("borrar")) dgvEquipos.Columns.Remove("borrar");
            if (dgvEquipos.Columns.Contains("editar")) dgvEquipos.Columns.Remove("editar");




            if (cmbEstadoFilter.SelectedItem != null)
            {
                opcionCombo estado = (opcionCombo)cmbEstadoFilter.SelectedItem;
                int valorSeleccionado = estado.valor;

                estadoSeleccionado = valorSeleccionado.ToString();

            }

                DataTable tablaEquipos = new DataTable();
                EquiposControladora.CargarTablaEquipos(tablaEquipos, txtNombreFilter.Text, txtTorneoFilter.Text, estadoSeleccionado);
                // Establecer el DataSource del DataGridView
                dgvEquipos.DataSource = tablaEquipos;

                // Agregar una columna de imagen al DataTable
                DataColumn imgCol = new DataColumn("ImagenEscudo", typeof(Image));

                tablaEquipos.Columns.Add(imgCol);

                // Llenar la columna de imagen en el DataTable
                foreach (DataRow row in tablaEquipos.Rows)
                {
                    // Obtener la ruta relativa del escudo
                    string rutaEscudo = row["escudo"].ToString();
                    string equipo = row["nombre"].ToString();

                    string rutaCompleta = Path.Combine(Application.StartupPath, "equipos", equipo, rutaEscudo);


                    // Cargar la imagen
                    if (File.Exists(rutaCompleta))
                    {
                        row["ImagenEscudo"] = Image.FromFile(rutaCompleta);

                    }
                    else
                    {
                        // Opcional: Manejar si la imagen no existe
                        row["ImagenEscudo"] = null; // O una imagen por defecto
                    }
                }



                // Configurar las columnas del DataGridView
                dgvEquipos.Columns["id_equipo"].Visible = false;
                dgvEquipos.Columns["id_torneo"].Visible = false;


                dgvEquipos.Columns["nombre"].HeaderText = "Nombre";
                dgvEquipos.Columns["escudo"].HeaderText = "Escudo";

                dgvEquipos.Columns["estado"].HeaderText = "Estado";
                dgvEquipos.Columns["fecha_agregado"].HeaderText = "Fecha Registro";
                dgvEquipos.Columns["nombre_torneo"].HeaderText = "Torneo Actual";


                dgvEquipos.Columns["estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // ---------------------------- COLUMNA IMAGEN ESCUDO ----------------------------
                DataGridViewImageColumn imgColDGV = new DataGridViewImageColumn();
                imgColDGV.Name = "Escudo";
                imgColDGV.HeaderText = " -- ";
                imgColDGV.DataPropertyName = "ImagenEscudo"; // Vincular la columna de imagen del DataTable
                imgColDGV.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgColDGV.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dgvEquipos.Columns.Add(imgColDGV);

                // ---------------------------- COLUMNA EDITAR ----------------------------

                DataGridViewImageColumn editarColumn = new DataGridViewImageColumn();
                editarColumn.HeaderText = "";
                editarColumn.Name = "editar";
                editarColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                editarColumn.Image = Properties.Resources.New_Project;
                editarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvEquipos.Columns.Add(editarColumn);

                // ---------------------------- COLUMNA BORRAR ----------------------------

                DataGridViewImageColumn borrarColumn = new DataGridViewImageColumn();
                borrarColumn.HeaderText = "";
                borrarColumn.Name = "borrar";
                borrarColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                borrarColumn.Image = Properties.Resources.trash_561125;
                borrarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvEquipos.Columns.Add(borrarColumn);

                // Eliminar la columna de texto original si ya no es necesaria
                dgvEquipos.Columns["escudo"].Visible = false;
                dgvEquipos.Columns["ImagenEscudo"].Visible = false;




        }

        private void Filtrar()
        {
            llenarTabla();
        }

        private void txtNombreFilter_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
    }

}


