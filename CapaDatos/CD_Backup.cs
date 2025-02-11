using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Backup
    {
        public bool HacerBackup()
        {
            bool exito = false;
            string carpetaBackup = @"C:\Backups";

            try
            {
                // Verificar si la carpeta de backup existe, si no, crearla
                if (!Directory.Exists(carpetaBackup))
                    Directory.CreateDirectory(carpetaBackup);

                // Generar la ruta del archivo con fecha y hora
                string rutaBackup = Path.Combine(carpetaBackup, $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak");

                using (SqlConnection conexion = new SqlConnection(Conection.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine($"BACKUP DATABASE DB_TECHGOAL TO DISK = '{rutaBackup}'");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conexion))
                    {
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        exito = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al hacer backup: {ex.Message}");
            }

            return exito;
        }
    }
}
