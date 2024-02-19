using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Personalizacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class formUsuarioModificar : Form
    {
        private formUsuarios recargarTabla;

        public  Funcionalidades funcionalidades = Funcionalidades.getInstance;

        public CC_Usuario UsuarioControladora = CC_Usuario.getInstance;

        public Usuario usuarioGlobal;

        public formUsuarioModificar(formUsuarios formUsuarios, Usuario usuarioSeleccionado)
        {
            InitializeComponent();
            recargarTabla = formUsuarios;

            rolTableAdapter.Fill(dB_TECHGOALDataSet.rol);

            txtCorreo.Text = usuarioSeleccionado.email;
            txtNombre.Text = usuarioSeleccionado.nombre;
            txtApellido.Text = usuarioSeleccionado.apellido;
            txtDocumento.Text = usuarioSeleccionado.dni;
            txtTelefono.Text = usuarioSeleccionado.telefono;
            cmbRoles.SelectedValue = usuarioSeleccionado.o_rol.id_rol;

            txtEstado.Text = usuarioSeleccionado.estado ? "Activo" : "Inactivo";
            button1.BackgroundImage = usuarioSeleccionado.estado ? Properties.Resources.Active : Properties.Resources.Inactive;

            usuarioGlobal = usuarioSeleccionado;

            


        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);

        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackgroundImage = txtEstado.Text == "Activo" ? Properties.Resources.Inactive : Properties.Resources.Active;

            txtEstado.Text = txtEstado.Text == "Activo" ? "Inactivo" : "Activo";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // ---------------------------- VALIDACION DE CAMPOS VACIOS ----------------------------

                foreach (Control control in Controls)
                {
                    if (control is TextBox || control is ComboBox)
                    {
                        if (string.IsNullOrEmpty(control.Text))
                        {

                            MessageBox.Show("Por favor complete todos los campos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }
                }

                if (funcionalidades.validarEmail(txtCorreo.Text))
                {
                    Usuario correoEncontrado = UsuarioControladora.EncontrarUsuarioCorreo(txtCorreo.Text);


                    if (correoEncontrado == null || correoEncontrado.email == usuarioGlobal.email)
                    {
                        Usuario documentoEncontrado = UsuarioControladora.EncontrarUsuarioDNI(txtDocumento.Text);

                        if(documentoEncontrado == null || documentoEncontrado.dni == usuarioGlobal.dni)
                        {

                            var mensaje = MessageBox.Show("¿Esta seguro de que desea modificar al usuario " + usuarioGlobal.email + "?", "Modificando usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (mensaje == DialogResult.No)
                            {
                                return;
                            }

                            bool estado = txtEstado.Text == "Activo" ? true : false;
                            
                            Usuario usuarioModificar = new Usuario()
                            {
                                id_usuario = usuarioGlobal.id_usuario,
                                email = txtCorreo.Text,
                                nombre = txtNombre.Text,
                                apellido = txtApellido.Text,
                                dni = txtDocumento.Text,
                                telefono = txtTelefono.Text,
                                o_rol = new Rol { id_rol = Convert.ToInt32(cmbRoles.SelectedValue) },
                                estado = estado
                            };

                            bool modificarUsuario = UsuarioControladora.ModificarUsuario(usuarioModificar);

                            if (modificarUsuario)
                            {
                                MessageBox.Show("Usuario modificado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();

                            }
                            else
                            {
                                MessageBox.Show("Hubo un error al modificar usuario. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Ya existe un usuario con ese DNI.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }  else
                    {
                        MessageBox.Show("Ya existe un usuario con ese correo.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("El correo ingresado no es valido", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception error)
            {

                MessageBox.Show($"{error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void formUsuarioModificar_FormClosed(object sender, FormClosedEventArgs e)
        {
            recargarTabla.LlenarTabla();
        }
    }
}
