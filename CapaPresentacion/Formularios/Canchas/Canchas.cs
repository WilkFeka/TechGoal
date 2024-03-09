using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Formularios.Canchas;
using CapaPresentacion.Personalizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class formCanchas : Form
    {
        CC_Cancha canchaControladora = CC_Cancha.getInstance;
        CC_Permiso permisoControladora = CC_Permiso.getInstance;
        bool modoModificar  = false;
        bool modoEliminar = false;
        formInicio formInicioC;

        public formCanchas(formInicio fomrInicio)
        {
            InitializeComponent();
            formInicioC = fomrInicio;
        }

        public void formCanchas_Load(object sender, EventArgs e)
        {
            // Modo normal es 0
            CargarCanchas(0);

            List<Permiso> listaPermisos = permisoControladora.ListarPermisosUsuario(formInicio.usuarioActual.id_usuario);

            foreach (Permiso permiso in listaPermisos)
            {
                if (permiso.obj_modulo.modulo == "ABMCanchas")
                {
                    btnAgregarCancha.Visible = true;
                    btnEditar.Visible = true;
                    btnEliminar.Visible = true;
                } else
                {
                    fpnlBotones.Size = new Size(84, 77);
                }
            }


            
        }

        public void CargarCanchas(int modo)
        {

            // Limpiamos los controles
            flowBotonesCanchas.Controls.Clear();


            // Obtenemos la lista de canchas

            List<Cancha> listaCanchas;

            if (modo == 0)
            {
                listaCanchas = canchaControladora.Listar().Where(c => c.estado).ToList();

            }
            else
            {
                listaCanchas = canchaControladora.Listar();

            }


            foreach (var cancha in listaCanchas)
            {
                // Crear botones
                MSButton button = new MSButton();
                button.Text = Convert.ToString(cancha.numero);
                button.ForeColor = Color.White;
                button.BorderRadius = 75;
                button.Margin = new Padding(20, 20, 20, 20);
                button.Font = new Font("Roboto", 48, FontStyle.Bold);
                button.Size = new Size(200, 200);

                // Cambiar color de fondo dependiendo el modo
                if (modo == 1)
                {
                    btnFondo.BackColor = Color.FromArgb(30, 200, 235);
                    flowBotonesCanchas.BackColor = Color.FromArgb(30, 200, 235);
                    button.BackColor = cancha.estado ? Color.FromArgb(50, 50, 50) : Color.FromArgb(80,80,80) ;
                }
                else if (modo == 2)
                {
                    btnFondo.BackColor = Color.FromArgb(250, 95, 95);
                    flowBotonesCanchas.BackColor = Color.FromArgb(250, 95, 95);
                    button.BackColor = cancha.estado ? Color.FromArgb(50, 50, 50) : Color.FromArgb(80, 80, 80);

                }
                else if (modo == 0)
                {
                    btnFondo.BackColor = Color.FromArgb(235, 235, 235);
                    flowBotonesCanchas.BackColor = Color.FromArgb(235, 235, 235);
                    button.BackColor = Color.FromArgb(50, 50, 50);


                }

                // Agregar boton al panel
                flowBotonesCanchas.Controls.Add(button);

                // Evento click del boton dependiendo el modo
                button.Click += (senderB, eB) =>
                {

                    if (modo == 0)
                    {
                        formInicioC.AbrirFormulario(new formCanchaIndividual(cancha, formInicioC));
                        return;
                    }
                    // Si esta en modo modificar
                    if (modo == 1)
                    {
                        formCanchasModificar formCanchasOpcion = new formCanchasModificar(cancha, this);
                        formCanchasOpcion.ShowDialog();
                        return;
                    }

                    // Si esta en modo eliminar

                    if (modo == 2)
                    {
                        EliminarCancha(cancha);

                    }

                };
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (modoEliminar)
            {
                MessageBox.Show("Salga del modo Eliminar para poder eliminar canchas", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            modoModificar = !modoModificar;
            lblSeleccion.Text = modoModificar ? "Modificar Cancha" : "Seleccionar Cancha";

            btnEditar.BackColor = modoModificar ? Color.FromArgb(30, 200, 235) : Color.FromArgb(50, 50, 50);

            bool modo = modoModificar ? true : false;

            // Modo modificar es 1
            CargarCanchas(modo ? 1 : 0);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (modoModificar)
            {
                MessageBox.Show("Salga del modo Modificar para poder eliminar canchas", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            modoEliminar = !modoEliminar;
            lblSeleccion.Text = modoEliminar ? "Eliminar Cancha" : "Seleccionar Cancha";


            btnEliminar.BackColor = modoEliminar ? Color.FromArgb(250, 95, 95) : Color.FromArgb(50, 50, 50);

            bool modo = modoEliminar ? true : false;
            // Modo eliminar es 2
            CargarCanchas(modo ? 2 : 0);

        }

        private void EliminarCancha(Cancha cancha)
        {
            var mensaje = MessageBox.Show("¿Esta seguro de que desea eliminarla cancha N: " + cancha.numero + "?", "Agregando usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mensaje == DialogResult.No)
            {
                return;
            }

            // Eliminar primero la relacion CanchaHorarios

            bool eliminarCanchaHorarios = canchaControladora.EliminarCanchaHorarios(cancha.id_cancha);

            if (eliminarCanchaHorarios == false)
            {
                MessageBox.Show("No se pudo eliminar la cancha. Por favor contacte un administrador", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            bool eliminarCancha = canchaControladora.EliminarCancha(cancha.id_cancha);

            if (eliminarCancha == false)
            {
                MessageBox.Show("No se pudo eliminar la cancha. Por favor contacte un administrador", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBox.Show("Cancha eliminada con exito", "Cancha eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Recargamos las canchas
            CargarCanchas(2);
        }

        private void btnAgregarCancha_Click(object sender, EventArgs e)
        {
            // Obtenemos la lista de canchas
            List<Cancha> listaCanchas = canchaControladora.Listar();

            if (listaCanchas.Count == 12)
            {
                MessageBox.Show("Se ha llegado al maximo numero de canchas. Por favor elimine una para poder agregar una nueva", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            modoEliminar = modoEliminar ? false : modoEliminar;
            modoModificar = modoModificar ? false : modoModificar;
            lblSeleccion.Text = "Seleccionar Cancha";
            btnEliminar.BackColor = Color.FromArgb(50, 50, 50);
            btnEditar.BackColor = Color.FromArgb(50, 50, 50);



            formCanchas_Load(sender, e);

            formCanchasAgregar formCanchasAgregar = new formCanchasAgregar(this);
            formCanchasAgregar.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }



    }
}
