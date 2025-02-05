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
using CapaPresentacion.Personalizacion;
using CapaPresentacion.Properties;

namespace CapaPresentacion.Formularios.Torneos
{
    public partial class formDisenioLlave : Form
    {
        Partido Llave;
        CC_Partido partidoControladora = CC_Partido.getInstance;
        CC_Equipos equiposControladora = CC_Equipos.getInstance;
        Equipo equipoL;
        Equipo equipoV;
        formInfoTorneoLlaves formInfoLlavesC;
        Funcionalidades funcionalidades = Funcionalidades.getInstance;
        bool finalizado;

        public formDisenioLlave(Partido partido, formInfoTorneoLlaves formInfoTorneoLlaves)
        {
            InitializeComponent();
            Llave = partido;
            formInfoLlavesC = formInfoTorneoLlaves;
            finalizado = partido.finalizado;

            if (finalizado)
            {
                btnEditar.Visible = false;
                btnRestart.Visible = true;
            }
        }

        private void DisenioLlave_Load(object sender, EventArgs e)
        {
            lblInstancia.Text = Llave.instancia;
            equipoL = Llave.id_local.HasValue ? equiposControladora.EncontrarEquipoID((int)Llave.id_local) 
            : new Equipo { id_equipo = 0, nombre = "A confirmar" };

            equipoV = Llave.id_visitante.HasValue
            ? equiposControladora.EncontrarEquipoID(Llave.id_visitante.Value)
            : new Equipo { id_equipo = 0, nombre = "A confirmar" };

            lblEL.Text = equipoL.nombre;
            lblEV.Text = equipoV.nombre;

            if (equipoV.id_equipo == 0)
            {
                btnEditar.Visible = false;

            }

            if (Llave.finalizado == false)
            {
                txtGolesL.Text = "";
                txtGolesV.Text = "";
            }
            else
            {
                txtGolesL.Text = Llave.golesL.ToString();
                txtGolesV.Text = Llave.golesV.ToString();
            }

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
                picEscudoL.Image = Resources.NoTeam; // O una imagen por defecto
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
                picEscudoV.Image = Resources.NoTeam; // O una imagen por defecto
            }

