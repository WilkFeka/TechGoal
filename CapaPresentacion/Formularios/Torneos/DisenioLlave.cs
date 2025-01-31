using CapaControladora;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CapaPresentacion.Formularios.Torneos
{
    public partial class formDisenioLlave : Form
    {
        Partido Llave;
        CC_Partido partidoControladora = CC_Partido.getInstance;
        CC_Equipos equiposControladora = CC_Equipos.getInstance;
        Equipo equipoL;
        Equipo equipoV;

        public formDisenioLlave(Partido partido)
        {
            InitializeComponent();
            Llave = partido;
        }

        private void DisenioLlave_Load(object sender, EventArgs e)
        {

            equipoL =  equiposControladora.EncontrarEquipoID(Llave.id_local);
            equipoV = Llave.id_visitante.HasValue
            ? equiposControladora.EncontrarEquipoID(Llave.id_visitante.Value)
            : new Equipo { nombre = "Descanso" };

            lblEL.Text = equipoL.nombre;
            lblEV.Text = equipoV.nombre;
            lblInstancia.Text = Llave.instancia;

            txtGolesL.Text = Llave.golesL.ToString();
            txtGolesV.Text = Llave.golesV.ToString();

            string rutaCompleta1 = Path.Combine(Application.StartupPath, "equipos", equipoL.nombre, equipoL.escudo);
            string rutaCompleta2 = Path.Combine(Application.StartupPath, "equipos", equipoV.nombre, equipoV.escudo);

            // ESCUDO LOCAL
            if (File.Exists(rutaCompleta1))
            {
                try
                {
                    // Cargar la imagen desde la ruta original
                    using (Image imagenOriginal = Image.FromFile(rutaCompleta1))
                    {
                        // Crear un archivo temporal para la imagen
                        string archivoTemporal = Path.GetTempFileName();
                        imagenOriginal.Save(archivoTemporal);

                        // Cargar la imagen temporal en el PictureBox
                        picEscudoL.Image = Image.FromFile(archivoTemporal);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones de carga de imagen
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                    picEscudoL.Image = null; // O una imagen por defecto
                }
            }
            else
            {
                // Opcional: Manejar si la imagen no existe
                picEscudoL.Image = null; // O una imagen por defecto
            }

            // ESCUDO VISITANTE
            if (File.Exists(rutaCompleta2))
            {
                try
                {
                    // Cargar la imagen desde la ruta original
                    using (Image imagenOriginal = Image.FromFile(rutaCompleta2))
                    {
                        // Crear un archivo temporal para la imagen
                        string archivoTemporal = Path.GetTempFileName();
                        imagenOriginal.Save(archivoTemporal);

                        // Cargar la imagen temporal en el PictureBox
                        picEscudoV.Image = Image.FromFile(archivoTemporal);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones de carga de imagen
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                    picEscudoV.Image = null; // O una imagen por defecto
                }
            }
            else
            {
                // Opcional: Manejar si la imagen no existe
                picEscudoV.Image = null; // O una imagen por defecto
            }



        }
    }
}
