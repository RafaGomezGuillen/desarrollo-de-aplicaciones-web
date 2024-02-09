using System;

namespace SumaDeDosNumeros {
  class Programa01 {
    public static void Main(String[] args) {
      Console.WriteLine("Suma de dos numeros solicitados por teclado.");

      Console.Write("Introduce el primer numero: ");
      int numero_01 = Convert.ToInt32(Console.ReadLine());

      Console.Write("Introduce el segundo numero: ");
      int numero_02 = Convert.ToInt32(Console.ReadLine());

      int suma = numero_01 + numero_02;

      Console.WriteLine("La suma de " + numero_01 + " + " + numero_02 + " = " + suma);
      Console.ReadKey();
    }
  }
}
