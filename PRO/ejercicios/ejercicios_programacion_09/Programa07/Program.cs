using System;

namespace Programa07 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tRealizar una función a la que se le pasa un vector de números enteros (positivos y/o negativos), \n" +
                        "y devuelve la posición del número de menor valor de todos los incluidos.\n");

      // Tamaño del vector
      int vectorSize = 0;
      Funciones.ComprobacionVectorSize(ref vectorSize);

      // Introducir datos al vector
      int[] vectorNumeros = new int[vectorSize];
      Funciones.IntroducirDatosVector(ref vectorNumeros);

      // Dato de menor valor
      Console.WriteLine("\nLa posición/es de menor valor es: " + Funciones.PosMinVector(vectorNumeros) + ".");
    }
  }
}
