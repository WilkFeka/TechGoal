using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Equipos
{
    public partial class formEquipos : Form
    {
        private formInicio formInicioC;

        public formEquipos(formInicio formInicio)
        {
            InitializeComponent();
            formInicioC = formInicio;

        }

        private void formEquipos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet2.equipos' Puede moverla o quitarla según sea necesario.
            this.equiposTableAdapter.Fill(this.dB_TECHGOALDataSet2.equipos);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }
    }
}
