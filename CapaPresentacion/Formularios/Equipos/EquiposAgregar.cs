using CapaControladora;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Equipos
{
    public partial class formAgregarEquipos : Form
    {
        CC_Equipos EquiposControladora = CC_Equipos.getInstance;
        string targetFolder;
        string targetFilePath;
        string sourceFilePath;
        public formAgregarEquipos()
        {
            InitializeComponent();
        }

        private void formAgregarEquipos_Load(object sender, EventArgs e)
        {

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

                // Generar un nombre único para la imagen
                string newFileName = txtNombre.Text;

                // Especificar la ruta donde se guardará el archivo
                targetFolder = Path.Combine(Application.StartupPath, "equipos", txtNombre.Text);
                targetFilePath = Path.Combine(targetFolder, newFileName);

                this.DialogResult = DialogResult.None;



            }
            txtPathEscudo.Text = sourceFilePath;

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

                Equipo buscarEquipoNombre = EquiposControladora.EncontrarEquipoNombre(txtNombre.Text);

                if (buscarEquipoNombre != null)

                {
                    MessageBox.Show("Ya existe un Equipo con ese nombre.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }



            } catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //// Asegurarse de que el directorio de destino existe
            //if (!Directory.Exists(targetFolder))
            //{
            //    Directory.CreateDirectory(targetFolder);
            //}

            //// Copiar el archivo a la nueva ubicación con el nuevo nombre
            //File.Copy(sourceFilePath, targetFilePath);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }
    }
}
