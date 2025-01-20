using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Reglas
    {
        public static CC_Reglas instance = null;

        public static CC_Reglas getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Reglas();
                return instance;
            }
        }

        public bool AgregarReglas(Reglas reglas)
        {
            bool resultado = new CD_Reglas().AgregarReglas(reglas);
            return resultado;
        }
    }
}
