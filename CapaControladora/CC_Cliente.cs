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

        public bool AgregarCliente(Cliente nuevoCliente)
        {
            bool agregado = new CD_Cliente().AgregarCliente(nuevoCliente);

            return agregado;
        }
    }
}
