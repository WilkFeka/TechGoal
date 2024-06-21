using CapaEntidad;
using CapaPresentacion.Personalizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Equipos
{
    public partial class formAgregarJugador : Form
    {
        Funcionalidades funcionalidades = Funcionalidades.getInstance;
        public formAgregarJugador(Jugador jugador)
        {
            InitializeComponent();
            txtNombreJug.Text = jugador.nombre;
            txtApellidoJug.Text = jugador.apellido;
            txtDorsalJug.Text = jugador.dorsal.ToString();
        }

        public formAgregarJugador()
        {
            InitializeComponent();
        }

        private void txtNombreJug_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);

        }

        private void txtApellidoJug_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);

        }

        private void txtDorsalJug_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);

            if (txtDorsalJug.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar el evento KeyPress
            }

        }
    }
}
