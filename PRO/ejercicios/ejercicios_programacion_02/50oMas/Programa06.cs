using System;

namespace Suma50oMas {
  class Programa06 {
    public static void Main(string[] args) {
      Console.Write("Pide números por teclado, hasta que sumen 50 o más. Introduce tu número: ");
      int suma = 0, numero_01 = 0;

      while (suma <= 50) {
          Console.Write("Introduce tu número se para hasta que su suma sea 50 o más: ");
          numero_01 = Convert.ToInt32(Console.ReadLine());
          suma = suma + numero_01;
          Console.WriteLine("Suma = " + suma);
      }
      Console.WriteLine("Pulse una tecla para salir...");
      Console.ReadKey();
    }
  }
}

