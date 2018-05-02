using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario
{
    public class datosSesion
    {
        public string no_cuenta;
        public string contra, nombre;
        private static datosSesion ins;


        private datosSesion(string no_cuenta,string contra) {
            this.no_cuenta = no_cuenta;
            this.contra = contra;

        }

        public static datosSesion instancia(string no_cuenta, string contra) {
            if (ins==null) {
                ins = new datosSesion(no_cuenta,contra);
                
            }
            return ins;
        }

        public static datosSesion instancia()
        {
            return ins;
        }

        public static datosSesion instancia2(string nombre)
        {
            ins.nombre = nombre;
            return ins;
        }

        public static void limpia()
        {
            ins = null;
        }


    }
}
