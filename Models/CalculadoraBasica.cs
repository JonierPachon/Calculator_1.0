using Interactuando.Interfaces;
using System;
using System.Collections.Generic;

namespace Interactuando.Models
{
   public class CalculadoraBasica
   {
      ICalcular GuardarUltimaOperacion;
      double numeroAuxiliar;
      double resultado;
      string numeroPantallaSecundaria, numeroPantallaPrincipal;
      bool calculoRealizado = false;

      public bool CalculoRealizado { get => calculoRealizado; set => calculoRealizado = value; }

      public string BorrarUltimoNumeroDigitado(string pNumeroPantallaPrincipal)
      {
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


      public (string, string) RealizarOperacion(ref ICalcular pOperacion, string 
               pNumeroPantallaPrincipal, string pNumeroPantallaSecundaria)
      {
         // aquí también podemos obtener un resultado de operacion cuando
         // presionamos en la calculadora los signos aritméticos

         numeroPantallaPrincipal = pNumeroPantallaPrincipal;
         numeroPantallaSecundaria = pNumeroPantallaSecundaria;
         string listaNumeros = "0123456789"+'"';

         // agregamos el signo de operación en la pantalla secundaria y preparamos
         // para que el usario pueda digitar el siguiente valor.
         // Ésto también aplica para cuando se obtiene un resultado presionando igual ya que
         // éste aparece en la pantalla secundaria de la siguiente manera "valor"


         if (listaNumeros.Contains(numeroPantallaSecundaria.Substring(numeroPantallaSecundaria.Length - 1)))
         {
            numeroAuxiliar = double.Parse(numeroPantallaPrincipal);
            numeroPantallaSecundaria = numeroPantallaPrincipal + pOperacion.GetSigno();
            numeroPantallaPrincipal = "0";
            GuardarUltimaOperacion = pOperacion;
         }

         // Aquí como el digito de la pantalla principal es "0" y la pantalla secundaria tiene
         // signo al final, lo que hacemos simplemente, es cambiar el signo al
         // final de ésta por el que indica el usuario
         else if ((!numeroPantallaSecundaria.EndsWith(pOperacion.GetSigno())) &
            numeroPantallaPrincipal == "0")
         {
            List<char> lista = new List<char>();
            lista.AddRange(numeroPantallaSecundaria);
            lista.RemoveAt(lista.Count - 1);
            lista.Add(char.Parse(pOperacion.GetSigno()));
            numeroPantallaSecundaria = "";
            foreach (char e in lista)
            {
               numeroPantallaSecundaria += e;
            }

            lista.Clear();
            calculoRealizado = false;
            GuardarUltimaOperacion = pOperacion;
         }


         else if (!pNumeroPantallaSecundaria.EndsWith(pOperacion.GetSigno()) &
                  numeroPantallaPrincipal != "0")
         {
            resultado = GuardarUltimaOperacion.Calculo(numeroAuxiliar,double.Parse(numeroPantallaPrincipal));
            numeroAuxiliar = resultado;
            numeroPantallaSecundaria = resultado.ToString() + pOperacion.GetSigno();
            numeroPantallaPrincipal = "0";
         }


         else if (pNumeroPantallaSecundaria.EndsWith(pOperacion.GetSigno()) &
                 numeroPantallaPrincipal != "0")
         {
            resultado = pOperacion.Calculo(numeroAuxiliar, double.Parse(numeroPantallaPrincipal));
            numeroAuxiliar = resultado;
            numeroPantallaSecundaria = resultado.ToString() + pOperacion.GetSigno();
            numeroPantallaPrincipal = "0";
         }

         return (numeroPantallaPrincipal, numeroPantallaSecundaria);

      }


      public (string,string) CalcularOperacionAritmetica(ref ICalcular pOperacion, string pNumeroPantallaPrincipal)
      {
         numeroPantallaPrincipal = pNumeroPantallaPrincipal;
         resultado = pOperacion.Calculo(numeroAuxiliar,double.Parse(pNumeroPantallaPrincipal));
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
