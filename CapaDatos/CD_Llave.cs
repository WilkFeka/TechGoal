using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Llave
    {
        public List<Llave> Listar()
        {
            List<Llave> lista = new List<Llave>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM Llaves");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Llave()
                                {
                                    id_llave = Convert.ToInt32(reader["id_llave"]),
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
                lista = new List<Llave>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }

        public bool AgregarLlave(Llave llave)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO Llaves (instancia, id_torneo, id_local, id_visitante) ");
                    query.AppendLine("VALUES (@instancia, @id_torneo, @id_local, @id_visitante)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@instancia", llave.instancia);
                        cmd.Parameters.AddWithValue("@id_torneo", llave.id_torneo);
                        cmd.Parameters.AddWithValue("@id_local", llave.id_local);
                        cmd.Parameters.AddWithValue("@id_visitante", llave.id_visitante);


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
