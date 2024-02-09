using System;

namespace ContarNumeros {
  class Programa09 {
    public static void Main(string[] args) {
      Console.WriteLine("Dados dos números, contar desde el primero al segundo número siempre que se pueda.");
      Console.Write("Introduce tu primer número: ");
      string? cadena_01 = Console.ReadLine();
      Console.Write("Introduce tu segundo número: ");
      string? cadena_02 = Console.ReadLine();
      int contador = 0;

      if (int.TryParse(cadena_01, out int numero_01) && int.TryParse(cadena_02, out int numero_02)) {
        if (numero_01 < numero_02) {
          for (int i = numero_01; i <= numero_02; i++) {
            Console.WriteLine(i);
            contador++;
          } 
          Console.WriteLine("Hay " + contador + " desde " + numero_01 + " hasta " + numero_02);
        } else {
          Console.WriteLine(numero_02 + " debe ser mayor que " + numero_01);
        }
      }
      else {
        Console.WriteLine(cadena_01 + " o " + cadena_02 + " no es número o no es entero.");
      }
    }
  }
}