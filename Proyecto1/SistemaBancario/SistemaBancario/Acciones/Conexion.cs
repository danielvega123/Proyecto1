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
            }
            con.Close();
            return false;
        }
    }
}
