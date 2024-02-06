using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladora;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        CC_Sesion SesionControladora = CC_Sesion.getInstance;
        CC_Usuario UsuarioControladora = CC_Usuario.getInstance;
        public Inicio(Usuario usuario)
        {
            InitializeComponent();
            string nombreUsuario = usuario.nombre;  //
            lblNombre.Text = nombreUsuario;         // Muestra el nombre del usuario en el label

        }


        // ---------------------------- ESTILOS BOTONES DE NAVEGACION ----------------------------
        private void btnAjusteUsuario_MouseEnter(object sender, EventArgs e)
        {
            btnAjusteUsuario.IconColor = Color.FromArgb(31,200,236);
            btnAjusteUsuario.IconSize = 70;
        }

        private void btnAjusteUsuario_MouseLeave(object sender, EventArgs e)
        {
            btnAjusteUsuario.IconColor = Color.White;
            btnAjusteUsuario.IconSize = 64;
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            btnSalir.ForeColor = Color.FromArgb(7,11,20);
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.ForeColor = Color.FromArgb(30,200,236) ;


        }

        // ---------------------------- FUNCIONALIDAD BOTON SALIR ----------------------------
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mensaje = MessageBox.Show("¿Esta seguro de que desea salir de la aplicacion?", "Saliendo de la aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mensaje == DialogResult.No)
            {
                e.Cancel = true;
            } else
            {
                SesionControladora.Logout();
            }


        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Login"].Show();
            
        }
    }
}
