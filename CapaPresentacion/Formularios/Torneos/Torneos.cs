using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Personalizacion;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Torneos
{
    public partial class formTorneos : Form
    {
        private formInicio formInicioC;
        public  CC_Torneos torneoControladora = CC_Torneos.getInstance;

        private BindingSource bindingSource = new BindingSource();
        private int currentPage = 1; // Página actual
        private int pageSize = 20;  // Tamaño de la página
        private int totalRecords = 0; // Total de registros
        private DataTable originalData; // Datos originales sin paginar


        public formTorneos(formInicio formInicio)
        {
            InitializeComponent();
            formInicioC = formInicio;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();

        }

        private void btnAgregarTorneo_Click(object sender, EventArgs e)
        {
            formAgregarTorneo formAgregarEquipos = new formAgregarTorneo(this);
            formAgregarEquipos.Show();
        }

        private void ConfigurarBindingNavigator()
        {
            Paginator.BindingSource = bindingSource;
        }

        private void CargarDatos()
        {
            this.torneosTableAdapter.Fill(this.dB_TECHGOALDataSet3.torneos);
            originalData = dB_TECHGOALDataSet3.torneos.Copy(); 
            totalRecords = originalData.Rows.Count; 
            MostrarPagina(1); 
        }

        private void MostrarPagina(int pageNumber)
        {
            // Calcular índices
            int startIndex = (pageNumber - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, totalRecords);

            // Crear un DataTable para la página actual
            DataTable pageData = originalData.Clone();
            for (int i = startIndex; i < endIndex; i++)
            {
                pageData.ImportRow(originalData.Rows[i]);
            }

            // Vincular datos al BindingSource
            bindingSource.DataSource = pageData;
            dgvTorneos.DataSource = bindingSource;

            // Actualizar variables
            currentPage = pageNumber;
            ActualizarEstadoBindingNavigator();
        }

        private void ActualizarEstadoBindingNavigator()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Actualizar el texto del BindingNavigatorCountItem
            bindingNavigatorCountItem.Text = $"Página {currentPage} de {totalPages}";

            // Deshabilitar los botones "Siguiente" y "Anterior" según la página actual
            bindingNavigatorMovePreviousItem.Enabled = currentPage > 1;
            bindingNavigatorMoveNextItem.Enabled = currentPage < totalPages;
        }

        private void formTorneos_Load(object sender, EventArgs e)
        {
            CargarDatos();

            ConfigurarBindingNavigator();

            // Mostrar la primera página
            MostrarPagina(1);

            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "En curso", valor = 1 });
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Finalizado", valor = 0 });
            cmbEstadoFilter.DisplayMember = "texto";
            cmbEstadoFilter.ValueMember = "valor";

            cmbTipoFilter.Items.Add(new opcionCombo { texto = "Liga", valor = 1 });
            cmbTipoFilter.Items.Add(new opcionCombo { texto = "LLaves", valor = 2 });
            cmbTipoFilter.DisplayMember = "texto";
            cmbTipoFilter.ValueMember = "valor";

            dtpFechaInicio.Format = DateTimePickerFormat.Custom;
            dtpFechaInicio.CustomFormat = "dd/MM/yyyy";

            dtpFechaFinal.Format = DateTimePickerFormat.Custom;
            dtpFechaFinal.CustomFormat = "dd/MM/yyyy";

            // COLUMNA INFO
            DataGridViewImageColumn infoColumn = new DataGridViewImageColumn();
            infoColumn.HeaderText = "";
            infoColumn.Name = "info";
            infoColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            infoColumn.Image = Properties.Resources.info;
            infoColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTorneos.Columns.Add(infoColumn);



        }

        private void ActualizarFiltro()
        {
            // Filtro por nombre
            string filtroNombre = string.IsNullOrWhiteSpace(txtNombreFilter.Text)
                ? ""
                : $"nombre LIKE '%{txtNombreFilter.Text.Replace("'", "''")}%'";

            // Filtro por fechas
            string filtroFechas = $"fechaInicio >= '{dtpFechaInicio.Value:yyyy-MM-dd}' AND fechaFinal <= '{dtpFechaFinal.Value:yyyy-MM-dd}'";

            // Filtro por tipo (ComboBox)
            string filtroTipo = cmbTipoFilter.SelectedItem is opcionCombo tipoSeleccionado
                ? $"tipo = {tipoSeleccionado.valor}"
                : "";

            // Filtro por estado (ComboBox)
            string filtroEstado = cmbEstadoFilter.SelectedItem is opcionCombo estadoSeleccionado
                ? $"estado = {estadoSeleccionado.valor}"
                : "";

            // Combinar filtros dinámicamente
            var filtros = new List<string> { filtroNombre, filtroFechas, filtroTipo, filtroEstado }
                .Where(f => !string.IsNullOrEmpty(f)) // Excluir filtros vacíos
                .ToList();

            // Combinar filtros con AND
            string filtroCompleto = string.Join(" AND ", filtros);

            // Aplicar el filtro al DefaultView
            dB_TECHGOALDataSet3.torneos.DefaultView.RowFilter = filtroCompleto;

            // Actualizar el conjunto de datos originalData con los datos filtrados
            originalData = dB_TECHGOALDataSet3.torneos.DefaultView.ToTable();

            // Actualizar el total de registros y mostrar la primera página
            totalRecords = originalData.Rows.Count;
            MostrarPagina(1);
        }

        private void txtNombreFilter_TextChanged(object sender, EventArgs e)
        {
            ActualizarFiltro();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            ActualizarFiltro();

        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            ActualizarFiltro();

        }

        private void cmbTipoFiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarFiltro();

        }

        private void cmbEstadoFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarFiltro();

        }

        private void dgvTorneos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTorneos.Columns["fechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvTorneos.Columns["fechaFinal"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void limpiarFiltros()
        {
            txtNombreFilter.Text = "";
            cmbTipoFilter.SelectedIndex = -1;
            cmbEstadoFilter.SelectedIndex = -1;
            dtpFechaInicio.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpFechaFinal.Value = new DateTime(DateTime.Now.Year, 12, 31);

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFiltros();
        }

        private void dgvTorneos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTorneos.Columns[e.ColumnIndex].Name == "tipo" && e.Value != null)
            {
                // Cambia los valores visibles según el contenido
                if (dgvTorneos.Columns[e.ColumnIndex].Name == "tipo" && e.Value != null)
                {
                    e.Value = e.Value.ToString() == "1" ? "Liga" : e.Value.ToString() == "2" ? "Llaves" : e.Value;
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvTorneos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTorneos.Columns[e.ColumnIndex].Name == "info" && e.RowIndex != -1)
            {
                Cursor = Cursors.Hand;
            }
        }

        private void dgvTorneos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.Default;

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                MostrarPagina(currentPage + 1);
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                MostrarPagina(currentPage - 1);
            }
        }

        private void dgvTorneos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvTorneos.Columns[e.ColumnIndex].Name == "info" && e.RowIndex != -1)
                {
                    // ------------- Obtiene el valor de la celda ID ---------------------
                    DataGridViewRow filaSeleccionada = dgvTorneos.CurrentRow;

                    DataGridViewCell celda = filaSeleccionada.Cells["id_torneo"];

                    int id = Convert.ToInt32(celda.Value);

                    Torneo torneoSeleccionado = torneoControladora.EncontrarTorneoID(id);

                    if (torneoSeleccionado.tipo == 1)
                    {
                        formInicioC.AbrirFormulario(new formInfoTorneoLiga(torneoSeleccionado, formInicioC)); // Sirve para que se pueda mostrar el formulario de roles y ocultar el de usuarios
                    }
                    else if (torneoSeleccionado.tipo == 2)
                    {

                        formInicioC.AbrirFormulario(new formInfoTorneoLlaves(torneoSeleccionado, formInicioC)); // Sirve para que se pueda mostrar el formulario de roles y ocultar el de usuarios
                    }



                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RecargarTabla()
        {
            // Limpiar el DataGridView
            dgvTorneos.DataSource = null;

            // Recargar los datos desde la base de datos
            this.torneosTableAdapter.Fill(this.dB_TECHGOALDataSet3.torneos);

            // Actualizar los datos originales y totales
            originalData = dB_TECHGOALDataSet3.torneos.Copy();
            totalRecords = originalData.Rows.Count;


            // Mostrar la primera página después de recargar
            MostrarPagina(1);
            ActualizarFiltro();
        }
    }
}
