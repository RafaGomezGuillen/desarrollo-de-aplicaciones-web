using System;

namespace Programa10 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tRealizar una función a la que dado un número entero (este numero no podrá ser menor o igual que 0), \n" +
                        "determine el número de cifras que tiene. Por ejemplo, si introduzco un 253, me devuelva un 3.\n");

      int numero = 0;
      Funciones.ComprobacionEnteroPositivo(ref numero);

      Console.WriteLine(numero + " tiene " + Funciones.CifraNumero(numero) +" cifras.");
    }
  }
}
