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
        int intentos = 0;
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

                datosSesion datos = datosSesion.instancia(no_cuenta, pass);
                Boolean existe = con.existeUsuario(cone, pass, no_cuenta);
                if (existe == true)
                {
                    //PASA A LA PANTALLA DE INICIO



                    MessageBox.Show("Bienvenido:\n" + Acciones.Sesion.credencial + "\n");
                    Pantallas.Principal p = new Pantallas.Principal();
                    p.Show();
                    this.Visible = false;
                }
                else
                {
                    datosSesion.limpia();
                    if (intentos < 3)
                    {
                        MessageBox.Show("Credenciales incorrectas");
                        intentos++;
                    }else
                    {
                        MessageBox.Show("Llego al limite de intentos por sesion");
                    }
                }
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            Pantallas.Registro r = new Pantallas.Registro();
            r.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
