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
        CC_Equipos EquiposControladora = CC_Equipos.getInstance;
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

            if (File.Exists(rutaCompleta))
            {
                try
                {
                    // Cargar la imagen desde la ruta original
                    using (Image imagenOriginal = Image.FromFile(rutaCompleta))
                    {
                        // Crear un archivo temporal para la imagen
                        string archivoTemporal = Path.GetTempFileName();
                        imagenOriginal.Save(archivoTemporal);

                        // Cargar la imagen temporal en el PictureBox
                        picEscudo.Image = Image.FromFile(archivoTemporal);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones de carga de imagen
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                    picEscudo.Image = null; // O una imagen por defecto
                }
            }
            else
            {
                // Opcional: Manejar si la imagen no existe
                picEscudo.Image = null; // O una imagen por defecto
            }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox)
                    {
                        if (string.IsNullOrEmpty(control.Text) && control != txtPathEscudo)
                        {

                            MessageBox.Show("Por favor complete todos los campos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }

                }

                foreach (Control control in flpControles.Controls)
                {
                    if (control is formAgregarJugador)
                    {
                        formAgregarJugador formJug = (formAgregarJugador)control;
                        if (string.IsNullOrEmpty(formJug.txtNombreJug.Text) || string.IsNullOrEmpty(formJug.txtApellidoJug.Text) || string.IsNullOrEmpty(formJug.txtDorsalJug.Text))
                        {
                            MessageBox.Show("Por favor complete todos los campos de los jugadores", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }


                Equipo buscarEquipoNombre = EquiposControladora.EncontrarEquipoNombre(txtNombre.Text);

                if (buscarEquipoNombre != null && buscarEquipoNombre.nombre != equipoSeleccionadoP.nombre)

                {
                    MessageBox.Show("Ya existe un Equipo con ese nombre.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                if (txtNombre.Text != equipoSeleccionadoP.nombre && txtPathEscudo.Text == "")
                {
                    targetFolder = Path.Combine(Application.StartupPath, "equipos", txtNombre.Text);
                    targetFilePath = Path.Combine(targetFolder, txtNombre.Text + ".png");
                    Directory.CreateDirectory(targetFolder);
                    File.Copy(Path.Combine(Application.StartupPath, "equipos", equipoSeleccionadoP.nombre,  equipoSeleccionadoP.nombre + ".png"), targetFilePath);

                } else if (txtNombre.Text != equipoSeleccionadoP.nombre && txtPathEscudo.Text != "")
                {
                    targetFolder = Path.Combine(Application.StartupPath, "equipos", txtNombre.Text);
                    targetFilePath = Path.Combine(targetFolder, txtNombre.Text + ".png");
                    Directory.CreateDirectory(targetFolder);
                    File.Copy(sourceFilePath, targetFilePath);

                } else if (txtPathEscudo.Text != "")
                {
                    targetFolder = Path.Combine(Application.StartupPath, "equipos", equipoSeleccionadoP.nombre);
                    targetFilePath = Path.Combine(targetFolder, equipoSeleccionadoP.escudo);
                    if (File.Exists(targetFilePath))
                    {
                        File.Delete(targetFilePath);
                        File.Copy(sourceFilePath, targetFilePath);
                    }

                }



                Equipo modificarEquipo = new Equipo()
                {
                    id_equipo = equipoSeleccionadoP.id_equipo,
                    nombre = txtNombre.Text,
                    fecha_agregado = equipoSeleccionadoP.fecha_agregado,
                    escudo = txtNombre.Text + ".png",
                    estado = true
                };

                bool modificarEquipoBool = EquiposControladora.ModificarEquipo(modificarEquipo);

                if (modificarEquipoBool == false)
                {
                    MessageBox.Show("Hubo un error al modificar equipo. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Close();

            } catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al modificar equipo. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void formEquipoModificar_FormClosed(object sender, FormClosedEventArgs e)
        {

            formEquiposP.llenarTabla();

        }
    }
}
