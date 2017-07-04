using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto
    {
        public static bool leer(string archivo, out string datos)
        {
            StreamReader reader = new StreamReader(archivo);
            datos = reader.ReadToEnd();
            reader.Close();
            return true;
        }
        
        public static bool guardar(string archivo, string datos)
        {
            StreamWriter writer = new StreamWriter(archivo, false);
            bool retorno = true;
            try
            {
                writer.Write(datos);
            }
            catch (IOException e)
            {
                Console.Write(e.StackTrace);
                retorno = false;
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }
    }
}
