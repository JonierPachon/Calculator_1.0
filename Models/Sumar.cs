﻿using Interactuando.Interfaces;

namespace Interactuando.Models
{
   public class Sumar : OperacionesAritmeticas, ICalcular
   {
      public Sumar()
      {
         signo = "+";
      }
      public double Calculo(double valor1, double valor2)
      {
         return valor1 + valor2;
      }
   }
}
