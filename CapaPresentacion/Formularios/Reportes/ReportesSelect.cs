using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Reportes
{
    public partial class formReportesSelect : Form
    {
        formInicio formInicioC;
        public formReportesSelect(formInicio formInicio)
        {
            InitializeComponent();
            formInicioC = formInicio;
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Hide();
            formInicioC.picLogoText.Hide();
            formInicioC.AbrirFormulario(new formReportes(formInicioC));
            Close();
        }

        private void btnReporteEquipos_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Hide();
            formInicioC.picLogoText.Hide();
            formInicioC.AbrirFormulario(new formReporteEquipos(formInicioC));
            Close();
        }
    }
}
