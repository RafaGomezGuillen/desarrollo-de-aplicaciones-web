using System;

namespace Programa20 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dado un código ISBN (identificador de libros) saber si este código es un ISBN válido (aplicar el de 13 dígitos).");

      Console.Write("\nIntroduce una cadena: ");
      string? cadena_01 = Console.ReadLine();
      /*978-84-7245-643-3*/
      Console.WriteLine(cadena_01.Length);
      int contador_raya = 0, contador_numero = 0;

      if (cadena_01.Length == 17) {
        for (int i = 0; i < cadena_01.Length; i++) {
          if (cadena_01[i] == '-') contador_raya++;
          if (cadena_01[i] >= '1' && cadena_01[i] <= '9') contador_numero++;
        }
        if (contador_raya == 4 && contador_numero == 13) {
          Console.WriteLine(cadena_01 + " es correcto.");
        } else {
          Console.WriteLine("El IBAN es incorrecto.");
        }
      } else {
        Console.WriteLine("El IBAN es incorrecto.");
      }
    }
  }
}
