using System;

namespace Programa12 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Desarrolla un programa que devuelva una cadena con un carácter repetido n veces, siendo n solicitado por teclado.");
      Console.Write("Introduce un caracter: ");
      char caracter_01;
      int numero_01;
      string cadena_01 = "";
      while (!char.TryParse(Console.ReadLine(), out caracter_01)) {
        Console.Write("ERROR. No ha introducido un caracter. Introduce un caracter: ");
      }

      Console.Write("Introduce un número: ");
      while (!int.TryParse(Console.ReadLine(), out numero_01)) {
        Console.Write("ERROR. No ha introducido un número. Introduce un número: ");
      }

      for (int i = 1; i <= numero_01; i++) {
        cadena_01 += caracter_01;
      }
      Console.WriteLine(cadena_01);
    }
  }
}
