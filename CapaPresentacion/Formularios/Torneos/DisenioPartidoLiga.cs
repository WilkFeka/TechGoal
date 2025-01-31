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
using CapaPresentacion.Personalizacion;

namespace CapaPresentacion.Formularios.Torneos
{
    public partial class formDisenioPartidoLiga : Form
    {
        Partido partido;
        CC_Partido partidoControladora = CC_Partido.getInstance;
        CC_Equipos equiposControladora = CC_Equipos.getInstance;
        Funcionalidades funcionalidades = Funcionalidades.getInstance;
        CC_Tabla_Torneo tablaTorneoControladora = CC_Tabla_Torneo.getInstance;
        Equipo equipoL;
        Equipo equipoV;
        formInfoTorneoLiga formInfoLigaC;
        bool finalizado;
        public formDisenioPartidoLiga(Partido partidoC, formInfoTorneoLiga formInfoLiga)
        {
            InitializeComponent();
            partido = partidoC;
            finalizado = partido.finalizado;
            formInfoLigaC = formInfoLiga;

            if (finalizado) {
                btnEditar.Visible = false;
                btnRestart.Visible = true;
            }
        }

        private void formDisenioPartidoLiga_Load(object sender, EventArgs e)
        {
            equipoL = equiposControladora.EncontrarEquipoID(partido.id_local);
            equipoV = partido.id_visitante.HasValue
            ? equiposControladora.EncontrarEquipoID(partido.id_visitante.Value)
            : new Equipo { id_equipo = 0, nombre = "Descanso" };

            lblEL.Text = equipoL.nombre;
            lblEV.Text = equipoV.nombre;

            if (equipoV.id_equipo == 0)
            {
                btnEditar.Visible = false;

            }

            if (partido.finalizado == false)
            {
                txtGolesL.Text = "";
                txtGolesV.Text = "";
            } else
            {
                txtGolesL.Text = partido.golesL.ToString();
                txtGolesV.Text = partido.golesV.ToString();
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
            foreach (Control control in pnlTemplate.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {

                        MessageBox.Show("Por favor complete todos los campos", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                }

            }
            DialogResult resultado = MessageBox.Show("¿Desea confirmar el resultado " + txtGolesL.Text + " : " + txtGolesV.Text + "? Esto sumara a las estadisticas", "Si", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.Cancel)
            {
                return;
            }

            partido.golesL = Convert.ToInt32(txtGolesL.Text);
            partido.golesV = Convert.ToInt32(txtGolesV.Text);
            partido.finalizado = true;

            if (Convert.ToInt32(txtGolesL.Text) > Convert.ToInt32(txtGolesV.Text))
            {
                partido.ganador = partido.id_local;

            } else if (Convert.ToInt32(txtGolesL.Text) < Convert.ToInt32(txtGolesV.Text))
            {
                partido.ganador = partido.id_visitante;
            }

            bool actualizar = partidoControladora.ActualizarPartido(partido);

            if (actualizar == false)
            {
                MessageBox.Show("Hubo un error al actualizar partido", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tabla_Torneo tabla_torneoL = tablaTorneoControladora.EncontrarTablaTorneo(partido.id_local, partido.id_torneo);
            Tabla_Torneo tabla_torneoV = tablaTorneoControladora.EncontrarTablaTorneo((int)partido.id_visitante, partido.id_torneo);


            if (tabla_torneoL == null || tabla_torneoV == null)
            {
                MessageBox.Show("Hubo un error al encontrar equipo tabla", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Convert.ToInt32(txtGolesL.Text) > Convert.ToInt32(txtGolesV.Text))
            {
                tabla_torneoL.puntos += 3;
                tabla_torneoL.goles_a_favor += (int) partido.golesL;
                tabla_torneoL.goles_en_contra += (int) partido.golesV;
                tabla_torneoL.partidos_jugados += 1;
                tabla_torneoL.diferencia = tabla_torneoL.goles_a_favor - tabla_torneoL.goles_en_contra;
                tabla_torneoL.ganados += 1;

                tabla_torneoV.goles_a_favor += (int) partido.golesV;
                tabla_torneoV.goles_en_contra += (int) partido.golesL;
                tabla_torneoV.partidos_jugados += 1;
                tabla_torneoV.diferencia = tabla_torneoV.goles_a_favor - tabla_torneoV.goles_en_contra;
                tabla_torneoV.perdidos += 1;



            }
            else if (Convert.ToInt32(txtGolesL.Text) < Convert.ToInt32(txtGolesV.Text))
            {
                tabla_torneoL.goles_a_favor += (int)partido.golesL;
                tabla_torneoL.goles_en_contra += (int)partido.golesV;
                tabla_torneoL.partidos_jugados += 1;
                tabla_torneoL.diferencia = tabla_torneoL.goles_a_favor - tabla_torneoL.goles_en_contra;
                tabla_torneoL.perdidos += 1;

                tabla_torneoV.goles_a_favor += (int)partido.golesV;
                tabla_torneoV.goles_en_contra += (int)partido.golesL;
                tabla_torneoV.partidos_jugados += 1;
                tabla_torneoV.diferencia = tabla_torneoV.goles_a_favor - tabla_torneoV.goles_en_contra;
                tabla_torneoV.puntos += 3;
                tabla_torneoV.ganados += 1;
            } else
            {
                tabla_torneoL.puntos += 1;
                tabla_torneoL.goles_a_favor += (int)partido.golesL;
                tabla_torneoL.goles_en_contra += (int)partido.golesV;
                tabla_torneoL.partidos_jugados += 1;
                tabla_torneoL.diferencia = tabla_torneoL.goles_a_favor - tabla_torneoL.goles_en_contra;
                tabla_torneoL.empatados += 1;

                tabla_torneoV.puntos += 1;
                tabla_torneoV.goles_a_favor += (int)partido.golesV;
                tabla_torneoV.goles_en_contra += (int)partido.golesL;
                tabla_torneoV.partidos_jugados += 1;
                tabla_torneoV.diferencia = tabla_torneoV.goles_a_favor - tabla_torneoV.goles_en_contra;
                tabla_torneoV.empatados += 1;

            }

            bool actualizarTablaL = tablaTorneoControladora.ActualizarTablaTorneo(tabla_torneoL);

            if (actualizarTablaL == false)
            {
                MessageBox.Show("Hubo un error al actualizar tabla local", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool actualizarTablaV = tablaTorneoControladora.ActualizarTablaTorneo(tabla_torneoV);

            if (actualizarTablaV == false)
            {
                MessageBox.Show("Hubo un error al actualizar tabla visitante", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("Resultado agregado con exito!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            btnRestart.Visible = true;
            formInfoLigaC.LlenarTabla();
            this.ActiveControl = null;
            txtGolesL.ReadOnly = true;
            txtGolesV.ReadOnly = true;



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
            DialogResult resultado = MessageBox.Show("¿Desea restablecer el partido? Esto restablecera las estadisticas", "Si", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.Cancel) return;

            Tabla_Torneo tabla_torneoL = tablaTorneoControladora.EncontrarTablaTorneo(partido.id_local, partido.id_torneo);

            Tabla_Torneo tabla_torneoV = tablaTorneoControladora.EncontrarTablaTorneo((int)partido.id_visitante, partido.id_torneo);

            if (tabla_torneoL == null || tabla_torneoV == null)
            {
                MessageBox.Show("Hubo un error al encontrar tabla", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (partido.ganador == partido.id_local)
            {
                tabla_torneoL.puntos -= 3;
                tabla_torneoL.goles_a_favor -= (int)partido.golesL;
                tabla_torneoL.goles_en_contra -= (int)partido.golesV;
                tabla_torneoL.partidos_jugados -= 1;
                tabla_torneoL.diferencia = tabla_torneoL.goles_a_favor - tabla_torneoL.goles_en_contra;
                tabla_torneoL.ganados -= 1;

                tabla_torneoV.goles_a_favor -= (int)partido.golesV;
                tabla_torneoV.goles_en_contra -= (int)partido.golesL;
                tabla_torneoV.partidos_jugados -= 1;
                tabla_torneoV.diferencia = tabla_torneoV.goles_a_favor - tabla_torneoV.goles_en_contra;
                tabla_torneoV.perdidos -= 1;

            }
            else if (partido.ganador == partido.id_visitante)
            {
                tabla_torneoL.goles_a_favor -= (int)partido.golesL;
                tabla_torneoL.goles_en_contra -= (int)partido.golesV;
                tabla_torneoL.partidos_jugados -= 1;
                tabla_torneoL.diferencia = tabla_torneoL.goles_a_favor - tabla_torneoL.goles_en_contra;
                tabla_torneoL.perdidos -= 1;

                tabla_torneoV.goles_a_favor -= (int)partido.golesV;
                tabla_torneoV.goles_en_contra -= (int)partido.golesL;
                tabla_torneoV.partidos_jugados -= 1;
                tabla_torneoV.diferencia = tabla_torneoV.goles_a_favor - tabla_torneoV.goles_en_contra;
                tabla_torneoV.puntos -= 3;
                tabla_torneoV.ganados -= 1;
            }
            else
            {
                tabla_torneoL.puntos -= 1;
                tabla_torneoL.goles_a_favor -= (int)partido.golesL;
                tabla_torneoL.goles_en_contra -= (int)partido.golesV;
                tabla_torneoL.partidos_jugados -= 1;
                tabla_torneoL.diferencia = tabla_torneoL.goles_a_favor - tabla_torneoL.goles_en_contra;
                tabla_torneoL.empatados -= 1;

                tabla_torneoV.puntos -= 1;
                tabla_torneoV.goles_a_favor -= (int)partido.golesV;
                tabla_torneoV.goles_en_contra -= (int)partido.golesL;
                tabla_torneoV.partidos_jugados -= 1;
                tabla_torneoV.diferencia = tabla_torneoV.goles_a_favor - tabla_torneoV.goles_en_contra;
                tabla_torneoV.empatados -= 1;
            }

            bool restablecerTablaL = tablaTorneoControladora.ActualizarTablaTorneo(tabla_torneoL);
            bool restablecerTablaV = tablaTorneoControladora.ActualizarTablaTorneo(tabla_torneoV);

            if (restablecerTablaL == false || restablecerTablaV == false)
            {
                MessageBox.Show("Hubo un error al restablecer tabla", "Oops! Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            partido.golesL = null;
            partido.golesV = null;
            partido.finalizado = false;
            partido.ganador = 0;

            bool actualizar = partidoControladora.ActualizarPartido(partido);
            
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
            formInfoLigaC.LlenarTabla();
            txtGolesL.Text = "";
            txtGolesV.Text = "";
            this.ActiveControl = null;
            txtGolesL.ReadOnly = true;
            txtGolesV.ReadOnly = true;

        }
    }
}
