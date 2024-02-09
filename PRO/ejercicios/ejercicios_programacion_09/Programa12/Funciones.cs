using System;

namespace Programa12 {
  internal class Funciones {
    public static string ComprobacionCadena(ref string cadena) {
      Console.Write("\nIntroduzca una cadena: ");
      cadena = Console.ReadLine();
      cadena = cadena.Trim();
      while (cadena.Length == 0) {
        Console.Write("\nERROR. Introduzca una cadena no vacia: ");
        cadena = Console.ReadLine();
        cadena = cadena.Trim();
      }
      return cadena;
    }
    public static char ComprobacionCaracter(ref char caracter) {
      Console.Write("\nIntroduzca un caracter: ");
      while (!char.TryParse(Console.ReadLine(), out caracter)) {
        Console.Write("\nERROR. Introduzca un caracter: ");
      }
      return caracter;
    }
    /// <summary>
    /// Vector que la cantidad de ves que aparece esa letra en el string y sus posiciones
    /// </summary>
    /// <param name="cadena">Cadena a introducir</param>
    /// <param name="caracter">Caracter a buscar</param>
    /// <returns>Retorna un vector cuya última posición es la cantidad de ves que aparece esa letra en el string</returns>
    public static int[] CantidadLetraPosicion(string cadena, char caracter) {
      // Cada vez que coincida un caracter con una caracter de la cadena tamaño incrementa
      int tamaño = 0;
      foreach(char c in cadena) {
        if (c == caracter) tamaño++;
      }

      // Tamaño es la longitud del vector + 1. Lo incremento a 1 para guardar luego la cantidad de veces
      // que aparece esa letra en el string
      int[] vector = new int[tamaño + 1];
      for (int i = 0, j = 0; i < cadena.Length; i++) {
        if (cadena[i] == caracter) {
          vector[j] = i;
          j++;
        }
      }
      // Guardo en la última posición la cantidad de veces que aparece esa letra en el string
      vector[tamaño] = tamaño;
      return vector;
    }
  }
}
