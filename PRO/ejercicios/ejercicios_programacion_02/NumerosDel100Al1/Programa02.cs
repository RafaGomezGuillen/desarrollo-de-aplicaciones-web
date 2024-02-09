using System;

namespace NumeroDel100Al1 {
  class Programa02 {
    public static void Main(string[] args) {
      Console.WriteLine("Números del 100 al 1");
      int numero_01 = 100;

      while (numero_01 > 0) {
        Console.WriteLine("Número: " + numero_01);
        numero_01--;
      }
      Console.WriteLine("Pulse una tecla para salir...");
      Console.ReadKey();
    }
  }
}