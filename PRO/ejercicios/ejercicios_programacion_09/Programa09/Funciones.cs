using System;

namespace Programa09 {
  internal class Funciones {
    public static int ComprobacionEnteroPositivo(ref int numero) {
      Console.Write("\nIntroduce un año: ");
      while (!int.TryParse(Console.ReadLine(), out numero) || (numero <= 0)) {
        Console.Write("\nERROR. Introduzca un número positivo: ");
      }
      return numero;
    }
    public static bool EsBisiesto(int año) {
      if (año % 4 == 0 && año % 100 != 0 || año % 400 == 0) return true;
      return false;
    }
  }
}
