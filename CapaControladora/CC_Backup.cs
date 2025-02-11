using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Backup
    {
        public static CC_Backup instance = null;


        // -------------------- SINGLETON ---------------------

        public static CC_Backup getInstance
        {
            get
            {
                if (instance == null)
                    instance = new CC_Backup();
                return instance;
            }
        }

        // ---------------------- HACER BACKUP --------------------

        public bool HacerBackup()
        {
            bool exito = new CD_Backup().HacerBackup();

            return exito;

        }
    }
}
