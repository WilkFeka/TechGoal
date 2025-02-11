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
    public partial class formTorneoReglas : Form
    {
        Torneo torneoSeleccionado;
        CC_Reglas reglasControladora = CC_Reglas.getInstance;
        public formTorneoReglas(Torneo torneo)
        {
            InitializeComponent();
            torneoSeleccionado = torneo;
        }

        private void formTorneoReglas_Load(object sender, EventArgs e)
        {
            lblReglas.Text += torneoSeleccionado.nombre;
            Reglas reglas = reglasControladora.Listar().Where(r => r.id_torneo == torneoSeleccionado.id_torneo).FirstOrDefault();
            txtReglas.Text = reglas.reglas;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
