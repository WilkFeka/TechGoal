using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Torneos
    {

        public List<Torneo> Listar()
        {
            List<Torneo> lista = new List<Torneo>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM torneos");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Torneo()
                                {
                                    id_torneo = Convert.ToInt32(reader["id_equipo"]),
                                    nombre = Convert.ToString(reader["nombre"]),
                                    cantEquipos = Convert.ToInt32(reader["cantEquipos"]),
                                    fechaFinal = DateTime.Parse(Convert.ToString(reader["fechaInicio"])),
                                    fechaInicio = DateTime.Parse(Convert.ToString(reader["fechaFinal"])),
                                    estado = Convert.ToBoolean(reader["estado"])
                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Torneo>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }
    }
}
