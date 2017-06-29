using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Illane.Federico.TP3.EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        protected string _nombre;
        protected string _apellido;
        protected ENacionalidad _nacionalidad;
        protected int _dni;
        #endregion

        #region Propiedades
        public abstract string Apellido { get; set; }
        public abstract int DNI { get; set; }
        public abstract ENacionalidad Nacionalidad { get; set; }
        public abstract string Nombre { get; set; }
        public abstract string StringToDNI { set; }
        #endregion

        #region Constructores
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            //TODO --> Terminar constructor

        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return this._apellido + ", " + this._nombre + ".DNI: " + this._dni + ".Nacionalidad: " + this._nacionalidad;
        }

        protected int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                    return dato;
                else
                    throw DniInvalidoException; 
            }
            else
            {
                if(dato >= 90000000)
                    return dato;
                else
                    throw DniInvalidoException; 
            }
        }

        protected int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 0;
        }

        protected string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("");
            if (r.IsMatch(dato))
            {

            }
            
            return "";
        }
        #endregion

    }
}
