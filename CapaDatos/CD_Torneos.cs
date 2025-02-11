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
                                    id_torneo = Convert.ToInt32(reader["id_torneo"]),
                                    nombre = Convert.ToString(reader["nombre"]),
                                    tipo = Convert.ToInt32(reader["tipo"]),
                                    cantEquipos = Convert.ToInt32(reader["cantEquipos"]),
                                    fechaFinal = DateTime.Parse(Convert.ToString(reader["fechaInicio"])),
                                    fechaInicio = DateTime.Parse(Convert.ToString(reader["fechaFinal"])),
                                    estado = Convert.ToBoolean(reader["estado"]),
                                    borrado = Convert.ToBoolean(reader["borrado"])

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

        public bool AgregarTorneo(Torneo torneo)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO torneos (nombre, tipo, cantEquipos, fechaInicio, fechaFinal, estado)");
                    query.AppendLine("VALUES (@nombre, @tipo, @cantEquipos, @fechaInicio, @fechaFinal, @estado)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", torneo.nombre);
                        cmd.Parameters.AddWithValue("@tipo", torneo.tipo);
                        cmd.Parameters.AddWithValue("@cantEquipos", torneo.cantEquipos);
                        cmd.Parameters.AddWithValue("@fechaInicio", torneo.fechaInicio);
                        cmd.Parameters.AddWithValue("@fechaFinal", torneo.fechaFinal);
                        cmd.Parameters.AddWithValue("@estado", torneo.estado);

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

        public bool BorrarTorneo(int id_torneo)
        {
            bool modificado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("UPDATE torneos SET borrado = 1");
                    query.AppendLine("WHERE id_torneo = @id_torneo");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_torneo", id_torneo);

                        conection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            modificado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return modificado;
        }
    }
}
