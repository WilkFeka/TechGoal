using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_TorneoEquipos
    {
        public List<TorneoEquipos> Listar()
        {
            List<TorneoEquipos> lista = new List<TorneoEquipos>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM equipos");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new TorneoEquipos()
                                {
                                    id_torneo_equipo = Convert.ToInt32(reader["id_torneo_equipo"]),
                                    id_torneo = Convert.ToInt32(reader["id_torneo"]),
                                    id_equipo = Convert.ToInt32(reader["id_equipo"]),
                                    estado = Convert.ToBoolean(reader["estado"])
                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<TorneoEquipos>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }
    }
}
