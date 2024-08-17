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

        public List<Jugador> Listar()
        {
            List<Jugador> listaJugadores = new CD_Jugador().Listar();

            return listaJugadores;

        }

        public Jugador EncontrarJugadorID(int id)
        {

            Jugador buscandoJugadorID = new CC_Jugador().Listar().Where(c => c.id_jugador == id).FirstOrDefault();

            if (buscandoJugadorID != null)
            {
                return buscandoJugadorID;
            }
            else
            {
                return buscandoJugadorID;
            }
        }

        public List<Jugador> EncontrarJugadoresEquipo(int id)
        {

            List<Jugador> buscandoJugadores = new CC_Jugador().Listar().Where(c => c.id_equipo == id).ToList();

            if (buscandoJugadores != null)
            {
                return buscandoJugadores;
            }
            else
            {
                return buscandoJugadores;
            }
        }

        public bool EliminarJugadoresEquipo(int id_equipo)
        {
            bool eliminado = new CD_Jugador().EliminarJugadoresEquipo(id_equipo);

            return eliminado;
        }




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

    }
}
