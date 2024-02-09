using System;

namespace MayorMenor {
  class Programa09 {
    public static void Main(string[] args) {
      Console.WriteLine("Solicitados cinco números por teclado, calcular cuál es el de mayor valor y cuál " +
                        "el de menor y mostrarlos por pantalla.");

      int contador_01 = 0;
      int minimo = 0;
      int maximo = 0;
      while (contador_01 < 5) {
        Console.Write("Introduce número: ");
        int numero_01 = Convert.ToInt32(Console.ReadLine());
        if (contador_01 == 0) {
          minimo = numero_01;
          maximo = numero_01;
        }
        if (maximo < numero_01) {
          maximo = numero_01;
        }

        if (minimo > numero_01) {
          minimo = numero_01;
        }
        contador_01++;
      }
      Console.WriteLine("El máximo es: " + maximo + " y el mínimo es: " + minimo);
      Console.WriteLine("Pulse tecla para salir...");
      Console.ReadKey();
    }
  }
}