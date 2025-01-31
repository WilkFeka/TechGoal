using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Tabla_Torneo
    {
        public static CC_Tabla_Torneo instance = null;

        public static CC_Tabla_Torneo getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Tabla_Torneo();
                return instance;
            }
        }

        public List<Tabla_Torneo> Listar()
        {
            List<Tabla_Torneo> listaTablas = new CD_Tabla_Torneo().Listar();

            return listaTablas;

        }

        public bool AgregarEquipoTabla(Tabla_Torneo tabla_torneo)
        {
            bool resultado = new CD_Tabla_Torneo().AgregarEquipoTabla(tabla_torneo);
            return resultado;
        }

        public Tabla_Torneo EncontrarTablaTorneo(int id_equipo, int id_torneo)
        {
            Tabla_Torneo buscandoEquipo = new CC_Tabla_Torneo().Listar().Where(c => c.id_equipo == id_equipo && c.id_torneo == id_torneo).FirstOrDefault();

            if (buscandoEquipo != null)
            {
                return buscandoEquipo;
            }
            else
            {
                return buscandoEquipo;
            }

        }

        public bool ActualizarTablaTorneo(Tabla_Torneo tabla_torneo)
        {
            bool resultado = new CD_Tabla_Torneo().ActualizarTablaTorneo(tabla_torneo);
            return resultado;
        }

    }
}
