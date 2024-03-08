using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Modulo
    {
        public static CC_Modulo instance = null;

        // -------------------- SINGLETON ---------------------

        public static CC_Modulo getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Modulo();
                return instance;
            }
        }
        public List<Modulo> Listar()
        {
            List<Modulo> listaModulos = new CD_Modulo().Listar();

            return listaModulos;

        }

       
    }
}
