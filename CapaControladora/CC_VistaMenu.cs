using CapaDatos;
using CapaDatos.Seguridad;
using CapaEntidad;
using CapaEntidad.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_VistaMenu
    {
        public static CC_VistaMenu instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_VistaMenu getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_VistaMenu();
                return instance;
            }
        }

        public List<VistaMenu> Listar()
        {
            List<VistaMenu> listaMenus = new CD_VistaMenu().Listar();

            return listaMenus;

        }

    }
}
