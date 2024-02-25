using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cancha
    {
        public List<Cancha> Listar()
        {
            List<Cancha> lista = new List<Cancha>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM canchas ORDER BY numero ASC");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Cancha()
                                {
                                    id_cancha = Convert.ToInt32(reader["id_cancha"]),
                                    numero = Convert.ToInt32(reader["numero"]),
                                    estado = Convert.ToBoolean(reader["estado"])
                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Cancha>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }

        public static bool AgregarCancha(int numero)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO canchas (numero) VALUES (@numero)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        cmd.Parameters.AddWithValue("@numero", numero);

                        cmd.ExecuteNonQuery();

                        return true;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool AgregarCanchaHorarios(int id_cancha)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO CanchasHorarios (id_cancha, id_horario, estadoHorario, estado)");
                    query.AppendLine("SELECT c.id_cancha, h.id_horario, h.estado, 1");
                    query.AppendLine("FROM canchas c");
                    query.AppendLine("CROSS JOIN horarios h");
                    query.AppendLine("WHERE c.id_cancha = @id_cancha");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        cmd.Parameters.AddWithValue("@id_cancha", id_cancha);

                        cmd.ExecuteNonQuery();

                        return true;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public static bool EliminarCancha(int id)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("DELETE FROM canchas WHERE id_cancha = @id");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();

                        return true;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool EliminarCanchaHorarios(int id_cancha)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("DELETE FROM CanchasHorarios WHERE id_cancha = @id_cancha");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        cmd.Parameters.AddWithValue("@id_cancha", id_cancha);

                        cmd.ExecuteNonQuery();

                        return true;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
