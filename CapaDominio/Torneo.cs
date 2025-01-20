using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Torneo
    {
        public int id_torneo { get; set; }
        public string nombre { get; set; }
        public int tipo { get; set; }
        public int cantEquipos { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public bool estado { get; set; }


    }
}
