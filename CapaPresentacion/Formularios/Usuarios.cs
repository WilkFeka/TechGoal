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
using System.Windows.Controls;
using CapaPresentacion.Formularios;

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
            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet.permisos' Puede moverla o quitarla según sea necesario.
            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet.rol' Puede moverla o quitarla según sea necesario.
            rolTableAdapter.Fill(dB_TECHGOALDataSet.rol);
            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet.usuarios' Puede moverla o quitarla según sea necesario.

            usuariosTableAdapter.Fill(dB_TECHGOALDataSet.usuarios);


            // ---------------------------- CARGA DE COMBOBOX ESTADO ----------------------------
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Activo", valor = 1 });
            cmbEstadoFilter.Items.Add(new opcionCombo { texto = "Inactivo", valor = 0 });
            cmbEstadoFilter.DisplayMember = "texto";
            cmbEstadoFilter.ValueMember = "valor";

            List<Rol> listaRoles = new CC_Rol().Listar();

            foreach (Rol rol in listaRoles)
            {
            }

            limpiarFiltros();
        }

        private void txtCorreoFilter_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtNombreFilter_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtDNIFilter_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
            
        }

        private void cmbRolFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            Filtrar();

        }

        private void cmbEstadoFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();

        }

        private void Filtrar()
        {
            string rolQuery = "";
            string estadoQuery = "";


            if (cmbRolFilter.SelectedValue != null)
            {
                string rolID = cmbRolFilter.SelectedValue.ToString();
                rolQuery = " AND id_rol = " + rolID;

            }

            if (cmbEstadoFilter.SelectedItem != null)
            {
                foreach (opcionCombo item in cmbEstadoFilter.Items)
                {
                    if (item.texto == cmbEstadoFilter.Text)
                    {
                        estadoQuery = " AND estado = " + item.valor;
                    }
                }   

            }


            usuariosBindingSource.Filter = "email LIKE '%" + txtCorreoFilter.Text + "%' AND nombre LIKE '%" + txtNombreFilter.Text + "%' AND dni LIKE '%" + txtDNIFilter.Text + "%'" + rolQuery + estadoQuery;

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFiltros();
        }

        private void limpiarFiltros()
        {
            txtCorreoFilter.Text = "";
            txtNombreFilter.Text = "";
            txtDNIFilter.Text = "";
            cmbRolFilter.SelectedIndex = -1;
            cmbEstadoFilter.SelectedIndex = -1;
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Form agregar = new formUsuarioAgregar();
            agregar.ShowDialog();

        }
    }
}
