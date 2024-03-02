using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Reserva
    {
        public static CC_Reserva instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_Reserva getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Reserva();
                return instance;
            }
        }

        // ---------------------- OBTENER TODAS LAS CANCHAS --------------------

        public List<Reserva> Listar()
        {
            List<Reserva> listaReservas = new CD_Reserva().Listar();

            return listaReservas;

        }

        public Reserva EncontrarReservasCanchaFecha(Cancha cancha, DateTime fecha, Horario horario)
        {
            Reserva reserva = new CC_Reserva().Listar().Where(r => r.fechaReserva == fecha && r.objCancha.id_cancha == cancha.id_cancha && r.objHorario.id_horario == horario.id_horario).FirstOrDefault();

            return reserva;

        }

        public Reserva EncontrarReservaID(int id)
        {
            Reserva buscandoReserva = new CC_Reserva().Listar().Where(r => r.id_reserva == id).FirstOrDefault();

            if (buscandoReserva != null)
            {
                return buscandoReserva;
            }
            else
            {
                return buscandoReserva;
            }

        }

        public bool AgregarReserva(Reserva reserva)
        {
            bool resultado = new CD_Reserva().AgregarReserva(reserva);

            return resultado;
        }

        public bool ModificarReserva(Reserva reserva)
        {
            bool resultado = new CD_Reserva().ModificarReserva(reserva);

            return resultado;
        }

        public bool EliminarReserva(int id)
        {
            bool resultado = new CD_Reserva().EliminarReserva(id);

            return resultado;
        }


    }
}
