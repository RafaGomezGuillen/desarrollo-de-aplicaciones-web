using System;

namespace Programa12 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tRealizar una función a la que, dado un string y una letra,  \n" +
                        "devuelve la cantidad de veces que aparece esa letra en el string, \n" +
                        "y las posiciones en las que se encuentra.\n");

      string cadena = " ";
      Funciones.ComprobacionCadena(ref cadena);
      char caracter = ' ';
      Funciones.ComprobacionCaracter(ref caracter);

      int[] vector = Funciones.CantidadLetraPosicion(cadena, caracter);
      Console.Write("\n\nLa última posición es la cantidad de veces que aparece esa letra en el string: ");
      foreach(int i in vector) {
        Console.Write(i + " ");
      }
    }
  }
}
