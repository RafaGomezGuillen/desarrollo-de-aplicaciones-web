using System;

namespace Programa10 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\nIntroduciremos números enteros por teclado hasta pulsar el cero. Los número deben ser mayores de cero y menores de diez. " +
                        "Ordenar y presentar por pantalla estos números ordenados de mayor a menor y de menor a mayor.\r\n");

      // Crea un vector para almacenar los números introducidos por el usuario
      const int MAXIMO_ELEMENTO = 10;
      int[] vectorInicial = new int[MAXIMO_ELEMENTO]; 

      // Pide al usuario que introduzca números hasta que pulse el cero
      Console.WriteLine("Introduce números enteros (pulsa 0 para finalizar):");
      int numeros;
      int count = 0; 
      do {
        // Lee el número introducido por el usuario
        Console.Write("\nIntroduce los números del vector (" + count + ") : ");
        numeros = int.Parse(Console.ReadLine());

        // Si el número es mayor que cero y menor que diez, lo añade al vector
        if (numeros > 0 && numeros < MAXIMO_ELEMENTO) {
          vectorInicial[count] = numeros;
          count++;
        }
      } while (numeros != 0);

      // Ordena el vector de mayor a menor (lo busqué en internet está parte siendo honestos)
      Array.Sort(vectorInicial, 0, count, Comparer<int>.Create((a, b) => b.CompareTo(a)));

      // Presenta los números ordenados de mayor a menor por pantalla
      Console.Write("\nNúmeros ordenados de mayor a menor: ");
      foreach (int i in vectorInicial) {
        Console.Write(i + " ");
      }

      // Ordena el vector de menor a mayor
      Array.Sort(vectorInicial, 0, count);

      // Presenta los números ordenados de menor a mayor por pantalla
      Console.Write("\nNúmeros ordenados de menor a mayor: ");
      foreach (int i in vectorInicial) {
        Console.Write(i + " ");
      }
    }
  }
}
