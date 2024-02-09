using System;

namespace Programa03 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena por teclado, mostrar la cadena al revés.");

      Console.Write("Introduce la cadena: ");
      string? cadena_01 = Console.ReadLine();

      for (int i = cadena_01.Length - 1; i >= 0; i--) {
        Console.Write(cadena_01[i]);
      }
    }
  }
}