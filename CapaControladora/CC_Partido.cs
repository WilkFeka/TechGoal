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
            return new CD_Partido().ActualizarPartido(partido);
        }

        public int ObtenerMaxIdPartido(int idTorneo, string instancia)
        {
            var partidos = new CC_Partido().Listar().Where(p => p.id_torneo == idTorneo && p.instancia == instancia);
            return partidos.Any() ? partidos.Max(p => p.id_partido) : 0;
        }

        public Partido ObtenerPartidoID(int id_sig_partido)
        {
            return new CC_Partido().Listar().FirstOrDefault(p => p.id_sig_partido == id_sig_partido);
        }

        public Partido ObtenerPartidoEsperandoRival(int idTorneo, string instancia)
        {
            return new CC_Partido().Listar()
                .FirstOrDefault(p => p.id_torneo == idTorneo
                                     && p.instancia == instancia
                                     && (p.id_local == null || p.id_visitante == null)); // Ahora busca si hay espacio libre
        }
        public int ContarPartidosEnInstancia(int idTorneo, string instancia)
        {
            return new CC_Partido().Listar().Count(p => p.id_torneo == idTorneo && p.instancia == instancia);
        }
        public List<Partido> ObtenerPartidosPorInstancia(int idTorneo, string instancia)
        {
            return new CC_Partido().Listar().Where(p => p.id_torneo == idTorneo && p.instancia == instancia).ToList();
        }


    }
}
