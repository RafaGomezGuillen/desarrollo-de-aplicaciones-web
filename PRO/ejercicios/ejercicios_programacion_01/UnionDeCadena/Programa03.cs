using System;

namespace UnionDeCadena {
  class Programa03 {
    public static void Main(String[] args) {
      Console.WriteLine("Solicitar dos mensajes solicitados por teclado y mostrar la union de ambas cadenas.");

      Console.Write("Introduce la primera cadena: ");
      string cadena_01 = Console.ReadLine();

      Console.Write("Introduce la segunda cadena: ");
      string cadena_02 = Console.ReadLine();

      Console.WriteLine("Union: " + cadena_01 + " " + cadena_02);
      Console.ReadKey();
    }
  }
}
