using System;

namespace SumaTodo {
  class Programa06 {
    public static void Main(string[] args) {
      Console.WriteLine("Para los números del 1 al 100, calcular la suma de todos, " +
                        "la suma de los pares y la suma de los múltiplos de tres.");
      int suma = 0, suma_pares = 0, suma_multiplos = 0;
      for (int i = 1; i <= 100; i++) {
        if (i % 2 == 0) {
          suma_pares += i;
        }
        if (i % 3 == 0) {
          suma_multiplos += i;
        }
        suma += i;
      }
      Console.WriteLine("Suma de todos = " + suma);
      Console.WriteLine("Suma de pares = " + suma_pares);
      Console.WriteLine("Suma de multiplos de tres = " + suma_multiplos);
    }
  }
}