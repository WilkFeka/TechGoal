using CapaControladora;
using CapaEntidad;
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
        bool modoModificar  = false;
        bool modoEliminar = false;

        public formCanchas()
        {
            InitializeComponent();
        }

        public void formCanchas_Load(object sender, EventArgs e)
        {
            // Limpiamos los controles
            flowBotonesCanchas.Controls.Clear();

            // Obtenemos la lista de canchas
            List<Cancha> listaCanchas = canchaControladora.Listar();



            foreach (var cancha in listaCanchas)
            {
                // Crear botones
                MSButton button = new MSButton();
                button.Text = Convert.ToString(cancha.numero);
                button.Size = new Size(200, 200);


                // Cambia color dependiendo el modo
                if (modoModificar)
                {
                    button.BackColor = Color.FromArgb(30, 200, 235);

                } else if (modoEliminar)
                {
                    button.BackColor = Color.FromArgb(255, 55, 55);

                } else
                {
                    button.BackColor = Color.FromArgb(50, 50, 50);
                }

                button.ForeColor = Color.White;
                button.BorderRadius = 75;
                button.Margin = new Padding(20, 20, 20, 20);
                button.Font = new Font("Roboto", 48, FontStyle.Bold);

                // Agregar boton al panel
                flowBotonesCanchas.Controls.Add(button);

                // Evento click del boton dependiendo el modo
                button.Click += (senderB, eB) =>
                {
                    // Si esta en modo modificar
                    if (modoModificar)
                    {
                        formCanchasModificar formCanchasOpcion = new formCanchasModificar(cancha);
                        formCanchasOpcion.ShowDialog();
                        return;
                    }

                    // Si esta en modo eliminar

                    if (modoEliminar)
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
            lblSeleccion.Text = modoModificar ? "Seleccionar Cancha (Modificar)" : "Seleccionar Cancha";

            btnEditar.BackColor = modoModificar ? Color.FromArgb(30, 200, 235) : Color.FromArgb(50, 50, 50);

            formCanchas_Load(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (modoModificar)
            {
                MessageBox.Show("Salga del modo Modificar para poder eliminar canchas", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            modoEliminar = !modoEliminar;
            lblSeleccion.Text = modoEliminar ? "Seleccionar Cancha (Eliminar)" : "Seleccionar Cancha";


            btnEliminar.BackColor = modoEliminar ? Color.FromArgb(255, 55, 55) : Color.FromArgb(50, 50, 50);

            formCanchas_Load(sender, e);


        }

        private void EliminarCancha(Cancha cancha)
        {
            var mensaje = MessageBox.Show("¿Esta seguro de que desea eliminarla cancha N: " + cancha.numero + "?", "Agregando usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mensaje == DialogResult.No)
            {
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
            formCanchas_Load(this, null);
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

            formCanchasAgregar formCanchasAgregar = new formCanchasAgregar(this);
            formCanchasAgregar.ShowDialog();
        }
    }
}
