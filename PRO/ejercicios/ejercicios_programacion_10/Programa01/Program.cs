using System;

namespace Programa01 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tMuestra por pantalla los números del 1 al 100 utilizando recursividad.\n");
      int numero = 1;

      Console.WriteLine(Funciones.NumerosDel1Al100(numero));
    }
  }
}