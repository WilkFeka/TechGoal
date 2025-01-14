using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TorneoEquipos
    {
        public int id_torneo { get; set; }
        public int id_equipo { get; set; }
        public int id_torneo_equipo { get; set; }
        public bool estado { get; set; }
    }
}
