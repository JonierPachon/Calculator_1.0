using Interactuando.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactuando.Models
{
   public class Dividir : OperacionesAritmeticas, ICalcular
   {
      public Dividir()
      {
         signo = "/";
      }
      public double Calculo(double valor1, double valor2)
      {
         return valor1 / valor2;
      }
   }
}
