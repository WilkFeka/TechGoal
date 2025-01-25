using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Tabla_Torneo
    {
        public List<Tabla_Torneo> Listar()
        {
            List<Tabla_Torneo> lista = new List<Tabla_Torneo>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM Partidos");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Tabla_Torneo()
                                {
                                    id_tabla = Convert.ToInt32(reader["id_tabla"]),
                                    id_torneo = Convert.ToInt32(reader["id_torneo"]),
                                    id_equipo = Convert.ToInt32(reader["id_equipo"]),
                                    puntos = Convert.ToInt32(reader["puntos"]),
                                    goles_a_favor = Convert.ToInt32(reader["goles_a_favor"]),
                                    goles_en_contra = Convert.ToInt32(reader["goles_en_contra"]),
                                    partidos_jugados = Convert.ToInt32(reader["partidos_jugados"]),
                                    diferencia = Convert.ToInt32(reader["diferencia"]),
                                    ganados = Convert.ToInt32(reader["ganados"]),
                                    empatados = Convert.ToInt32(reader["empatados"]),
                                    perdidos = Convert.ToInt32(reader["perdidos"]),

                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Tabla_Torneo>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }

        public bool AgregarEquipoTabla(Tabla_Torneo tabla_torneo)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO Tablas_Torneos (id_torneo, id_equipo)");
                    query.AppendLine("VALUES (@id_torneo, @id_equipo)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_torneo", tabla_torneo.id_torneo);
                        cmd.Parameters.AddWithValue("@id_equipo", tabla_torneo.id_equipo);

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
    }
}
