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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginV2_Load(object sender, EventArgs e)
        {

            lblCorreo.Select(); // Evita que se seleccione automaticamente el textbox al cargar

        }

        // ---------------------------- PLACEHOLDERS  ----------------------------------------------------
        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "ejemplo@gmail.com.ar") 
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.FromArgb(0, 23, 49);

            }

        }

        private void form_closing(object sender, FormClosingEventArgs e)
        {
            txtClave.Text = "ejemplo123";
            txtCorreo.Text = "ejemplo@gmail.com.ar";
            Show();
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "ejemplo123")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.FromArgb(0, 23, 49);

            }

        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "ejemplo@gmail.com.ar";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "ejemplo123";
                txtClave.ForeColor = Color.DimGray;
            }

        }

        // ---------------------------- ESTILOS BOTONES  ----------------------------------------------------


        private void btnIniciarSesion_MouseLeave(object sender, EventArgs e)
        {

            btnIniciarSesion.ForeColor = Color.FromArgb(31, 201, 236);

        }


        private void btnIniciarSesion_MouseEnter(object sender, EventArgs e)
        {

            btnIniciarSesion.ForeColor = Color.FromArgb(7, 11, 20);
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BorderColor = Color.FromArgb(31, 201, 236);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {


            // Lista de usuarios de la base de datos
            List<Usuario> listaUsuarios = new CC_Usuario().Listar();

            //Filtrar usuarios por email y clave proporcionados
            Usuario usuarioIniciando = new CC_Usuario().Listar().Where(u => u.email == txtCorreo.Text && u.clave == txtClave.Text).FirstOrDefault();

            

            if (usuarioIniciando == null) // Si el usuario NO existe
            {
                MessageBox.Show("Correo o contraseña incorrectos. Por favor verifique los mismos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                

            } else // Si el usuario existe
            {

            Inicio formInicio = new Inicio();
            formInicio.Show();

            Hide();

            formInicio.FormClosing += form_closing;

            }





        }

        
    }
}
