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

namespace CapaPresentacion.Formularios.Torneos
{
    public partial class formInfoTorneoLlaves : Form
    {
        formTorneos formTorneos;
        Torneo torneoSeleccionado;
        formInicio formInicioC;
        CC_Partido partidoControladora = CC_Partido.getInstance;
        public formInfoTorneoLlaves(formTorneos formularioTorneos, Torneo torneo, formInicio formInicio)
        {
            InitializeComponent();
            formTorneos = formularioTorneos;
            torneoSeleccionado = torneo;
            formInicioC = formInicio;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.AbrirFormulario(new formTorneos(formInicioC)); // Sirve para ocultar el formulario actual y abrir el formulario de usuarios

        }

        private void formInfoTorneoLlaves_Load(object sender, EventArgs e)
        {
            lblTorneo.Text = torneoSeleccionado.nombre;
            List<Partido> listaLlaves = partidoControladora.EncontrarPartidosTorneo(torneoSeleccionado.id_torneo);

            // Limpiar panel antes de agregar nuevos controles
            panel5.Controls.Clear();

            // Calcular el número de rondas basado en el número de partidos (se asume eliminación simple)
            int rondas = (int)Math.Ceiling(Math.Log(listaLlaves.Count) / Math.Log(2));
            int anchoPanel = panel5.Width;
            int altoPanel = panel5.Height;

            // Calcular el tamaño para cada partido (considera cuántos partidos caben en el espacio disponible)
            int alturaEspaciada = altoPanel / listaLlaves.Count;
            int anchoControl = 150; // Ancho predeterminado para cada control de partido

            // Agregar los formularios de cada partido al panel5
            foreach (Partido partido in listaLlaves)
            {
                formDisenioLlave formDisenioLlave = new formDisenioLlave(partido);
                formDisenioLlave.TopLevel = false;
                formDisenioLlave.Dock = DockStyle.Top;

                // Cálculo de posiciones para distribuir los partidos
                int x = (anchoPanel / rondas) * (listaLlaves.IndexOf(partido) / 2); // Distribuir horizontalmente
                int y = listaLlaves.IndexOf(partido) * alturaEspaciada; // Distribuir verticalmente

                formDisenioLlave.Location = new Point(x, y);

                panel5.Controls.Add(formDisenioLlave);
                formDisenioLlave.Show();
            }


        }




    }
}
