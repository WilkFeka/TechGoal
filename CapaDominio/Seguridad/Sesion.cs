using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Seguridad
{
    internal class Sesion
    {

        public Usuario Usuario { get; set; }

        private Sesion()
        {
        }

        public static Sesion obtenerSesion
        {
            get
            {
                return sesion;
            }
        }

        private static Sesion sesion;


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
                throw new Exception("Ya se ha iniciado sesion.");
            }
            else
            {
                throw new Exception("Cierre la sesion para poder ingresar con un nuevo usauario.");
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
                throw new Exception("No hay sesión iniciada.");
            }
        }
    }
}
