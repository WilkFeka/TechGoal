using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Partido
    {
        public static CC_Partido instance = null;

        public static CC_Partido getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Partido();
                return instance;
            }
        }

        public List<Partido> Listar()
        {
            List<Partido> listaLlaves = new CD_Partido().Listar();

            return listaLlaves;

        }

        public bool AgregarPartido(Partido partido)
        {
            bool resultado = new CD_Partido().AgregarPartido(partido);
            return resultado;
        }




    }
}
