using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactuando.Models
{
   public class CalculadoraBasica
   {
      double numeroAuxiliar;
      string signoAritmetico;
      double resultado;
      string numeroPantallaSecundaria, numeroPantallaPrincipal;
      bool calculoRealizado = false;

      public bool CalculoRealizado { get => calculoRealizado; set => calculoRealizado = value; }
      public double NumeroAuxiliar { get => numeroAuxiliar; set => numeroAuxiliar = value; }
      public double Resultado { get { return resultado; } set => resultado = value; }

      public void LimpiarCalculadora()
      {
         //reiniciamos valores
         numeroAuxiliar = 0;
         resultado = 0;
      }

      public string BorrarUltimoNumeroDigitado(string pNumeroPantallaPrincipal)
      {
         //if ((pNumeroPantallaPrincipal).ToLower() == "nan")
         //{
         //    pNumeroPantallaPrincipal = "0";
         //}

         if (pNumeroPantallaPrincipal != "0")
         {
            List<char> NumBorrar = new List<char>();

            NumBorrar.AddRange(pNumeroPantallaPrincipal);

            NumBorrar.RemoveAt(NumBorrar.Count - 1);

            pNumeroPantallaPrincipal = "";

            if (NumBorrar.Count > 0)
            {
               foreach (char x in NumBorrar)
               {

                  pNumeroPantallaPrincipal += x;

               }
            }//para que si queda solo un dígito y se borra, la pantalla no quede sin números
            else pNumeroPantallaPrincipal = "0";

            NumBorrar.Clear();
         }

         return pNumeroPantallaPrincipal;
      }


      public (string, string) RealizarOperacion(string pSigno, string pNumeroPantallaPrincipal, string pNumeroPantallaSecundaria)
      {
         // aquí el, mas (+), también funciona como el botón igual
         // ya que también nos puede dar el resultado

         numeroPantallaPrincipal = pNumeroPantallaPrincipal;

         // agregamos el signo de operación en la pantalla secundaria y preparamos
         // para que el usario pueda digitar el siguiente valor. Ésto también aplica
         // para cuando se obtiene un resultado presionando igual ya que éste aparece en la
         // pantalla secundaria de la siguiente manera "valor"
         if (!pNumeroPantallaSecundaria.EndsWith("-") 
               & !pNumeroPantallaSecundaria.EndsWith("+") 
               & !pNumeroPantallaSecundaria.EndsWith("*")
               & !pNumeroPantallaSecundaria.EndsWith("/"))
         {
            numeroAuxiliar = double.Parse(numeroPantallaPrincipal);
            numeroPantallaSecundaria = numeroPantallaPrincipal + pSigno;
            numeroPantallaPrincipal = "0";
            calculoRealizado = false;
         }

         // Aquí como el digito de la pantalla principal es "0" y la pantalla secundaria tiene
         // signo al final, lo que hacemos simplemente, es cambiar el signo al
         // final de ésta por el que indica el usuario
         else if ((pNumeroPantallaSecundaria.EndsWith("-") | 
               pNumeroPantallaSecundaria.EndsWith("+") |
            pNumeroPantallaSecundaria.EndsWith("*") | 
            pNumeroPantallaSecundaria.EndsWith("/")) & 
            numeroPantallaPrincipal == "0")
         {
            List<char> lista = new List<char>();
            lista.AddRange(pNumeroPantallaSecundaria);
            lista.RemoveAt(lista.Count - 1);
            lista.Add(Char.Parse(pSigno));
            numeroPantallaSecundaria = "";
            foreach (char e in lista)
            {
               numeroPantallaSecundaria += e;
            }

            lista.Clear();
            calculoRealizado = false;
         }


         // aquí como la pantalla secundaria tiene signo aritmético al final y la pantalla principal
         // es diferente de "0" realizamos calculo para obtener un resultado
         else
         {
            EscogerOperacion();
            numeroPantallaSecundaria = resultado.ToString() + pSigno;
            numeroAuxiliar = resultado;
            // con esto indicamos que cuando se presione algún botón numérico
            resultado = 0; 
            numeroPantallaPrincipal = "0";
            calculoRealizado = true;
         }

         signoAritmetico = pSigno;
         return (numeroPantallaPrincipal, numeroPantallaSecundaria);

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
      }

      public (string,string) CalcularOperacionAritmetica(string pNumeroPantallaPrincipal, string pNumeroPantallaSecunddaria)
      {
         numeroPantallaPrincipal = pNumeroPantallaPrincipal;
         numeroPantallaSecundaria = pNumeroPantallaSecunddaria;
         EscogerOperacion();
         calculoRealizado = true;
         numeroPantallaSecundaria += numeroPantallaPrincipal;
         numeroPantallaPrincipal = resultado.ToString();

         return (numeroPantallaPrincipal, numeroPantallaSecundaria);
      }

      public string FiltroPuntoDecimal(string pNumeroPantallaPrincipal)
      {
         try
         {
            //de esta manera se evita que se pueda colocar mas 2 o mas puntos decimales
            //y también que se quiera agregar otro punto decimal, después de un
            //número digitado después del punto
                
            double n = double.Parse(pNumeroPantallaPrincipal + ".");

            // para saber si es decimal
            if (n % 1 == 0)
            {
               pNumeroPantallaPrincipal += ".";
            }
         }
         catch (FormatException)
         {

         }

         return pNumeroPantallaPrincipal;
      }

      public string ConvertidorNegativoPositivo(string pNumeroPantallaPrincipal)
      {
         if (pNumeroPantallaPrincipal != "0")
         {
            double numero = double.Parse(pNumeroPantallaPrincipal) * -1;
            pNumeroPantallaPrincipal = numero.ToString();

         }

         return pNumeroPantallaPrincipal;
      }
            

   }
}
