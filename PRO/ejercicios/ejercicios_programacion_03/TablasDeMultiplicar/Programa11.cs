using System;

namespace TablasDeMultiplicar {
  class Programa11 {
    public static void Main(string[] args) {
      Console.WriteLine("Tablas de multiplicar.");
     for (int i = 0; i <= 10; i++) {
        for(int j = 1; j <= 10; j++) {
          Console.WriteLine(i + " * " + j + " = " + (i * j));
        }
        Console.WriteLine("-------------------------");
      }
      Console.WriteLine("Introduce alguna letra para salir...");
      Console.ReadKey();
    }
  }
}