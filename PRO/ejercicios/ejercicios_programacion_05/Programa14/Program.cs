using System;

namespace Programa14 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena de caracteres, elimina los caracteres en blanco a la derecha de la cadena y la muestre por pantalla.");

      Console.Write("Introduce una frase: ");
      string? cadena_01 = Console.ReadLine();
      string cadena_02 = "";
      char ultima_letra = cadena_01[cadena_01.Length - 1];

      for (int i = 0, j = i + 2; i < cadena_01.Length && j < cadena_01.Length; i++, j++) {
        if (cadena_01[j] != ' ' || cadena_01[i] != ' ') {
          cadena_02 += cadena_01[i];
        }
      }
      Console.WriteLine("Longitud frase original: " + cadena_01.Length);
      Console.WriteLine(cadena_02);
      Console.WriteLine("Longitud frase cambiada: " + cadena_02.Length);
    }
  }
}
