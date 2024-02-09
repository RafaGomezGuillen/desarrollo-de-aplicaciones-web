using System;

namespace Programa02 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Solicitada una frase y una letra, encontrar el número " +
                        "de veces que dicha letra aparece en la frase dada.");

      Console.Write("Introduce la cadena: ");
      string? cadena_01 = Console.ReadLine();
      Console.Write("Introduce la cadena: ");
      string? cadena_02 = Console.ReadLine();

      int contador_01 = 0;
      if (char.TryParse(cadena_02, out char letra_01)) {
        for (int i = 0; i < cadena_01.Length; i++) {
          if (cadena_01[i] == letra_01) {
          contador_01++;
        }
        Console.WriteLine(letra_01 + " aparece " + contador_01 + " veces en la cadena " + cadena_01);
      }
      } else {
        Console.WriteLine(cadena_02 + " no es un char.");
      }
    }
  }
}