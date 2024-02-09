using System;

namespace TablaDeMultiplicar {
  class Programa07 {
    public static void Main(string[] args) {
      Console.WriteLine("Dado un número por teclado, mostrar su tabla de multiplicar.");
      Console.Write("Introduce tu número: ");
      string? cadena_01 = Console.ReadLine();

      if (int.TryParse(cadena_01, out int numero_01)) {
        for (int i = 1; i <= 10; i++) {
          Console.WriteLine(i + " * " + numero_01 + " = " + (i * numero_01));
        }
      } else {
        Console.WriteLine(cadena_01 + " no es número o no es entero.");
      }
    }
  }
}