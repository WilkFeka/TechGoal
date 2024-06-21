using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Jugador
    {
        public List<Jugador> Listar()
        {
            List<Jugador> lista = new List<Jugador>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM jugadores");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Jugador()
                                {
                                    id_jugador = Convert.ToInt32(reader["id_jugador"]),
                                    nombre = Convert.ToString(reader["nombre"]),
                                    apellido = Convert.ToString(reader["apellido"]),
                                    dorsal = Convert.ToInt32(reader["dorsal"]),
                                    id_equipo = Convert.ToInt32(reader["id_equipo"]),

                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Jugador>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }



        public bool AgregarJugador(Jugador nuevoJugador)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO jugadores (nombre, apellido, dorsal, id_equipo)");
                    query.AppendLine("VALUES (@nombre, @apellido, @dorsal, @id_equipo)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nuevoJugador.nombre);
                        cmd.Parameters.AddWithValue("@apellido", nuevoJugador.apellido);
                        cmd.Parameters.AddWithValue("@dorsal", nuevoJugador.dorsal);
                        cmd.Parameters.AddWithValue("@id_equipo", nuevoJugador.id_equipo);


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

        public bool EliminarJugadoresEquipo(int id_equipo)
        {
            bool eliminado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("DELETE FROM jugadores WHERE id_equipo = @id_equipo");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_equipo", id_equipo);

                        conection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            eliminado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return eliminado;
        }
    }


}