            if (Llave.id_local == null || Llave.id_visitante == null)
            {
                btnEditar.Visible = false;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtGolesL.ReadOnly = false;
            txtGolesV.ReadOnly = false;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
            btnEditar.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtGolesL.ReadOnly = true;
            txtGolesV.ReadOnly = true;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            btnEditar.Visible = true;
            txtGolesL.Text = "";
            txtGolesV.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validar que los campos de goles estén completos
            foreach (Control control in pnlTemplate.Controls)
            {
                if (control is TextBox && string.IsNullOrEmpty(control.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (txtGolesL.Text == txtGolesV.Text)
            {
                MessageBox.Show("No puede haber empate. Ingrese un resultado válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                $"¿Desea confirmar el resultado {txtGolesL.Text} : {txtGolesV.Text}?",
                "Confirmar Resultado",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Cancel) return;

            // Asignar goles y determinar el ganador
            Llave.golesL = Convert.ToInt32(txtGolesL.Text);
            Llave.golesV = Convert.ToInt32(txtGolesV.Text);
            Llave.finalizado = true;

            Llave.ganador = (Llave.golesL > Llave.golesV) ? Llave.id_local : Llave.id_visitante;

            // Actualizar el partido actual en la base de datos
            if (!partidoControladora.ActualizarPartido(Llave))
            {
                MessageBox.Show("Hubo un error al actualizar el partido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener todos los partidos de la instancia actual
            var partidosActuales = partidoControladora.ObtenerPartidosPorInstancia(Llave.id_torneo, Llave.instancia);

            string siguienteInstancia = ObtenerSiguienteInstancia(Llave.instancia);
            List<Partido> llavesPosteriores = partidoControladora.ObtenerPartidosPosteriores( Llave.id_torneo, siguienteInstancia);



            // Verificar si todos los partidos de esta instancia ya se jugaron
            if (partidosActuales.All(p => p.finalizado) && llavesPosteriores.Count == 0)
            {
                // Obtener la siguiente instancia
                if (string.IsNullOrEmpty(siguienteInstancia)) // Si no hay más instancias (es la final), salir
                {
                    MessageBox.Show("Resultado agregado con éxito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Deshabilitar edición
                    btnAceptar.Visible = false;
                    btnCancelar.Visible = false;
                    btnRestart.Visible = true;
                    txtGolesL.ReadOnly = true;
                    txtGolesV.ReadOnly = true;
                    return;
                }

                // Obtener solo los ganadores de los partidos actuales
                var ganadores = partidosActuales.OrderBy(p => p.id_partido).Select(p => p.ganador).ToList();


                // Crear los partidos de la siguiente fase agrupando de a 2
                for (int i = 0; i < ganadores.Count; i += 2)
                {
                    if (i + 1 >= ganadores.Count) break; // Evitar errores si hay un número impar de ganadores

                    Partido nuevoPartido = new Partido
                    {
                        id_partido = partidoControladora.ObtenerMaxIdPartido(Llave.id_torneo, siguienteInstancia) + 1,
                        instancia = siguienteInstancia,
                        id_torneo = Llave.id_torneo,
                        id_local = ganadores[i],
                        id_visitante = ganadores[i + 1],
                        finalizado = false
                    };

                    partidoControladora.AgregarPartido(nuevoPartido);
                }

                List<Partido> nuevosPartidos = partidoControladora.ObtenerPartidosPorInstancia(Llave.id_torneo, siguienteInstancia);

                // **Actualizar los partidos actuales con el id_sig_partido correspondiente**
                for (int i = 0; i < partidosActuales.Count; i++)
                {
                    int index = i / 2; // Cada dos partidos deben apuntar al mismo `id_sig_partido`
                    if (index < nuevosPartidos.Count)
                    {
                        partidosActuales[i].id_sig_partido = nuevosPartidos[index].id_partido;
                        partidoControladora.ActualizarPartido(partidosActuales[i]);
                    }
                }
            } else if (llavesPosteriores.Count > 0)
            {
                Partido sigPartido = partidoControladora.ObtenerPartidosIdSiguiete(Llave.id_torneo, (int)Llave.id_sig_partido);


                sigPartido.id_local = sigPartido.id_local ?? Llave.ganador;

                if (sigPartido.id_local == Llave.ganador)
                {
                    partidoControladora.ActualizarPartido(sigPartido);
                }
                else
                {
                    sigPartido.id_visitante = sigPartido.id_visitante ?? Llave.ganador;
                    partidoControladora.ActualizarPartido(sigPartido);
                }
            }

            MessageBox.Show("Resultado agregado con éxito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Deshabilitar edición
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            btnRestart.Visible = true;
            txtGolesL.ReadOnly = true;
            txtGolesV.ReadOnly = true;

            formInfoLlavesC.formInfoTorneoLlaves_Load(sender, e);
        }



        private string ObtenerSiguienteInstancia(string instanciaActual)
        {
            if (instanciaActual == "32vos") return "16vos";
            if (instanciaActual == "16vos") return "8vos";
            if (instanciaActual == "8vos") return "4tos";
            if (instanciaActual == "4tos") return "Semifinal";
            if (instanciaActual == "Semifinal") return "Final";
            return null; // La final no tiene siguiente instancia
        }


        private void txtGolesL_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);

            if (txtGolesL.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar el evento KeyPress
            }
        }

        private void txtGolesV_KeyPress(object sender, KeyPressEventArgs e)
        {
            funcionalidades.soloNumeros(sender, e);

            if (txtGolesV.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar el evento KeyPress
            }
        }

        private void txtGolesL_Click(object sender, EventArgs e)
        {
            if (btnEditar.Visible)
            {

                ActiveControl = null;

            }
        }

        private void txtGolesV_Click(object sender, EventArgs e)
        {
            if (btnEditar.Visible)
            {

                ActiveControl = null;

            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("¿Desea restablecer el partido? Esto restablecera las estadisticas y partidos posteriores.", "Si", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);




            if (resultado == DialogResult.Cancel) return;


            List<Partido> llavesPosteriores = partidoControladora.ObtenerPartidosPosterioresConGanador((int)Llave.ganador, Llave.id_torneo, Llave.id_partido);

            foreach (Partido partido in llavesPosteriores)
            {
                partido.id_local = (partido.id_local == Llave.ganador) ? null : partido.id_local;
                partido.id_visitante = (partido.id_visitante == Llave.ganador) ? null : partido.id_visitante;

                partido.golesL = null;
                partido.golesV = null;
                partido.finalizado = false;
                partido.ganador = null;


                bool actualizarPartidosPosteriores = partidoControladora.ActualizarPartido(partido);

                if (actualizarPartidosPosteriores == false)
                {
                    MessageBox.Show("Hubo un error al restablecer partido posterior", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Llave.golesL = null;
            Llave.golesV = null;
            Llave.finalizado = false;
            Llave.ganador = null;

            bool actualizar = partidoControladora.ActualizarPartido(Llave);

            if (actualizar == false)
            {
                MessageBox.Show("Hubo un error al restablecer partido", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Resultado restablecido con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            btnRestart.Visible = false;
            btnEditar.Visible = true;
            txtGolesL.Text = "";
            txtGolesV.Text = "";
            this.ActiveControl = null;
            txtGolesL.ReadOnly = true;
            txtGolesV.ReadOnly = true;

            formInfoLlavesC.formInfoTorneoLlaves_Load(sender, e);

        }
    }
}
