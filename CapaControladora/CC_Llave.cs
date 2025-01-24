using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Llave
    {
        public static CC_Llave instance = null;

        public static CC_Llave getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Llave();
                return instance;
            }
        }

        public List<Llave> Listar()
        {
            List<Llave> listaLlaves = new CD_Llave().Listar();

            return listaLlaves;

        }

        public bool AgregarLlave(Llave llave)
        {
            bool resultado = new CD_Llave().AgregarLlave(llave);
            return resultado;
        }




    }
}
