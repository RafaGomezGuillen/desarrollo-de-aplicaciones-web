using System;

namespace CalcularDivisores {
  class Programa08 {
    public static void Main(string[] args) {
      Console.WriteLine("Dado un número entero, calcular todos sus divisores.");
      Console.Write("Introduce tu número: ");
      string? cadena_01 = Console.ReadLine();

      if (int.TryParse(cadena_01, out int numero_01)) {
        if (numero_01 >= 1) {
          for (int i = 1; i <= numero_01; i++) {
            if (numero_01 % i == 0) {
              Console.WriteLine(i + " es divisor de " + numero_01);
            }
          }
        } else {
          Console.WriteLine(numero_01 + " debe ser mayor que 1.");
        }
      }
      else {
        Console.WriteLine(cadena_01 + " no es número o no es entero.");
      }
    }
  }
}