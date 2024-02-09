using System;

namespace Programa03 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tRealizar una función que devuelva un número entero correctamente introducido por teclado. \n" +
                        "En el caso de no ser correcto, volver a pedirlo hasta que lo introduzca correctamente.\n");

      int numeroEntero = 0;
      Funciones.ComprobacionEntero(ref numeroEntero);
      Funciones.Adios();
    }
  }
  class Funciones {
    public static void ComprobacionEntero(ref int num1) {
      Console.Write("\nIntroduzca un número: ");
      while (!int.TryParse(Console.ReadLine(), out num1)) {
        Console.Write("\nERROR. Introduzca un número: ");
      }
      Console.WriteLine("\n" + num1 + " bien introducido.");
    }
    public static void Adios() {
      Console.Write("\nIntroduce una tecla para salir...");
      Console.ReadKey();
    }
  }
}