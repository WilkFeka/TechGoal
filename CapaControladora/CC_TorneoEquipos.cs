using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_TorneoEquipos
    {
        public static CC_TorneoEquipos instance = null;

        // -------------------- SINGLETON ---------------------

        public static CC_TorneoEquipos getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_TorneoEquipos();
                return instance;
            }
        }

        // ---------------------- OBTENER TODAS LAS CANCHAS --------------------

        public List<TorneoEquipos> Listar()
        {
            List<TorneoEquipos> listaTorneoEquipos = new CD_TorneoEquipos().Listar();

            return listaTorneoEquipos;

        }

        public bool AgregarTorneoEquipo(TorneoEquipos TE)
        {
            bool resultado = new CD_TorneoEquipos().AgregarTorneoEquipo(TE);
            return resultado;
        }

        public bool BorrarVinculaciones(int id_torneo)
        {
            bool resultado = new CD_TorneoEquipos().BorrarVinculaciones(id_torneo);
            return resultado;
        }
    }
}
