﻿using System;
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
using CapaEntidad;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CapaPresentacion.Formularios.Equipos
{
    public partial class formEquipos : Form
    {
        private formInicio formInicioC;
        private CC_Equipos EquiposControladora = CC_Equipos.getInstance;
        private CC_Jugador JugadorControladora = CC_Jugador.getInstance;

        private int paginaActual = 1;
        private int totalPaginas;
        private int registrosPorPagina = 20;
        private DataTable tablaCompleta; // Almacena la tabla completa de datos



        public formEquipos(formInicio formInicio)
        {
            borrarCarpetasEquipos();

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
            limpiarFiltros();
            


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }

        private void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            formAgregarEquipos formAgregarEquipos = new formAgregarEquipos(this);
            formAgregarEquipos.ShowDialog();

           

        }

        public void llenarTabla()
        {
            string estadoSeleccionado = "";

            var selectedItem = cmbEstadoFilter.SelectedItem as opcionCombo;
            if (selectedItem != null)
            {
                int valor = selectedItem.valor;
                estadoSeleccionado = Convert.ToString(valor);
            }

            dgvEquipos.DataSource = null;
            if (dgvEquipos.Columns.Contains("borrar")) dgvEquipos.Columns.Remove("borrar");
            if (dgvEquipos.Columns.Contains("editar")) dgvEquipos.Columns.Remove("editar");

            List<string> archivosTemporales = new List<string>();

            tablaCompleta = new DataTable();
            EquiposControladora.CargarTablaEquipos(tablaCompleta, txtNombreFilter.Text, txtTorneoFilter.Text, estadoSeleccionado);

            totalPaginas = (int)Math.Ceiling((double)tablaCompleta.Rows.Count / registrosPorPagina);

            DataTable paginaTabla = ObtenerPagina(paginaActual);

            DataColumn imgCol = new DataColumn("ImagenEscudo", typeof(Image));
            paginaTabla.Columns.Add(imgCol);

            foreach (DataRow row in paginaTabla.Rows)
            {
                string rutaEscudo = row["escudo"].ToString();
                string equipo = row["nombre"].ToString();
                string rutaCompleta = Path.Combine(Application.StartupPath, "equipos", equipo, rutaEscudo);

                if (File.Exists(rutaCompleta))
                {
                    try
                    {
                        using (Image imagenOriginal = Image.FromFile(rutaCompleta))
                        {
                            string archivoTemporal = Path.GetTempFileName();
                            imagenOriginal.Save(archivoTemporal);
                            archivosTemporales.Add(archivoTemporal);
                            row["ImagenEscudo"] = Image.FromFile(archivoTemporal);
                        }
                    }
                    catch (Exception ex)
                    {
                        row["ImagenEscudo"] = null;
                    }
                }
                else
                {
                    row["ImagenEscudo"] = null;
                }
            }

            dgvEquipos.DataSource = paginaTabla;

            dgvEquipos.Columns["id_equipo"].Visible = false;
            dgvEquipos.Columns["id_torneo"].Visible = false;
            dgvEquipos.Columns["nombre"].HeaderText = "Nombre";
            dgvEquipos.Columns["escudo"].HeaderText = "Escudo";
            dgvEquipos.Columns["estado"].HeaderText = "Estado";
            dgvEquipos.Columns["fecha_agregado"].HeaderText = "Fecha Registro";
            dgvEquipos.Columns["nombre_torneo"].HeaderText = "Torneo Actual";
            dgvEquipos.Columns["estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewImageColumn imgColDGV = new DataGridViewImageColumn();
            imgColDGV.Name = "Escudo";
            imgColDGV.HeaderText = " -- ";
            imgColDGV.DataPropertyName = "ImagenEscudo";
            imgColDGV.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgColDGV.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvEquipos.Columns.Add(imgColDGV);

            DataGridViewImageColumn editarColumn = new DataGridViewImageColumn();
            editarColumn.HeaderText = "";
            editarColumn.Name = "editar";
            editarColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            editarColumn.Image = Properties.Resources.New_Project;
            editarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEquipos.Columns.Add(editarColumn);

            DataGridViewImageColumn borrarColumn = new DataGridViewImageColumn();
            borrarColumn.HeaderText = "";
            borrarColumn.Name = "borrar";
            borrarColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            borrarColumn.Image = Properties.Resources.trash_561125;
            borrarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEquipos.Columns.Add(borrarColumn);

            dgvEquipos.Columns["escudo"].Visible = false;
            dgvEquipos.Columns["ImagenEscudo"].Visible = false;

            // Actualizar el bindingNavigatorCountItem
            bindingNavigatorCountItem.ForeColor = Color.Black;
            bindingNavigatorCountItem.Text = $"Página {paginaActual} de {totalPaginas}";
        }

        private DataTable ObtenerPagina(int numeroPagina)
        {
            DataTable paginaTabla = tablaCompleta.Clone();
            int inicio = (numeroPagina - 1) * registrosPorPagina;
            int fin = Math.Min(inicio + registrosPorPagina, tablaCompleta.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                paginaTabla.ImportRow(tablaCompleta.Rows[i]);
            }

            return paginaTabla;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
   
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
           
        }


        private void Filtrar()
        {
            llenarTabla();
        }

        private void txtNombreFilter_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtTorneoFilter_TextChanged(object sender, EventArgs e)
        {
            Filtrar();

        }

        private void cmbEstadoFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();

        }

        private void limpiarFiltros()
        {
            txtNombreFilter.Text = "";
            txtTorneoFilter.Text = "";
            cmbEstadoFilter.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFiltros();
        }

        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvEquipos.Columns[e.ColumnIndex].Name == "borrar" && e.RowIndex != -1)
                {
                    DataGridViewRow filaSeleccionada = dgvEquipos.CurrentRow;

                    DataGridViewCell celda = filaSeleccionada.Cells["id_equipo"];

                    int id = Convert.ToInt32(celda.Value);

                    Equipo equipoEncontrado = EquiposControladora.EncontrarEquipoID(id);

                    var mensaje = MessageBox.Show("¿Esta seguro de que desea borrar el equipo " + equipoEncontrado.nombre + "?", "Borrando equipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (mensaje == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                       // PRIMERO BORRAR JUGADORES DEL EQUIPO
                        bool eliminarJugadores = JugadorControladora.EliminarJugadoresEquipo(equipoEncontrado.id_equipo);

                        bool eliminarEquipo = EquiposControladora.EliminarEquipo(equipoEncontrado.id_equipo);

                        string folderEquipo = Path.Combine(Application.StartupPath, "equipos", equipoEncontrado.nombre);

                        if (eliminarEquipo)
                        {
                            MessageBox.Show("Equipo eliminado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            llenarTabla();

                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al eliminar equipo. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    llenarTabla();
                    }




                }

                if (dgvEquipos.Columns[e.ColumnIndex].Name == "editar" && e.RowIndex != -1)
                {
                    // ------------- Obtiene el valor de la celda ID ---------------------
                    DataGridViewRow filaSeleccionada = dgvEquipos.CurrentRow;

                    DataGridViewCell celda = filaSeleccionada.Cells["id_equipo"];

                    int id = Convert.ToInt32(celda.Value);

                    Equipo equipoSeleccionado = EquiposControladora.EncontrarEquipoID(id);


                    formEquipoModificar formEquipoModificar = new formEquipoModificar(this, equipoSeleccionado);
                    formEquipoModificar.ShowDialog();

                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }
        }

        private void formEquipos_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void borrarCarpetasEquipos()
        {
            // Suponiendo que EquiposControladora.Listar() devuelve una lista de objetos Equipo
            List<Equipo> listaEquipos = EquiposControladora.Listar();

            // Obtener los nombres de los equipos
            HashSet<string> nombresEquipos = new HashSet<string>(listaEquipos.Select(e => e.nombre));

            // Ruta del directorio que contiene las carpetas
            string rutaDirectorio = Path.Combine(Application.StartupPath, "equipos");

            // Obtener todas las carpetas en el directorio
            string[] carpetas = Directory.GetDirectories(rutaDirectorio);

            foreach (string carpeta in carpetas)
            {
                // Obtener el nombre de la carpeta
                string nombreCarpeta = Path.GetFileName(carpeta);

                // Verificar si el nombre de la carpeta está en la lista de nombres de equipos
                if (!nombresEquipos.Contains(nombreCarpeta))
                {
                    try
                    {
                        // Eliminar la carpeta y todo su contenido
                        Directory.Delete(carpeta, true);
                        Console.WriteLine($"Carpeta eliminada: {nombreCarpeta}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"No se pudo eliminar la carpeta {nombreCarpeta}: {ex.Message}");
                    }
                }
            }


        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                llenarTabla();
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                llenarTabla();
            }
        }
    }

}


