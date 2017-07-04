using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region Constructores
        static Profesor()
        {
            _random = new Random();
        }
        public Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._clasesRandom();
        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this()
        {
            this._legajo = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.StringToDNI = dni;
            this.Nacionalidad = nacionalidad;
        }
        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor a, Universidad.EClases b)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in a._clasesDelDia)
            {
                if (item.Equals(b))
                    retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Un Profesor no será igual a un EClase si no da esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor a, Universidad.EClases b)
        {
            return !(a == b);
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Se asignarán dos clases al azar al Profesor mediante el método randomClases. Las dos clases pueden o no ser la misma.
        /// </summary>
        private void _clasesRandom()
        {
            Array valores = Enum.GetValues(typeof(Universidad.EClases));

            for (int i = 0; i < 2; i++)
            {
                Universidad.EClases claseRandom = (Universidad.EClases)valores.GetValue(_random.Next(valores.Length));
                this._clasesDelDia.Enqueue(claseRandom);
            }
        }

        /// <summary>
        /// Retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder a = new StringBuilder();
            a.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                a.AppendLine(item.ToString());                
            }
            return a.ToString();
        }

        /// <summary>
        /// Sobreescribirá el método MostrarDatos con todos los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder a = new StringBuilder();
            a.AppendLine(base.MostrarDatos());
            a.AppendLine(this.ParticiparEnClase());

            return a.ToString();
        }

        /// <summary>
        /// Hará públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
