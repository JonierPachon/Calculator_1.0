using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactuando.Interfaces
{
   public interface ICalcular
   {
      double Calculo(double valor1, double valor2);
      string GetSigno();
   }
}
