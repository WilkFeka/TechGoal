using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Equipo
    {
        public int id_equipo { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_agregado { get; set; }

        public string escudo { get; set; }

        public bool estado { get; set; }
    }
}
