using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Llave
    {
        public int id_llave { get; set; } // Identificador único de la llave
        public string instancia { get; set; } // Fase o instancia del torneo (ej. "Cuartos de Final", "Semifinal", etc.)
        public int id_torneo { get; set; } // Identificador del torneo al que pertenece la llave
        public int id_local { get; set; } // ID del equipo local
        public int id_visitante { get; set; } // ID del equipo visitante
        public int? golesL { get; set; } // Goles del equipo local (nullable)
        public int? golesV { get; set; } // Goles del equipo visitante (nullable)
        public int? ganador { get; set; } // ID del equipo ganador (nullable)
    }
}
