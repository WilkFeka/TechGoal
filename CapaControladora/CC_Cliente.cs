using CapaDatos;
using CapaDatos.Seguridad;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Cliente
    {
        public static CC_Cliente instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_Cliente getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Cliente();
                return instance;
            }
        }

        // ---------------------- OBTENER TODOS LOS USUARIOS --------------------

        public List<Cliente> Listar()
        {
            List<Cliente> listaClientes = new CD_Cliente().Listar();

            return listaClientes;

        }

        public Cliente EncontrarClienteDNI(string txtDNI)
        {

            Cliente buscandoCliente = new CC_Cliente().Listar().Where(c => c.dni == txtDNI).FirstOrDefault();

            if (buscandoCliente != null)
            {
                return buscandoCliente;
            }
            else
            {
                return buscandoCliente;
            }


        }

        public Cliente EncontrarClienteID(int id)
        {

            Cliente buscandoCliente = new CC_Cliente().Listar().Where(c => c.id_cliente == id).FirstOrDefault();

            if (buscandoCliente != null)
            {
                return buscandoCliente;
            }
            else
            {
                return buscandoCliente;
            }


        }



        public bool AgregarCliente(Cliente nuevoCliente)
        {
            bool agregado = new CD_Cliente().AgregarCliente(nuevoCliente);

            return agregado;
        }

        public bool ModificarCliente(Cliente clienteModificar)
        {
            bool modificado = new CD_Cliente().ModificarCliente(clienteModificar);

            return modificado;
        }

        public bool ModificarEstadoCliente(int id, bool estado)
        {
            bool modificado = new CD_Cliente().ModificarEstadoCliente(id, estado);

            return modificado;
        }

        public bool EliminarCliente(int id)
        {
            bool eliminado = new CD_Cliente().EliminarCliente(id);

            return eliminado;
        }
    }
}
