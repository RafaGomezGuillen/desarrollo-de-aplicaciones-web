using System;

namespace Programa10 {
  internal class Funciones {
    public static int ComprobacionEnteroPositivo(ref int numero) {
      Console.Write("\nIntroduce un número: ");
      while (!int.TryParse(Console.ReadLine(), out numero) || (numero <= 0)) {
        Console.Write("\nERROR. Introduzca un número positivo: ");
      }
      return numero;
    }
    public static int CifraNumero(int numero) {
      string cadena = Convert.ToString(numero);
      int cifra = cadena.Length;
      return cifra;
    }
  }
}
