using System;

namespace Programa03 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Solicitar 10 números distintos por teclado y mostrarlos.");
      const int ElementoMaximo = 10;
      double[] NumerosDistintos = new double[ElementoMaximo];
      double Elementos; 

      for (int i = 0; i < ElementoMaximo; i++) {
        Console.Write($"\n Introduzca los elementos del vector (" + i + ") : ");
        while (!double.TryParse(Console.ReadLine(), out Elementos)) {
          Console.Write("Error. Introduzca un número (" + i + ") : ");
        }
        NumerosDistintos[i] = Elementos;
        for (int j = 0; j < i; j++) {
          if (NumerosDistintos[i] == NumerosDistintos[j]) {
            Console.Write("\nError. Introduce un número distinto: ");
            i--;
          }
        }
      }

      for (int i = 0; i < ElementoMaximo; i++) {
        Console.Write(NumerosDistintos[i] + " ");
      }
    }
  }
}