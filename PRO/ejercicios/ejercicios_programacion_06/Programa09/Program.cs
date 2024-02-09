using System;

namespace Programa09 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\nSolicitar 10 números por teclado y mostrarlos de menor a mayor.");
      const int ElementoMaximo = 10;
      decimal[] VectorNumeros = new decimal[ElementoMaximo];
      decimal Elementos = 0, aux = 0;

      for (int i = 0; i < ElementoMaximo; i++) {
        Console.Write("\n Introduzca los números del vector (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out Elementos)) {
          Console.Write("Error. Introduzca un número (" + i + ") : ");
        }
        VectorNumeros[i] = Elementos;
      }

      for (int i = 0; i < ElementoMaximo; i++) {
        for (int j = i; j < ElementoMaximo; j++) {
          if (VectorNumeros[i] > VectorNumeros[j]) {
            aux = VectorNumeros[i];
            VectorNumeros[i] = VectorNumeros[j];
            VectorNumeros[j] = aux;
          }
        }
      }

      Console.WriteLine("\nVector ordenado.");
      for (int i = 0; i < ElementoMaximo; i++) {
        Console.Write(VectorNumeros[i] + " ");
      }
    }
  }
}