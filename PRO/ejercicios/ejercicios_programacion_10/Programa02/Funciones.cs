using System;

namespace Programa02 {
  internal class Funciones {
    public static int NumeroEntero(ref int numero) {
      Console.Write("\nIntroduce un número entero: ");
      while(!int.TryParse(Console.ReadLine(), out numero) ||(numero <= 0)) {
        Console.Write("\nERROR. Introduce un número entero: ");
      }
      return numero;
    }
    public static bool EsPrimo(int numero, int divisor = 2) {
      if (numero <= 1) return false;
      if (numero == 2) return true;
      if (numero % divisor == 0) return false;
      if (divisor > Math.Sqrt(numero)) return true;
      return EsPrimo(numero, divisor + 1);
    }
  }
}
