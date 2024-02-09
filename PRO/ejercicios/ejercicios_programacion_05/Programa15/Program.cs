using System;

namespace Programa15 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena de caracteres, elimina los espacios en blanco a ambos extremos de la cadena " +
                        "y la muestra por pantalla.");

      Console.Write("Introduce una frase: ");
      string? cadena_01 = Console.ReadLine();
      string cadena_02 = "";

      for (int i = 0, j = i + 1, k = i + 2; i < cadena_01.Length && j < cadena_01.Length && k < cadena_01.Length; i++, j++, k++) {
        if (cadena_01[j] != ' ' || cadena_01[i] != ' ' || cadena_01[k] != ' ') {
          cadena_02 += cadena_01[i];
        }
      }

      Console.WriteLine("Longitud frase original: " + cadena_01.Length);
      int contador = 0;
      for (int i = 2; i < cadena_02.Length; i++) {
        Console.Write(cadena_02[i]);
        contador = i;
      }
      Console.WriteLine("\nLongitud frase cambiada: " + contador);
    }
  }
}
