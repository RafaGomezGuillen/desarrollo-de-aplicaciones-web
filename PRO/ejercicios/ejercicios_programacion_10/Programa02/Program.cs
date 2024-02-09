using System;

namespace Programa02 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tComprobar si un número es primo utilizando recursividad.\n");
      int numero = 0;
      Funciones.NumeroEntero(ref numero);

      if (Funciones.EsPrimo(numero))
        Console.WriteLine(numero + " es primo.");
      else
        Console.WriteLine(numero + " no es primo.");
    }
  }
}