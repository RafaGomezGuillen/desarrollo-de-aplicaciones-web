using System;

namespace MultiplicacionDeDosNumeros {
  class Programa02 {
    public static void Main(String[] args) {
      Console.WriteLine("Multiplicacion de dos numeros solicitados por teclado.");

      Console.Write("Introduce el primer numero: ");
      int numero_01 = Convert.ToInt32(Console.ReadLine());

      Console.Write("Introduce el segundo numero: ");
      int numero_02 = Convert.ToInt32(Console.ReadLine());

      int multiplicacion = numero_01 * numero_02;

      Console.WriteLine("La multiplicacion de " + numero_01 + " * " + numero_02 + " = " + multiplicacion);
      Console.ReadKey();
    }
  }
}
