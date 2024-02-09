using System;

namespace RangoNumerosNaturales {
  class Programa10 {
    public static void Main(string[] args) {
      Console.WriteLine("Dados dos números introducidos por teclado, mostrar los números naturales que hay entre ambos.");

      Console.Write("Introduce el primer número: ");
      string? cadena_01 = Console.ReadLine();
      Console.Write("Introduce el segundo número: ");
      string? cadena_02 = Console.ReadLine();

      if (int.TryParse(cadena_01, out int numero_01) && int.TryParse(cadena_02, out int numero_02)) {
        if (numero_01 >= 0 && numero_02 >= 0) {
          if (numero_01 < numero_02) {
            while (numero_01 <= numero_02) {
              Console.WriteLine("Número: " + numero_01);
              numero_01++;
            }
          } else {
            while (numero_02 <= numero_01) {
              Console.WriteLine("Número: " + numero_02);
              numero_02++;
            }
          }
        } else {
          Console.WriteLine(numero_01 + " o " + numero_02 + " no son números naturales.");
        }
      } else {
        Console.WriteLine(cadena_01 + " o " + cadena_02 + " no son números.");
      }
      Console.WriteLine("Pulse tecla para salir...");
      Console.ReadKey();
    }
  }
}