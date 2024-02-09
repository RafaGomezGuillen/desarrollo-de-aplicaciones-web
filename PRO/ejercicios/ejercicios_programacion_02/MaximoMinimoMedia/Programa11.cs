using System;

namespace MaximoMinimoMedia {
  class Programa11 {
    public static void Main(string[] args) {
      Console.WriteLine("Leer números enteros hasta teclear cero, y nos muestre el máximo, el mínimo y la media de todos ellos.");
      int numero_01 = 1, minimo = 0, maximo = 0, contador = 0, suma = 0;
      decimal media = 0;

      while (numero_01 != 0) {
        Console.Write("Introduce número: ");
        numero_01 = Convert.ToInt32(Console.ReadLine());
        if (maximo < numero_01) {
            maximo = numero_01;
        }
        if (minimo > numero_01) {
            minimo = numero_01;
        }
        contador++;
        suma = suma + numero_01;
        media = Convert.ToDecimal(suma) / Convert.ToDecimal(contador);
      }
      Console.WriteLine("El máximo es: " + maximo + ", el mínimo es: " + minimo + " y la media es {0:F2}", media);
      Console.WriteLine("Pulse tecla para salir...");
      Console.ReadKey();
    }
  }
}