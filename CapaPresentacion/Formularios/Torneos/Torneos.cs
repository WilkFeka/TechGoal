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

        }
    }
}
