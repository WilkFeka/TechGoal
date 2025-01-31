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
            List<Partido> listaPartidos = new CD_Partido().Listar();

            return listaPartidos;

        }

        public bool AgregarPartido(Partido partido)
        {
            bool resultado = new CD_Partido().AgregarPartido(partido);
            return resultado;
        }

        public List<Partido> EncontrarPartidosTorneo(int torneoID)
        {
            List<Partido> listaPartidos = new CC_Partido().Listar().Where(u => u.id_torneo == torneoID).ToList();

            return listaPartidos;

        }

        public bool ActualizarPartido(Partido partido)
        {
            bool resultado = new CD_Partido().ActualizarPartido(partido);
            return resultado;
        }



    }
}
