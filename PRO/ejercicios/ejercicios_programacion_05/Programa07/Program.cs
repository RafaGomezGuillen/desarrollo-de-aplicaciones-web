using System;

namespace Programa07 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena por teclado, y una segunda de comparación, " +
                        "mostrar por pantalla la cadena “Está” cuando encontremos " +
                        "la segunda cadena en cualquier posición de la primera.");

      Console.Write("Introduce la primera cadena: ");
      string? cadena_01 = Console.ReadLine();
      Console.Write("Introduce la segunda cadena de comparación: ");
      string? cadena_02 = Console.ReadLine();
      bool esta = false;
      int j = 0;
      for (int i = 0; i < cadena_01.Length; i++) {
        while (j < cadena_02.Length) {
          if (cadena_01[i] == cadena_02[j]) {
            esta = true;
          }
          j++;
        }
      }
      if (esta == true) Console.WriteLine("Está");
    }
  }
}