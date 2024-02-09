using System;

namespace PositivoNegativo {
  class Programa14 {
    public static void Main(String[] args) {
      Console.WriteLine("Introducir un número por teclado y mostrar el mensaje de si es positivo o negativo.");

      Console.Write("Introduce un número: ");
      string cadena_01 = Console.ReadLine();

      if (Double.TryParse(cadena_01, out double numero_01)) {
        if (numero_01 > 0) {
          Console.WriteLine(numero_01 + " es positivo.");
        }
        else if (numero_01 == 0) {
          Console.WriteLine(numero_01 + " es neutro.");
        }
        else {
          Console.WriteLine(numero_01 + " es negativo.");
        }
      } else {
        Console.WriteLine(cadena_01 + " no es un número.");
      }
      Console.ReadKey();
    }
  }
}
