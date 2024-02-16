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
    }
}
