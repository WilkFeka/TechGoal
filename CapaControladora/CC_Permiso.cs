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

        // ---------------------- OBTENER TODOS LOS PERMISOS --------------------

        public List<Permiso> Listar(int id_usuario)
        {
            List<Permiso> listaPermisos = new CD_Permiso().Listar(id_usuario);

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



    }
}
