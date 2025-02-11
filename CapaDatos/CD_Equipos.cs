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
                                    estado = Convert.ToBoolean(reader["estado"]),
                                    borrado = Convert.ToBoolean(reader["borrado"])
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
                        query.AppendLine("SELECT e.id_equipo, e.nombre, e.fecha_agregado, e.escudo,");
                        query.AppendLine("t.id_torneo,");
                        query.AppendLine("t.nombre AS nombre_torneo,");
                        query.AppendLine("e.estado");
                        query.AppendLine("FROM equipos e");
                        query.AppendLine("OUTER APPLY (");
                        query.AppendLine("    SELECT TOP 1 te_sub.id_torneo, te_sub.estado");
                        query.AppendLine("    FROM torneos_equipos te_sub");
                        query.AppendLine("    WHERE te_sub.id_equipo = e.id_equipo AND te_sub.estado = 1"); // Solo torneos activos
                        query.AppendLine("    ORDER BY te_sub.estado DESC");
                        query.AppendLine(") te");
                        query.AppendLine("INNER JOIN torneos t ON te.id_torneo = t.id_torneo"); // Se usa INNER JOIN para forzar solo equipos con torneos
                        query.AppendLine("WHERE e.borrado = 0 AND e.estado = 1"); // Aseguramos que no estén eliminados y sean activos
                        query.AppendLine("AND e.nombre LIKE @nombreP");
                        query.AppendLine("AND t.nombre LIKE @torneoP;");
                    }
                    else
                    {
                        query.AppendLine("SELECT DISTINCT e.id_equipo, e.nombre, e.fecha_agregado, e.escudo,");
                        query.AppendLine("CASE WHEN te.estado = 0 THEN NULL ELSE t.id_torneo END AS id_torneo,");
                        query.AppendLine("CASE WHEN te.estado = 0 THEN NULL ELSE t.nombre END AS nombre_torneo,");
                        query.AppendLine("e.estado");
                        query.AppendLine("FROM equipos e");
                        query.AppendLine("OUTER APPLY (");
                        query.AppendLine("    SELECT TOP 1 te_sub.id_torneo, te_sub.estado");
                        query.AppendLine("    FROM torneos_equipos te_sub");
                        query.AppendLine("    WHERE te_sub.id_equipo = e.id_equipo");
                        query.AppendLine("    ORDER BY te_sub.estado DESC"); // Priorizamos estado = 1 si existe
                        query.AppendLine(") te");
                        query.AppendLine("LEFT JOIN torneos t ON te.id_torneo = t.id_torneo");
                        query.AppendLine("WHERE e.borrado = 0 AND e.estado = 1"); // Se filtran equipos activos y no eliminados
                        query.AppendLine("AND e.nombre LIKE @nombreP");
                        query.AppendLine("AND (t.nombre IS NULL OR t.nombre LIKE @torneoP);");
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

                    query.AppendLine("update equipos set borrado = 1 WHERE id_equipo = @id");

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

        public bool ModificarEquipo(Equipo equipo)
        {
            bool modificar = false;

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("update equipos set ");
                    query.AppendLine("nombre = @nombre, ");
                    query.AppendLine("escudo = @escudo, ");
                    query.AppendLine("estado = @estado ");
                    query.AppendLine("where id_equipo = @id_equipo");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", equipo.nombre);
                        cmd.Parameters.AddWithValue("@escudo", equipo.escudo);
                        cmd.Parameters.AddWithValue("@estado", equipo.estado);
                        cmd.Parameters.AddWithValue("@id_equipo", equipo.id_equipo);


                        conection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            modificar = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return modificar;


        }

        public List<Equipo> EquiposLibres()
        {
            List<Equipo> lista = new List<Equipo>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT e.id_equipo, e.nombre, e.escudo");
                    query.AppendLine("FROM equipos e");
                    query.AppendLine("WHERE e.estado = 1");
                    query.AppendLine("AND e.borrado = 0");  // Asegura que el equipo no esté borrado
                    query.AppendLine("AND NOT EXISTS (");
                    query.AppendLine("    SELECT 1");
                    query.AppendLine("    FROM torneos_equipos te");
                    query.AppendLine("    WHERE te.id_equipo = e.id_equipo");
                    query.AppendLine("    AND te.estado = 1");  // Evita equipos con torneos activos
                    query.AppendLine(");");

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
                                    escudo = Convert.ToString(reader["escudo"]),
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

        public List<Dictionary<string, object>> ObtenerEstadisticasEquipo(int idEquipo)
        {
            List<Dictionary<string, object>> lista = new List<Dictionary<string, object>>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ");
                    query.AppendLine("    e.id_equipo,");
                    query.AppendLine("    e.nombre AS equipo,");
                    query.AppendLine("    COALESCE(SUM(CASE WHEN p.ganador = e.id_equipo THEN 1 ELSE 0 END), 0) AS ganados,");
                    query.AppendLine("    COALESCE(SUM(CASE WHEN p.ganador IS NULL AND p.finalizado = 1 AND p.golesL = p.golesV THEN 1 ELSE 0 END), 0) AS empatados,");
                    query.AppendLine("    COALESCE(SUM(CASE WHEN p.finalizado = 1 AND p.ganador IS NOT NULL AND p.ganador <> e.id_equipo THEN 1 ELSE 0 END), 0) AS perdidos");
                    query.AppendLine("FROM equipos e");
                    query.AppendLine("LEFT JOIN partidos p ON e.id_equipo = p.id_local OR e.id_equipo = p.id_visitante");
                    query.AppendLine("LEFT JOIN torneos t ON p.id_torneo = t.id_torneo");
                    query.AppendLine("WHERE e.id_equipo = @id_equipo AND t.borrado = 0 AND e.borrado = 0");
                    query.AppendLine("GROUP BY e.id_equipo, e.nombre;");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_equipo", idEquipo);
                        conexion.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Dictionary<string, object>
                        {
                            { "IdEquipo", reader["id_equipo"] },
                            { "Nombre", reader["equipo"] },
                            { "Ganados", reader["ganados"] },
                            { "Empatados", reader["empatados"] },
                            { "Perdidos", reader["perdidos"] }
                        });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = new List<Dictionary<string, object>>();
                Console.WriteLine(ex.Message);
            }

            return lista;
        }


        public List<Equipo> ListarEquiposActivosFiltrados(string filtro)
        {
            List<Equipo> lista = new List<Equipo>();

            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT id_equipo, nombre FROM equipos WHERE borrado = 0 AND nombre LIKE @filtro");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                        conection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Equipo()
                                {
                                    id_equipo = Convert.ToInt32(reader["id_equipo"]),
                                    nombre = Convert.ToString(reader["nombre"])
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


    }




}
