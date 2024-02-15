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
using System.Windows.Controls;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class formUsuarioNuevaClave : Form
    {
        private Funcionalidades funcionalidades = Funcionalidades.getInstance;
        private CC_Usuario UsuarioControladora = CC_Usuario.getInstance;

        private formUsuarios recargarTabla;
        public Usuario usuarioGlobal;


        public formUsuarioNuevaClave(formUsuarios formUsuarios, Usuario usuarioSeleccionado)
        {
            InitializeComponent();
            recargarTabla = formUsuarios;
            usuarioGlobal = usuarioSeleccionado;

        }

        private void btnGenerarClave_Click(object sender, EventArgs e)
        {
            string nuevaClave = funcionalidades.generarClave(8);
            txtClave.Text = nuevaClave;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClave.Text))
            {

                MessageBox.Show("Por favor complete todos los campos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            var mensaje = MessageBox.Show("¿Esta seguro de que desea cambiar la clave del usuario " + usuarioGlobal.email + "?", "Modificando usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mensaje == DialogResult.No)
            {
                return;
            }

            string claveHash = UsuarioControladora.EncriptarClave(txtClave.Text);


            Usuario usuarioModificar = new Usuario()
            {
                id_usuario = usuarioGlobal.id_usuario,
                 clave = claveHash
            };

            bool modificarUsuario = UsuarioControladora.NuevaClave(usuarioModificar);

            if (modificarUsuario)
            {
                MessageBox.Show("Clave actualizada con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar clave. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void formUsuarioNuevaClave_FormClosed(object sender, FormClosedEventArgs e)
        {
            recargarTabla.LlenarTabla();
        }
    }
}
