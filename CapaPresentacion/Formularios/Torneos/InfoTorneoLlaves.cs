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
        Torneo torneoSeleccionado;
        formInicio formInicioC;
        CC_Partido partidoControladora = CC_Partido.getInstance;
        CC_Reglas reglasControladora = CC_Reglas.getInstance;
        CC_TorneoEquipos torneoEquiposControladora = CC_TorneoEquipos.getInstance;
        int cantidadInstancias;
        public formInfoTorneoLlaves(Torneo torneo, formInicio formInicio)
        {
            InitializeComponent();
            torneoSeleccionado = torneo;
            formInicioC = formInicio;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            formInicioC.AbrirFormulario(new formTorneos(formInicioC)); // Sirve para ocultar el formulario actual y abrir el formulario de usuarios

        }

        public void formInfoTorneoLlaves_Load(object sender, EventArgs e)
        {
            lblTorneo.Text = torneoSeleccionado.nombre;
            List<Partido> listaLlaves = partidoControladora.EncontrarPartidosTorneo(torneoSeleccionado.id_torneo);

            flp.Controls.Clear();
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.LeftToRight; // Alineación horizontal
            flp.WrapContents = false; // Evita que los paneles bajen a una nueva línea
            flp.Height = 604;
            var instanciasUnicas = listaLlaves.Select(p => p.instancia).Distinct().ToList();
            int index = 0;
            foreach (var instancia in instanciasUnicas)
            { 
                Panel panelInstancia = new Panel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Padding = new Padding(10),
                    Margin = new Padding(5), // Espacio entre paneles
                    Height = flp.Height - 20,  // Asegurarse de que ocupe toda la altura
                    Width = 500, // Ancho calculado para cada panel
                    AutoScroll = true,
                };

                panelInstancia.MinimumSize = new Size(500, 0);

                if (index > 0)
                {
                    panelInstancia.Height = flp.Controls[0].Height;
                }

                index++;
                int totalHeight = 0;
                List<Control> controles = new List<Control>();

                foreach (Partido partido in listaLlaves.Where(p => p.instancia == instancia))
                {
                    formDisenioLlave formDisenioLlave = new formDisenioLlave(partido, this)
                    {
                        TopLevel = false,
                        FormBorderStyle = FormBorderStyle.None,
                        AutoSize = true,
                    };

                    controles.Add(formDisenioLlave);
                    totalHeight += formDisenioLlave.Height;
                    formDisenioLlave.Show();
                }

                int spaceTop = Math.Max(10, (panelInstancia.Height - totalHeight) / 2);

                foreach (Control ctrl in controles)
                {
                    ctrl.Top = spaceTop;
                    ctrl.Left = (panelInstancia.Width - ctrl.Width) / 2;
                    panelInstancia.Controls.Add(ctrl);
                    spaceTop += ctrl.Height + 5;
                }

                flp.Controls.Add(panelInstancia);
            }
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            Reglas reglas = reglasControladora.Listar().Where(r => r.id_torneo == torneoSeleccionado.id_torneo).FirstOrDefault();
            if (reglas == null)
            {
                MessageBox.Show("No se han definido reglas para este torneo", "Reglas no definidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            formTorneoReglas formReglasS = new formTorneoReglas(torneoSeleccionado);
            formReglasS.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
               $"¿Desea eliminar el torneo {torneoSeleccionado.nombre}?",
               "Confirmar Resultado",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question);

            if (resultado == DialogResult.Cancel) return;

            bool borrarVinculaciones = torneoEquiposControladora.BorrarVinculaciones(torneoSeleccionado.id_torneo);

            if (borrarVinculaciones == false)
            {
                MessageBox.Show("No se pudo eliminar el torneo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            bool borrar = CC_Torneos.getInstance.BorrarTorneo(torneoSeleccionado.id_torneo);

            if (borrar == false)
            {
                MessageBox.Show("No se pudo eliminar el torneo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Torneo eliminado correctamente", "Torneo eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnVolver_Click(sender, e);
        }
    }
}
