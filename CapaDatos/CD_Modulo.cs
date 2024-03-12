using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Modulo
    {
        public List<Modulo> Listar()
        {
            List<Modulo> lista = new List<Modulo>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT id_modulo, modulo FROM modulos");



                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Modulo()
                                {
                                    id_modulo = Convert.ToInt32(reader["id_modulo"]),
                                    modulo = reader["modulo"].ToString(),

                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Modulo>();
                Console.WriteLine(ex.Message);
            }



            return lista;
        }
    }
}
