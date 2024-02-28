using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_CanchaHorario
    {
        public static CC_CanchaHorario instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_CanchaHorario getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_CanchaHorario();
                return instance;
            }
        }

        // ---------------------- OBTENER TODAS LAS CANCHAS --------------------

        public List<CanchaHorario> Listar()
        {
            List<CanchaHorario> listaCanchaHorario = new CD_CanchaHorario().Listar();

            return listaCanchaHorario;

        }


    }
}
