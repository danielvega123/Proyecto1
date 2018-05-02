using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SistemaBancario.Acciones
{
    public class Conexion
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
                Acciones.Sesion.no_cuenta = nombre;
                Acciones.Sesion.credencial = credencial;

                //datosSesion d = datosSesion.instancia2(credencial);
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


        public Boolean existeCuenta(MySqlConnection con, String no_cuenta)
        {
            con.Open();
            String query = "select no_cuenta,concat(primer_nombre,\" \",primer_apellido) as Credencial from usuario where no_cuenta = @no;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@no", no_cuenta);
            MySqlDataReader consultar = cmd.ExecuteReader();
            while (consultar.Read())
            {
                string nombre = consultar.GetString(0);
                string credencial = consultar.GetString(1);
                //datosSesion d = datosSesion.instancia2(credencial);
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        public bool transaccion(MySqlConnection con, String nocuenta, double cantidad, string noCuentaEnt) {
            if (obtenerSaldo(con,nocuenta)>cantidad && existeCuenta(con, noCuentaEnt) && nocuenta!=noCuentaEnt) {


                con.Open();
                String query = "insert into transferencia(cuenta_actual,cuenta_destino,monto)" +
                                "values(@actual, @destino,@monto);";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@actual", Convert.ToInt64(nocuenta));
                cmd.Parameters.AddWithValue("@destino", Convert.ToInt64(noCuentaEnt));
                cmd.Parameters.AddWithValue("@monto", Convert.ToDouble(cantidad));
                cmd.ExecuteNonQuery();
                con.Close();

                double debito = obtenerSaldo(con,nocuenta);
                double abono = obtenerSaldo(con, noCuentaEnt);

                con.Open();
                query = "update usuario set saldo_inicial=@sald where no_cuenta=@no";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@no", nocuenta);
                cmd.Parameters.AddWithValue("@sald", Convert.ToDouble(debito-cantidad));
                cmd.ExecuteNonQuery();

                query = "update usuario set saldo_inicial=@sald where no_cuenta=@no";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@no", noCuentaEnt);
                cmd.Parameters.AddWithValue("@sald", Convert.ToDouble(abono + cantidad));
                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }

            return false;
        }

        public double obtenerSaldo(MySqlConnection con, String nocuenta)
        {
            con.Open();
            double monto = -1;
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
