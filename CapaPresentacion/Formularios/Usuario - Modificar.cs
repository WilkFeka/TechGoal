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
    public partial class formUsuarioModificar : Form
    {
        public formUsuarioModificar()
        {
            InitializeComponent();
        }

        private void formUsuarioModificar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dB_TECHGOALDataSet.rol' Puede moverla o quitarla según sea necesario.
            rolTableAdapter.Fill(dB_TECHGOALDataSet.rol);

        }
    }
}
