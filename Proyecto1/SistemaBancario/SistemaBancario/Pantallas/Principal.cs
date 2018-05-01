using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario.Pantallas
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            lblcredencial.Text = Acciones.Sesion.no_cuenta + " - " + Acciones.Sesion.credencial;
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
