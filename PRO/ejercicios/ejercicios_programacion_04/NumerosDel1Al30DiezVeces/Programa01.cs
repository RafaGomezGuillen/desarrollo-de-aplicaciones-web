using System;

namespace NumerosDel1Al30DiezVeces {
  class Programa01 {
    public static void Main(string[] args) {
      Console.WriteLine("Imprimir 10 veces la serie de números del 1 al 30 en una misma línea.");

      for (int i = 0; i < 10; i++) {
        for (int j = 1; j <= 30; j++) {
          Console.Write(j + " ");
        }
        Console.WriteLine();
      }
    }
  }
}