using System;

namespace PrimoOno {
  class Programa02 {
    public static void Main(string[] args) {
      Console.WriteLine("Comprobar que un número introducido por teclado es primo y que que es mayor que 1.");
      Console.Write("Introduce tu número: ");
      string? cadena_01 = Console.ReadLine();
      int contador_01 = 0;

      if ((int.TryParse(cadena_01, out int numero_01)) && numero_01 > 1) {
        for (int i = 2; i < numero_01; i++) {
          if (numero_01 % i == 0) {
            contador_01++;
          }
        }
        if (contador_01 == 0) {
          Console.WriteLine(numero_01 + " es primo.");
        } else {
          Console.WriteLine(numero_01 + " no es primo.");
        }
      } else {
        Console.WriteLine(cadena_01 + " debe ser un número y mayor que uno.");
      }
    }
  }
}