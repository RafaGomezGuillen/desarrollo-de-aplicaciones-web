using System;

namespace Programa01 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena de caracteres introducida por teclado, " +
                        "contar el número de caracteres que la componen.");
      Console.Write("Introduce la cadena: ");
      string? cadena_01 = Console.ReadLine();
      Console.WriteLine("El número de carácteres de " + cadena_01 + " es " + cadena_01.Length);
    }
  }
}