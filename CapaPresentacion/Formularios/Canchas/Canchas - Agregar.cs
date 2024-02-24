using CapaControladora;
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

namespace CapaPresentacion.Formularios
{
    public partial class formCanchasAgregar : Form
    {
        CC_Cancha CanchaControladora = CC_Cancha.getInstance;
        Funcionalidades Funcionalidades = Funcionalidades.getInstance;
        formCanchas formCanchasC;
        public formCanchasAgregar(formCanchas formCanchas)
        {
            InitializeComponent();
            formCanchasC = formCanchas;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                MessageBox.Show("Por favor complete todos los campos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (txtNumero.Text == "0")
            {
                MessageBox.Show("El numero de cancha no puede ser 0. Por favor ingrese uno diferente", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cancha ecnontrarCancha = CanchaControladora.EncontrarCanchaNum(Convert.ToInt32(txtNumero.Text));

            if (ecnontrarCancha != null)
            {
                MessageBox.Show("Numero de cancha existente, por favoir ingrese otro numero", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            bool agregarCancha = CanchaControladora.AgregarCancha(Convert.ToInt32(txtNumero.Text));

            if (agregarCancha == false)
            {
                MessageBox.Show("Hubo un error al agregar cancha, Por favor contacte a un administrador", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cancha canchaNueva = CanchaControladora.EncontrarCanchaNum(Convert.ToInt32(txtNumero.Text));

            bool asociarCanchaHorarios = CanchaControladora.AgregarCanchaHorarios(canchaNueva.id_cancha);

            if (asociarCanchaHorarios == false)
            {
                MessageBox.Show("Hubo un error al asociar cancha con horarios. Por favor contacte a un administrador", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Cancha agregada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funcionalidades.soloNumeros(sender, e);
        }

        private void formCanchasAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            formCanchasC.formCanchas_Load(sender, e);
        }
    }
}
