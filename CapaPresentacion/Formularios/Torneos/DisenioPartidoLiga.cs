using CapaControladora;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CapaPresentacion.Formularios.Torneos
{
    public partial class formDisenioPartidoLiga : Form
    {
        Partido partido;
        CC_Partido partidoControladora = CC_Partido.getInstance;
        CC_Equipos equiposControladora = CC_Equipos.getInstance;
        Equipo equipoL;
        Equipo equipoV;
        public formDisenioPartidoLiga(Partido partidoC)
        {
            InitializeComponent();
            partido = partidoC;
        }

        private void formDisenioPartidoLiga_Load(object sender, EventArgs e)
        {
            equipoL = equiposControladora.EncontrarEquipoID(partido.id_local);
            equipoV = partido.id_visitante.HasValue
            ? equiposControladora.EncontrarEquipoID(partido.id_visitante.Value)
            : new Equipo { nombre = "Descanso" };

            lblEL.Text = equipoL.nombre;
            lblEV.Text = equipoV.nombre;

            txtGolesL.Text = partido.golesL.ToString();
            txtGolesV.Text = partido.golesV.ToString();

            string escudoL = equipoL.escudo ?? "";
            string escudoV = equipoV.escudo ?? "";

            string rutaCompleta1 = Path.Combine(Application.StartupPath, "equipos", equipoL.nombre, escudoL);
            string rutaCompleta2 = Path.Combine(Application.StartupPath, "equipos", equipoV.nombre, escudoV);

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
