using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Jugador
    {
        public static CC_Jugador instance = null;

        public static CC_Jugador getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Jugador();
                return instance;
            }
        }

        public bool AgregarJugador(Jugador nuevoJugador)
        {
            bool agregado = new CD_Jugador().AgregarJugador(nuevoJugador);

            return agregado;
        }

        //public List<Jugador> Listar()
        //{
        //    List<Jugador> listaJugadores = new CD_Jugador().Listar();

        //    return listaJugadores;

        //}

        //public Jugador EncontrarJugadorNombre(string nombre)
        //{

        //    Jugador buscandoJugadorNombre = new CC_Jugador().Listar().Where(c => c.nombre == nombre).FirstOrDefault();

        //    if (buscandoJugadorNombre != null)
        //    {
        //        return buscandoJugadorNombre;
        //    }
        //    else
        //    {
        //        return buscandoJugadorNombre;
        //    }
        //}

        //public bool AgregarJugador(Jugador jugador)
        //{
        //    bool resultado = new CD_Jugador().AgregarJugador(jugador);
        //    return resultado;
        //}
    }
}
