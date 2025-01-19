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

namespace CapaPresentacion.Formularios.Torneos
{
    public partial class formTorneos : Form
    {
        private formInicio formInicioC;

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
            formAgregarTorneo formAgregarEquipos = new formAgregarTorneo();
            formAgregarEquipos.Show();
        }

        private void formTorneos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet3.torneos' Puede moverla o quitarla según sea necesario.
            this.torneosTableAdapter.Fill(this.dB_TECHGOALDataSet3.torneos);
            dgvTorneos.DataSource = dB_TECHGOALDataSet3.torneos;


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

            // Aplicar el filtro
            dB_TECHGOALDataSet3.torneos.DefaultView.RowFilter = filtroCompleto;
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
    }
}
