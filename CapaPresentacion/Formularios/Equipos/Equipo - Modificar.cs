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
using System.IO;
using CapaControladora;

namespace CapaPresentacion.Formularios.Equipos
{
    public partial class formEquipoModificar : Form
    {
        formEquipos formEquiposP;
        Equipo equipoSeleccionadoP;
        CC_Jugador JugadorControladora = CC_Jugador.getInstance;
        CC_Equipos EquipoControladora = CC_Equipos.getInstance;
        string estadoEquipo;
        string targetFolder;
        string targetFilePath;
        string sourceFilePath;
        public formEquipoModificar(formEquipos formEquipos, Equipo equipoSeleccionado )
        {
            InitializeComponent();
            formEquiposP = formEquipos;
            equipoSeleccionadoP = equipoSeleccionado;
        }

        private void formEquipoModificar_Load(object sender, EventArgs e)
        {
            txtNombre.Text = equipoSeleccionadoP.nombre;
            estadoEquipo = equipoSeleccionadoP.estado ? "Activo" : "Inactivo";
            txtEstado.Text = estadoEquipo;
            string rutaCompleta = Path.Combine(Application.StartupPath, "equipos", equipoSeleccionadoP.nombre, equipoSeleccionadoP.escudo);
            picEscudo.Image = Image.FromFile(rutaCompleta);
            LoadJugadoresActuales();
        }

        private void btnAgregarEscudo_Click(object sender, EventArgs e)
        {
            // Crear un diálogo para seleccionar el archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                sourceFilePath = openFileDialog.FileName;


                picEscudo.Image = Image.FromFile(sourceFilePath);
            }
            txtPathEscudo.Text = sourceFilePath;
            DialogResult = DialogResult.None;

        }

        private void formEquipoModificar_FormClosed(object sender, FormClosedEventArgs e)
        {
            formEquiposP.llenarTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackgroundImage = txtEstado.Text == "Activo" ? Properties.Resources.Inactive : Properties.Resources.Active;

            txtEstado.Text = txtEstado.Text == "Activo" ? "Inactivo" : "Activo";
        }

        public void agregarFormJugador()
        {

            formAgregarJugador formJugador = new formAgregarJugador();
            formJugador.TopLevel = false;
            flpControles.Controls.Add(formJugador);
            formJugador.Show();

            foreach (Control control in flpControles.Controls)
            {
                if (control is formAgregarJugador)
                {
                    formAgregarJugador formJug = (formAgregarJugador)control;
                    formJug.btnBorrarJug.Click += (s, e) =>
                    {
                        flpControles.Controls.Remove(formJug);
                    };
                    if (flpControles.Controls.IndexOf(control) != 0)
                    {
                        formJug.btnBorrarJug.Visible = true;
                    }


                }
            }
        }

        private void btnAgregarJugador_Click(object sender, EventArgs e)
        {
            agregarFormJugador();

        }

        private void LoadJugadoresActuales()
        {
            List<Jugador> jugadoresEquipo = JugadorControladora.EncontrarJugadoresEquipo(equipoSeleccionadoP.id_equipo);

            foreach (Jugador jugador in jugadoresEquipo)
            {
                formAgregarJugador formJugador = new formAgregarJugador(jugador);
                formJugador.TopLevel = false;
                flpControles.Controls.Add(formJugador);
                formJugador.Show();

                foreach (Control control in flpControles.Controls)
                {
                    if (control is formAgregarJugador)
                    {
                        formAgregarJugador formJug = (formAgregarJugador)control;
                        formJug.btnBorrarJug.Click += (s, e) =>
                        {
                            flpControles.Controls.Remove(formJug);
                        };
                        if (flpControles.Controls.IndexOf(control) != 0)
                        {
                            formJug.btnBorrarJug.Visible = true;
                        }

                    }
                }
            }
        }
    }
}
