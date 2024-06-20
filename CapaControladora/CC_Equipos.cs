using CapaDatos;
using CapaDatos.Seguridad;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Equipos
    {
        public static CC_Equipos instance = null;

        public static CC_Equipos getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Equipos();
                return instance;
            }
        }

        public List<Equipo> Listar()
       {
            List<Equipo> listaEquipos = new CD_Equipos().Listar();

            return listaEquipos;

        }

        public DataTable CargarTablaEquipos(DataTable tablaEquiposP, string nombreP, string torneoP, string estadoP)
        {
            tablaEquiposP = new CD_Equipos().CargarTablaEquipos(tablaEquiposP, nombreP, torneoP, estadoP);
            return tablaEquiposP;

        }

       public Equipo EncontrarEquipoNombre(string nombre)
        {

            Equipo buscandoEquipoNombre = new CC_Equipos().Listar().Where(c => c.nombre == nombre).FirstOrDefault();

            if (buscandoEquipoNombre != null)
            {
                return buscandoEquipoNombre;
            }
            else
            {
                return buscandoEquipoNombre;
            }
        }

        public bool AgregarEquipo(Equipo equipo)
        {
            bool resultado = new CD_Equipos().AgregarEquipo(equipo);
            return resultado;
        }
    }
}
