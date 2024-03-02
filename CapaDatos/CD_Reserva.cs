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

        public bool AgregarReserva(Reserva reserva)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO reservas (id_cancha, id_horario, id_cliente, fechaReserva, tipo, estado) ");
                    query.AppendLine("VALUES (@id_cancha, @id_horario, @id_cliente, @fechaReserva, @tipo, @estado)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_cancha", reserva.objCancha.id_cancha);
                        cmd.Parameters.AddWithValue("@id_horario", reserva.objHorario.id_horario);
                        cmd.Parameters.AddWithValue("@id_cliente", reserva.objCliente.id_cliente);
                        cmd.Parameters.AddWithValue("@fechaReserva", reserva.fechaReserva);
                        cmd.Parameters.AddWithValue("@tipo", reserva.tipo);
                        cmd.Parameters.AddWithValue("@estado", reserva.estado);

                        conection.Open();

                        resultado = cmd.ExecuteNonQuery() > 0;

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;

        }

        public bool ModificarReserva(Reserva reserva)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("UPDATE reservas SET id_cancha = @id_cancha, id_horario = @id_horario, id_cliente = @id_cliente, fechaReserva = @fechaReserva, tipo = @tipo, estado = @estado ");
                    query.AppendLine("WHERE id_reserva = @id_reserva");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_cancha", reserva.objCancha.id_cancha);
                        cmd.Parameters.AddWithValue("@id_horario", reserva.objHorario.id_horario);
                        cmd.Parameters.AddWithValue("@id_cliente", reserva.objCliente.id_cliente);
                        cmd.Parameters.AddWithValue("@fechaReserva", reserva.fechaReserva);
                        cmd.Parameters.AddWithValue("@tipo", reserva.tipo);
                        cmd.Parameters.AddWithValue("@estado", reserva.estado);
                        cmd.Parameters.AddWithValue("@id_reserva", reserva.id_reserva);

                        conection.Open();

                        resultado = cmd.ExecuteNonQuery() > 0;

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;

        }

        public bool EliminarReserva(int id)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("DELETE FROM reservas WHERE id_reserva = @id_reserva");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_reserva", id);

                        conection.Open();

                        resultado = cmd.ExecuteNonQuery() > 0;

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }

    }



}
