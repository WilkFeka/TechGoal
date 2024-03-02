using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Personalizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class formCanchasModificar : Form
    {
        CC_Cancha CanchaControladora = CC_Cancha.getInstance;
        Funcionalidades Funcionalidades = Funcionalidades.getInstance;
        Cancha canchaSeleccionada;
        formCanchas formCanchasC;
        bool estado;
        public formCanchasModificar(Cancha cancha, formCanchas formCanchas)
        {
            InitializeComponent();
            canchaSeleccionada = cancha;
            estado = cancha.estado;
            formCanchasC = formCanchas;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void formCanchasModificar_Load(object sender, EventArgs e)
        {
            txtNumero.Text = Convert.ToString(canchaSeleccionada.numero);
            txtEstado.Text = estado ? "Activa" : "Inactiva";
            btnEstado.BackgroundImage = estado ? Properties.Resources.Active : Properties.Resources.Inactive;

        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            btnEstado.BackgroundImage = txtEstado.Text == "Activa" ? Properties.Resources.Inactive : Properties.Resources.Active;

            txtEstado.Text = txtEstado.Text == "Activa" ? "Inactiva" : "Activa";
            estado = !estado;


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
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

                Cancha encontrarCancha = CanchaControladora.EncontrarCanchaNum(Convert.ToInt32(txtNumero.Text));

                if (encontrarCancha != null && encontrarCancha.numero != canchaSeleccionada.numero)
                {

                    MessageBox.Show("Numero de cancha existente, por favoir ingrese otro numero", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var mensaje = MessageBox.Show("¿Esta seguro de que desea modificar la Cancha " + Convert.ToString(canchaSeleccionada.numero) + "?", "Modificando Cancha", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.No)
                {
                    return;
                }


                Cancha cancha = new Cancha()
                {
                    id_cancha = canchaSeleccionada.id_cancha,
                    numero = Convert.ToInt32(txtNumero.Text),
                    estado = estado
                };

                bool modificarCancha = CanchaControladora.ModificarCancha(cancha);

                if (modificarCancha == false)
                {
                    MessageBox.Show("Hubo un error al modificar Rol. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Cancha modificada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

            }
            catch
            {

            }
            

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {

            Funcionalidades.soloNumeros(sender, e);
            if (txtNumero.Text.Length == 4)
            {
                // Permitir teclas de control como retroceso o eliminar
                if (!char.IsControl(e.KeyChar))
                {
                    // Evitar que se escriba el quinto carácter
                    e.Handled = true;
                }
            }
        }

        private void formCanchasModificar_FormClosed(object sender, FormClosedEventArgs e)
        {
            formCanchasC.CargarCanchas(1);
        }
    }
}
