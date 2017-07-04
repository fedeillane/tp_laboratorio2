using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        #region Atributos
        private string _file;
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this._file = archivo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool guardar(string data)
        {
            bool retorno;
            StreamWriter txt = new StreamWriter(this._file, true);

            try
            {
                txt.WriteLine(data);
                retorno = true;
            }
            catch (IOException e)
            {
                Console.Write("Error al guardar: " + this._file + "\x0D\x0A" + e.StackTrace);
                retorno = false;
            }
            finally
            {
                txt.Close();
            }

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool leer(out List<String> data)
        {
            bool retorno;

            try
            {
                var file = File.ReadAllLines(this._file);
                data = new List<String>(file);
                retorno = true;
            }
            catch (Exception e)
            {
                Console.Write("Error al leer: " + this._file + "\x0D\x0A" + e.Message);
                data = new List<String>();
                retorno = false;
            }

            return retorno;
        }

        #endregion
    }
}
