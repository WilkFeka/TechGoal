using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Formularios.Reservas;
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

namespace CapaPresentacion.Formularios.Canchas
{
    public partial class formCanchaIndividual : Form
    {
        Cancha canchaSeleccionada;
        formInicio formInicioC;
        CC_CanchaHorario CanchaHorarioControladora = CC_CanchaHorario.getInstance;
        CC_Horario HorarioControladora = CC_Horario.getInstance;
        CC_Reserva ReservaControladora = CC_Reserva.getInstance;
        public formCanchaIndividual(Cancha cancha, formInicio formInicio)
        {
            InitializeComponent();
            canchaSeleccionada = cancha;
            dtpFecha.Value = DateTime.Today;
            formInicioC = formInicio;
            lblCancha.Text += Convert.ToString(canchaSeleccionada.numero);

        }

        private void formCanchaIndividual_Load(object sender, EventArgs e)
        {
            CargarHorariosCancha();
        }

        public void CargarHorariosCancha()
        {


            // Limpiamos los controles
            flowHorarios.Controls.Clear();

            // Obtenemos la lista de canchas

            List<Horario> listaHorarios;

            listaHorarios = HorarioControladora.ListarHorariosActivos();




            foreach (var horario in listaHorarios)
            {
                // Crear botones
                MSButton button = new MSButton();
                button.Text = Convert.ToString(horario.hora) + " Hs";
                button.ForeColor = Color.FromArgb(50,50,50);
                button.BorderRadius = 60;
                button.Margin = new Padding(20, 20, 20, 20);
                button.Font = new Font("Roboto", 24, FontStyle.Bold);
                button.Size = new Size(170, 170);

                // Cambiar color de fondo dependiendo el modo

                Reserva horarioReservado = ReservaControladora.EncontrarReservasCanchaFecha(canchaSeleccionada, dtpFecha.Value, horario);

                if (horarioReservado != null)
                {
                    button.BackColor = Color.FromArgb(250, 95, 95);
                    button.ForeColor = Color.White;

                } else
                {
                    button.BackColor = Color.FromArgb(115,255,65) ;

                }


                // Agregar boton al panel
                flowHorarios.Controls.Add(button);

                // Evento click del boton dependiendo el modo
                button.Click += (senderB, eB) =>
                {
                    if (horarioReservado != null)
                    {
                        formReservaModificar formReservaModificar = new formReservaModificar(canchaSeleccionada, dtpFecha.Value, horario, this, horarioReservado.objCliente, horarioReservado );
                        formReservaModificar.ShowDialog();
                    } else
                    {
                        formReservaNueva formReservaNueva = new formReservaNueva(canchaSeleccionada, dtpFecha.Value, horario, this);
                        formReservaNueva.ShowDialog();
                    }
                    
                };
            }

        

            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.AbrirFormulario(new formCanchas(formInicioC)); // Sirve para ocultar el formulario actual y abrir el formulario de usuarios

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarHorariosCancha();
        }

        private void btnTomorrow_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = dtpFecha.Value.AddDays(1);
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = dtpFecha.Value.AddDays(-1);

        }
    }
}
