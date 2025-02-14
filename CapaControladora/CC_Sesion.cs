using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using CapaEntidad.Seguridad;
using CapaDatos;

namespace CapaControladora
{
    public  class CC_Sesion
    {
        private static CC_Sesion instance = null;


        private CC_Sesion() { }

        public static CC_Sesion getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Sesion();
                return instance;
            }
        }

        public Sesion SesionUsuario()
        {
            Sesion sesionActiva = Sesion.getInstance;
            return sesionActiva;
        }

        public void Login(Usuario usuario)
        {
            Sesion.IniciarSesion(usuario);
            CD_Auditoria.RegistrarMovimiento("Sesión iniciada", usuario.id_usuario, "Sesión iniciada con éxito");
        }

        public void Logout(Usuario usuario)
        {
            CD_Auditoria.RegistrarMovimiento("Sesión Cerrada", usuario.id_usuario, "Sesión cerrada con éxito");
            Sesion.CerrarSesion();
        }
    }

}
