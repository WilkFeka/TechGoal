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

        public formInfoTorneoLiga(Torneo torneo, formInicio formInicio)
        {
            InitializeComponent();
            torneoSeleccionado = torneo;
            formInicioC = formInicio;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.AbrirFormulario(new formTorneos(formInicioC)); // Sirve para ocultar el formulario actual y abrir el formulario de usuarios

        }

        private void InfoTorneoLiga_Load(object sender, EventArgs e)
        {// Llenar el DataSet completo
            this.tablas_TorneosTableAdapter.Fill(this.dB_TECHGOALDataSet4.Tablas_Torneos);

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
                    HeaderText = "Nombre del Equipo",
                    DataPropertyName = "nombre" // Enlazar con la columna "nombre"
                };
                dgvTabla.Columns.Add(nombreColumn);
            }
        }

    }
}
