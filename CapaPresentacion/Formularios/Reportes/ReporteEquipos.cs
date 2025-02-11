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
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion.Formularios.Reportes
{
    public partial class formReporteEquipos : Form
    {
        formInicio formInicioC;
        CC_Equipos equipoControladora = CC_Equipos.getInstance;
        int id_equipo;
        List<Equipo> equiposActivos;
        List<opcionCombo> opcionesCombo;
        public formReporteEquipos(formInicio formInicio)
        {
            InitializeComponent();
            formInicioC = formInicio;
            equiposActivos = CargarEquipos();
            opcionesCombo = GenerarOpcionesCombo(equiposActivos);
            cmbEquipos.DataSource = opcionesCombo;
            cmbEquipos.DisplayMember = "texto";
            cmbEquipos.ValueMember = "valor";
            cmbEquipos.SelectedIndex = -1;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (cmbEquipos.SelectedIndex == -1) return;

            id_equipo = ((opcionCombo)cmbEquipos.SelectedItem).valor;
            List<Dictionary<string, object>> estadisticas = equipoControladora.ObtenerEstadisticasEquipo(id_equipo);

            // Limpiar series previas
            chEstadisticaEquipos.Series.Clear();

            if (estadisticas.Count > 0)
            {
                var datos = estadisticas[0];

                int ganados = Convert.ToInt32(datos["Ganados"]);
                int empatados = Convert.ToInt32(datos["Empatados"]);
                int perdidos = Convert.ToInt32(datos["Perdidos"]);

                // Crear una nueva serie
                Series serie = new Series("Partidos")
                {
                    ChartType = SeriesChartType.Pie
                };

                // Agregar puntos al gráfico con colores específicos
                int indexGanados = serie.Points.AddXY("Ganados", ganados);
                serie.Points[indexGanados].Color = Color.LightGreen;

                int indexEmpatados = serie.Points.AddXY("Empatados", empatados);
                serie.Points[indexEmpatados].Color = Color.LightYellow;

                int indexPerdidos = serie.Points.AddXY("Perdidos", perdidos);
                serie.Points[indexPerdidos].Color = Color.LightCoral;

                // Agregar la serie al chart
                chEstadisticaEquipos.Series.Add(serie);

                // Agregar etiquetas con fuente Roboto 14
                serie.IsValueShownAsLabel = true;
                serie.LabelFormat = "#,##0";

                foreach (DataPoint punto in serie.Points)
                {
                    punto.Font = new Font("Roboto", 14, FontStyle.Bold);
                }

                chEstadisticaEquipos.Visible = true;
            }
            else
            {
                MessageBox.Show("No hay datos de estadísticas para este equipo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        public List<Equipo> CargarEquipos()
        {
            List<Equipo> listaEquipos = equipoControladora.ListarEquiposActivosFiltrados(txtNombre.Text);

            return listaEquipos;

        }

        public List<opcionCombo> GenerarOpcionesCombo(List<Equipo> equipos)
        {
            List<opcionCombo> opciones = new List<opcionCombo>();

            foreach (var equipo in equipos)
            {
                opciones.Add(new opcionCombo()
                {
                    valor = equipo.id_equipo,
                    texto = equipo.nombre
                });
            }

            return opciones;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            equiposActivos = CargarEquipos();
            opcionesCombo = GenerarOpcionesCombo(equiposActivos);
            cmbEquipos.DataSource = opcionesCombo;
            cmbEquipos.SelectedIndex = -1;


        }
    }
}
