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

namespace CapaPresentacion.Formularios
{
    public partial class formHorarios : Form
    {
        CC_Horario horarioControladora = CC_Horario.getInstance;
        bool modoModificar = false;
        List<Horario> listaHorarios;
        formInicio formInicioC;

        public formHorarios(formInicio formInicio)
        {
            InitializeComponent();
            lblSeleccion.Visible = false;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            formInicioC = formInicio;
        }

        public void Horarios_Load(object sender, EventArgs e)
        {

            // Limpiamos los controles
            flowBotonesHorarios.Controls.Clear();

            // Obtenemos la lista de canchas
            listaHorarios = horarioControladora.Listar();



            foreach (var horario in listaHorarios)
            {
                // Crear botones
                MSButton button = new MSButton();
                button.Text = Convert.ToString(horario.hora);
                button.Size = new Size(180, 180);

                //ESTILOS DE BOTONES

                // cambia el color dependiendo el estado
                if (horario.estado)
                {
                    button.BackColor = Color.FromArgb(50, 50, 50);
                    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
                }
                else
                {
                    button.BackColor = Color.FromArgb(235, 235, 235);
                }

                button.ForeColor = Color.White;
                button.BorderRadius = 75;
                button.Margin = new Padding(20, 20, 20, 20);
                button.Font = new Font("Roboto", 48, FontStyle.Bold);

                // Agregar boton al panel
                flowBotonesHorarios.Controls.Add(button);

                // Evento click del boton dependiendo el modo
                button.Click += (senderB, eB) =>
                {
                    // Si esta en modo modificar
                    if (modoModificar)
                    {
                        horario.estado = !horario.estado;
                        button.BackColor = horario.estado ? Color.FromArgb(50, 50, 50) : Color.FromArgb(235, 235, 235);
                        return;
                    }

                  // Si esta en modo eliminar

                };
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (modoModificar)
            {
                var mensaje = MessageBox.Show("¿Esta seguro de que desea salir del modo edicion?", "Horarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.No)
                {
                    return;
                }

                Horarios_Load(sender, e);
            }

            modoModificar = !modoModificar;
            lblSeleccion.Visible = !lblSeleccion.Visible;
            btnAceptar.Visible = !btnAceptar.Visible;
            btnCancelar.Visible = !btnCancelar.Visible;
            btnEditar.BackColor = modoModificar ? Color.FromArgb(30, 200, 235) : Color.FromArgb(50, 50, 50);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar_Click(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Esta seguro de que desea actualizar los horarios?", "Horarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mensaje == DialogResult.No)
            {
                return;
            }


            bool actualizarHorarios = horarioControladora.ActualizarHorarios(listaHorarios);

            if (actualizarHorarios == false)
            {
                MessageBox.Show("No se pudo eliminar la cancha. Por favor contacte un administrador", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Horarios actualizados con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


            Horarios_Load(sender, e);

            modoModificar = !modoModificar;
            lblSeleccion.Visible = !lblSeleccion.Visible;
            btnAceptar.Visible = !btnAceptar.Visible;
            btnCancelar.Visible = !btnCancelar.Visible;
            btnEditar.BackColor = modoModificar ? Color.FromArgb(30, 200, 235) : Color.FromArgb(50, 50, 50);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }
    }
}
