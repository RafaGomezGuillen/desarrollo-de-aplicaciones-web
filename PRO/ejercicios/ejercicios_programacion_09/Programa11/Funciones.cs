using System;

namespace Programa11 {
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
    public static decimal MediaVector(int[] vector) {
      decimal media = 0, suma = 0;

      for (int i = 0; i < vector.Length; i++) {
        suma += vector[i];
        Console.Write(vector[i] + " ");
      }

      media = suma / vector.Length;
     
      return media;
    }
  }
}
