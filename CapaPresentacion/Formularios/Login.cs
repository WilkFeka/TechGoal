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
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Login : Form
    {

        private CC_Usuario UsuarioControladora = CC_Usuario.getInstance;

        public Login()
        {
            InitializeComponent();
        }

        private void LoginV2_Load(object sender, EventArgs e)
        {

            lblCorreo.Select(); // Evita que se seleccione automaticamente el textbox al cargar
            txtClave.UseSystemPasswordChar = true; // Oculta la contraseña





        }

        // ---------------------------- PLACEHOLDERS  ----------------------------------------------------
        private void txtCorreo_Enter(object sender, EventArgs e)
        {


            if (txtCorreo.Text == "ejemplo@gmail.com.ar") 
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.WhiteSmoke;

                if (txtClave.Text == "")
                {
                    txtClave.Text = "ejemplo123";
                    txtClave.ForeColor = Color.DimGray;

                }


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

            }
            
            txtClave.ForeColor = Color.WhiteSmoke;

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
                txtClave.UseSystemPasswordChar = true;
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

            IniciarSesion();

        }

        private void btnVerClave_Click(object sender, EventArgs e)
        {
            if (btnVerClave.IconChar == IconChar.EyeSlash)
            {
                btnVerClave.IconChar = IconChar.Eye;

            } else
            {
                btnVerClave.IconChar = IconChar.EyeSlash;

            }


            if (txtClave.Text == "ejemplo123")
            {
                txtClave.Text = "";
                txtClave.UseSystemPasswordChar = false; // Muestra contrasenia

            }

            if (txtClave.Text != "" && txtClave.Text != "ejemplo123")
            {

                if (txtClave.UseSystemPasswordChar == true)
                {
                    txtClave.UseSystemPasswordChar = false; // Muestra contrasenia
                }
                else
                {
                    txtClave.UseSystemPasswordChar = true;

                }
            }


        }

        private void btnVerClave_MouseEnter(object sender, EventArgs e)
        {
            btnVerClave.IconFont = IconFont.Solid;
        }

        private void btnVerClave_MouseLeave(object sender, EventArgs e)
        {
            btnVerClave.IconFont = IconFont.Regular;

        }

        private void IniciarSesion()
        {
            var usuarioEncontrado = UsuarioControladora.EncontrarUsuario(txtCorreo.Text, txtClave.Text);

            if (usuarioEncontrado)
            {

                Inicio formInicio = new Inicio();
                formInicio.Show();

                Hide();

                formInicio.FormClosing += form_closing;

            } else
            {
                MessageBox.Show("Correo o contraseña incorrectos. Por favor verifique los mismos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private Point mousePosicion;

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                mousePosicion = e.Location;
            }

        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mousePosicion.X;
                int deltaY = e.Y - mousePosicion.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }

        }
    }
}
