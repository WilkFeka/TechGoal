using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reserva
    {
        public List<Reserva> Listar()
        {
            List<Reserva> lista = new List<Reserva>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM reservas");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Reserva()
                                {
                                    id_reserva = Convert.ToInt32(reader["id_reserva"]),
                                    objCancha = new Cancha() { id_cancha = Convert.ToInt32(reader["id_cancha"]) },
                                    objHorario = new Horario() { id_horario = Convert.ToInt32(reader["id_horario"]) },
                                    objCliente = new Cliente() { id_cliente = Convert.ToInt32(reader["id_cliente"]) },
                                    fechaReserva = Convert.ToDateTime(reader["fechaReserva"]),
                                    tipo = reader["tipo"].ToString(),
                                    estado = Convert.ToBoolean(reader["estado"]),

                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Reserva>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }


    }
}
