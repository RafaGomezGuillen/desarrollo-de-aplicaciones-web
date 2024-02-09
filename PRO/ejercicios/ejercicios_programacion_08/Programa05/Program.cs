using System;

namespace Programa05 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\tDada una cadena de caracteres, elimina los espacios en blanco a ambos extremos de la cadena y la muestra por pantalla.\r\n");

      // Pido la cadena inicial
      Console.Write("\t\nIntroduce una cadena: ");
      string? cadenaInicial = Console.ReadLine();

      // Comprueba que no sea vacia
      while (cadenaInicial == null) {
        Console.Write("\nERROR. Introduce una cadena no vacia: ");
        cadenaInicial = Console.ReadLine();
      }

      // Elimino los espacios en blanco con trim
      Console.WriteLine(cadenaInicial.Trim());
    }
  }
}