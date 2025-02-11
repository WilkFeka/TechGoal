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

namespace CapaPresentacion.Formularios.Reportes
{
    public partial class formReportes : Form
    {
        formInicio formInicioC;
        CC_Reserva ReservaControladora = CC_Reserva.getInstance;
        CC_Cancha CanchaControladora = CC_Cancha.getInstance;
        DateTime fechaInicio;
        DateTime fechaFinal;
        int flag;
        public formReportes(formInicio formInicio)
        {
            InitializeComponent();
            formInicioC = formInicio;
        }

        private void formReportes_Load(object sender, EventArgs e)
        {
            
            dtpFechaInicio.Value = new DateTime(2024, 01, 01);
            dtpFechaFinal.Value = DateTime.Today;

            fechaInicio = dtpFechaInicio.Value;
            fechaFinal = dtpFechaFinal.Value;

            btnReservas_Click(sender, e);

        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            chReservaCancha.Visible = true;
            chClientesReservas.Visible = false;
            chHorarios.Visible = false;
            flag = 1;

            chReservaCancha.Series[0].Points.Clear();

            List<Cancha> listaCanchas = CanchaControladora.Listar();


            foreach (Cancha cancha in listaCanchas)
            {
                List<Reserva> listaReservas = ReservaControladora.EncontrarReservasCanchaFIFF(cancha, fechaInicio, fechaFinal );

                chReservaCancha.Series[0].Points.AddXY(cancha.numero.ToString(), listaReservas.Count);
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
           /* chReservaCancha.Visible = false;
            chClientesReservas.Visible = true;
            chHorarios.Visible = false;
            flag = 2;*/
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            /*chReservaCancha.Visible = false;
            chClientesReservas.Visible = false;
            chHorarios.Visible = true;
            flag = 3;*/
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            fechaInicio = dtpFechaInicio.Value;
            fechaFinal = dtpFechaFinal.Value;



            switch (flag)
            {
                case 1:
                    btnReservas_Click(sender, e);
                    break;
/*                case 2:
                    btnClientes_Click(sender, e);
                    break;
                case 3:
                    btnHorarios_Click(sender, e);
                    break;
*/
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }
    }
}
