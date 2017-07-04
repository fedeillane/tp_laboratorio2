using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada : Texto
    {
        #region Atributos
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        #endregion

        #region Constructores
        private Jornada()
        {
            _alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            return Texto.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            string retorno = "";

            Texto.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out retorno);

            return retorno;
        }

        /// <summary>
        /// Mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder a = new StringBuilder();
            a.AppendLine("CLASE DE " + this.Clase + " POR " + this.Instructor.ToString());
            a.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.Alumnos)
            {
                a.AppendLine(item.ToString());
            }
            a.AppendLine("**********************************************************************\n");
            return a.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada a, Alumno b)
        {
            bool retorno = false;
            foreach (Alumno item in a._alumnos)
            {
                if( item == b)
                    retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Una Jornada no será igual a un Alumno si el mismo no participa de ella.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada a, Alumno b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada a, Alumno b)
        {
            if (a != b)
                a.Alumnos.Add(b);
            return a;
        }
        #endregion

    }
}
