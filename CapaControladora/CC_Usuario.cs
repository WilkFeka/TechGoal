using CapaDatos.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaControladora
{
    public class CC_Usuario
    {
        public static CC_Usuario instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_Usuario getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Usuario();
                return instance;
            }
        }

        // ---------------------- OBTENER TODOS LOS USUARIOS --------------------

        public List<Usuario> Listar()
        {
            List<Usuario> listaUsuarios = new CD_Usuario().Listar();

            return listaUsuarios;
            
        }

        // ---------------------- ENCONTRAR USUARIO EN LA LISTA POR CREDENCIALES OBTENIDAS--------------------

        public bool EncontrarUsuario (string txtCorreo, string txtClave)
        {
            //Filtrar usuarios por email y clave proporcionados
            Usuario usuarioIniciando = new CC_Usuario().Listar().Where(u => u.email == txtCorreo && u.clave == txtClave).FirstOrDefault();

            if (usuarioIniciando != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


    }
}
