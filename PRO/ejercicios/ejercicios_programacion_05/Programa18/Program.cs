using System;

namespace Programa18 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena de caracteres, determina la cantidad de minúsculas y mayúsculas que contiene la cadena.");

      Console.Write("Introduce una cadena: ");
      string? cadena_01 = Console.ReadLine();
      int contador_minuscula = 0, contador_mayuscula = 0;

      for (int i = 0; i < cadena_01.Length; i++) {
        if (cadena_01[i] >= 'a' && cadena_01[i] <= 'z') {
          contador_minuscula++;
        } else if (cadena_01[i] >= 'A' && cadena_01[i] <= 'Z') {
          contador_mayuscula++;
        }
      }
      Console.WriteLine(cadena_01 + " tiene " + contador_minuscula + " minúsculas y " + contador_mayuscula + " mayúscula.");
    }
  }
}
