using System;

namespace CuantosImparesHay {
  class Programa05 {
    public static void Main(string[] args) {
      Console.Write("Cúantos números impares menor que 100. Introduce tu número: ");
      string? cadena_01 = Console.ReadLine();
      int contador = 0, suma = 0;
      if (int.TryParse(cadena_01, out int numero_01)) {
        if (numero_01 > 100) {
          Console.WriteLine(numero_01 + " deber ser menor que 100");
        } else {
          while (numero_01 < 100) {
            if (numero_01 % 2 == 1) {
              contador++;
              suma += numero_01;
            }
            numero_01++;
          }
        }
      }
      else {
        Console.WriteLine(cadena_01 + " no es número");
      }
      Console.WriteLine("Hay " + contador + " números impares desde " + cadena_01 + " hasta 100 y su suma es " + suma);
      Console.WriteLine("Pulse una tecla para salir...");
      Console.ReadKey();
    }
  }
}