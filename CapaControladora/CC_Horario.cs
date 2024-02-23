using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Horario
    {

        public static CC_Horario instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_Horario getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Horario();
                return instance;
            }
        }

        // ---------------------- OBTENER TODOS LOS HORARIOS --------------------

        public List<Horario> Listar()
        {
            List<Horario> listaHorarios = new CD_Horario().Listar();

            return listaHorarios;

        }

        public bool ActualizarHorarios(List<Horario> listaHorarios)
        {
            if (listaHorarios != null)
            {
                if (CD_Horario.ActualizarHorarios(listaHorarios))
                {
                    return true;

                }
                else return false;

            }
            else
            {
                return false;
            }

        }


    }
}
