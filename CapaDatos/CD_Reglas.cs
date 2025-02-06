using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reglas
    {
        public bool AgregarReglas(Reglas reglas)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO reglas (id_torneo, reglas) ");
                    query.AppendLine("VALUES (@id_torneo, @reglas)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_torneo", reglas.id_torneo);
                        cmd.Parameters.AddWithValue("@reglas", reglas.reglas);


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

        public List<Reglas> Listar()
        {
            List<Reglas> lista = new List<Reglas>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM reglas");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Reglas()
                                {
                                    id_reglas = Convert.ToInt32(reader["id_reglas"]),
                                    id_torneo = Convert.ToInt32(reader["id_torneo"]),
                                    reglas = Convert.ToString(reader["reglas"]),


                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Reglas>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }
    }

}
