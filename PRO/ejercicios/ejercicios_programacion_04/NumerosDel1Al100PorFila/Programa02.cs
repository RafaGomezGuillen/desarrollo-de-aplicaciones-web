using System;

namespace NumerosDel1Al100PorFila {
  class Programa02 {
    public static void Main(string[] args) {
      Console.WriteLine("Mostrar por pantalla los números del 1 al 100, colocando 10 números en cada fila a mostrar.");
      int i;

      for (i = 1; i <= 100;) {
        for (int j = 1; j <= 10; j++) {
          Console.Write(i + " ");
          i++;
        }
        Console.WriteLine();
      }
    }
  }
}