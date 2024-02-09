using System;

namespace NumerosParesDel1Al100 {
  class Programa03 {
    public static void Main(string[] args) {
      Console.WriteLine("Números pares del 1 al 100");
      int numero_01 = 1;

      while (numero_01 <= 100) {
        if (numero_01 % 2 == 0) {
          Console.WriteLine("Número: " + numero_01);
        }
        numero_01++;
      }
      Console.WriteLine("Pulse una tecla para salir...");
      Console.ReadKey();
    }
  }
}