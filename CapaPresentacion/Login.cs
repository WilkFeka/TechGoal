using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            Font fuenteComun = new Font("Arial", 10, FontStyle.Regular);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmInicio frmInicio = new frmInicio();
            frmInicio.Show();
            this.Hide();

            frmInicio.FormClosing += frm_closing;

        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtEmail.Text = "";
            txtClave.Text = "";

            this.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Tema.cambiarTema("Dark");
            this.BackColor = Tema.colorOscuro;
            this.lblClave.ForeColor = Tema.colorClaro;
            this.lblEmail.ForeColor = Tema.colorClaro;
            this.btnCancelar.BackColor = Tema.colorSecundario;

        }
    }
}
