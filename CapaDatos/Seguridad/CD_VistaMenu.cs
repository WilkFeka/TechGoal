using CapaEntidad;
using CapaEntidad.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Seguridad
{
    public class CD_VistaMenu
    {
        public List<VistaMenu> Listar()
        {
            List<VistaMenu> lista = new List<VistaMenu>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT id_menu, menu FROM menus");



                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new VistaMenu()
                                {
                                    id_menu = Convert.ToInt32(reader["id_menu"]),
                                    menu = reader["menu"].ToString(),

                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<VistaMenu>();
                Console.WriteLine(ex.Message);
            }



            return lista;
        }
    }
}
