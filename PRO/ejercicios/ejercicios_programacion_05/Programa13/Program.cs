using System;

namespace Programa13 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Programa que, dada una cadena de caracteres, elimine los caracteres "+
                        "en blanco a la izquierda de una cadena y la muestre por pantalla.");

      Console.Write("Introduce una frase: ");
      string? cadena_01 = Console.ReadLine();
      string cadena_02 = "";
      char ultima_letra = cadena_01[cadena_01.Length - 1];

      for (int i = 0, j = i + 1; i < cadena_01.Length && j < cadena_01.Length; i++, j++) { 
        if (cadena_01[j] != ' ' || cadena_01[i] != ' ') {
          cadena_02 += cadena_01[i];
        }
      }
      
      for (int i = 1; i < cadena_02.Length; i++) {
        Console.Write(cadena_02[i]);
      }
      Console.Write(ultima_letra);
    }
  }
}
