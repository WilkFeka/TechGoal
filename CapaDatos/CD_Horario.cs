using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Horario
    {

        public List<Horario> Listar()
        {
            List<Horario> lista = new List<Horario>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM horarios");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Horario()
                                {
                                    id_horario = Convert.ToInt32(reader["id_horario"]),
                                    hora = Convert.ToInt32(reader["hora"]),
                                    estado = Convert.ToBoolean(reader["estado"])
                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Horario>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }

        public static bool ActualizarHorarios(List<Horario> listaHorarios)
        {
            bool result = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    conection.Open();

                    foreach (var horario in listaHorarios)
                    {
                        StringBuilder query = new StringBuilder();

                        query.AppendLine("UPDATE horarios SET estado = @estado WHERE id_horario = @id_horario");

                        using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                        {
                            cmd.Parameters.AddWithValue("@estado", horario.estado);
                            cmd.Parameters.AddWithValue("@id_horario", horario.id_horario);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
