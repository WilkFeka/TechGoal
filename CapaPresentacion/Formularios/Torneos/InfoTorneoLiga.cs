using CapaControladora;
using CapaEntidad;
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
    public partial class formInfoTorneoLiga : Form
    {
        formInicio formInicioC;
        Torneo torneoSeleccionado;
        CC_Equipos equipoControladora = CC_Equipos.getInstance;
        CC_Partido partidoControladora = CC_Partido.getInstance;
        CC_Reglas reglasControladora = CC_Reglas.getInstance;
        CC_Torneos torneoControladora = CC_Torneos.getInstance;
        CC_TorneoEquipos torneosEquiposControladora = CC_TorneoEquipos.getInstance;
        int numFecha = 1;
        List<Partido> partidos;
        int cantidadInstancias;

        public formInfoTorneoLiga(Torneo torneo, formInicio formInicio)
        {
            InitializeComponent();
            torneoSeleccionado = torneo;
            formInicioC = formInicio;
            lblTorneo.Text = torneoSeleccionado.nombre;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.AbrirFormulario(new formTorneos(formInicioC)); // Sirve para ocultar el formulario actual y abrir el formulario de usuarios

        }

        private void InfoTorneoLiga_Load(object sender, EventArgs e)
        {
            LlenarTabla();
            lblFecha.Text = "Fecha " + Convert.ToString(numFecha);

            CargarPartidos();


        }

        public void CargarPartidos()
        {
            partidos = partidoControladora.EncontrarPartidosTorneo(torneoSeleccionado.id_torneo);
            cantidadInstancias = partidos.Select(p => p.instancia).Distinct().Count();
            partidos = partidos.Where(u => u.instancia == lblFecha.Text).ToList();
            flpFechas.Controls.Clear();

            foreach (Partido partido in partidos)
            {

                formDisenioPartidoLiga formDisenioPartidoLiga = new formDisenioPartidoLiga(partido, this);
                formDisenioPartidoLiga.TopLevel = false;
                formDisenioPartidoLiga.FormBorderStyle = FormBorderStyle.None; // Eliminar bordes del formulario
                formDisenioPartidoLiga.Width = flpFechas.Width - 30; // Hacer que ocupe todo el ancho
                formDisenioPartidoLiga.Dock = DockStyle.Top; // Ocupar el ancho y apilar hacia arriba
                flpFechas.Controls.Add(formDisenioPartidoLiga);
                formDisenioPartidoLiga.Show();
            }


        }

        private void sortByPtsToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tablas_TorneosTableAdapter.SortByPts(this.dB_TECHGOALDataSet4.Tablas_Torneos);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByPuntosToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tablas_TorneosTableAdapter.FillByPuntos(this.dB_TECHGOALDataSet4.Tablas_Torneos);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        public void LlenarTabla()
        {
            // Llenar el DataSet completo
            this.tablas_TorneosTableAdapter.Fill(this.dB_TECHGOALDataSet4.Tablas_Torneos);
            this.tablas_TorneosTableAdapter.FillByPuntos(this.dB_TECHGOALDataSet4.Tablas_Torneos);

            // Asegurarse de que la columna "nombre" esté en el DataTable
            if (!this.dB_TECHGOALDataSet4.Tablas_Torneos.Columns.Contains("nombre"))
            {
                this.dB_TECHGOALDataSet4.Tablas_Torneos.Columns.Add("nombre", typeof(string));
            }

            // Crear un DataView y filtrar por id_torneo
            DataView dv = new DataView(this.dB_TECHGOALDataSet4.Tablas_Torneos)
            {
                RowFilter = $"id_torneo = {torneoSeleccionado.id_torneo}" // Aplicar el filtro
            };

            // Llenar la columna "nombre" con los datos correspondientes
            foreach (DataRowView row in dv)
            {
                int idEquipo = Convert.ToInt32(row["id_equipo"]);
                Equipo equipo = equipoControladora.EncontrarEquipoID(idEquipo); // Obtener el equipo por su ID
                row["nombre"] = equipo.nombre; // Asignar el nombre del equipo a la columna "nombre"
            }

            // Asignar el DataView al DataGridView
            dgvTabla.DataSource = dv;

            // Asegurarse de que la columna "nombre" aparezca en el DataGridView
            if (!dgvTabla.Columns.Contains("nombre"))
            {
                DataGridViewTextBoxColumn nombreColumn = new DataGridViewTextBoxColumn
                {
                    Name = "nombre",
                    HeaderText = "Nombre",
                    DataPropertyName = "nombre" // Enlazar con la columna "nombre"
                };
                dgvTabla.Columns.Add(nombreColumn);
            }

            dgvTabla.Columns["nombre"].DisplayIndex = 0;
            dgvTabla.Columns["nombre"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTabla.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void btnFechaMenos_Click(object sender, EventArgs e)
        {
            if (numFecha > 1) {

                numFecha--;
                lblFecha.Text = "Fecha " + Convert.ToString(numFecha);
                CargarPartidos();
            }
        }

        private void btnFechaMas_Click(object sender, EventArgs e)
        {
            if (numFecha < cantidadInstancias)
            {

                numFecha++;
                lblFecha.Text = "Fecha " + Convert.ToString(numFecha);
                CargarPartidos();
            }

        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            Reglas reglas = reglasControladora.Listar().Where(r => r.id_torneo == torneoSeleccionado.id_torneo).FirstOrDefault();
            if (reglas == null)
            {
                MessageBox.Show("No se han definido reglas para este torneo", "Reglas no definidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            formTorneoReglas formReglasS = new formTorneoReglas(torneoSeleccionado);
            formReglasS.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                $"¿Desea elimminar el torneo {torneoSeleccionado.nombre}?",
                "Confirmar Resultado",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Cancel) return;

            bool borrar = torneoControladora.BorrarTorneo(torneoSeleccionado.id_torneo);

            if (borrar == false)
            {
                MessageBox.Show("No se pudo eliminar el torneo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool borrarVinculaciones = torneosEquiposControladora.BorrarVinculaciones(torneoSeleccionado.id_torneo);

            if (borrarVinculaciones == false)
            {
                MessageBox.Show("No se pudieron eliminar las vinculaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Torneo eliminado correctamente", "Torneo eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}
