using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Personalizacion
{
    public  class Funcionalidades
    {
        private static Funcionalidades instancia = null;

        private Funcionalidades()
        {
        }
        public static Funcionalidades getInstance
        {

            // -------------------- SINGLETON ---------------------
            get
            {
                if (instancia == null)
                {
                    instancia = new Funcionalidades();
                }
                return instancia;
            }
        }

            // ---------------------------- SOLO LETRAS ----------------------------

        public void soloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

            // ---------------------------- SOLO NUMEROS ----------------------------

        public void soloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // ----------------- GENERACION DE CLAVE AUTOMATICA -----------------------

        public string generarClave(int longitud)
        {
            Random random = new Random();
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder sb = new StringBuilder(longitud);

            for (int i = 0; i < longitud; i++)
            {
                // Seleccionar un carácter aleatorio de la cadena de caracteres
                int indice = random.Next(caracteres.Length);
                char caracter = caracteres[indice];

                // Agregar el carácter a la clave
                sb.Append(caracter);
            }

            return sb.ToString();
        }

        // ----------- VALIDACION SI EL CORREO ESTA BIEN ESCRITO -----------

        public bool validarEmail(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Crear una instancia de la clase Regex con el patrón
            Regex regex = new Regex(patron);

            // Verificar si el correo electrónico coincide con el patrón
            return regex.IsMatch(correo);
        }

       


    }

    // --------------- GENERACION PARA LOS COMBO BOX -------------

    public class opcionCombo
    {
        public string texto { get; set; }
        public int valor { get; set; }
    }
  
}
