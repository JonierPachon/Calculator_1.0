using Interactuando.Interfaces;

namespace Interactuando.Models
{
   public class Multiplicar :OperacionesAritmeticas, ICalcular
   {
      public Multiplicar()
      {
         signo = "*";
      }
      public double Calculo(double valor1, double valor2)
      {
         return valor1 * valor2;
         
      }
   }
}
