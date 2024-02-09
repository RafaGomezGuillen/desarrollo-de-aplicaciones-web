using System;

namespace NumerosImparTeclado {
  class Programa04 {
    public static void Main(string[] args) {
      Console.Write("Números impares menor que 100. Introduce tu número: ");
      string? cadena_01 = Console.ReadLine();

      if (int.TryParse(cadena_01, out int numero_01)) {
        if (numero_01 >= 100) {
          Console.WriteLine(numero_01 + " debe ser menor que 100");
        } else {
          while (numero_01 <= 100) {
            if (numero_01 % 2 == 1) {
              Console.WriteLine("Número: " + numero_01);
            }
            numero_01++;
          }
        }
      } else {
        Console.WriteLine(cadena_01 + " no es número");
      }
      Console.WriteLine("Pulse una tecla para salir...");
      Console.ReadKey();
    }
  }
}