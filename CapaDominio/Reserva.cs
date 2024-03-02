using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Reserva
    {
        public int id_reserva { get; set; }
        public Cancha objCancha { get; set; }
        public Horario objHorario { get; set; }
        public Cliente objCliente { get; set; }

        public DateTime fechaReserva { get; set; }

        public string tipo { get; set; }
        public bool estado { get; set; }

        public string fechaRegistro { get; set; }

    }
}
