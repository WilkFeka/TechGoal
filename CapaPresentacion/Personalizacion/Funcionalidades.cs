using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladora;
using CapaEntidad;
using System.Windows.Documents;
using System.IO;
using ClosedXML.Excel;

namespace CapaPresentacion.Personalizacion
{
    public  class Funcionalidades
    {
        private static Funcionalidades instancia = null;
        CC_Usuario usuarioControladora = new CC_Usuario();

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

        public bool EnviarCorreo(string correo)
        {
            // ----------------- ENVIO DE CORREO -------------------

            bool respuesta = false;


            try
            { 
            
                if (string.IsNullOrEmpty(correo))
                {
                    MessageBox.Show("Por favor complete todos los campos.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return respuesta;
                }

                if (validarEmail(correo) == false)
                {
                    MessageBox.Show("Por favor escriba una direccion de correo valida.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return respuesta;
                }

                Usuario usuarioEncontrado = usuarioControladora.EncontrarUsuarioCorreo(correo);

                if (usuarioEncontrado == null)
                {
                MessageBox.Show("No se encontro un usuario con ese correo. Por favor escriba un correo existente.", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return respuesta;
                }

                string nuevaClave = generarClave(8);

                string claveHash =  usuarioControladora.EncriptarClave(nuevaClave);

                usuarioEncontrado.clave = claveHash;

                usuarioControladora.NuevaClave(usuarioEncontrado);



                // Configurar el cliente SMTP y el mensaje
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // Reemplaza "smtp.example.com" con el servidor SMTP que estés utilizando
                smtpClient.Port = 587; // Puerto SMTP (generalmente 587 para TLS o 465 para SSL)
                smtpClient.Credentials = new NetworkCredential("techgoalsistema@gmail.com", "bdqv iefp ntlu cviq");
                smtpClient.EnableSsl = true; // Habilitar SSL/TLS


                MailMessage message = new MailMessage();
                message.From = new MailAddress("techgoalsistema@gmail.com"); // Remitente
                message.To.Add(correo); // Destinatario
                message.Subject = "Recuperar Clave | Sistema TechGoal"; // Asunto
                message.Body = "Esta es tu nueva clave para el ingreso al sistema TechGoal: " + nuevaClave ; // Contenido

                // Envía el correo
                smtpClient.Send(message);
                Console.WriteLine("Correo enviado exitosamente.");

                MessageBox.Show("Se ha enviado un correo con su nueva clave.", "Correo Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }

            return respuesta;
        }

        public void ExportarDataGridViewAExcel(DataGridView dataGridView, string rutaArchivo)
        {
            Cursor.Current = Cursors.WaitCursor;

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Datos");

            // Ajustar el estilo de la fuente para todas las celdas
            worksheet.Style.Font.FontName = "Roboto";
            worksheet.Style.Font.FontSize = 14;

            // Agregar encabezados de columna visibles y formatear en negrita
            int columnaIndex = 1;
            foreach (DataGridViewColumn columna in dataGridView.Columns)
            {
                if (columna.Visible && columna.HeaderText != "")
                {
                    worksheet.Cell(1, columnaIndex).Value = columna.HeaderText;
                    worksheet.Cell(1, columnaIndex).Style.Font.Bold = true;
                    columnaIndex++;
                }
            }

            worksheet.Cell(1, columnaIndex).Value = "Fecha Exportacion";
            worksheet.Cell(1, columnaIndex).Style.Font.Bold = true;

            worksheet.Cell(2, columnaIndex).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Agregar datos filtrados
            int filaIndex = 2;
            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                if (fila.Visible)
                {
                    columnaIndex = 1;
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        if (dataGridView.Columns[celda.ColumnIndex].Visible && dataGridView.Columns[celda.ColumnIndex].HeaderText != "")
                        {
                            worksheet.Cell(filaIndex, columnaIndex).Value = celda.Value?.ToString();
                            columnaIndex++;
                        }
                    }
                    filaIndex++;
                }


            }




            // Ajustar ancho de columnas para que se ajusten al contenido
            worksheet.Columns().AdjustToContents();


            // Guardar el libro de Excel

            workbook.SaveAs(rutaArchivo);


            MessageBox.Show("Archivo exportado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Cursor.Current = Cursors.Default;


        }




    }

    // --------------- GENERACION PARA LOS COMBO BOX -------------

    public class opcionCombo
    {
        public string texto { get; set; }
        public int valor { get; set; }
    }
  
}
