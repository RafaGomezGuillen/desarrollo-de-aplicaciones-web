using System;

namespace ParImpar {
  class Programa15 {
    public static void Main(String[] args) {
      Console.WriteLine("Introducir un número por teclado y mostrar el mensaje de si es par o impar.");

      Console.Write("Introduce un número: ");
      string cadena_01 = Console.ReadLine();

      if (Double.TryParse(cadena_01, out double numero_01)) {
        if (numero_01 % 2 == 0) {
          Console.WriteLine(numero_01 + " es par.");
        }
        else {
          Console.WriteLine(numero_01 + " es impar.");
        }
      } else {
        Console.WriteLine(cadena_01 + " no es un número.");
      }
       Console.ReadKey();
    }
  }
}
