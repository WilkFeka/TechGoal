using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Torneos
    {
        public static CC_Torneos instance = null;

        public static CC_Torneos getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Torneos();
                return instance;
            }
        }

        public List<Torneo> Listar()
        {
            List<Torneo> listaTorneos = new CD_Torneos().Listar();

            return listaTorneos;

        }

        public Torneo EncontrarTorneoNombre(string nombre)
        {

            Torneo buscandoTorneoNombre = new CC_Torneos().Listar().Where(c => c.nombre == nombre && c.borrado == false).FirstOrDefault();

            if (buscandoTorneoNombre != null)
            {
                return buscandoTorneoNombre;
            }
            else
            {
                return buscandoTorneoNombre;
            }
        }

        public Torneo EncontrarTorneoID(int id)
        {

            Torneo buscandoTorneoID = new CC_Torneos().Listar().Where(c => c.id_torneo == id).FirstOrDefault();

            if (buscandoTorneoID != null)
            {
                return buscandoTorneoID;
            }
            else
            {
                return buscandoTorneoID;
            }
        }

        public bool AgregarTorneo(Torneo torneo)
        {
            bool resultado = new CD_Torneos().AgregarTorneo(torneo);
            return resultado;
        }

        public bool BorrarTorneo(int id_torneo)
        {
            bool resultado = new CD_Torneos().BorrarTorneo(id_torneo);
            return resultado;
        }
    }
}
