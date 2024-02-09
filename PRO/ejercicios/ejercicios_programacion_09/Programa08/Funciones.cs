using System;

namespace Programa08 {
  internal class Funciones {
    public static int ComprobacionVectorSize(ref int numero) {
      Console.Write("\nIntroduce un el tamaño del vector: ");
      while (!int.TryParse(Console.ReadLine(), out numero) || (numero <= 0)) {
        Console.Write("\nERROR. Introduzca un número positivo: ");
      }
      return numero;
    }
    public static int[] RandomVector(int vectorSize) {
      Random aleatorio = new Random();
      int[] vector = new int[vectorSize];
      for (int i = 0; i < vectorSize; i++) {
        vector[i] = aleatorio.Next(1, 99);
      }
      return vector;
    }
  }
}
