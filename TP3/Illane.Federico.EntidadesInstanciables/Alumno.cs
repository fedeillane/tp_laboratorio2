using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        private EEstadoCuenta _estadoCuenta;
        private Universidad.EClases _claseQueToma;
        #endregion

        #region Constructores
        public Alumno() : base() { }

        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(legajo, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retornará la cadena "TOMA CLASES DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma + "\n";
        }

        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder a = new StringBuilder("");
            a.AppendLine(base.MostrarDatos());
            a.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            a.AppendLine(this.ParticiparEnClase());
            return a.ToString();
        }

        /// <summary>
        /// ToString hará públicos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga de Operados
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases b)
        {
            bool retorno = false;

            if (a._claseQueToma.Equals(b) && !(a._estadoCuenta.Equals(EEstadoCuenta.Deudor)))
                retorno = true;
                
            return retorno;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases b)
        {
            return !(a._claseQueToma.Equals(b));
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// 
        /// </summary>
        public enum EEstadoCuenta
        {
            Becado,
            Deudor,
            AlDia
        }
        #endregion

    }
}
