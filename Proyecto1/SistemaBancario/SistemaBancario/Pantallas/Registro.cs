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
    public partial class Registro : Form
    {
        Acciones.Conexion con;
        public Registro()
        {            
            InitializeComponent();
            con = new Acciones.Conexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comprobarcampos() == true)
            {
                MySqlConnection cone = con.obtenerConexion();
                if (cone != null)
                {
                    String primer_nombre = txtprimernombre.Text;
                    String segundo_nombre = txtsegundonombre.Text;
                    String tercer_nombre = txttercerapellido.Text;
                    String primer_apellido = txtprimerapellido.Text;
                    String segundo_apellido = txtsegundoapellido.Text;
                    String tercer_apellido = txttercerapellido.Text;
                    String dpi = txtdpi.Text;
                    String no_cuenta = txtnocuenta.Text;
                    String saldo = txtsaldo.Text;
                    String correo = txtcorreo.Text;
                    String pass = txtpassword.Text;
                    if (MessageBox.Show(this, "Esta seguro de continuar esta accion?", "Guardar Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                       int id = con.nuevoUsuario(cone, primer_nombre, segundo_nombre, tercer_nombre, primer_apellido, segundo_apellido, tercer_apellido, dpi, no_cuenta, saldo, correo, pass);
                        if (id != -1)
                        {
                            MessageBox.Show("El codigo de seguridad de su cuenta es: " + id);
                        }
                    }
                }else
                {
                    MessageBox.Show("Ocurrio un error en la conexion a la BD");
                }
                
            }
        }

        private Boolean comprobarcampos()
        {
            if (txtprimernombre.Text == "")
            {
                txtprimernombre.BackColor = Color.Red;
                return false;
            }else
            {
                txtprimernombre.BackColor = Color.White;
            }
            if (txtsegundonombre.Text == "")
            {
                txtsegundonombre.BackColor = Color.Red;
                return false;
            }else
            {
                txtsegundonombre.BackColor = Color.White;
            }
            if (txtprimerapellido.Text == "")
            {
                txtprimerapellido.BackColor = Color.Red;
                return false;
            }else
            {
                txtprimerapellido.BackColor = Color.White;
            }
            if(txtsegundoapellido.Text == "")
            {
                txtsegundoapellido.BackColor = Color.Red;
                return false;
            }else
            {
                txtsegundoapellido.BackColor = Color.White;
            }
            if(txtdpi.Text == "")
            {
                txtdpi.BackColor = Color.Red;
                return false;
            }else
            {
                txtdpi.BackColor = Color.White;
            }
            if (txtnocuenta.Text == "")
            {
                txtnocuenta.BackColor = Color.Red;
                return false;
            }else
            {
                txtnocuenta.BackColor = Color.White;
            }
            if (txtsaldo.Text == "")
            {
                txtsaldo.BackColor = Color.Red;
                return false;
            }else
            {
                txtsaldo.BackColor = Color.White;
            }
            if(txtcorreo.Text == "")
            {
                txtcorreo.BackColor = Color.Red;
                return false;
            }else
            {
                txtcorreo.BackColor = Color.White;
            }
            if (txtpassword.Text == "")
            {
                txtpassword.BackColor = Color.Red;
                return false;
            }else
            {
                txtpassword.BackColor = Color.White;
            }
            return true;
        }
    }
}
