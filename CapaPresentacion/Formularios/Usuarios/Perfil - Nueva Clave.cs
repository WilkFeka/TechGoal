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

namespace CapaPresentacion.Formularios
{
    public partial class formPerfilClave : Form
    {
        Usuario usuarioActual;
        CC_Usuario UsuarioControladora = CC_Usuario.getInstance;
        formPerfil formPerfilC;
        public formPerfilClave(Usuario usuario, formPerfil formPerfil)
        {
            InitializeComponent();
            usuarioActual = usuario;
            formPerfilC = formPerfil;

            txtClaveActual.UseSystemPasswordChar = true;
            txtNuevaClave.UseSystemPasswordChar = true;
            txtConfNuevaClave.UseSystemPasswordChar = true;



        }

        private void btnVerClave_Click(object sender, EventArgs e)
        {
            txtClaveActual.UseSystemPasswordChar = !txtClaveActual.UseSystemPasswordChar;
            txtNuevaClave.UseSystemPasswordChar = !txtNuevaClave.UseSystemPasswordChar;
            txtConfNuevaClave.UseSystemPasswordChar = !txtConfNuevaClave.UseSystemPasswordChar;



            btnVerClave.BackgroundImage = txtClaveActual.UseSystemPasswordChar ? Properties.Resources.eyeSlashW : Properties.Resources.eyeW__1_;


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

                string claveHASH = UsuarioControladora.EncriptarClave(txtClaveActual.Text);

                if (claveHASH != usuarioActual.clave)
                {
                    MessageBox.Show("La clave ingresada es incorrecta.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtNuevaClave.Text != txtConfNuevaClave.Text)
                {
                    MessageBox.Show("Las claves no coinciden.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtNuevaClave.Text == txtClaveActual.Text)
                {
                    MessageBox.Show("La nueva clave no puede ser igual a la actual.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtNuevaClave.TextLength < 8)
                {
                    MessageBox.Show("La nueva clave debe tener al menos 8 caracteres.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string nuevaClaveHASH = UsuarioControladora.EncriptarClave(txtNuevaClave.Text);

                usuarioActual.clave = nuevaClaveHASH;

                bool cambiarClave = UsuarioControladora.NuevaClave(usuarioActual);

                if (cambiarClave == false)
                {
                    MessageBox.Show("Hubo un error al actualizar la clave. Por faor contacte un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Clave actualizada correctamente.", "Clave actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formPerfilClave_FormClosed(object sender, FormClosedEventArgs e)
        {
            formPerfilC.formPerfil_Load(sender, e);
        }
    }
}
