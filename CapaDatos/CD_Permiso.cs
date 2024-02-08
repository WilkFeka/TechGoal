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
        // ---------------------- OBTENER TODOS LOS PERMISOS --------------------
        public List<Permiso> Listar(int id_usuario)
        {
            List<Permiso> lista = new List<Permiso>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();
                    /*select p.id_rol, p.nombreMenu from permisos p
                    inner join rol r on r.id_rol = p.id_rol
                    inner join usuarios u on u.id_rol = r.id_rol
                    where u.id_usuario = 1*/
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
    }
}
