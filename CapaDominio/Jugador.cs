using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Jugador
    {
        public int id_jugador { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dorsal { get; set; }
        public int id_equipo { get; set;}
    }
}
