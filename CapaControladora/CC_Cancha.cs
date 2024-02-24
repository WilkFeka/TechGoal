using CapaDatos;
using CapaDatos.Seguridad;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Cancha
    {

        public static CC_Cancha instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_Cancha getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Cancha();
                return instance;
            }
        }

        // ---------------------- OBTENER TODAS LAS CANCHAS --------------------

        public List<Cancha> Listar()
        {
            List<Cancha> listaCanchas = new CD_Cancha().Listar();

            return listaCanchas;

        }

        // ---------------------- ENCONTRAR CANCHA POR NUMERO --------------------

        public Cancha EncontrarCanchaNum(int num)
        {

            Cancha buscandoCancha = new CC_Cancha().Listar().Where(c => c.numero == num).FirstOrDefault();

            if (buscandoCancha != null)
            {
                return buscandoCancha;
            }
            else
            {
                return buscandoCancha;
            }


        }

        public bool AgregarCancha(int numero)
        {
            if (numero != 0)
            {
                if (CD_Cancha.AgregarCancha(numero))
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

        public bool AgregarCanchaHorarios(int id_cancha)
        {
            if (id_cancha != 0)
            {
                if (CD_Cancha.AgregarCanchaHorarios(id_cancha))
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

        public bool EliminarCancha(int id)
        {
            if (id != 0)
            {
                if (CD_Cancha.EliminarCancha(id))
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

        public bool EliminarCanchaHorarios(int id_cancha)
        {
            if (CD_Cancha.EliminarCanchaHorarios(id_cancha))
            {
                return true;

            }
            else return false;

        }
    }
}
