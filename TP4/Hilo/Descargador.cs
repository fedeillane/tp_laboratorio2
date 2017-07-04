using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        #region Atributos
        private string html;
        private Uri direccion;
        #endregion

        #region Delegados
        public delegate void progresoCarga(int progreso);
        public delegate void descargaCompleta(string resultado);
        #endregion

        #region Eventos
        public event progresoCarga progreso;
        public event descargaCompleta descargaFinalizada;
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="direccion"></param>
        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        /// <summary>
        /// 
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progreso(e.ProgressPercentage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                this.descargaFinalizada(this.html);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error al intentar acceder a URL solicitada: " + err.Message);
            }
        }
        #endregion
    }
}
