using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributo
        protected int _legajo;
        #endregion

        #region Constructor
        public Universitario():base() { }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Dos Universitarios serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (this == (Universitario)obj);
        }

        /// <summary>
        /// Retornará todos los datos del Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder a = new StringBuilder();
            a.AppendLine(base.ToString());
            a.Append("LEGAJO NUMERO: " + this._legajo);

            return a.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Universitario a, Universitario b)
        {

            return ((a is Universitario && b is Universitario) && (a._legajo == b._legajo || a.DNI == b.DNI));
        }

        public static bool operator !=(Universitario a, Universitario b) { return !(a == b); }

        #endregion
    }
}
