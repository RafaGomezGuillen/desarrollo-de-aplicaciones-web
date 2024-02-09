using System;

namespace SumaDeCincoNumeros {
  class Programa02 {
    public static void Main(string[] args) {
      Console.WriteLine("Pide por teclado cinco números y muestra su suma.");
      float suma = 0, numero_01 = 0;

      for (int i = 0; i < 5; i++) {
        Console.Write("Introduce un número: ");
        while (!float.TryParse(Console.ReadLine(), out numero_01)) {
          Console.Write("ERROR. No ha introducido un número. Introduce un número: ");
        }
        suma += numero_01;
        Console.WriteLine("La suma = " + suma);
      }
    }
  }
}