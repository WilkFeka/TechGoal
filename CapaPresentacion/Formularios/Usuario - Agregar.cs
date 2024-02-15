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
    public partial class formUsuarioAgregar : Form
    {

        private Funcionalidades funcionalidades = Funcionalidades.getInstance;
        private CC_Usuario UsuarioControladora = CC_Usuario.getInstance;

        private formUsuarios recargarTabla;


        public formUsuarioAgregar(formUsuarios formUsuarios)
        {
            InitializeComponent();
            recargarTabla = formUsuarios;

        }

        private void formUsuarioAgregar_Load(object sender, EventArgs e)
        {
            rolTableAdapter.Fill(dB_TECHGOALDataSet.rol);
            cmbRoles.SelectedIndex = -1;



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

        private void btnGenerarClave_Click(object sender, EventArgs e)
        {
            string nuevaClave = funcionalidades.generarClave(8);
            txtClave.Text = nuevaClave;

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
                    if (correoEncontrado == null)
                    {
                        
                        Usuario documentoEncontrado = UsuarioControladora.EncontrarUsuarioDNI(txtDocumento.Text);
                        if (documentoEncontrado == null)
                        {


                            var mensaje = MessageBox.Show("¿Esta seguro de que desea agregar este usuario?", "Agregando usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (mensaje == DialogResult.No)
                            {
                                return;
                            }

                            string claveHash = UsuarioControladora.EncriptarClave(txtClave.Text);

                            Usuario nuevoUsuario = new Usuario()
                            {
                                email = txtCorreo.Text,
                                clave = claveHash,
                                nombre = txtNombre.Text,
                                apellido = txtApellido.Text,
                                dni = txtDocumento.Text,
                                telefono = txtTelefono.Text,
                                o_rol = new Rol { id_rol = Convert.ToInt32(cmbRoles.SelectedValue) },
                                estado = true
                            };

                            bool agregarUsuario = UsuarioControladora.AgregarUsuario(nuevoUsuario);

                            if (agregarUsuario)
                            {
                                MessageBox.Show("Usuario agregado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();

                            }
                            else
                            {
                                MessageBox.Show("Hubo un error al agregar usuario. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Ya existe un usuario con ese DNI.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    } 
                    else
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

        private void formUsuarioAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            recargarTabla.LlenarTabla();
        }
    }



            
}
