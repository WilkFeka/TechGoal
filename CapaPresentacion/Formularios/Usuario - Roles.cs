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
    public partial class formRoles : Form
    {   

        CC_Rol rolControladora = CC_Rol.getInstance;
        CC_Permiso permisoControladora = CC_Permiso.getInstance;

        formInicio formInicioC;
        public formRoles(formInicio formInicio)
        {
            InitializeComponent();

            formInicioC = formInicio;
        }

        public void formUsuarioRoles_Load(object sender, EventArgs e)
        {
            this.rolTableAdapter.Fill(this.dB_TECHGOALDataSet.rol);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.AbrirFormulario(new formUsuarios(formInicioC)); // Sirve para ocultar el formulario actual y abrir el formulario de usuarios
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            formRolesAgregar formRolesAgregar = new formRolesAgregar(this);
            formRolesAgregar.ShowDialog();
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                // ------------- Obtiene el valor de la celda ID ---------------------

                DataGridViewRow filaSeleccionada = dgvRoles.CurrentRow;

                DataGridViewCell celda = filaSeleccionada.Cells["id_rol"];

                int id = Convert.ToInt32(celda.Value);

                Rol rolSeleccionado = rolControladora.BuscarRolID(id);

                var mensaje = MessageBox.Show("¿Esta seguro de que desea borrar el rol " + rolSeleccionado.descripcion + "?", "Borrando Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.No)
                {
                    return;
                }

                //List<Permiso> listaPermisos = permisoControladora.BuscarPermisoID_Rol(rolSeleccionado.id_rol);

                //if (listaPermisos == null)
                //{
                //    MessageBox.Show("Hubo un error al eliminar permisos. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}

                bool eliminarPermisos = permisoControladora.EliminarPermiso(rolSeleccionado.id_rol);

                if (!eliminarPermisos)
                {
                    MessageBox.Show("Hubo un error al eliminar permisos. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                bool eliminarRol = rolControladora.EliminarRol(rolSeleccionado.id_rol);

                if (eliminarRol)
                {
                    MessageBox.Show("Rol eliminado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formUsuarioRoles_Load(sender, e); // Recarga la tabla

                }
                else
                {
                    MessageBox.Show("Hubo un error al eliminar el Rol. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            
        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {

            DataGridViewRow filaSeleccionada = dgvRoles.CurrentRow;

            DataGridViewCell celda = filaSeleccionada.Cells["id_rol"];

            int id = Convert.ToInt32(celda.Value);

            Rol rolSeleccionado = rolControladora.BuscarRolID(id);
            formRolesModificar formRolesModificar = new formRolesModificar(this, rolSeleccionado);
            formRolesModificar.ShowDialog();
        }
    }
}
