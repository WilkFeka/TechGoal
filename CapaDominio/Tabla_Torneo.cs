using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Tabla_Torneo
    {
        public int id_tabla { get; set; }
        public int id_torneo { get; set; }
        public int id_equipo { get; set; }
        public int puntos { get; set; } = 0;
        public int goles_a_favor { get; set; } = 0;
        public int goles_en_contra { get; set; } = 0;
        public int partidos_jugados { get; set; } = 0;
        public int diferencia { get; set; } = 0;
        public int ganados { get; set; } = 0;
        public int empatados { get; set; } = 0;
        public int perdidos { get; set; } = 0;
    }
}
