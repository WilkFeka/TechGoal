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

namespace CapaPresentacion.Formularios.Clientes
{
    public partial class formClientesModificar : Form
    {
        Cliente clienteSeleccionado;
        formClientes formClientesC;
        CC_Cliente ClienteControladora = CC_Cliente.getInstance;

        public formClientesModificar(formClientes formClientes, Cliente cliente)
        {
            InitializeComponent();
            clienteSeleccionado = cliente;
            formClientesC = formClientes;

        }

        private void formClientesModificar_Load(object sender, EventArgs e)
        {
            txtNombre.Text = clienteSeleccionado.nombre;
            txtApellido.Text = clienteSeleccionado.apellido;
            txtDocumento.Text = clienteSeleccionado.dni;
            txtTelefono.Text = clienteSeleccionado.telefono;
            txtEstado.Text = clienteSeleccionado.estado ? "Activo" : "Inactivo";

            btnSwitch.BackgroundImage = clienteSeleccionado.estado ? Properties.Resources.Active : Properties.Resources.Inactive;
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            btnSwitch.BackgroundImage = txtEstado.Text == "Activo" ? Properties.Resources.Inactive : Properties.Resources.Active;

            txtEstado.Text = txtEstado.Text == "Activo" ? "Inactivo" : "Activo";
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


                Cliente buscarCliente = ClienteControladora.EncontrarClienteDNI(txtDocumento.Text);

                if(buscarCliente != null && buscarCliente.dni != clienteSeleccionado.dni)
                {
                    MessageBox.Show("Ya existe un cliente con ese DNI.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                var mensaje = MessageBox.Show("¿Esta seguro de que desea modificar al cliente " + clienteSeleccionado.nombre + "?", "Modificando usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == DialogResult.No)
                {
                    return;
                }

                bool estado = txtEstado.Text == "Activo" ? true : false;

                Cliente clienteModificar = new Cliente()
                {
                    id_cliente = clienteSeleccionado.id_cliente,
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    dni = txtDocumento.Text,
                    telefono = txtTelefono.Text,
                    estado = estado
                };

                 bool modificarCliente = ClienteControladora.ModificarCliente(clienteModificar);

                if (modificarCliente == false)
                {
                    MessageBox.Show("Hubo un error al modificar cliente. Por favor consulte con un administrador.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Cliente modificado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            catch (Exception error)
            {

                MessageBox.Show($"{error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void formClientesModificar_FormClosed(object sender, FormClosedEventArgs e)
        {
            formClientesC.llenarTabla();
        }
    }
}
