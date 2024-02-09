using System;

namespace Programa01 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Solicitar 10 números por teclado y calcular su media aritmética.");
      const int ElementoMaximo = 10;
      double[] MediaAritmetica = new double[ElementoMaximo];
      double Elementos = 0, SumaElementos = 0;

      for (int i = 0; i < ElementoMaximo; i++) {
        Console.Write("\n Introduzca los elementos del vector (" + i + ") : ");
        while (!double.TryParse(Console.ReadLine(), out Elementos)) {
          Console.Write("Error. Introduzca un número (" + i + ") : ");
        }
        MediaAritmetica[i] = Elementos;
        SumaElementos += MediaAritmetica[i];
      }

      for (int i = 0; i < ElementoMaximo; i++) {
        Console.Write(MediaAritmetica[i] + " ");
      }
      Console.WriteLine("\nMedia aritmética: " + (SumaElementos / ElementoMaximo));
    }
  }
}