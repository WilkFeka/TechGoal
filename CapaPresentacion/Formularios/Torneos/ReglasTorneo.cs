using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Torneos
{
    public partial class formReglasTorneo : Form
    {
        public string reglas;
        public formReglasTorneo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formReglasTorneo_Load(object sender, EventArgs e)
        {
        }

        private void rtxtReglas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                rtxtReglas.AppendText(Environment.NewLine); // Agregar un salto de línea
                e.Handled = true; // Evitar que se procese más
            }
        }

        private void rtxtReglas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rtxtReglas.AppendText(Environment.NewLine);
                e.SuppressKeyPress = true; // Bloquea el procesamiento estándar
            }
        }

        private void rtxtReglas_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Evitar que el formulario procese la tecla Enter
                rtxtReglas.AppendText(Environment.NewLine); // Agregar salto de línea
            }
        }

        private void rtxtReglas_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void rtxtReglas_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnAceptar;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtxtReglas.Text)) // Verifica si está vacío o tiene solo espacios
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show(
                    "¿Está seguro de no agregar reglas?",
                    "Atención",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return; // No cierra el formulario si elige "No"
                }
                else
                {
                    this.DialogResult = DialogResult.OK; // Indica que se aceptó
                    this.Close(); // Cierra el formulario
                }
            }
            else
            {
                reglas = rtxtReglas.Text;
                this.DialogResult = DialogResult.OK; // Indica que se aceptó
                this.Close(); // Cierra el formulario
            }
        }
    }
}
