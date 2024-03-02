using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Formularios.Canchas;
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

namespace CapaPresentacion.Formularios.Reservas
{
    public partial class formReservaModificar : Form
    {
        Cancha canchaSeleccionada;
        Horario horarioSeleccionado;
        DateTime fechaSeleccionada;

        Funcionalidades funcionalidades = Funcionalidades.getInstance;
        CC_Cliente ClienteControladora = CC_Cliente.getInstance;
        CC_Reserva ReservaControladora = CC_Reserva.getInstance;
        Cliente clienteSeleccionado;
        Reserva reservaSeleccionada;
        formCanchaIndividual formCanchaIndividualC;

        bool clientesAbierto = false;
        public formReservaModificar(Cancha cancha, DateTime fecha, Horario horario, formCanchaIndividual formCanchaIndividual, Cliente cliente, Reserva reserva)
        {
            InitializeComponent();
            reservaSeleccionada = ReservaControladora.EncontrarReservaID(reserva.id_reserva);


            canchaSeleccionada = cancha;
            fechaSeleccionada = fecha;
            horarioSeleccionado = horario;
            reservaSeleccionada = reserva;
            clienteSeleccionado = ClienteControladora.EncontrarClienteID(cliente.id_cliente);
            formCanchaIndividualC = formCanchaIndividual;




            Size = new Size(551, 576);
        }

        private void formReservaModificar_Load(object sender, EventArgs e)
        {
            txtCancha.Text = canchaSeleccionada.numero.ToString();
            txtFecha.Text = fechaSeleccionada.ToShortDateString();
            txtHorario.Text = horarioSeleccionado.hora.ToString();
            txtCliente.Text = clienteSeleccionado.nombre + " " + clienteSeleccionado.apellido;
            cmbTipo.SelectedIndex = reservaSeleccionada.tipo == "Partido" ? 0 : 1;
            llenarTabla();
        }

        private void btnElegirCliente_Click(object sender, EventArgs e)
        {
            if (clientesAbierto == false)
            {
                AbrirClientes();
            }
        }

        public void llenarTabla()
        {
            clientesTableAdapter.Fill(dB_TECHGOALDataSet1.clientes);

            filtrar();

        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Size = new Size(551, 576);
            Location = new Point(Location.X + 300, Location.Y);
            clientesAbierto = !clientesAbierto;

            // ------------- Obtiene el valor de la celda ID ---------------------
            DataGridViewRow filaSeleccionada = dgvClientes.CurrentRow;

            DataGridViewCell celda = filaSeleccionada.Cells["id_cliente"];

            int id = Convert.ToInt32(celda.Value);

            clienteSeleccionado = ClienteControladora.EncontrarClienteID(id);


            txtCliente.Text = clienteSeleccionado.nombre + " " + clienteSeleccionado.apellido;


        }
        public void AbrirClientes()
        {
            clientesAbierto = !clientesAbierto;
            Size = new Size(1222, 576);
            Location = new Point(Location.X - 300, Location.Y);
        }

        private void filtrar()
        {
            string filtro = $"nombre LIKE '%{txtNombreFilter.Text}%' AND apellido LIKE '%{txtApellidoFilter.Text}%' AND dni LIKE '%{txtDocumentoFilter.Text}%' AND estado = 1";

            clientesBindingSource.Filter = filtro;
        }

        private void txtNombreFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);

        }

        private void txtApellidoFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);

        }

        private void txtDocumentoFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);

        }

        private void txtNombreFilter_TextChanged(object sender, EventArgs e)
        {
            filtrar();

        }

        private void txtApellidoFilter_TextChanged(object sender, EventArgs e)
        {
            filtrar();

        }

        private void txtDocumentoFilter_TextChanged(object sender, EventArgs e)
        {
            filtrar();

        }

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnOkay_Click(sender, e);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                // ---------------------------- VALIDACION DE CAMPOS VACIOS ----------------------------

                foreach (Control control in Controls)
                {
                    if (control is TextBox || control is ComboBox)
                    {
                        if (string.IsNullOrEmpty(control.Text))
                        {

                            MessageBox.Show("Por favor complete todos los campos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }

                }

                // ---------------------------- AGREGAR CLIENTE ----------------------------
                Reserva nuevaReserva = new Reserva()
                {
                    id_reserva = reservaSeleccionada.id_reserva,
                    objCancha = new Cancha { id_cancha = canchaSeleccionada.id_cancha },
                    objHorario = new Horario { id_horario = horarioSeleccionado.id_horario },
                    objCliente = new Cliente { id_cliente = clienteSeleccionado.id_cliente },
                    fechaReserva = fechaSeleccionada,
                    tipo = cmbTipo.Items[cmbTipo.SelectedIndex].ToString(),
                    estado = true

                };

                bool modificarReserva = ReservaControladora.ModificarReserva(nuevaReserva);

                if (modificarReserva == false)
                {
                    MessageBox.Show("Hubo un error al modificar reserva. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Reserva modificada con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void formReservaModificar_FormClosed(object sender, FormClosedEventArgs e)
        {
            formCanchaIndividualC.CargarHorariosCancha();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var mensaje = MessageBox.Show("¿Está seguro que desea eliminar la reserva?", "Eliminar Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.No)
                {
                    return;
                }

                bool eliminarReserva = ReservaControladora.EliminarReserva(reservaSeleccionada.id_reserva);

                if (eliminarReserva == false)
                {
                    MessageBox.Show("Hubo un error al eliminar reserva. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Reserva eliminada con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            } catch
            {

            }
        }
    }
}
