using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SistemaBancario.Acciones
{
    class Conexion
    {
        String cadena = "server=35.231.149.124;database=Banco;persistsecurityinfo=True;user id = root; password=12345678;Port=3306;SslMode=none;";
        public MySqlConnection obtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(cadena);
            return conexion;
        }        

        public Boolean existeUsuario(MySqlConnection con, String password, String no_cuenta)
        {
            con.Open();
            String query = "select no_cuenta,concat(primer_nombre,\" \",primer_apellido) as Credencial from usuario where no_cuenta = @no and contrasenia= @pass;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@no", no_cuenta);
            cmd.Parameters.AddWithValue("@pass", password);
            MySqlDataReader consultar = cmd.ExecuteReader();
            while (consultar.Read())
            {
                string nombre = consultar.GetString(0);
                string credencial = consultar.GetString(1);
                MessageBox.Show("Bienvenido:\n" + credencial + "\n");
                Acciones.Sesion.no_cuenta = nombre;
                Acciones.Sesion.credencial = credencial;
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        //p = primer
        //s = segundo
        //t = tercero
        //n = nombre
        //a = apellido
        public int nuevoUsuario(MySqlConnection con, String pn, String sn, String tn, String pa, String sa, String ta, String dpi, String noCuenta, String monto, String correo, String pass)       
        {
            con.Open();
            String query = "insert into usuario(no_cuenta,primer_nombre,segundo_nombre,tercer_nombre,primer_apellido,segundo_apellido,tercer_apellido,dpi,saldo_inicial,correo,contrasenia)" +
                            "values(@no, @pn, @sn, @tn,@pa, @sa,@ta, @dpi, @saldo, @email, @pass);";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@no", Convert.ToInt64(noCuenta));
            cmd.Parameters.AddWithValue("@pn", pn);
            cmd.Parameters.AddWithValue("@sn", sn);
            cmd.Parameters.AddWithValue("@tn", tn);
            cmd.Parameters.AddWithValue("@pa", pa);
            cmd.Parameters.AddWithValue("@sa", sa);
            cmd.Parameters.AddWithValue("@ta", ta);
            cmd.Parameters.AddWithValue("@dpi", dpi);
            cmd.Parameters.AddWithValue("@saldo", Convert.ToDouble(monto));
            cmd.Parameters.AddWithValue("@email", correo);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.ExecuteNonQuery();

            query = "select id_usuario from usuario where no_cuenta = @no";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@no", noCuenta);
            MySqlDataReader consultar = cmd.ExecuteReader();
            while (consultar.Read())
            {
                int id = (int) consultar.GetInt32(0);
                con.Close();
                return id;
            }
            con.Close();
            return -1;
        }

        public double obtenerSaldo(MySqlConnection con, String nocuenta)
        {
            con.Open();
            double monto = 0;
            String query = "select saldo_inicial from usuario where no_cuenta = @no";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@no", nocuenta);
            MySqlDataReader consultar = cmd.ExecuteReader();
            while (consultar.Read())
            {
                monto = (double)consultar.GetDouble(0);
                con.Close();
                return monto;
            }
            con.Close();
            return monto;
        }
    }
}
