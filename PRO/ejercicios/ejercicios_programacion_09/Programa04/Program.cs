using System;

namespace Programa04 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tRealizar una función a la que se le pasa una cadena de caracteres y una letra y \n" +
                        "devuelve la cantidad de veces que aparece esta letra en la cadena.\n");

      string cadena = " ";
      Funciones.ComprobacionCadena(ref cadena);
      char caracter = ' ';
      Funciones.ComprobacionCaracter(ref caracter);
      Console.WriteLine("\n" + cadena + " contiene " + caracter + " " + Funciones.CuantasVecesCaracterEnCadena(cadena, caracter) +
                        " veces");
      Funciones.Adios();
    }
  }
  class Funciones {
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
    public static int CuantasVecesCaracterEnCadena(string cadena, char caracter) {
      int contadorVeces = 0;
      for (int i = 0; i < cadena.Length; i++) {
        if (cadena[i] == caracter) contadorVeces++;
      }
      return contadorVeces;
    }
    public static void Adios() {
      Console.Write("\nIntroduce una tecla para salir...");
      Console.ReadKey();
    }
  }
}