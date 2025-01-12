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

namespace CapaPresentacion.Formularios.Torneos
{
    public partial class formAgregarTorneo : Form
    {
        Funcionalidades funcionalidades = Funcionalidades.getInstance;
        CC_Torneos TorneosControladora = CC_Torneos.getInstance;

        public formAgregarTorneo()
        {
            InitializeComponent();
        }

        private void formAgregarTorneo_Load(object sender, EventArgs e)
        {
            // ---------------------------- CARGA DE COMBOBOX ESTADO ----------------------------
            cmbTipo.Items.Add(new opcionCombo { texto = "Liga", valor = 1 });
            cmbTipo.Items.Add(new opcionCombo { texto = "Llave", valor = 0 });
            cmbTipo.DisplayMember = "texto";
            cmbTipo.ValueMember = "valor";

            dtpFechaFinal.MinDate = dtpFechaInicio.Value;
            dtpFechaFinal.Value = dtpFechaInicio.Value.AddMonths(1);
        }

        private void txtCantEquipos_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);

            if (txtCantEquipos.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar el evento KeyPress
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox)
                    {
                        if (string.IsNullOrEmpty(control.Text))
                        {

                            MessageBox.Show("Por favor complete todos los campos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }

                    if (control is ComboBox)
                    {
                        if (string.IsNullOrEmpty((control as ComboBox).Text))
                        {

                            MessageBox.Show("Por favor complete todos los campos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }

                }


                Torneo buscarTorneo = TorneosControladora.EncontrarTorneoNombre(txtNombre.Text);

                if (buscarTorneo != null)
                {
                    MessageBox.Show("Ya existe un Torneo con ese nombre.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool potencia2 = funcionalidades.IsPowerOfTwo(Convert.ToInt32(txtCantEquipos.Text));
                opcionCombo seleccionado = (opcionCombo)cmbTipo.SelectedItem;

                if (potencia2 == false && seleccionado.valor == 0)
                {
                    MessageBox.Show("La cantidad de equipos debe ser potencia de 2.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                




                Torneo nuevoTorneo = new Torneo()
                {
                    nombre = txtNombre.Text,
                    fechaInicio = dtpFechaInicio.Value,
                    fechaFinal = dtpFechaFinal.Value,
                    tipo = seleccionado.valor,
                    cantEquipos = Convert.ToInt32(txtCantEquipos.Text),
                    estado = true
                };

                bool agregarTorneo = TorneosControladora.AgregarTorneo(nuevoTorneo);

                if (agregarTorneo == false)
                {
                    MessageBox.Show("Hubo un error al agregar torneo. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar agregar el Torneo.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFinal.MinDate = dtpFechaInicio.Value;
            dtpFechaFinal.Value = dtpFechaInicio.Value.AddMonths(1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
