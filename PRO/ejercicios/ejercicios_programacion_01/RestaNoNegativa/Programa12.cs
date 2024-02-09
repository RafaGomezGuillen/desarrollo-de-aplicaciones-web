using System;

namespace RestaNoNegativa {
  class Programa12 {
    public static void Main(String[] args) {
      Console.WriteLine("Presenta por pantalla la resta de dos números solicitados por teclado. " +
                        "No puede devolver el resultado como un número negativo.");

      Console.Write("Introduce el primer número: ");
      string cadena_01 = Console.ReadLine();
      Console.Write("Introduce el segundo número: ");
      string cadena_02 = Console.ReadLine();
      double numero_resta = 0;

      if (Double.TryParse(cadena_01, out double numero_01) && Double.TryParse(cadena_02, out double numero_02)) {
        if (numero_01 >= numero_02) {
          numero_resta = numero_01 - numero_02;
          Console.WriteLine(numero_01 + " - " + numero_02 + " = " + numero_resta);
        }
        else {
          numero_resta = numero_01 - (-numero_02);
          Console.WriteLine(numero_01 + " - (-" + numero_02 + ") = " + numero_resta);
        }
      } else {
        Console.WriteLine("Los numero introducidos no son numeros.");
      }
      
      Console.ReadKey();
    }
  }
}
