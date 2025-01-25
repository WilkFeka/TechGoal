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
        CC_Reglas ReglasControladora = CC_Reglas.getInstance;
        CC_Llave LlavesControladora = CC_Llave.getInstance;
        CC_TorneoEquipos TorneoEquiposControladora = CC_TorneoEquipos.getInstance;

        private formTorneos recargarTabla;

        public formAgregarTorneo(formTorneos formTorneos)
        {
            InitializeComponent();
            recargarTabla = formTorneos;
        }

        private void formAgregarTorneo_Load(object sender, EventArgs e)
        {
            // ---------------------------- CARGA DE COMBOBOX ESTADO ----------------------------
            cmbTipo.Items.Add(new opcionCombo { texto = "Liga", valor = 1 });
            cmbTipo.Items.Add(new opcionCombo { texto = "Llaves", valor = 2 });
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

                if (txtCantEquipos.Text == "0")
                {
                    MessageBox.Show("La cantidad de equipos no puede ser 0.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                Torneo buscarTorneo = TorneosControladora.EncontrarTorneoNombre(txtNombre.Text);

                if (buscarTorneo != null)
                {
                    MessageBox.Show("Ya existe un Torneo con ese nombre.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtCantEquipos.Text == "1")
                {
                    MessageBox.Show("No es posible elejir solo 1 equipo.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                } 

                bool potencia2 = funcionalidades.IsPowerOfTwo(Convert.ToInt32(txtCantEquipos.Text));
                opcionCombo seleccionado = (opcionCombo)cmbTipo.SelectedItem;

                if (potencia2 == false && seleccionado.valor == 2)
                {
                    MessageBox.Show("La cantidad de equipos debe ser potencia de 2.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                


                formVincularTorneoEquipos formVincularEquipos = new formVincularTorneoEquipos(Convert.ToInt32(txtCantEquipos.Text));
                if (formVincularEquipos.ShowDialog() != DialogResult.OK)
                {
                    return;
                }


                formReglasTorneo formReglas = new formReglasTorneo();
                if (formReglas.ShowDialog() != DialogResult.OK)
                {
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

                Torneo torneo = TorneosControladora.EncontrarTorneoNombre(txtNombre.Text);

                List<ListViewItem> resultados = formVincularEquipos.Resultados;

                List<int> equiposLlaves = new List<int>();

                foreach (ListViewItem item in resultados)
                {
                    int idEquipo = (int)item.Tag;
                    equiposLlaves.Add(idEquipo);
                    

                    TorneoEquipos torneoEquipo = new TorneoEquipos()
                    {
                        id_torneo = torneo.id_torneo,
                        id_equipo = idEquipo,
                        estado = true
                    };

                    bool agregarTorneoEquipo = TorneoEquiposControladora.AgregarTorneoEquipo(torneoEquipo);

                    if (agregarTorneoEquipo == false)
                    {
                        MessageBox.Show("Hubo un error al agregar torneo. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                string reglas = formReglas.reglas;

                Reglas regla = new Reglas()
                {
                    id_torneo = torneo.id_torneo,
                    reglas = reglas
                };

                bool agregarReglas = ReglasControladora.AgregarReglas(regla);



                // Crear el generador de torneo para llaves
                var generadorDeLlaves = new GeneradorFixture.GeneradorDeTorneo(new GeneradorFixture.GeneradorLlaves());

                List<Llave> llavesGeneradas = generadorDeLlaves.CrearFixture(equiposLlaves, torneo.cantEquipos, torneo.id_torneo);

                foreach (Llave llave in llavesGeneradas)
                {
                    bool agregarLlave = LlavesControladora.AgregarLlave(llave);

                    if (agregarLlave == false)
                    {
                        MessageBox.Show("Hubo un error al agregar torneo. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                MessageBox.Show("Torneo agregado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.Close();



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

        private void formAgregarTorneo_FormClosed(object sender, FormClosedEventArgs e)
        {
            recargarTabla.RecargarTabla();
        }
    }
}
