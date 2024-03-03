using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Formularios.Canchas;
using CapaPresentacion.Formularios.Clientes;
using CapaPresentacion.Personalizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Reservas
{
    public partial class formReservaNueva : Form
    {
        Cancha canchaSeleccionada;
        Horario horarioSeleccionado;
        DateTime fechaSeleccionada;

        Funcionalidades funcionalidades = Funcionalidades.getInstance;  
        CC_Cliente ClienteControladora = CC_Cliente.getInstance;
        CC_Reserva ReservaControladora = CC_Reserva.getInstance;
        Cliente clienteSeleccionado;
        formCanchaIndividual formCanchaIndividualC;
        private int paginaActual = 1;
        private int registrosPorPagina = 15;


        bool clientesAbierto = false;
        public formReservaNueva(Cancha cancha, DateTime fecha, Horario horario, formCanchaIndividual formCanchaIndividual)
        {
            InitializeComponent();
            canchaSeleccionada = cancha;
            fechaSeleccionada = fecha;
            horarioSeleccionado = horario;
            formCanchaIndividualC = formCanchaIndividual;
            Size = new Size(551,576);

        }

        private void Reserva___Nueva_Load(object sender, EventArgs e)
        {
            
            txtCancha.Text = canchaSeleccionada.numero.ToString();
            txtFecha.Text = fechaSeleccionada.ToShortDateString();
            txtHorario.Text = horarioSeleccionado.hora.ToString();
            llenarTabla();
        }

        private void btnElegirCliente_Click(object sender, EventArgs e)
        {
           if (clientesAbierto == false) {
                AbrirClientes();
            }
           

        }

        public void llenarTabla()
        {
            clientesTableAdapter.Fill(dB_TECHGOALDataSet1.clientes);

            MostrarPagina(paginaActual);



        }

        private void MostrarPagina(int numeroPagina)
        {
            int primerRegistro = (numeroPagina - 1) * registrosPorPagina;

            clientesBindingSource.DataSource = dB_TECHGOALDataSet1.clientes
                .AsEnumerable()
                .Skip(primerRegistro)
                .Take(registrosPorPagina)
                .CopyToDataTable();

            bindingNavigatorCountItem.Text = $"Página {numeroPagina}";
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
            clientesBindingSource.DataSource = dB_TECHGOALDataSet1.clientes;
            clientesTableAdapter.Fill(dB_TECHGOALDataSet1.clientes);

            string filtro = $"nombre LIKE '%{txtNombreFilter.Text}%' AND apellido LIKE '%{txtApellidoFilter.Text}%' AND dni LIKE '%{txtDocumentoFilter.Text}%' AND estado = 1";

            clientesBindingSource.Filter = filtro;
        }

        private void txtDocumentoFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);
        }

        private void txtApellidoFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);
        }

        private void txtNombreFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloLetras(sender, e);

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

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            formClientesAgregar formClientesAgregar = new formClientesAgregar(this);
            formClientesAgregar.ShowDialog();
        }


        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnOkay_Click(sender, e);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPagina(paginaActual);
                bindingNavigatorMoveNextItem.Enabled = true;
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            paginaActual++;
            MostrarPagina(paginaActual);
            bindingNavigatorMoveNextItem.Enabled = (paginaActual * registrosPorPagina) < dB_TECHGOALDataSet1.clientes.Rows.Count;
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
                    objCancha = new Cancha { id_cancha = canchaSeleccionada.id_cancha },
                    objHorario = new Horario { id_horario = horarioSeleccionado.id_horario },
                    objCliente = new Cliente { id_cliente = clienteSeleccionado.id_cliente },
                    fechaReserva = fechaSeleccionada,
                    tipo = cmbTipo.Items[cmbTipo.SelectedIndex].ToString(),
                    estado = true

                };

                bool agregarReserva = ReservaControladora.AgregarReserva(nuevaReserva);

                if (agregarReserva == false)
                {
                    MessageBox.Show("Hubo un error al agregar reserva. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Reserva agregada con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void formReservaNueva_FormClosed(object sender, FormClosedEventArgs e)
        {
            formCanchaIndividualC.CargarHorariosCancha();
        }
    }
}
