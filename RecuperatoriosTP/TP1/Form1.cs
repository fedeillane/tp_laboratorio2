using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Illane.Federico.Calculadora
{
    public partial class formCalculadora : Form
    {
        Numero numero1;
        Numero numero2;
        
        public formCalculadora()
        {
            InitializeComponent();
        }

        #region Eventos

        /**
         * Evento del boton CC que pone todos los  valores de los componentes
         * de la calculadora en su valor por defecto
         * */
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            labelResultado.Text = "0";
            
            comboBoxOperaciones.Text = "+";

            textBoxNumero1.Text = "0";

            textBoxNumero2.Text = "0";

        }

        /**
         * Evento del boton Operar opera sobre los numeros que se agregaron
         * */
        private void buttonIgual_Click(object sender, EventArgs e)
        {
            double resultado = 0;
            string operador = comboBoxOperaciones.Text;

            // Inicializo los numeros con su constructor 
            numero1 = new Numero(textBoxNumero1.Text);
            numero2 = new Numero(textBoxNumero2.Text);

            // Si el operador es una division y si el numero 2 es igual a cero me muestra el error en el label resultado
            if (operador.Equals("/") && numero2.getNumero() == 0)
            {
                labelResultado.Text = "Error! No se puede divir por cero";
            }
            else
            {
                // Caso contrario hago la operacion normalmente
                resultado = Calculadora.operar(numero1, numero2, operador);
                labelResultado.Text = resultado.ToString();
            }

           
        }

        #endregion
    }
}
