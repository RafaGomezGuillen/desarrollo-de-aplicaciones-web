using System;

namespace Programa19 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Calcula la cantidad de veces que se repite un carácter dado en una cadena.");

      Console.Write("\nIntroduce una cadena: ");
      string? cadena_01 = Console.ReadLine();
      Console.Write("Introduce un caracter a contar: ");
      char caracter_01;
      int contador = 0;

      while(!char.TryParse(Console.ReadLine(), out caracter_01)) {
        Console.Write("ERROR. Introduce un caracter: ");
      } 

      for (int i = 0; i < cadena_01.Length; i++) {
        if (cadena_01[i] == caracter_01) contador++; 
      }
      Console.WriteLine("El caracter " + caracter_01 + " se repite " + contador + " veces en " + cadena_01);
    }
  }
}
