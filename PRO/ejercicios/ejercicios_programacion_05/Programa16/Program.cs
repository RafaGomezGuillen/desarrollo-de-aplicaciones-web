using System;

namespace Programa16 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Un palíndromo es una palabra que se lee igual hacia adelante que hacia atrás. " +
                        "Dada una cadena de caracteres por teclado, mostrar si la cadena es un palíndromo o no.");

      Console.Write("Introduce una frase: ");
      string? cadena_01 = Console.ReadLine();
      string? cadena_02 = "";

      for (int i = cadena_01.Length - 1; i >= 0; i--) {
        cadena_02 += cadena_01[i];
      }
      if (cadena_02 == cadena_01) {
        Console.WriteLine(cadena_02 + " es palíndromo.");
      } else {
        Console.WriteLine(cadena_01 + " no es palíndromo."); 
      }
    }
  }
}
