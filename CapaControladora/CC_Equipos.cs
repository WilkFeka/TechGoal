using CapaDatos;
using CapaDatos.Seguridad;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Seguridad;


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

            Equipo buscandoEquipoNombre = new CC_Equipos().Listar().Where(c => c.nombre == nombre && c.borrado == false).FirstOrDefault();

            if (buscandoEquipoNombre != null)
            {
                return buscandoEquipoNombre;
            }
            else
            {
                return buscandoEquipoNombre;
            }
        }

        public Equipo EncontrarEquipoID(int id)
        {

            Equipo buscandoEquipoID = new CC_Equipos().Listar().Where(c => c.id_equipo == id).FirstOrDefault();

            if (buscandoEquipoID != null)
            {
                return buscandoEquipoID;
            }
            else
            {
                return buscandoEquipoID;
            }
        }

        public bool AgregarEquipo(Equipo equipo)
        {
            bool resultado = new CD_Equipos().AgregarEquipo(equipo);
            if (resultado)
            {
                Equipo equipoC = new CC_Equipos().EncontrarEquipoNombre(equipo.nombre);
                CD_Auditoria.RegistrarMovimientoEquipo(Sesion.sesion.Usuario.id_usuario, equipoC.id_equipo, "Agregar", "Se agregó el equipo " + equipo.nombre);
            }

            return resultado;
        }

        public bool EliminarEquipo(Equipo equipo)
        {
            bool resultado = new CD_Equipos().EliminarEquipo(equipo.id_equipo);
            if (resultado )
            {

                CD_Auditoria.RegistrarMovimientoEquipo(Sesion.sesion.Usuario.id_usuario, equipo.id_equipo, "Eliminar", "Se elimino el equipo " + equipo.nombre);
            }

            return resultado;
        }

        public bool ModificarEquipo(Equipo equipo)
        {
            bool resultado = new CD_Equipos().ModificarEquipo(equipo);
            if (resultado)
            {

                CD_Auditoria.RegistrarMovimientoEquipo(Sesion.sesion.Usuario.id_usuario, equipo.id_equipo, "Modificar", "Se modifico el equipo " + equipo.nombre);
            }
            return resultado;
        }

        public List<Equipo> EncontrarEquiposLibres()
        {

            List<Equipo> buscandoEquiposLibres = new CD_Equipos().EquiposLibres();
            return buscandoEquiposLibres;
           
        }

        public List<Dictionary<string, object>> ObtenerEstadisticasEquipo(int idEquipo)
        {
            List<Dictionary<string, object>> lista = new CD_Equipos().ObtenerEstadisticasEquipo(idEquipo);  
            return lista;

        }

        public List<Equipo> ListarEquiposActivosFiltrados(string filtro)
        {
            List<Equipo> listaEquipos = new CD_Equipos().ListarEquiposActivosFiltrados(filtro);
            return listaEquipos;

        }



    }
}
