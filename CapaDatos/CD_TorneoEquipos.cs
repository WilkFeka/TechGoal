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

        public bool AgregarTorneoEquipo(TorneoEquipos TE)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO torneos_equipos (id_torneo, id_equipo, estado)");
                    query.AppendLine("VALUES (@id_torneo, @id_equipo, @estado)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_torneo", TE.id_torneo);
                        cmd.Parameters.AddWithValue("@id_equipo", TE.id_equipo);
                        cmd.Parameters.AddWithValue("@estado", TE.estado);

                        conection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            agregado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return agregado;


        }

        public bool BorrarVinculaciones(int id_torneo)
        {
            bool borrado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("UPDATE torneos_equipos set estado = 0 WHERE id_torneo = @id_torneo");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_torneo", id_torneo);

                        conection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            borrado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return borrado;
        }
    }
}
