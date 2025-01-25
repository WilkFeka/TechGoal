using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Personalizacion;
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
    public partial class formVincularTorneoEquipos : Form
    {

        Funcionalidades funcionalidades = Funcionalidades.getInstance;
        CC_Equipos EquiposControladora = CC_Equipos.getInstance;
        CC_Torneos TorneosControladora = CC_Torneos.getInstance;

        public List<ListViewItem> Resultados;
        int cantEquipos;
        int Seleccionados = 0;
        public formVincularTorneoEquipos(int cantidadEquipos)
        {
            InitializeComponent();
            cantEquipos = cantidadEquipos;
        }

        private void formVincularTorneoEquipos_Load(object sender, EventArgs e)
        {

            List<Equipo> equipos = EquiposControladora.EncontrarEquiposLibres();

            listViewLibres.Columns.Add("Nombre", -2);
            listViewAgregados.Columns.Add("Nombre", -2);


            foreach (Equipo equipo in equipos)
            {
                ListViewItem item = new ListViewItem(equipo.nombre);
                item.Tag = equipo.id_equipo;
                listViewLibres.Items.Add(item);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewLibres_MouseClick(object sender, MouseEventArgs e)
        {


            var clickedItem = listViewLibres.GetItemAt(e.X, e.Y);
            if (clickedItem.Checked == false)
                clickedItem.Checked = (listViewLibres.CheckedItems.Count + listViewAgregados.Items.Count) < cantEquipos;
            else clickedItem.Checked = false;
           
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (listViewAgregados.Items.Count >= cantEquipos)
            {
                MessageBox.Show("No se pueden agregar más equipos. Has alcanzado el límite.");
                return; 
            }

            listViewLibres.CheckedItems.Cast<ListViewItem>().ToList().ForEach(item =>
            {
                item.Checked = false;

                ListViewItem itemCopy = (ListViewItem)item.Clone();
                listViewLibres.Items.Remove(item);
                listViewAgregados.Items.Add(itemCopy);
            });
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            listViewAgregados.CheckedItems.Cast<ListViewItem>().ToList().ForEach(item =>
            {
                item.Checked = false;
                ListViewItem itemCopy = (ListViewItem)item.Clone();
                listViewAgregados.Items.Remove(item);
                listViewLibres.Items.Add(itemCopy);

            });

        }

        private void listViewAgregados_MouseClick(object sender, MouseEventArgs e)
        {
            var clickedItem = listViewAgregados.GetItemAt(e.X, e.Y);
            if (clickedItem != null)
            {
                // Cambiar el estado de Check
                clickedItem.Checked = !clickedItem.Checked;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (listViewAgregados.Items.Count != cantEquipos)
            {
                MessageBox.Show("Debe agregar " + Convert.ToString(cantEquipos) + " equipos en total.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                Resultados = listViewAgregados.Items.Cast<ListViewItem>().ToList();
                this.DialogResult = DialogResult.OK; // Indica que se aceptó
                this.Close(); // Cierra el formulario
            }

        }

        private void listViewAgregados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var clickedItem = listViewLibres.GetItemAt(e.X, e.Y);


        }

        private void listViewLibres_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left && e.NewValue != e.CurrentValue)
            {
                e.NewValue = e.CurrentValue; // Cancela el cambio de check
            }
        }
    }
}
