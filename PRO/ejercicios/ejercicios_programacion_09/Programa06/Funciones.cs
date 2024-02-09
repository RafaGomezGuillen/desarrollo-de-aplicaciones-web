using System;

namespace Programa06 {
  internal class Funciones {
    public static int ComprobacionVectorSize(ref int numero) {
      Console.Write("\nIntroduce un el tamaño del vector: ");
      while (!int.TryParse(Console.ReadLine(), out numero) || (numero <= 0)) {
        Console.Write("\nERROR. Introduzca un número positivo: ");
      }
      return numero;
    }
    public static int[] IntroducirDatosVector(ref int[] vector) {
      for (int i = 0; i < vector.Length; i++) {
        Console.Write("\nIntroduce los números del vector (" + i + ") : ");
        while (!int.TryParse(Console.ReadLine(), out vector[i])) {
          Console.Write("\nERROR. Introduce un número (" + i + ") :");
        }
      }
      return vector;
    }
    public static int MinVector(int[] vector) {
      int minimo = vector.Min();
      return minimo;
    }
  }
}
