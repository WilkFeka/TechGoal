using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos.Seguridad;
using CapaDatos;

namespace CapaControladora
{
    public class CC_Permiso
    {

        public static CC_Permiso instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_Permiso getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Permiso();
                return instance;
            }
        }

        // ---------------------- OBTENER TODOS LOS PERMISOS DE UN USUARIO  --------------------

        public List<Permiso> ListarPermisosUsuario(int id_usuario)
        {
            List<Permiso> listaPermisos = new CD_Permiso().ListarPermisosUsuario(id_usuario);

            return listaPermisos;

        }

        // ---------------------- OBTENER TODOS LOS PERMISOS  --------------------
        public List<Permiso> Listar()
        {
            List<Permiso> listaPermisos = new CD_Permiso().Listar();

            return listaPermisos;

        }

        // ---------------------- AGREGAR NUEVO ROL --------------------

        public bool AgregarPermiso(Permiso nuevoPermiso)
        {
            if (nuevoPermiso != null)
            {
                if (CD_Permiso.AgregarPermiso(nuevoPermiso))
                {
                    return true;

                }
                else return false;
            }
            else return false;
        }

        public List<Permiso> BuscarPermisoID_Rol(int id_rol)
        {
            List<Permiso> listaPermisos = new CC_Permiso().Listar().Where(r => r.obj_rol.id_rol == id_rol).ToList();

            return listaPermisos;

        }

        public bool EliminarPermiso(int id_rol)
        {
            if (CD_Permiso.EliminarPermiso(id_rol))
            {
                return true;
            }
            else return false;
        }



    }
}
