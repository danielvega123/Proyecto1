using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using SistemaBancario.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaBancario.Acciones.Tests
{
    [TestClass()]
    public class ConexionTests
    {
        [TestMethod()]
        public void existeUsuarioTest()
        {
            Conexion con = new Conexion();
            MySqlConnection cone = con.obtenerConexion();
            //VALIDAR ID Y CONTRASEÑA
            bool validar = con.existeUsuario(cone, "8888", "88585858");

            //ASSERT
            //Assert.AreEqual(false,validar);

            //SEGUNDA VALIDACION:

            validar = con.existeUsuario(cone, "8103", "81038103");

            //ASSERT
            Assert.AreEqual(validar, true);
        }

        [TestMethod()]
        public void nuevoUsuarioTest()
        {
            Conexion con = new Conexion();
            MySqlConnection cone = con.obtenerConexion();
            //VALIDAR REGISTRO
            //int validar = con.nuevoUsuario(cone, "juan", "paco", "pedro", "delamar", "me", "llamoyo", "56556", "5555", "500", "correo", "1234");
            
            //REGISTRO CORRECTO
            //Assert.AreNotEqual(validar, -1);
        }

        [TestMethod()]
        public void existeCuentaTest()
        {
            Conexion con = new Conexion();
            MySqlConnection cone = con.obtenerConexion();
            //VALIDAR ID 
            bool validar = con.existeCuenta(cone, "88585858");

            //ASSERT
            Assert.AreEqual(false, validar);

            //SEGUNDA VALIDACION:

            validar = con.existeCuenta(cone, "81038103");

            //ASSERT
            Assert.AreEqual(validar, true);
        }

        [TestMethod()]
        public void transaccionTest()
        {
            Conexion con = new Conexion();
            MySqlConnection cone = con.obtenerConexion();
            //VALIDAR cuenta a la que se le transfiere exista
            bool validar = con.transaccion(cone, "81038103", 500, "12396587");

            //ASSERT
            Assert.AreEqual(false, validar);

            //SEGUNDA VALIDACION: MONTO EXISTENTE EN CUENTA
            validar = con.transaccion(cone, "81038103", 5000000, "8103");

            //ASSERT
            Assert.AreEqual(false, validar);

            //TERCERA VALIDACION: 
            validar = con.transaccion(cone, "81038103", 50, "8103");

            //ASSERT
            Assert.AreEqual(true, validar);
        }

        [TestMethod()]
        public void obtenerSaldoTest()
        {
            Conexion con = new Conexion();
            MySqlConnection cone = con.obtenerConexion();
            //VALIDAR ID 
            double validar = con.obtenerSaldo(cone, "88585858");

            //ASSERT
            Assert.AreEqual(-1, validar);

            //SEGUNDA VALIDACION:

            validar = con.obtenerSaldo(cone, "81038103");

            //ASSERT
            Assert.AreNotEqual(-1, validar);
        }
    }
}