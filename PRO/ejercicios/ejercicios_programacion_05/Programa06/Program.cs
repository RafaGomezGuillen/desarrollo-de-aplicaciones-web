using System;

namespace Programa06 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena por teclado, contar el número de vocales que contiene.");

      Console.Write("Introduce la cadena: ");
      string cadena_01 = Console.ReadLine();
      int contador = 0;

      for (int i = 0; i < cadena_01.Length; i++) {
        if ((cadena_01[i] == 'a') || (cadena_01[i] == 'A')) contador++;
        if ((cadena_01[i] == 'e') || (cadena_01[i] == 'E')) contador++;
        if ((cadena_01[i] == 'i') || (cadena_01[i] == 'I')) contador++;
        if ((cadena_01[i] == 'o') || (cadena_01[i] == 'O')) contador++;
        if ((cadena_01[i] == 'u') || (cadena_01[i] == 'U')) contador++;
      }
      Console.WriteLine("La palabra " + cadena_01 + " contiene " + contador + " vocales.");
    }
  }
}