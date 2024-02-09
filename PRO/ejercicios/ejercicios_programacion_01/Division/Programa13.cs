using System;

namespace Division {
  class Programa13 {
    public static void Main(String[] args) {
      Console.WriteLine("Presenta por pantalla la división de dos números solicitados por teclado.");

      Console.Write("Introduce el primer número: ");
      string cadena_01 = Console.ReadLine();
      Console.Write("Introduce el segundo número: ");
      string cadena_02 = Console.ReadLine();

      if(Double.TryParse(cadena_01, out double numero_01) && Double.TryParse(cadena_02, out double numero_02)) {
        if (numero_02 == 0) {
          Console.WriteLine("No se posible dividir entre 0.");
        }
        else {
          double numero_division = numero_01 / numero_02;
          Console.WriteLine(numero_01 + " / " + numero_02 + " = " + Math.Round(numero_division, 1));
        }
      } else {
        Console.WriteLine("Numeros mal introducidos.");
      } 
      Console.ReadKey();
    }
  }
}
