using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Personalizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Equipos
{
    public partial class formAgregarEquipos : Form
    {
        CC_Equipos EquiposControladora = CC_Equipos.getInstance;
        CC_Jugador JugadorControladora = CC_Jugador.getInstance;
        formEquipos formEquiposC;
        string targetFolder;
        string targetFilePath;
        string sourceFilePath;
        public formAgregarEquipos(formEquipos formEquipos)
        {
            InitializeComponent();
            formEquiposC = formEquipos;
        }

        private void formAgregarEquipos_Load(object sender, EventArgs e)
        {
            agregarFormJugador();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox)
                    {
                        if (string.IsNullOrEmpty(control.Text))
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

                if (buscarEquipoNombre != null)

                {
                    MessageBox.Show("Ya existe un Equipo con ese nombre.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                Equipo nuevoEquipo = new Equipo()
                {
                    nombre = txtNombre.Text,
                    fecha_agregado = DateTime.Now,
                    escudo = txtNombre.Text + ".png",
                    estado = true
                };

                bool agregarEquipo = EquiposControladora.AgregarEquipo(nuevoEquipo);

                if (agregarEquipo == false)
                {
                    MessageBox.Show("Hubo un error al agregar equipo. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                // Agregar jugadores

                Equipo equipo = EquiposControladora.EncontrarEquipoNombre(txtNombre.Text);



                foreach (Control control in flpControles.Controls)
                {
                    if (control is formAgregarJugador)
                    {
                        formAgregarJugador formJug = (formAgregarJugador)control;
                        Jugador nuevoJugador = new Jugador()
                        {
                            nombre = formJug.txtNombreJug.Text,
                            apellido = formJug.txtApellidoJug.Text,
                            dorsal = Convert.ToInt32(formJug.txtDorsalJug.Text),
                            id_equipo = equipo.id_equipo
                        };

                        bool agregarJugador = JugadorControladora.AgregarJugador(nuevoJugador);

                        if (agregarJugador == false)
                        {
                            MessageBox.Show("Hubo un error al agregar jugador. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                if (agregarEquipo)
                {
                    string newFileName = txtNombre.Text + ".png";
                    // Especificar la ruta donde se guardará el archivo
                    targetFolder = Path.Combine(Application.StartupPath, "equipos", txtNombre.Text);
                    targetFilePath = Path.Combine(targetFolder, newFileName);
                    // Asegurarse de que el directorio de destino existe
                    if (Directory.Exists(targetFolder))
                    {
                        File.Delete(targetFilePath);
                        File.Copy(sourceFilePath, targetFilePath);

                    }
                    else
                    {
                        Directory.CreateDirectory(targetFolder);
                        // Copiar el archivo a la nueva ubicación con el nuevo nombre
                        File.Copy(sourceFilePath, targetFilePath);

                    }
                }

                MessageBox.Show("Equipo agregado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }

        private void formAgregarEquipos_FormClosed(object sender, FormClosedEventArgs e)
        {
            formEquiposC.llenarTabla();

        }


        private void btnAgregarJugador_Click_1(object sender, EventArgs e)
        {
            
            agregarFormJugador();

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
    }
}
