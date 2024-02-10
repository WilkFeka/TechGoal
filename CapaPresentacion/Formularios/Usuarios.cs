using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Personalizacion;
using CapaControladora;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class formUsuarios : Form
    {
        public formUsuarios()
        {
            InitializeComponent();
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet.usuarios' Puede moverla o quitarla según sea necesario.

            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                // Establece el alto máximo para cada fila
                row.Height = 15; // Establece el alto máximo
            }
            usuariosTableAdapter.Fill(this.dB_TECHGOALDataSet.usuarios);

            // ---------------------------- CARGA DE COMBOBOX ESTADO ----------------------------
            cmbEstado.Items.Add(new opcionComboEstado { texto = "Activo", valor = 1 });
            cmbEstado.Items.Add(new opcionComboEstado { texto = "Inactivo", valor = 0 });
            cmbEstado.DisplayMember = "texto";
            cmbEstado.ValueMember = "valor";


            List<Rol> listaRoles = new CC_Rol().Listar();

            foreach (Rol item in listaRoles)
            {
                cmbRol.Items.Add(new opcionComboEstado { texto = item.descripcion, valor = item.id_rol });
            }

            cmbRol.DisplayMember = "texto";
            cmbRol.ValueMember = "valor";



        }
    }
}
