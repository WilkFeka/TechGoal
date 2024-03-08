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
        public List<Permiso> ListarPermisosUsuario(int id_usuario)
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
                                    obj_modulo = new Modulo() { id_modulo = Convert.ToInt32(reader["id_modulo"]) },

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

        // ---------------------- OBTENER TODOS LOS PERMISOS DE UN ROL --------------------

        public List<Permiso> Listar()
        {
            List<Permiso> lista = new List<Permiso>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT id_rol, id_modulo FROM permisos");
                    

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Permiso()
                                {
                                    obj_rol = new Rol() { id_rol = Convert.ToInt32(reader["id_rol"]) },
                                    obj_modulo = new Modulo() { id_modulo = Convert.ToInt32(reader["id_modulo"]) },
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
                    query.AppendLine("INSERT INTO permisos (id_rol, id_modulo) VALUES (@id_rol, @id_modulo)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_rol", nuevoPermiso.obj_rol.id_rol);
                        cmd.Parameters.AddWithValue("@id_modulo", nuevoPermiso.obj_modulo.id_modulo);

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

        public static bool EliminarPermiso(int id)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("DELETE FROM permisos WHERE id_rol = @id_rol");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id_rol", id);

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
