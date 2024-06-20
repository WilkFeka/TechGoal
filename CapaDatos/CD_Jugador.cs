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

    }

}
