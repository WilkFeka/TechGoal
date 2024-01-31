using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    public static class Tema
    {
        public static System.Drawing.Color colorPrincipal;
        public static System.Drawing.Color colorSecundario;
        public static System.Drawing.Color colorOscuro;
        public static System.Drawing.Color colorResaltado;
        public static System.Drawing.Color colorClaro;
        public static System.Drawing.Color colorIconos;

        // Tema Default DarkM

        private static readonly System.Drawing.Color colorPrincipalD = System.Drawing.Color.FromArgb(1, 35, 64);
        private static readonly System.Drawing.Color colorSecundarioD = System.Drawing.Color.FromArgb(23, 140, 166);
        private static readonly System.Drawing.Color colorOscuroD = System.Drawing.Color.FromArgb(0, 23, 49);
        private static readonly System.Drawing.Color colorResaltadoD = System.Drawing.Color.FromArgb(67, 231, 207);
        private static readonly System.Drawing.Color colorClaroD = System.Drawing.Color.FromArgb(220, 240, 242);
        private static readonly System.Drawing.Color colorIconosD = System.Drawing.Color.White;

        //Tema Light


        public static void cambiarTema(string tema)
        {
            if (tema == "Dark")
            {
                colorPrincipal = colorPrincipalD;
                colorSecundario = colorSecundarioD;
                colorOscuro = colorOscuroD;
                colorResaltado = colorResaltadoD;
                colorClaro = colorClaroD;
                colorIconos = colorIconosD;

            }

            if (tema == "Light")
            {

            }

        }
    }   


}
