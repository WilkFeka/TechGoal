using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Equipos
    {
        public List<Equipo> Listar()
        {
            List<Equipo> lista = new List<Equipo>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM equipos");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                lista.Add(new Equipo()
                                {
                                    id_equipo = Convert.ToInt32(reader["id_equipo"]),
                                    nombre = Convert.ToString(reader["nombre"]),
                                    fecha_agregado = DateTime.Parse(Convert.ToString(reader["fecha_agregado"])),
                                    escudo = Convert.ToString(reader["escudo"]),
                                    estado = Convert.ToBoolean(reader["estado"])
                                });

                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                lista = new List<Equipo>();
                Console.WriteLine(ex.Message);
            }

            return lista;

        }
        public DataTable CargarTablaEquipos(DataTable tablaEquiposP, string nombreP, string torneoP, string estadoP)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    if (torneoP != "")
                    {
                        query.AppendLine("SELECT equipos.id_equipo, equipos.nombre, equipos.fecha_agregado, equipos.escudo, torneos.id_torneo, torneos.nombre AS nombre_torneo , equipos.estado  ");
                        query.AppendLine("FROM equipos ");
                        query.AppendLine("LEFT JOIN torneos_equipos ON equipos.id_equipo = torneos_equipos.id_equipo ");
                        query.AppendLine("LEFT JOIN torneos ON torneos_equipos.id_torneo = torneos.id_torneo ");
                        query.AppendLine("WHERE equipos.nombre LIKE @nombreP AND torneos.nombre LIKE @torneoP AND equipos.estado LIKE @estadoP");

                    }

                    else
                    {
                        query.AppendLine("SELECT equipos.id_equipo, equipos.nombre, equipos.fecha_agregado, equipos.escudo, torneos.id_torneo, torneos.nombre AS nombre_torneo , equipos.estado  ");
                        query.AppendLine("FROM equipos ");
                        query.AppendLine("LEFT JOIN torneos_equipos ON equipos.id_equipo = torneos_equipos.id_equipo ");
                        query.AppendLine("LEFT JOIN torneos ON torneos_equipos.id_torneo = torneos.id_torneo ");
                        query.AppendLine("WHERE equipos.nombre LIKE @nombreP AND (torneos.nombre IS NULL OR torneos.nombre LIKE @torneoP) AND equipos.estado LIKE @estadoP");


                    }







                    SqlDataAdapter adapter;


                    using (adapter = new SqlDataAdapter(query.ToString(), conection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@nombreP", "%" + nombreP + "%");
                        adapter.SelectCommand.Parameters.AddWithValue("@estadoP", "%" + estadoP + "%");
                        adapter.SelectCommand.Parameters.AddWithValue("@torneoP", "%" + torneoP + "%");




                        adapter.Fill(tablaEquiposP);
                        return tablaEquiposP;

                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tablaEquiposP;

            }
        }

        public bool AgregarEquipo(Equipo equipo)
        {
            bool agregado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("INSERT INTO equipos (nombre, escudo, estado)");
                    query.AppendLine("VALUES (@nombre, @escudo, @estado)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", equipo.nombre);
                        cmd.Parameters.AddWithValue("@escudo", equipo.escudo);
                        cmd.Parameters.AddWithValue("@estado", equipo.estado);

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

        public bool EliminarEquipo(int id)
        {
            bool eliminado = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("DELETE FROM equipos WHERE id_equipo = @id");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        conection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            eliminado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return eliminado;
        }
    }
}
