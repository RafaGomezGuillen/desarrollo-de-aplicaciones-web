using System;

namespace Programa08 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Teniendo en cuenta que la clave es “eureka”, escribir un algoritmo que nos pida una clave. " +
                        "Solo tenemos 3 intentos para acertar, si fallamos los 3 intentos nos " +
                        "mostrara un mensaje indicándonos que hemos agotado esos 3 intentos. Si acertamos la clave, " +
                        "saldremos directamente del programa.");

      Console.Write("Introduce la una clave: ");
      string? cadena_01 = Console.ReadLine();
      int contador = 0;
      string? cadena_02;

      while(contador != 3) {
        Console.Write("Introduce una cadena para acertar (tienes 3 intentos): ");
        cadena_02 = Console.ReadLine();
        if (cadena_01 == cadena_02) {
          Console.WriteLine("Eureka");
          break;
        }
        contador++;
      }
    }
  }
}