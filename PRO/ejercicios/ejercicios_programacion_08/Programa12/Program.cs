using System;

namespace Programa12 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\tSolicitar un vector de 20 números enteros positivos, y solicitar un nuevo número entero positivo que debe ser buscado en el vector. " +
                        "\nEn un nuevo vector, cada vez que el valor del vector inicial coincida con el número solicitado, debemos colocar un -1. " +
                        "\nSi no coincide, colocamos un 0. Al final debemos mostrar ambos vectores, el inicial sin modificar.\r\n\n");

      const int MAXIMO_ELEMENTO = 20;
      // Guardo los 20 números en un vector
      int[] vectorInicial = new int[MAXIMO_ELEMENTO];
      for (int i = 0; i < MAXIMO_ELEMENTO; i++) {
        Console.Write("\nIntroduce los números del vector (" + i + ") : ");
        while (!int.TryParse(Console.ReadLine(), out vectorInicial[i]) || vectorInicial[i] <= 0) {
          Console.Write("\nERROR. Introduce un número entero positivo (" + i + ") :");
        }
      }

      // Pido el número a buscar
      int numeroBuscado = 0;
      Console.Write("\nIntroduce el número a buscar: ");
      while (!int.TryParse(Console.ReadLine(), out numeroBuscado) || numeroBuscado <= 0) {
        Console.Write("\nERROR. Introduce un número entero positivo :");
      }

      // Nuevo vector
      int[] vectorFinal = new int[MAXIMO_ELEMENTO];
      for(int i = 0; i < MAXIMO_ELEMENTO; i++) {
        // Si i == a vectorFinal vale -1 sino 0
        if (vectorInicial[i] == numeroBuscado) {
          vectorFinal[i] = -1;
        } else {
          vectorFinal[i] = 0;
        }
      }

      // Muestro el vector inicial
      Console.Write("\nVector inicial: ");
      foreach(int i in vectorInicial) {
        Console.Write(i + " ");
      }
      // Muestro el vector final
      Console.Write("\nVector final: ");
      foreach (int i in vectorFinal) {
        Console.Write(i + " ");
      }
    }
  }
}