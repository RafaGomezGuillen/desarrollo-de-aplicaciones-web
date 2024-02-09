using System;

namespace Numeros1HastaTeclado {
  class Programa07 {
    public static void Main(string[] args) {
      Console.Write("Presentar por pantalla los números que hay desde el 1 hasta un número solicitado por teclado" +
                    ". Introduce tu número: ");
      string? cadena_01 = Console.ReadLine();
      int contador = 0;
      if (int.TryParse(cadena_01, out int numero_01)) {
        if (numero_01 >= 0) {
          while (contador < numero_01) {
            contador++;
          }
        } else {
          while (contador >= numero_01) {
            contador--;
          }
        }
      }
      else {
        Console.WriteLine(cadena_01 + " no es número");
      }
      Console.WriteLine("Hay " + contador + " números de 1 al " + cadena_01);
      Console.WriteLine("Pulse una tecla para salir...");
      Console.ReadKey();
    }
  }
}
