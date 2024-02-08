using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Seguridad
{
    public class Sesion
    {

        public Usuario Usuario { get; set; }
        private static Sesion sesion;

        private Sesion()
        {
        }

        public static Sesion getInstance
        {
            get
            {
                return sesion;
            }
        }



        public static void IniciarSesion(Usuario usuario)
        {
            if (sesion == null)
            {
                sesion = new Sesion();
            }

            if (sesion.Usuario == null)
            {
                sesion.Usuario = usuario;
            }

            else if (sesion.Usuario.email == usuario.email)
            {
                throw new Exception("Ya hay una sesion iniciada.");
            }
            else
            {
                throw new Exception("Cierre su sesion para poder ingresar con otro usuario.");
            }
        }

        // Cerrar la sesión
        public static void CerrarSesion()
        {
            if (sesion != null)
            {
                sesion = null;
            }
            else
            {
                throw new Exception("No ha sido posible cerrar sesion.");
            }
        }
    }
}
