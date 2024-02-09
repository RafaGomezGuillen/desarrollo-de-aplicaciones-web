using System;

namespace Programa09 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tCrear una función a la que se le pasa un número que representa el año, " +
                        "y devuelve true si se trata de una año bisiesto y false si no lo es.\n");

      // Tamaño del vector
      int año = 0;
      Funciones.ComprobacionEnteroPositivo(ref año);

      // Pos el vector
      if (Funciones.EsBisiesto(año)) {
        Console.WriteLine(año + " es bisiesto.");
      } else {
        Console.WriteLine(año + " no es bisiesto.");
      }
    }
  }
}
