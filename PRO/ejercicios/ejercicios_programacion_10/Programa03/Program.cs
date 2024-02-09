using System;

namespace Programa03 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tRealizar una función a la que se le pasa una cadena de caracteres \n" +
                        "y una letra y devuelve la cantidad de veces que aparece esta letra en la cadena, utilizando recursividad.\n");
      string cadena = " ";
      Funciones.ComprobacionCadena(ref cadena);
      char caracter = ' ';
      Funciones.ComprobacionCaracter(ref caracter);
      Console.WriteLine("\n" + cadena + " contiene " + caracter + " " + Funciones.CuantasVecesCaracterEnCadena(cadena, caracter) +
                        " veces");
    }
  }
}