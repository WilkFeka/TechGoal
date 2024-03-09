using CapaEntidad;
using CapaEntidad.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Seguridad
{
    public class CD_GrupoPermiso
    {
        public List<GrupoPermiso> ListarGrupoPermiso()
        {
            List<GrupoPermiso> listagp = new List<GrupoPermiso>();


            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.id_component, c.nombre, c.estado,");
                    query.AppendLine("gp.id_grupoPermiso ");
                    query.AppendLine("from componente c");
                    query.AppendLine("inner join grupo_permiso gp on c.id_componente = gp.id_componente");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {

                        conection.Open();
                        Console.WriteLine(cmd);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GrupoPermiso grupoPermiso = new GrupoPermiso();
                                grupoPermiso.IdGrupoPermiso = Convert.ToInt32(reader["id_grupoPermiso"]);
                                grupoPermiso.IdComponente = Convert.ToInt32(reader["id_componente"]);
                                grupoPermiso.Nombre = reader["nombre"].ToString();
                                grupoPermiso.Estado = Convert.ToBoolean(reader["estado"]);
                                grupoPermiso.NombreGrupo = reader["nombre"].ToString();

                                listagp.Add(grupoPermiso);

                            }
                        }

                    }




                }

            }
            catch (Exception ex)
            {
                listagp = new List<GrupoPermiso>();
                Console.WriteLine(ex.Message);
            }



            return listagp;
        }

        public List<Componente> ListarComponente(int idGrupoPermiso)
        {
            List<Componente> listac = new List<Componente>();


            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    StringBuilder query = new StringBuilder();
                    if (idGrupoPermiso != 0)
                    {
                        query.AppendLine("select c.Nombre, c.TipoComponente, c.Estado, c.id_componente ");
                        query.AppendLine("from GRUPO_PERMISO_COMPONENTE gpc ");
                        query.AppendLine("inner join GRUPO_PERMISO gp on gpc.IdGrupoPermiso = gp.IdGrupoPermiso ");
                        query.AppendLine("inner join COMPONENTE c on gpc.id_componente = c.id_componente ");
                        query.AppendLine("where gpc.IdGrupoPermiso = @IdGrupoPermiso");
                    }
                    else
                    {
                        query.AppendLine("select id_componente, Nombre, TipoComponente, Estado ");
                        query.AppendLine("from COMPONENTE");
                    }

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conection))
                    {
                        if (idGrupoPermiso != 0)
                        {
                            cmd.Parameters.AddWithValue("@IdGrupoPermiso", idGrupoPermiso);
                        }

                        conection.Open();
                        Console.WriteLine(cmd);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Componente componente = new Componente();
                                componente.IdComponente = Convert.ToInt32(reader["id_componente"]);
                                componente.Nombre = reader["Nombre"].ToString();
                                componente.Estado = Convert.ToBoolean(reader["Estado"]);
                                componente.TipoComponente = reader["tipoComponente"].ToString();

                                listac.Add(componente);

                            }
                        }

                    }




                }

            }
            catch (Exception ex)
            {
                listac = new List<Componente>();
                Console.WriteLine(ex.Message);
            }



            return listac;
        }

        public bool RegistrarGrupoPermiso(GrupoPermiso oGrupoPermiso, DataTable listaComponentes, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection conection = new SqlConnection(Conection.cadena))
                {

                    

                    using (SqlCommand cmd = new SqlCommand("SP_RegistrarGrupoPermiso", conection))
                    {
                        cmd.Parameters.AddWithValue("NombreGrupo", oGrupoPermiso.NombreGrupo);
                        cmd.Parameters.AddWithValue("Estado", oGrupoPermiso.Estado);
                        cmd.Parameters.AddWithValue("Componentes", listaComponentes);

                        conection.Open();
                        Console.WriteLine(cmd);

                        //Parametros de Salida
                        cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("Mensaje", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;

                        cmd.CommandType = CommandType.StoredProcedure;

                        conection.Open();

                        cmd.ExecuteNonQuery();

                        resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                    }




                }

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                resultado = false;
            }



            return resultado;
        }
    }
}
