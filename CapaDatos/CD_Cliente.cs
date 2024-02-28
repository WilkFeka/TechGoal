using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cliente
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM clientes");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Cliente()
                                {
                                    id_cliente = Convert.ToInt32(reader["id_cliente"]),
                                    nombre = Convert.ToString(reader["nombre"]),
                                    apellido = Convert.ToString(reader["apellido"]),
                                    dni = Convert.ToString(reader["dni"]),
                                    telefono = Convert.ToString(reader["telefono"]),
                                    estado = Convert.ToBoolean(reader["estado"])
                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Cliente>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }

        public bool AgregarCliente(Cliente nuevoCliente)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO clientes (nombre, apellido, dni, telefono, estado)");
                    query.AppendLine("VALUES (@nombre, @apellido, @dni, @telefono, @estado)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nuevoCliente.nombre);
                        cmd.Parameters.AddWithValue("@apellido", nuevoCliente.apellido);
                        cmd.Parameters.AddWithValue("@dni", nuevoCliente.dni);
                        cmd.Parameters.AddWithValue("@telefono", nuevoCliente.telefono);
                        cmd.Parameters.AddWithValue("@estado", nuevoCliente.estado);

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
