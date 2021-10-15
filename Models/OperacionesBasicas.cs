using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactuando.Models
{
    public class OperacionesBasicas
    {
        double numeroAuxiliar;
        string signoAritmetico;
        double resultado;
        string numeroPantallaSecundaria, numeroPantallaPrincipal;
        bool presionarIgual = false; //hace referencia ha si se ha dado click en igual

        //public double NumeroAuxiliar { set { numeroAuxiliar = value; } }
        public string NumeroPantallaSecundaria { get=> numeroPantallaSecundaria;  }
        public string NumeroPantallaPrincipal { get => numeroPantallaPrincipal; }
        public string SignoAritmetico{ set { signoAritmetico = value; } }
        public double Resultado { get { return resultado; } }

        public void LimpiarCalculadora()
        {
            //reiniciamos valores
            numeroAuxiliar = 0;
            resultado = 0;
            //txtPantallaPrincipal.Text = "0";
            //lblPantallaSecundaria.Content = "0";
        }
        public string BorrarUltimoNumeroDigitado(string numeroPantallaPrincipal)
        {
            if ((numeroPantallaPrincipal).ToLower() == "nan")
            {
                numeroPantallaPrincipal = "0";
            }

            else if (numeroPantallaPrincipal != "" & numeroPantallaPrincipal != "0")
            {
                List<char> NumBorrar = new List<char>();

                NumBorrar.AddRange(numeroPantallaPrincipal);

                NumBorrar.RemoveAt(NumBorrar.Count - 1);

                numeroPantallaPrincipal = "";

                if (NumBorrar.Count > 0)
                {
                    foreach (char x in NumBorrar)
                    {

                        numeroPantallaPrincipal += x;

                    }
                }

                else numeroPantallaPrincipal = "0";//cuando se elimina un unico elemento 
                //txtPantallaPrincipal queda vacio, por esto coloco el "else"

                NumBorrar.Clear();

            }

            return numeroPantallaPrincipal;
        }

        //operacion()
        public void Realizarcalculo(string pNumeroPantallaSecundaria, string pNumeroPantallaPrincipal, string pSigno)
        {
            numeroPantallaPrincipal = pNumeroPantallaPrincipal;
            numeroPantallaSecundaria = pNumeroPantallaSecundaria;

            // aquí el, mas (+), también funciona como el botón igual
            // ya que también nos puede dar el resultado

            string pValor = (string)numeroPantallaSecundaria;

            // agregamos el signo de operación y preparamos para que el usario
            // pueda digitar el siguiente valor
            if (!pValor.EndsWith("-") & !pValor.EndsWith("+") & !pValor.EndsWith("*")
                & !pValor.EndsWith("/") & !pValor.EndsWith("%"))
            {
                numeroAuxiliar = double.Parse(numeroPantallaPrincipal);
                numeroPantallaSecundaria = numeroPantallaPrincipal + pSigno;
                numeroPantallaPrincipal = "0";
                presionarIgual = false;
            }

            // Aquí como txtPantallaPrincipal es "0" y lblPantallaSecundaria tiene
            // signo al final, lo que hacemos simplemente, es cambiar el signo al
            // final por el que indicó el usuario
            else if ((pValor.EndsWith("-") | pValor.EndsWith("+") |
               pValor.EndsWith("*") | pValor.EndsWith("/") |
               pValor.EndsWith("%")) & numeroPantallaPrincipal == "0")
            {
                List<char> Lista = new List<char>();
                Lista.AddRange(pValor);
                Lista.RemoveAt(Lista.Count - 1);
                pValor = "";
                foreach (char i in Lista)
                {
                    pValor += i;
                }

                numeroPantallaSecundaria = pValor + pSigno;
                Lista.Clear();
                presionarIgual = false;
            }


            // aquí como lblPantallaSecundaria tiene signo aritmético al final y txtPantallaPrincipal
            // es diferente de "0"y además la variable operador tiene guardado un signo aritmético, realizamos calculo para obtener un resultado
            else
            {
                EscogerOperacion();
                numeroPantallaSecundaria = resultado.ToString() + pSigno;
                numeroAuxiliar = resultado;
                resultado = 0; // para que esta variable no se cumpla en el if de 'FiltarBotonesNumericos()' 
                numeroPantallaPrincipal = "0";
                presionarIgual = true;
            }

            signoAritmetico = pSigno;

        }

        private void EscogerOperacion()
        {
            if (signoAritmetico == "+")
            {
                resultado = numeroAuxiliar + double.Parse(numeroPantallaPrincipal);

            }
            else if (signoAritmetico == "-")
            {
                resultado = numeroAuxiliar - double.Parse(numeroPantallaPrincipal);
            }
            else if (signoAritmetico == "*")
            {
                resultado = numeroAuxiliar * double.Parse(numeroPantallaPrincipal);
            }
            else if (signoAritmetico == "/")
            {
                resultado = numeroAuxiliar / double.Parse(numeroPantallaPrincipal);
            }
            else if (signoAritmetico == "%")
            {
                resultado = numeroAuxiliar % double.Parse(numeroPantallaPrincipal);
            }
        }

        private void CalcularOperacionAritmetica()
        {
            EscogerOperacion();
            presionarIgual = true;
            numeroPantallaSecundaria += numeroPantallaPrincipal;
            numeroPantallaPrincipal = resultado.ToString();
        }

    }
}
