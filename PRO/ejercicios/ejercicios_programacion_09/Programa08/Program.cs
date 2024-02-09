using System;

namespace Programa08 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tRealizar una función a la que se le pasa el número de elementos con el que se rellena \n" +
                        "un vector con números aleatorios entre el 1 y el 99.\n");

      // Tamaño del vector
      int vectorSize = 0;
      Funciones.ComprobacionVectorSize(ref vectorSize);

      // Pos el vector
      Console.Write("\nVector: ");
      foreach(int i in Funciones.RandomVector(vectorSize)) {
        Console.Write(i + " ");
      }
    }
  }
}
