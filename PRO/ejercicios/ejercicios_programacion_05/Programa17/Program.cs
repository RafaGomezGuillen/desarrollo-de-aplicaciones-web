using System;

namespace Programa17 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Un número capicúo se refiere a cualquier número que se lee igual de izquierda a derecha y de derecha a izquierda. " +
                        "Dado un número por teclado, devolver si se trata de un capicúo o no.");

      Console.Write("Introduce una número: ");
      string? cadena_01 = Console.ReadLine();
      string? cadena_mitad = "";
      string? cadena_mitad_reves = "";

      for (int i = 0; i < cadena_01.Length / 2; i++) {
        cadena_mitad += cadena_01[i];
      }

      for (int i = cadena_mitad.Length - 1; i >= 0; i--) {
        cadena_mitad_reves += cadena_mitad[i];
      }

      if ((cadena_mitad + cadena_mitad_reves) == cadena_01) {
        Console.WriteLine((cadena_mitad + cadena_mitad_reves) + " es capicúa.");
      } else {
        Console.WriteLine(cadena_01 + " no es capicúa.");
      }
    }
  }
}
