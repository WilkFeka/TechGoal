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
    public partial class formRolesModificar : Form
    {
        CC_Permiso permisoControladora = CC_Permiso.getInstance;
        CC_Rol rolControladora = CC_Rol.getInstance;
        CC_Modulo moduloControladora = CC_Modulo.getInstance;


        formRoles formRolesC;
        Rol rolSeleccionadoC;

        private bool activadoUsuarios, activadoCanchas, activadoTorneos, activadoEquipos, activadoPantalla, activadoReportes, activadoClientes, activadoABMCanchas, activadoHorarios;
        Dictionary<Modulo, bool> modulosActivados = new Dictionary<Modulo, bool>();


        public formRolesModificar(formRoles formRoles, Rol rolSeleccionado)
        {
            InitializeComponent();
            formRolesC = formRoles;
            rolSeleccionadoC = rolSeleccionado;

            txtNombre.Text = rolSeleccionado.descripcion;

            List<Permiso> listaPermisos = permisoControladora.BuscarPermisoID_Rol(rolSeleccionado.id_rol);

            List<Modulo> listaModulos = moduloControladora.Listar();

            foreach (Modulo modulo in listaModulos)
            {
                modulosActivados.Add(modulo, false);

            }



            foreach (Permiso permiso in listaPermisos)
            {
                switch (permiso.obj_modulo.id_modulo)
                {
                    case 1:
                        btnUsuarios.BackgroundImage = Properties.Resources.Active;
                        activadoUsuarios = true;
                        break;
                    case 2:
                        btnCanchas.BackgroundImage = Properties.Resources.Active;
                        activadoCanchas = true;
                        break;
                    case 3:
                        btnHorarios.BackgroundImage = Properties.Resources.Active;
                        activadoHorarios = true;
                        break;
                    case 4:
                        btnClientes.BackgroundImage = Properties.Resources.Active;
                        activadoClientes = true;
                        break;
                    case 5:
                        btnTorneos.BackgroundImage = Properties.Resources.Active;
                        activadoTorneos = true;
                        break;
                    case 6:
                        btnEquipos.BackgroundImage = Properties.Resources.Active;
                        activadoEquipos = true;
                        break;
                    case 7:
                        btnPantalla.BackgroundImage = Properties.Resources.Active;
                        activadoPantalla = true;
                        break;
                    case 8:
                        btnReportes.BackgroundImage = Properties.Resources.Active;
                        activadoReportes = true;
                        break;
                    case 10:
                        btnABMCanchas.BackgroundImage = Properties.Resources.Active;
                        activadoABMCanchas = true;
                        break;
                }
            }




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

                if (activadoCanchas)
                {
                    modulosActivados[modulosActivados.Keys.First(m => m.modulo == "vistaCanchas")] = true;
                }

                if (activadoEquipos)
                {
                    modulosActivados[modulosActivados.Keys.First(m => m.modulo == "vistaEquipos")] = true;
                }

                if (activadoPantalla)
                {
                    modulosActivados[modulosActivados.Keys.First(m => m.modulo == "vistaPantalla")] = true;
                }

                if (activadoReportes)
                {
                    modulosActivados[modulosActivados.Keys.First(m => m.modulo == "vistaReportes")] = true;
                }

                if (activadoTorneos)
                {
                    modulosActivados[modulosActivados.Keys.First(m => m.modulo == "vistaTorneos")] = true;
                }

                if (activadoUsuarios)
                {
                    modulosActivados[modulosActivados.Keys.First(m => m.modulo == "vistaUsuario")] = true;
                }

                if (activadoClientes)
                {
                    modulosActivados[modulosActivados.Keys.First(m => m.modulo == "vistaClientes")] = true;
                }

                if (activadoABMCanchas)
                {
                    modulosActivados[modulosActivados.Keys.First(m => m.modulo == "ABMCanchas")] = true;
                }

                if (activadoHorarios)
                {
                    modulosActivados[modulosActivados.Keys.First(m => m.modulo == "vistaHorarios")] = true;
                }


                if (modulosActivados.All(a => !a.Value))
                {
                    MessageBox.Show("Por favor seleccione al menos un permiso", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // ---------------------- BUSCAR ROL ROL ----------------------

                Rol rolEncontrado = rolControladora.BuscarRol(txtNombre.Text);

                if (rolEncontrado != null && rolEncontrado.id_rol != rolSeleccionadoC.id_rol)
                {
                    MessageBox.Show("Ya existe un Rol con ese nombre.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var mensaje = MessageBox.Show("¿Esta seguro de que desea modificar el Rol " + rolSeleccionadoC.descripcion + "?", "Modificando Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.No)
                {
                    return;
                }

                Rol rol = new Rol()
                {
                    id_rol = rolSeleccionadoC.id_rol,
                    descripcion = txtNombre.Text
                };

                bool modificarRol = rolControladora.ModificarRol(rol);

                if (modificarRol == false)
                {
                    MessageBox.Show("Hubo un error al modificar Rol. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ---------------------- AGREGAR PERMISOS ----------------------


                Rol buscarRol = rolControladora.BuscarRol(txtNombre.Text);

                bool borrarPermisos = permisoControladora.EliminarPermiso(buscarRol.id_rol);

                if (!borrarPermisos)
                {
                    MessageBox.Show("Hubo un error al eliminar permiso. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                foreach (KeyValuePair<Modulo, bool> modulo in modulosActivados)
                {
                    if (modulo.Value)
                    {
                        Permiso permiso = new Permiso()
                        {
                            obj_rol = buscarRol,
                            obj_modulo = modulo.Key
                        };

                        bool agregarPermiso = permisoControladora.AgregarPermiso(permiso);

                        if (agregarPermiso == false)
                        {
                            MessageBox.Show("Hubo un error al agregar permiso. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                MessageBox.Show("Rol modificado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            catch (Exception error)
            {
                MessageBox.Show($"{error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }



        private void formRolesModificar_Load(object sender, EventArgs e)
        {

        }

        private void btnABMCanchas_Click(object sender, EventArgs e)
        {
            btnABMCanchas.BackgroundImage = activadoABMCanchas ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoABMCanchas = !activadoABMCanchas;
        }

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

        private void btnTorneos_Click(object sender, EventArgs e)
        {
            btnTorneos.BackgroundImage = activadoTorneos ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoTorneos = !activadoTorneos;
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            btnEquipos.BackgroundImage = activadoEquipos ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoEquipos = !activadoEquipos;
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            
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

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            btnHorarios.BackgroundImage = activadoHorarios ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoHorarios = !activadoHorarios;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            btnClientes.BackgroundImage = activadoClientes ? Properties.Resources.Inactive : Properties.Resources.Active;
            activadoClientes = !activadoClientes;
        }
    }
}
