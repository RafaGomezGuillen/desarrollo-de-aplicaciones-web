using System;

namespace Programa01 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\tDada una cadena por teclado, indicar cuáles son las vocales que contiene.\r\n");

      // Pido la cadena
      Console.Write("\t\nIntroduce una cadena: ");
      string? cadenaInicial = Console.ReadLine();

      // Que la cadena sea minúscula
      cadenaInicial = cadenaInicial.ToLower();

      while(cadenaInicial.Length == 0) {
        Console.Write("Introduzca una cadena que no sea nula: ");
        cadenaInicial = Console.ReadLine();
      }

      // Compruebo si la cadena contiene cada una de las vocales
      string vocales = "aeiou";
      foreach(char elementos in vocales) {
        if(cadenaInicial.Contains(elementos)) {
          Console.WriteLine(elementos);
        }
      }
    }
  }
}