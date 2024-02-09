using System;

namespace Programa11 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\tCrear un programa que pida al usuario 10 números decimales, calcule su media " +
                        "\ny luego muestre los que están por encima de la media.\r\n\n");

      const int MAXIMO_ELEMENTO = 10;
      // Guardo los 10 números en un vector
      decimal[] vectorInicial = new decimal[MAXIMO_ELEMENTO];
      for (int i = 0; i < MAXIMO_ELEMENTO; i++) {
        Console.Write("\nIntroduce los números del vector (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out vectorInicial[i])) {
          Console.Write("\nERROR. Introduce un número (" + i + ") :");
        }
      }

      // Muestro la media del vector con la función average
      Console.WriteLine("\nMedia: " + vectorInicial.Average());

      // Muestro los que están encima de la media
      Console.Write("\nNúmeros encima de la media: ");
      foreach (decimal val in vectorInicial ) {
        if (val > vectorInicial.Average()) {
          Console.Write(val + " ");
        }
      }
    }
  }
}