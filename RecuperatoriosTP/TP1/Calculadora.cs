using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illane.Federico.Calculadora
{
    class Calculadora
    {
        #region Atributos
        private static string suma = "+";
        private static string resta = "-";
        private static string multiplicacion = "*";
        private static string division = "/";
        #endregion

        #region Metodos
        /**
         * Metodo estatico y publico que opera los numeros.
         * 
         * @param name="numero1"
         * @param name="numero2"
         * @param name="operador"
         * @returns string
         * */
        public static double operar(Numero numero1 , Numero numero2, string operador)
        {
            double resultado = 0;
            double operando1 = numero1.getNumero();
            double operando2 = numero2.getNumero();
            string operadorLocal = Calculadora.validarOperador(operador);

            if(operadorLocal.Equals(suma))
            {
                resultado = operando1 + operando2;
            }
            else if(operadorLocal.Equals(resta))
            {
                resultado = operando1 - operando2;
            }
            else if (operadorLocal.Equals(multiplicacion))
            {
                resultado = operando1 * operando2;
            }
            else if (operadorLocal.Equals(division) && operando2 != 0)
            {
                resultado = operando1 / operando2;
            }

            return resultado;
        }

        /**
         * Metodo estatico y publico que valida el operador.
         * 
         * @param name="operador"
         * @returns string
         * */
        public static string validarOperador(string operador)
        {
            string retorno = suma;

            if (operador.Equals(resta) || operador.Equals(multiplicacion) || operador.Equals(division))
            {
                retorno = operador;
            }

            return retorno;
        }
        #endregion
    }
}
