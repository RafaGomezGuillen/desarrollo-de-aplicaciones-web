using System;

namespace Programa05 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Escriba un programa que lea desde teclado valores para un vector con 20 números enteros positivos " +
                        "\nque representan las notas de alumnado (entre 0 y 10) y muestre por pantalla su contenido. " +
                        "\nA continuación, debe contar el número de alumn@s aproba@s y el número de alumn@s suspendid@s, " +
                        "\nasí como la media de notas del grupo.");

      const int MAXIMO_ELEMENTO = 20;
      int[] listaAlumnos = new int[MAXIMO_ELEMENTO];

      // Pido las notas de listaAlumnos. Tienen que estar entre 0 y 10
      for (int i = 0; i < MAXIMO_ELEMENTO; i++) {
        Console.Write("\nIntroduzca las notas del vector (" + i + ") : ");
        while (!int.TryParse(Console.ReadLine(), out listaAlumnos[i]) || (listaAlumnos[i] > 10 || listaAlumnos[i] < 0)) {
          Console.Write("\nERROR. Introduce un número entre 0 y 10: ");
        }
      }

      int numeroAprobados = 0, numeroSuspendidos = 0;
      decimal media = 0, suma = 0;
      // Imprimo el vector inicial
      Console.Write("\nVector inicial: ");
      for (int i = 0; i < MAXIMO_ELEMENTO; i++) {
        Console.Write(listaAlumnos[i] + " ");
        // Sumo la cantidad de aprobados y suspendidos con dos contadores
        if (listaAlumnos[i] >= 5) {
          numeroAprobados++;
        } else {
          numeroSuspendidos++;
        }
        // Guardo la suma de las notas para luego sacar la media
        suma += listaAlumnos[i];
      }

      media = suma / Convert.ToDecimal(MAXIMO_ELEMENTO);

      Console.WriteLine("\nNúmeros aprobados: " + numeroAprobados);
      Console.WriteLine("Números suspendidos: " + numeroSuspendidos);
      Console.WriteLine("Media del grupo: " + media);
    }
  }
}