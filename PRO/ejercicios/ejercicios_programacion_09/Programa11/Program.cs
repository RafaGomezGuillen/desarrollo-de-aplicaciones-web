using System;

namespace Programa11 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tRealizar una función que, pasado un vector del que desconocemos su longitud, \n" +
                        "calcule la media de sus valores (no se utilizan funciones de cálculo). \n" +
                        "Utilizar la función del ejercicio 3 para rellenar los valores.\n");

      // Tamaño del vector
      int vectorSize = 0;
      Funciones.ComprobacionVectorSize(ref vectorSize);

      // Pos el vector
      Console.Write("\nVector: ");
      Console.WriteLine("\nLa media del vector es: " + Funciones.MediaVector(Funciones.RandomVector(vectorSize)));
    }
  }
}
