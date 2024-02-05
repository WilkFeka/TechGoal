using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos.Seguridad
{
    public class CD_Usuario
    {
        // ---------------------- OBTENER TODOS LOS USUARIOS --------------------
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM usuarios");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {

                        conection.Open();
                        Console.WriteLine(cmd);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Usuario()
                                {
                                    id_usuario = Convert.ToInt32(reader["id_usuario"]),
                                    email = reader["email"].ToString(),
                                    clave = reader["clave"].ToString(),
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),
                                    dni = reader["dni"].ToString(),
                                    telefono = reader["telefono"].ToString(),
                                    id_rol = Convert.ToInt32(reader["id_rol"]),
                                    estado = Convert.ToBoolean(reader["estado"]),
                                    fechaRegistro = reader["fechaRegistro"].ToString()
                                });

                            }
                        }

                    }




                }

            } catch (Exception ex) { 
                lista = new List<Usuario>();
                Console.WriteLine(ex.Message);
            }

            

            return lista;
        }

    }
}
