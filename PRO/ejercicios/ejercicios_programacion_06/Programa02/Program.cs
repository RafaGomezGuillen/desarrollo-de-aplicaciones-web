using System;

namespace Programa02 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Solicitar 10 números por teclado. A continuación, solicitar otro. " +
                        "Buscar ese último número entre los 10 primeros y decir, en el caso de que esté, en qué lugar fue introducido.");
      const int ElementoMaximo = 10;
      double[] VectorDeNumeros = new double[ElementoMaximo];
      double Elementos = 0, EncontrarNumero = 0;

      for (int i = 0; i < ElementoMaximo; i++) {
        Console.Write("\n Introduzca los elementos del vector (" + i + ") : ");
        while (!double.TryParse(Console.ReadLine(), out Elementos)) {
          Console.Write("Error. Introduzca un número (" + i + ") : ");
        }
        VectorDeNumeros[i] = Elementos;
      }

      Console.Write("Introduce un número a encontrar: ");
      while(!double.TryParse(Console.ReadLine(), out EncontrarNumero)) {
        Console.Write("ERROR. Introduce un número: ");
      }

      for (int i = 0; i < ElementoMaximo; i++) {
        if (VectorDeNumeros[i] == EncontrarNumero) {
          Console.Write("\n" + EncontrarNumero + " está en " + VectorDeNumeros[i]);
        } else {
          Console.Write("\n" + EncontrarNumero + " no está en " + VectorDeNumeros[i]);
        }
      }
    }
  }
}