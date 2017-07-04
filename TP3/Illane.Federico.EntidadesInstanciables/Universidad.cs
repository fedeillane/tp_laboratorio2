using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { jornada = value; }
        }

        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexador.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return jornada[i]; }
            set { jornada[i] = value; }
        }
        #endregion

        #region Constructores
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Los datos del Universidad se harán públicos mediante ToString.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="u"></param>
        /// <returns>bool</returns>
        public static bool Guardar(Universidad u)
        {
            StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", false);
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));
            bool retorno = true;
            try
            {
                xml.Serialize(writer, u);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.ToString());
                retorno = false;
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        private string MostrarDatos(Universidad u)
        {
            StringBuilder str = new StringBuilder("");
            str.AppendLine("JORNADA: ");
            foreach (Jornada item in u.Jornadas)
            {
                str.AppendLine(item.ToString());
            }

            return str.ToString();
        }

        /// <summary>
        /// Los datos del Universidad se harán públicos mediante ToString.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml");
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));

            Universidad uni = (Universidad)xml.Deserialize(reader);

            reader.Close();

            return uni;

        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in u.Alumnos)
        	{
                if (item == a)
                    retorno = true;
	        }

            return retorno;
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases c)
        {
            Profesor retorno = null;
            foreach (Profesor item in u.Instructores)
            {
                if (item == c)
                    retorno = item;
            }
            return retorno;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            bool retorno = false;
            foreach (Profesor item in u.Instructores)
            {
                if (item == p)
                    retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases c)
        {
            Profesor retorno = null;
            foreach (Profesor item in u.Instructores)
            {
                if (item != c)
                    retorno = item;
            }
            return retorno;
        }

        /// <summary>
        /// Un Universidad no será igual a un Profesor si el mismo no está dando clases en él.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return u;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman 
        /// (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="u"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases c)
        {
            Profesor p = (u == c);
            List<Alumno> alumnos = new List<Alumno>();
            Jornada j = null;

            if (!(Object.Equals(p, null)))
                j = new Jornada(c, p);
            else
                throw new SinProfesorException();
            if (!(Object.Equals(j, null)))
            {
                foreach (Alumno item in u.Alumnos)
                {
                    if (item == c)
                        j = j + item;
                }
                u.Jornadas.Add(j);
            }
            return u;
        }

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
                u.Instructores.Add(p);
            else
                throw new SinProfesorException();

            return u;
        }
        #endregion

        #region Enumerado
        public enum EClases
        {
            Programacion,
            Legislacion,
            Laboratorio,
            SPD
        }
        #endregion
    }
}
