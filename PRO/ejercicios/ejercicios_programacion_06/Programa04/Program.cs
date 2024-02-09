using System;

namespace Programa04 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Solicitar una cantidad no definida de datos y calcular su suma. " +
                        "Debe estar preparado para un máximo de 100 números, que pedirá de uno en uno. " +
                        "Cuando se introduzca un valor cero, mostrará la suma de todos los anteriores y dará el número de datos introducidos.");
      const int ElementoMaximo = 100;
      double[] VectorDeNumeros = new double[ElementoMaximo];
      double Elementos = 1, Suma = 0;
      int i = 0, Contador = 0;

      while (i < ElementoMaximo && Elementos != 0) {
        Console.Write($"\n Introduzca los elementos del vector (" + i + ") : ");
        while (!double.TryParse(Console.ReadLine(), out Elementos)) {
          Console.Write("Error. Introduzca un número (" + i + ") : ");
        }
        VectorDeNumeros[i] = Elementos;
        Suma += VectorDeNumeros[i];
        i++;
        Contador++;
      }
      
      for (i = 0; i < Contador - 1; i++) {
        Console.Write(VectorDeNumeros[i] + " ");
      }
      Console.WriteLine("\nSuma : " + Suma);
    }
  }
}