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

namespace SistemaBancario
{
    public partial class Form1 : Form
    {
        Acciones.Conexion con;
        public Form1()
        {
            InitializeComponent();
            con = new Acciones.Conexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cone = con.obtenerConexion();
            if (cone != null)
            {
                String no_cuenta = txtuser.Text;
                String pass = txtpass.Text;
                con.existeUsuario(cone, pass, no_cuenta);
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {

        }
    }
}
