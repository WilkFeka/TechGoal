using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using CapaControladora;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class formInicio : Form
    {
        CC_Sesion SesionControladora = CC_Sesion.getInstance;
        CC_Usuario UsuarioControladora = CC_Usuario.getInstance;
        private static Form formularioActual = null;
        public static Usuario usuarioActual;
        public formInicio(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            // Obtener el tamaño de la pantalla
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            // Definir el tamaño del formulario con un pequeño margen para que la barra de tareas sea visible
            Size = new Size(screenSize.Width, screenSize.Height - SystemInformation.CaptionHeight);
            // Alinear el formulario en la esquina superior izquierda de la pantalla
            Location = new Point(0, 0);



        }


        // ---------------------------- ESTILOS BOTONES DE NAVEGACION ----------------------------


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
                Application.OpenForms["formLogin"].Show();

        }

        public void AbrirFormulario(Form formulario)
        {
            if (formularioActual != null)
            {
                formularioActual.Close();
            }

            formularioActual = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlGrande.Controls.Add(formulario);
            formulario.Show();
            
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            pnlContainer.Hide();
            picLogoText.Hide();
            AbrirFormulario(new formUsuarios(this));


        }

        private void formInicio_Load(object sender, EventArgs e)
        {

            // ---------------------------- PERMISOS DE USUARIO ----------------------------

            List<Permiso> listaPermisos = new CC_Permiso().ListarPermisosUsuario(usuarioActual.id_usuario);

            var panelMenus = flwPanelButons.Controls;



            foreach (System.Windows.Forms.Control control in panelMenus )
            {
                bool encontrado = listaPermisos.Any(p => p.nombreMenu == control.Name);

                if (encontrado)
                {
                    control.Visible = true;
                }
                else
                {
                    control.Visible = false;
                }

            }

        }

        private void btnAjusteUsuario_MouseEnter(object sender, EventArgs e)
        {

            btnAjusteUsuario.IconColor = Color.FromArgb(31, 200, 236);
            btnAjusteUsuario.IconSize = 70;
        }

        private void btnAjusteUsuario_MouseLeave(object sender, EventArgs e)
        {
            btnAjusteUsuario.IconColor = Color.White;
            btnAjusteUsuario.IconSize = 64;


        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.IconColor = Color.FromArgb(31, 200, 236);
            btnHome.IconSize = 70;

        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.IconColor = Color.White;
            btnHome.IconSize = 64;

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlContainer.Show();
            picLogoText.Show();

            if (formularioActual != null)
            {
                formularioActual.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
    }
