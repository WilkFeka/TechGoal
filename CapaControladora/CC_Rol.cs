using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> listaRoles = new CD_Rol().Listar();

            return listaRoles;

        }

    }
}
