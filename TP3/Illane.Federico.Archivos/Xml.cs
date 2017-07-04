using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            StreamWriter str = new StreamWriter(archivo, false);
            XmlSerializer xml = new XmlSerializer(typeof(T));
            bool retorno = true;
            try
            {
                xml.Serialize(str, datos);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.ToString());
                retorno = false;
            }
            finally
            {
                str.Close();
            }

            return retorno; 
        }

        public bool leer(string archivo, out T datos)
        { 
            datos = default(T);
            return true; 
        }
    }
}
