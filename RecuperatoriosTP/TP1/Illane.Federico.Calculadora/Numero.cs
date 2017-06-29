using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illane.Federico.Calculadora
{
    class Numero
    {
        #region Atributos
        private double _numero;
        #endregion

        #region Constructores

        /**
         * Constructor por defecto
         * */
        public Numero()
        {
            this._numero = 0;
        }

        /**
        * Constructor que setea un double al numero
        * */
        public Numero(double numero)
        {
            this._numero = numero;
        }

        /**
        * Constructor que setea un string parseado al numero
        * si el valor no es valido devuelve cero.
        * */
        public Numero(string numero) 
        {
            this.setNumero(numero);
        }
        #endregion

        #region Metodos
        /**
         * Metodo privado y estatico que toma el numero y lo valida
         * 
         * @param name="numeroString"
         * @returns double
         * */
        private static double validarNumero(string numeroString)
        {
            double retorno;
            Double.TryParse(numeroString, out retorno);
            return retorno;
        }

        /**
         * Metodo publico que recupera el numero
         * 
         * @returns double
         * */
        public double getNumero()
        {
          return this._numero;
        }

        /**
        * Metodo privado que setea el numero
        * 
        * @param name="value"
        * @returns void
        * */
        private void setNumero(string value)
        {
            this._numero = Numero.validarNumero(value);
        }
        #endregion
    }
}
