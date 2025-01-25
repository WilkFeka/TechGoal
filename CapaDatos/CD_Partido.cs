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
                                    id_torneo = Convert.ToInt32(reader["id_torneo"]),
                                    instancia = Convert.ToString(reader["instancia"]),
                                    id_local = Convert.ToInt32(reader["id_local"]),
                                    id_visitante = Convert.ToInt32(reader["id_visitante"]),
                                    golesL = Convert.ToInt32(reader["golesL"]),
                                    golesV = Convert.ToInt32(reader["golesV"]),
                                    ganador = Convert.ToInt32(reader["golesV"]),

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
    }
}
