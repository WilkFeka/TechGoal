using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDatos
{
    public class CD_Rol
    {

        // ---------------------- OBTENER TODOS LOS ROLES --------------------
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();
                    
                    query.AppendLine("SELECT id_rol, descripcion FROM rol");



                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Rol()
                                {
                                    id_rol = Convert.ToInt32(reader["id_rol"]),
                                    descripcion = reader["descripcion"].ToString(),

                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Rol>();
                Console.WriteLine(ex.Message);
            }



            return lista;
        }

        public static bool AgregarRol(Rol nuevoRol)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO rol (descripcion) VALUES (@descripcion)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@descripcion", nuevoRol.descripcion);

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
