using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Personalizacion
{
    public  class Funcionalidades
    {
        private static Funcionalidades instancia = null;

        private Funcionalidades()
        {
        }
        public static Funcionalidades Instanciar
        {

            // -------------------- SINGLETON ---------------------
            get
            {
                if (instancia == null)
                {
                    instancia = new Funcionalidades();
                }
                return instancia;
            }
        }

        


    }
}
