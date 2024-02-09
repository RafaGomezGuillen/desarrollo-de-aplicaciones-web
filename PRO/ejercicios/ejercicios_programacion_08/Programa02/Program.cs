using System;

namespace Programa02 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\tDada una cadena por teclado, y una segunda de comparación, " +
                        "\nmostrar por pantalla la cadena “Está” cuando encontremos la segunda cadena en cualquier posición de la primera.\r\n");

      // Pido la cadena inicial
      Console.Write("\t\nIntroduce una cadena: ");
      string cadenaInicial = Console.ReadLine();

      // Compruebo que no sea nula
      while (cadenaInicial.Length == 0) {
        Console.Write("Introduzca una cadena que no sea nula: ");
        cadenaInicial = Console.ReadLine();
      }

      // Pido la cadena de comparación
      Console.Write("\t\nIntroduce una cadena de comparación: ");
      string cadenaComparacion = Console.ReadLine();

      // Compruebo que no sea nula
      while (cadenaComparacion.Length == 0) {
        Console.Write("Introduzca una cadena que no sea nula: ");
        cadenaComparacion = Console.ReadLine();
      }

      // Comprueba si cadanaInicial contiene cadenaComparacion
      if (cadenaInicial.Contains(cadenaComparacion)) Console.WriteLine("Está.");
    }
  }
}