using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Permiso
    {
        // ---------------------- OBTENER TODOS LOS PERMISOS DE UN USUARIO --------------------
        public List<Permiso> Listar(int id_usuario)
        {
            List<Permiso> lista = new List<Permiso>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();
                   
                    query.AppendLine("SELECT p.id_rol, p.nombreMenu FROM permisos p");
                    query.AppendLine("INNER JOIN rol r ON r.id_rol = p.id_rol");
                    query.AppendLine("INNER JOIN usuarios u ON u.id_rol = r.id_rol");
                    query.AppendLine("WHERE u.id_usuario = @id_usuario");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Permiso()
                                {
                                    obj_rol = new Rol() { id_rol = Convert.ToInt32(reader["id_rol"]) },
                                    nombreMenu = reader["nombreMenu"].ToString(),
                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Permiso>();
                Console.WriteLine(ex.Message);
            }



            return lista;
        }

        // ---------------------- AGREGAR NUEVO PERMISO --------------------

        public static bool AgregarPermiso(Permiso nuevoPermiso)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO permisos (id_rol, nombreMenu) VALUES (@id_rol, @nombreMenu)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_rol", nuevoPermiso.obj_rol.id_rol);
                        cmd.Parameters.AddWithValue("@nombreMenu", nuevoPermiso.nombreMenu);

                        conection.Open();

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            resultado = true;
                        }
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
