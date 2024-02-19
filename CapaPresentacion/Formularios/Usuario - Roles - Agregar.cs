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
    public partial class formRolesAgregar : Form
    {
        CC_Rol rolControladora = CC_Rol.getInstance;
        CC_Permiso permisoControladora = CC_Permiso.getInstance;
        formRoles formRolesC;

        private bool activadoUsuarios, activadoCanchas, activadoTorneos, activadoEquipos, activadoPantalla, activadoReportes, activadoRoles  = false;



        public formRolesAgregar(formRoles formRoles)
        {
            InitializeComponent();
            formRolesC = formRoles;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                // ---------------------- VALIDACIONES ----------------------


                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool[] activados = { activadoUsuarios, activadoCanchas, activadoEquipos, activadoPantalla, activadoReportes, activadoRoles, activadoTorneos };


                

                if (activados.All(a => !a))
                {
                    MessageBox.Show("Por favor seleccione al menos un permiso", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // ---------------------- AGREGAR ROL ----------------------

                Rol rolEncontrado = rolControladora.BuscarRol(txtNombre.Text);

                if (rolEncontrado != null)
                {
                    MessageBox.Show("Ya existe un Rol con ese nombre.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var mensaje = MessageBox.Show("¿Esta seguro de que desea agregar este Rol?", "Agregando Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.No)
                {
                    return;
                }

                Rol rol = new Rol()
                {
                    descripcion = txtNombre.Text
                };

                bool agregarRol = rolControladora.AgregarRol(rol);

                if (agregarRol == false)
                {
                    MessageBox.Show("Hubo un error al agregar nuevo Rol. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ---------------------- AGREGAR PERMISOS ----------------------


                Rol buscarRol = rolControladora.BuscarRol(txtNombre.Text);

                // Nombres de los menus. Tienen que tener el mismo index que las variables en 'activados'
                string[] nombreMenus = { "menuUsuarios", "menuCanchas", "menuEquipos", "menuPantalla", "menuReportes", "menuRoles", "menuTorneos" }; 

                for (int i = 0; i < activados.Length; i++)
                {
                    if (activados[i])
                    {
                        string nombreMenu = nombreMenus[i];

                        Permiso permiso = new Permiso()
                        {
                            obj_rol = buscarRol,
                            nombreMenu = nombreMenu
                        };

                        bool agregarPermiso = permisoControladora.AgregarPermiso(permiso);

                        if (agregarPermiso == false)
                        {
                            MessageBox.Show("Hubo un error al agregar nuevo permiso. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }

                MessageBox.Show("Rol agregado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            } catch (Exception error)
            {
                MessageBox.Show($"{error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void formRolesAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Recarga la tabla al cerrar el formulario
            formRolesC.formUsuarioRoles_Load(sender, e); 
        }

        // ---------------------------- FUNCIONALIDADES Y VISTAS DE BOTONES ----------------------------

        private void btnUsuarios_Click(object sender, EventArgs e)
        {

            btnUsuarios.BackgroundImage = activadoUsuarios ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoUsuarios = !activadoUsuarios;

        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            btnCanchas.BackgroundImage = activadoCanchas ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoCanchas = !activadoCanchas;

        }

        private void btnPantalla_Click(object sender, EventArgs e)
        {
            btnPantalla.BackgroundImage = activadoPantalla ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoPantalla = !activadoPantalla;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            btnReportes.BackgroundImage = activadoReportes ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoReportes = !activadoReportes;
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            btnRoles.BackgroundImage = activadoRoles ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoRoles = !activadoRoles;
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            btnEquipos.BackgroundImage = activadoEquipos ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoEquipos = !activadoEquipos;
        }

        private void btnTorneos_Click(object sender, EventArgs e)
        {
            btnTorneos.BackgroundImage = activadoTorneos ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoTorneos = !activadoTorneos;
        }
    }
}
