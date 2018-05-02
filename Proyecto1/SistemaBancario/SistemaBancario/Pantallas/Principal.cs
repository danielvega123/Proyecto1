using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaBancario.Pantallas
{
    public partial class Principal : Form
    {
        Acciones.Conexion con;
        public Principal()
        {
            InitializeComponent();
            lblcredencial.Text = Acciones.Sesion.no_cuenta + " - " + Acciones.Sesion.credencial;
            con = new Acciones.Conexion();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
          
        }

        private void txtconsultar_Click(object sender, EventArgs e)
        {
            MySqlConnection cone = con.obtenerConexion();
            if (cone != null)
            {
                double saldo = con.obtenerSaldo(cone, Acciones.Sesion.no_cuenta);
                MessageBox.Show("El saldo de su cuenta es : " + saldo);
            }
        }

        private void txttransferencia_Click(object sender, EventArgs e)
        {
            transferencia t = new transferencia();
            t.Show();
            this.Visible=false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 p = new Form1();
            p.Show();
            this.Visible = false;
        }
    }
}
