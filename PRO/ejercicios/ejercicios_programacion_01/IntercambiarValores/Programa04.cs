using System;

namespace IntercambiarValores {
  class Programa04 {
    public static void Main(String[] args) {
      Console.WriteLine("Intercambiar valores A y B.");

      Console.Write("Introduce A: ");
      int numero_a = Convert.ToInt32(Console.ReadLine());

      Console.Write("Introduce B: ");
      int numero_b = Convert.ToInt32(Console.ReadLine());

      int aux = numero_a;
      numero_a = numero_b;
      numero_b = aux; 

      Console.WriteLine("A: " + numero_a + " ,B: " + numero_b);
      Console.ReadKey();
    }
  }
}
