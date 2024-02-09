using System;

namespace Programa06 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\tDada una cadena de caracteres, determina la cantidad de minúsculas y mayúsculas que contiene la cadena.\r\n");

      // Pido la cadena inicial
      Console.Write("\t\nIntroduce una cadena: ");
      string? cadenaInicial = Console.ReadLine();

      // Comprueba que no sea vacia
      while (cadenaInicial.Length == 0) {
        Console.Write("\nERROR. Introduce una cadena no vacia: ");
        cadenaInicial = Console.ReadLine();
      }

      int contadorMayuscula = 0, contadorMinuscula = 0;  
      foreach(char caracter in cadenaInicial) {
        if (caracter >= 'A' && caracter <= 'Z') {
          contadorMayuscula++;
        } else if (caracter >= 'a' && caracter <= 'z') {
          contadorMinuscula++;
        }
      }
      Console.WriteLine(cadenaInicial + " contiene " + contadorMayuscula + " mayúsculas.");
      Console.WriteLine(cadenaInicial + " contiene " + contadorMinuscula + " minúsculas.");

      // Otra manera de hacerlo
      contadorMayuscula = 0; 
      contadorMinuscula = 0;

      foreach(char letra in cadenaInicial) {
        if (char.IsUpper(letra)) {
          contadorMayuscula++;
        } else if (char.IsLower(letra)) {
          contadorMinuscula++;
        }
      }
      Console.WriteLine(cadenaInicial + " contiene " + contadorMayuscula + " mayúsculas.");
      Console.WriteLine(cadenaInicial + " contiene " + contadorMinuscula + " minúsculas.");
    }
  }
}