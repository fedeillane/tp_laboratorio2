using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illane.Federico.TP3.EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        #region Atributos
        protected int _identificador;
        #endregion

        #region Constructor
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
