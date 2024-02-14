using CapaEntidad;
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

            picEstado.Image = usuarioSeleccionado.estado ? Properties.Resources.Active : Properties.Resources.Inactivo;
        }

        private void formUsuarioModificar_Load(object sender, EventArgs e)
        {

        }

        private void picEstado_Click(object sender, EventArgs e)
        {
            picEstado.Image = txtEstado.Text == "Activo" ? Properties.Resources.Inactive : Properties.Resources.Active;

            txtEstado.Text = txtEstado.Text == "Activo" ? "Inactivo" : "Activo";

        }
    }
}
