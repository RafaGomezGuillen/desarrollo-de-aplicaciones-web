using System;
using System.Security.Cryptography;

namespace Programa03 {
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
    public static int CuantasVecesCaracterEnCadena(string cadena, char caracter, int i = 0) {
      if (i == cadena.Length) return 0;
      int contador = CuantasVecesCaracterEnCadena(cadena, caracter, i + 1);
      if (cadena[i] == caracter) contador++;
      return contador;
    }
  }
}
