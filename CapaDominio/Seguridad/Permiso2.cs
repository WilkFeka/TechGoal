using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Seguridad
{
    public class Permiso2
    {
        //
        //ATRIBUTOS
        //
        private int idPermiso;
        private string nombreMenu;
        private string fechaRegistro;

        //
        //PROPIEDADES
        //
        public int IdPermiso { get; set; }
        public string NombreMenu { get; set; }
        public string FechaRegistro { get; set; }
    }
}
