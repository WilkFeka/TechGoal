using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Partido
    {
        public List<Partido> Listar()
        {
            List<Partido> lista = new List<Partido>();

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

                                lista.Add(new Partido()
                                {
                                    id_partido = Convert.ToInt32(reader["id_partido"]),
                                    instancia = reader["instancia"].ToString(),
                                    id_torneo = Convert.ToInt32(reader["id_torneo"]),
                                    id_local = reader["id_local"] != DBNull.Value ? Convert.ToInt32(reader["id_local"]) : (int?)null,
                                    id_visitante = reader["id_visitante"] != DBNull.Value ? Convert.ToInt32(reader["id_visitante"]) : (int?)null,
                                    golesL = reader["golesL"] != DBNull.Value ? Convert.ToInt32(reader["golesL"]) : 0,
                                    golesV = reader["golesV"] != DBNull.Value ? Convert.ToInt32(reader["golesV"]) : 0,
                                    ganador = reader["ganador"] != DBNull.Value ? Convert.ToInt32(reader["ganador"]) : (int?)null,
                                    finalizado = Convert.ToBoolean(reader["finalizado"]),
                                    id_sig_partido = reader["id_sig_partido"] != DBNull.Value ? Convert.ToInt32(reader["id_sig_partido"]) : (int?)null,

                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Partido>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }

        public bool AgregarPartido(Partido partido)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO Partidos (instancia, id_torneo, id_local, id_visitante) ");
                    query.AppendLine("VALUES (@instancia, @id_torneo, @id_local, @id_visitante)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@instancia", partido.instancia);
                        cmd.Parameters.AddWithValue("@id_torneo", partido.id_torneo);
                        cmd.Parameters.AddWithValue("@id_local", partido.id_local);
                        if (partido.id_visitante == null)
                        {
                            cmd.Parameters.AddWithValue("@id_visitante", DBNull.Value); // Insertar NULL si es necesario
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@id_visitante", partido.id_visitante); // Si no es nulo, insertar el valor
                        }


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

        public bool ActualizarPartido(Partido partido)
        {
            bool actualizado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("UPDATE Partidos SET golesL = @golesL, golesV = @golesV, ganador = @ganador, finalizado = @finalizado, id_sig_partido =  @id_sig_partido, ");
                    query.AppendLine("id_local = @id_local, id_visitante = @id_visitante ");
                    query.AppendLine("WHERE id_partido = @id_partido");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@golesL", partido.golesL ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@golesV", partido.golesV ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@finalizado", partido.finalizado);
                        cmd.Parameters.AddWithValue("@ganador", partido.ganador ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@id_partido", partido.id_partido);
                        cmd.Parameters.AddWithValue("@id_sig_partido", partido.id_sig_partido ?? (object)DBNull.Value);

                        cmd.Parameters.AddWithValue("@id_local", partido.id_local ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@id_visitante", partido.id_visitante ?? (object)DBNull.Value);



                        conection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            actualizado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return actualizado;
        }
    }
}
