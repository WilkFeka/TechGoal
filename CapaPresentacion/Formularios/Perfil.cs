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
    public partial class formPerfil : Form
    {
        Funcionalidades Funcionalidades = Funcionalidades.getInstance;
        CC_Usuario UsuarioControladora = CC_Usuario.getInstance;
        Usuario usuarioActual;
        formInicio formInicioC;
        public formPerfil(Usuario usuario, formInicio formInicio)
        {
            InitializeComponent();
            usuarioActual = usuario;
            formInicioC = formInicio;



        }

        public void formPerfil_Load(object sender, EventArgs e)
        {

            Usuario cargarUsuario = UsuarioControladora.EncontrarUsuarioID(usuarioActual.id_usuario);

            txtCorreo.Text = cargarUsuario.email;
            txtNombre.Text = cargarUsuario.nombre;
            txtApellido.Text = cargarUsuario.apellido;
            txtDocumento.Text = cargarUsuario.dni;
            txtTelefono.Text = cargarUsuario.telefono;
            txtClave.Text = "";
            txtClave.UseSystemPasswordChar = true;

            txtCorreo.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDocumento.Enabled = false;
            txtTelefono.Enabled = false;

            lblClave.Visible = false;
            txtClave.Visible = false;
            btnFondoClave.Visible = false;
            btnVerClave.Visible = false;

            btnCancelar.Visible = false;
            btnAceptar.Visible = false;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtCorreo.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDocumento.Enabled = true;
            txtTelefono.Enabled = true;

            lblClave.Visible = true;
            txtClave.Visible = true;
            btnFondoClave.Visible = true;
            btnVerClave.Visible = true;

            btnCancelar.Visible = true;
            btnAceptar.Visible = true;  
            
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcionalidades.soloNumeros(sender, e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcionalidades.soloLetras(sender, e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcionalidades.soloLetras(sender, e);

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcionalidades.soloNumeros(sender, e);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.pnlContainer.Show();
            formInicioC.picLogoText.Show();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            var mensaje = MessageBox.Show("¿Esta seguro de que desea cancelar la operacion?", "Agregando usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mensaje == DialogResult.No)
            {
                return;
            }

            txtCorreo.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDocumento.Enabled = false;
            txtTelefono.Enabled = false;

            lblClave.Visible = false;
            txtClave.Visible = false;
            btnFondoClave.Visible = false;

            btnCancelar.Visible = false;
            btnAceptar.Visible = false;

            formPerfil_Load(sender,e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // ---------------------------- VALIDACION DE CAMPOS VACIOS ----------------------------

                foreach (Control control in pnlContainer.Controls)
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

                if (Funcionalidades.validarEmail(txtCorreo.Text) == false)
                {
                    MessageBox.Show("El correo ingresado no es valido", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Usuario correoEncontrado = UsuarioControladora.EncontrarUsuarioCorreo(txtCorreo.Text);

                if (correoEncontrado != null && correoEncontrado.email != usuarioActual.email)
                {
                    MessageBox.Show("Ya existe un usuario con ese correo.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                string claveHASH = UsuarioControladora.EncriptarClave(txtClave.Text);

                if (claveHASH != usuarioActual.clave)
                {
                    MessageBox.Show("La clave ingresada es incorrecta.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Usuario usuarioModificado = new Usuario
                {
                    id_usuario = usuarioActual.id_usuario,
                    email = txtCorreo.Text,
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    dni = txtDocumento.Text,
                    telefono = txtTelefono.Text,
                    o_rol = usuarioActual.o_rol,
                    estado = usuarioActual.estado
                };

                bool modificarusuario = UsuarioControladora.ModificarUsuario(usuarioModificado);

                if (modificarusuario == false)
                {
                    MessageBox.Show("Hubo un error al modificar usuario. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Usuario modificado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                formPerfil_Load(sender, e);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al actualizar el perfil", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerClave_Click(object sender, EventArgs e)
        {

            txtClave.UseSystemPasswordChar = !txtClave.UseSystemPasswordChar;

            btnVerClave.BackgroundImage = txtClave.UseSystemPasswordChar ? Properties.Resources.eyeW__1_ : Properties.Resources.eyeSlashW;

        }

        private void btnNuevaClave_Click(object sender, EventArgs e)
        {
            formPerfil_Load(sender, e);

            formPerfilClave formPerfilClave = new formPerfilClave(usuarioActual, this);
            formPerfilClave.ShowDialog();
        }
    }
}
