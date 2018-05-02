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
    public partial class transferencia : Form
    {
        public transferencia()
        {
            InitializeComponent();
        }

        private void transferencia_Load(object sender, EventArgs e)
        {
           

            this.label3.Text=("no. Cuenta: " +Acciones.Sesion.no_cuenta + "\n nombre:" + Acciones.Sesion.credencial);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Acciones.Conexion con = new Acciones.Conexion();
          
                double noCuenta = Convert.ToDouble(this.textBox1.Text.ToString());
                double saldo = Convert.ToDouble(this.textBox2.Text.ToString());
           bool ver= con.transaccion(con.obtenerConexion(),Acciones.Sesion.no_cuenta,saldo,noCuenta.ToString());
            if (ver)
            {

                MessageBox.Show("Transaccion Efectuada con exito \n");
            }
            else {
                MessageBox.Show("Transaccion no Efectuada con exito \n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            p.Show();
            this.Visible = false;
        }
    }
}
