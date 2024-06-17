using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Equipos
    {
        public DataTable CargarTablaEquipos(DataTable tablaEquiposP, string nombreP, string torneoP, string estadoP)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT equipos.id_equipo, equipos.nombre, equipos.fecha_agregado, equipos.escudo, torneos.id_torneo, torneos.nombre AS nombre_torneo , equipos.estado  ");
                    query.AppendLine("FROM equipos ");
                    query.AppendLine("LEFT JOIN torneos_equipos ON equipos.id_equipo = torneos_equipos.id_equipo ");
                    query.AppendLine("LEFT JOIN torneos ON torneos_equipos.id_torneo = torneos.id_torneo ");
                    query.AppendLine("WHERE equipos.nombre LIKE @nombreP AND (torneos.nombre IS NULL OR torneos.nombre LIKE @torneoP) AND equipos.estado LIKE @estadoP");






                    SqlDataAdapter adapter;


                    using (adapter = new SqlDataAdapter(query.ToString(), conection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@nombreP", "%" + nombreP + "%");
                        adapter.SelectCommand.Parameters.AddWithValue("@estadoP", "%" + estadoP + "%");
                        adapter.SelectCommand.Parameters.AddWithValue("@torneoP", "%" + torneoP + "%");




                        adapter.Fill(tablaEquiposP);
                        return tablaEquiposP;

                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tablaEquiposP;

            }
        }
    }
}
