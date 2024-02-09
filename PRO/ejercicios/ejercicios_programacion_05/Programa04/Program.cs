using System;

namespace Programa04 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena por teclado, mostrar la cadena al revés.");

      Console.Write("Introduce la cadena: ");
      string cadena_01 = Console.ReadLine();
      string cadena_02 = "";

      for (int i = cadena_01.Length - 1; i >= 0; i--) {
        cadena_02 += cadena_01[i];
      }
      Console.WriteLine(cadena_01 + " al revéz es "+ cadena_02);
    }
  }
}